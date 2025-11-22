using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace ASCOM.Utilities
{
    // Minimal exceptions to be compatible with callers expecting ASCOM-specific exceptions.
    namespace Exceptions
    {
        public class SerialPortInUseException : Exception
        {
            public SerialPortInUseException(string message) : base(message) { }
        }

        public class NotConnectedException : Exception
        {
            public NotConnectedException(string message) : base(message) { }
        }

        public class InvalidValueException : Exception
        {
            public InvalidValueException(string paramName, string value, string allowed) : base($"{paramName} invalid: {value}. Allowed: {allowed}") { }
        }
    }

    public enum SerialSpeed
    {
        ps110 = 110,
        ps300 = 300,
        ps600 = 600,
        ps1200 = 1200,
        ps2400 = 2400,
        ps4800 = 4800,
        ps9600 = 9600,
        ps19200 = 19200,
        ps38400 = 38400,
        ps57600 = 57600,
        ps115200 = 115200
    }

    public enum SerialHandshake
    {
        None = 0,
        XOnXOff = 1,
        RequestToSend = 2,
        RequestToSendXOnXOff = 3
    }

    public enum SerialParity
    {
        None = Parity.None,
        Odd = Parity.Odd,
        Even = Parity.Even,
        Mark = Parity.Mark,
        Space = Parity.Space
    }

    public enum SerialStopBits
    {
        One = StopBits.One,
        OnePointFive = StopBits.OnePointFive,
        Two = StopBits.Two
    }

    // Minimal safe Serial wrapper using System.IO.Ports.SerialPort
    public class Serial : IDisposable
    {
        private SerialPort _port;
        private readonly object _sync = new object();
        private Encoding _textEncoding = Encoding.UTF8;
        private bool _disposed = false;
        private bool _connected = false;

        // settings with defaults matching ASCOM.Serial original defaults
        private string _portName = "COM1";
        private SerialSpeed _speed = SerialSpeed.ps9600;
        private int _receiveTimeoutMs = 5000;
        private int _dataBits = 8;
        private bool _dtrEnable = true;
        private bool _rtsEnable = false;
        private SerialHandshake _handshake = SerialHandshake.None;
        private SerialParity _parity = SerialParity.None;
        private SerialStopBits _stopBits = SerialStopBits.One;

        // semaphore to emulate in-use guard
        private Semaphore _serSemaphore = new Semaphore(1, 1);

        // ctor
        public Serial()
        {
            // default encoding - keep UTF8; host may register CodePagesEncodingProvider if needed
            _textEncoding = Encoding.UTF8;
        }

        // Allow external override of encoding (keeps compatibility)
        public Encoding TextEncoding
        {
            get => _textEncoding;
            set => _textEncoding = value ?? Encoding.UTF8;
        }

        public int DataBits
        {
            get => _dataBits;
            set
            {
                _dataBits = value;
                if (_port != null && _port.IsOpen)
                    _port.DataBits = _dataBits;
            }
        }

        public bool DTREnable
        {
            get => _dtrEnable;
            set
            {
                _dtrEnable = value;
                if (_port != null && _port.IsOpen)
                    _port.DtrEnable = _dtrEnable;
            }
        }

        public bool RTSEnable
        {
            get => _rtsEnable;
            set
            {
                _rtsEnable = value;
                if (_port != null && _port.IsOpen)
                    _port.RtsEnable = _rtsEnable;
            }
        }

        public SerialHandshake Handshake
        {
            get => _handshake;
            set
            {
                _handshake = value;
                if (_port != null && _port.IsOpen)
                    _port.Handshake = (HandshakeMapping(_handshake));
            }
        }

        public SerialParity Parity
        {
            get => _parity;
            set
            {
                _parity = value;
                if (_port != null && _port.IsOpen)
                    _port.Parity = (Parity)_parity;
            }
        }

        public SerialStopBits StopBits
        {
            get => _stopBits;
            set
            {
                _stopBits = value;
                if (_port != null && _port.IsOpen)
                    _port.StopBits = (StopBits)_stopBits;
            }
        }

        public SerialSpeed Speed
        {
            get => _speed;
            set
            {
                _speed = value;
                if (_port != null && _port.IsOpen)
                    _port.BaudRate = (int)_speed;
            }
        }

        // Port number (COMx) accessor for compatibility
        public int Port
        {
            get
            {
                if (string.IsNullOrEmpty(_portName)) return 0;
                if (_portName.StartsWith("COM", StringComparison.OrdinalIgnoreCase) && int.TryParse(_portName.Substring(3), out int n))
                    return n;
                return 0;
            }
            set
            {
                _portName = "COM" + value.ToString();
                if (_port != null && !_port.IsOpen) _port.PortName = _portName;
            }
        }

        public string PortName
        {
            get => _portName;
            set
            {
                _portName = value;
                if (_port != null && !_port.IsOpen) _port.PortName = _portName;
            }
        }

        // ReceiveTimeout in seconds (compatibility)
        public int ReceiveTimeout
        {
            get => (int)Math.Round(_receiveTimeoutMs / 1000.0);
            set
            {
                if (value < 1 || value > 120) throw new Exceptions.InvalidValueException("ReceiveTimeout", value.ToString(), "1 to 120 seconds");
                _receiveTimeoutMs = value * 1000;
                if (_port != null && _port.IsOpen)
                {
                    _port.ReadTimeout = _receiveTimeoutMs;
                    _port.WriteTimeout = _receiveTimeoutMs;
                }
            }
        }

        // Milliseconds timeout
        public int ReceiveTimeoutMs
        {
            get => _receiveTimeoutMs;
            set
            {
                if (value <= 0 || value > 120000) throw new Exceptions.InvalidValueException("ReceiveTimeoutMs", value.ToString(), "1 to 120000 milliseconds");
                _receiveTimeoutMs = value;
                if (_port != null && _port.IsOpen)
                {
                    _port.ReadTimeout = _receiveTimeoutMs;
                    _port.WriteTimeout = _receiveTimeoutMs;
                }
            }
        }

        // Connected property - opening/closing is synchronous and guarded
        public bool Connected
        {
            get => _connected;
            set
            {
                if (value == _connected) return;

                // try to take semaphore quickly
                if (!_serSemaphore.WaitOne(_receiveTimeoutMs + 2000))
                    throw new Exceptions.SerialPortInUseException("Serial:Connected - unable to get serial port semaphore before timeout.");

                try
                {
                    if (value)
                        OpenPort();
                    else
                        ClosePort();
                }
                finally
                {
                    try { _serSemaphore.Release(); } catch { }
                }
            }
        }

        private void OpenPort()
        {
            lock (_sync)
            {
                if (_connected) return;

                _port = new SerialPort(_portName)
                {
                    BaudRate = (int)_speed,
                    DataBits = _dataBits,
                    DtrEnable = _dtrEnable,
                    RtsEnable = _rts_enable_helper(_rtsEnable),
                    Handshake = HandshakeMapping(_handshake),
                    Parity = (Parity)_parity,
                    StopBits = (StopBits)_stopBits,
                    ReadTimeout = _receiveTimeoutMs,
                    WriteTimeout = _receiveTimeoutMs,
                    Encoding = _textEncoding
                };

                // ensure RTS/RTS mapping for older .NET versions
                _port.DtrEnable = _dtrEnable;
                _port.RtsEnable = _rtsEnable;
                _port.Parity = (Parity)_parity;
                _port.StopBits = (StopBits)_stopBits;

                _port.Open();
                _connected = true;
            }
        }

        private void ClosePort()
        {
            lock (_sync)
            {
                if (!_connected) return;
                try
                {
                    try { _port.DiscardOutBuffer(); } catch { }
                    try { _port.DiscardInBuffer(); } catch { }
                    _port.Close();
                }
                finally
                {
                    try { _port.Dispose(); } catch { }
                    _port = null;
                    _connected = false;
                }
            }
        }

        // Clear buffers
        public void ClearBuffers()
        {
            if (!_connected)
                throw new Exceptions.NotConnectedException("Serial port is not connected - you cannot use ClearBuffers");

            lock (_sync)
            {
                try
                {
                    _port.DiscardInBuffer();
                    _port.DiscardOutBuffer();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        // Transmit string (blocking)
        public void Transmit(string data)
        {
            if (!_connected) throw new Exceptions.NotConnectedException("Serial port is not connected - you cannot use the Serial.Transmit command");

            lock (_sync)
            {
                _port.Write(data);
            }
        }

        // Transmit binary
        public void TransmitBinary(byte[] data)
        {
            if (!_connected) throw new Exceptions.NotConnectedException("Serial port is not connected - you cannot use the Serial.TransmitBinary command");

            lock (_sync)
            {
                _port.Write(data, 0, data.Length);
            }
        }

        // Receive string (reads all available and returns)
        public string Receive()
        {
            if (!_connected) throw new Exceptions.NotConnectedException("Serial port is not connected - you cannot use the Serial.Receive command");

            lock (_sync)
            {
                try
                {
                    // ReadExisting returns immediately with available data; to wait for full response caller should use ReceiveTerminated or ReceiveCounted
                    string s = _port.ReadExisting();
                    return s;
                }
                catch (TimeoutException tex)
                {
                    throw new TimeoutException("Timed out waiting for received data", tex);
                }
            }
        }

        // Receive one byte as numeric value
        public byte ReceiveByte()
        {
            if (!_connected) throw new Exceptions.NotConnectedException("Serial port is not connected - you cannot use the Serial.ReceiveByte command");

            lock (_sync)
            {
                try
                {
                    int b = _port.ReadByte();
                    if (b < 0) throw new TimeoutException("Serial port timed out waiting to read a byte");
                    return (byte)b;
                }
                catch (TimeoutException tex)
                {
                    throw new TimeoutException("Timed out waiting for received data", tex);
                }
            }
        }

        // Read exactly Count characters as a string (blocks)
        public string ReceiveCounted(int Count)
        {
            if (!_connected) throw new Exceptions.NotConnectedException("Serial port is not connected - you cannot use the Serial.ReceiveCounted command");
            if (Count < 0) throw new ArgumentOutOfRangeException(nameof(Count));

            var sb = new StringBuilder(Count);
            var buffer = new char[1];
            var deadline = DateTime.UtcNow.AddMilliseconds(_receiveTimeoutMs);

            lock (_sync)
            {
                while (sb.Length < Count)
                {
                    if (DateTime.UtcNow > deadline) throw new TimeoutException("Timed out waiting for received data");
                    try
                    {
                        int read = _port.Read(buffer, 0, 1); // this honors ReadTimeout
                        if (read > 0) sb.Append(buffer[0]);
                    }
                    catch (TimeoutException)
                    {
                        // loop and check deadline
                    }
                }
            }

            return sb.ToString();
        }

        // Receive binary Count bytes
        public byte[] ReceiveCountedBinary(int Count)
        {
            if (!_connected) throw new Exceptions.NotConnectedException("Serial port is not connected - you cannot use the Serial.ReceiveCountedBinary command");
            if (Count < 0) throw new ArgumentOutOfRangeException(nameof(Count));

            var result = new byte[Count];
            int offset = 0;
            var deadline = DateTime.UtcNow.AddMilliseconds(_receiveTimeoutMs);

            lock (_sync)
            {
                while (offset < Count)
                {
                    if (DateTime.UtcNow > deadline) throw new TimeoutException("Timed out waiting for received data");
                    try
                    {
                        int read = _port.Read(result, offset, Count - offset); // honors ReadTimeout
                        if (read > 0) offset += read;
                    }
                    catch (TimeoutException)
                    {
                        // continue until deadline
                    }
                }
            }

            return result;
        }

        // Read until terminator string is seen
        public string ReceiveTerminated(string Terminator)
        {
            if (!_connected) throw new Exceptions.NotConnectedException("Serial port is not connected - you cannot use the Serial.ReceiveTerminated command");
            if (string.IsNullOrEmpty(Terminator)) throw new Exceptions.InvalidValueException("ReceiveTerminated Terminator", "null/empty", "Character or character string");

            var sb = new StringBuilder();
            var buffer = new char[1];
            var deadline = DateTime.UtcNow.AddMilliseconds(_receiveTimeoutMs);
            var termLen = Terminator.Length;

            lock (_sync)
            {
                while (true)
                {
                    if (DateTime.UtcNow > deadline) throw new TimeoutException("Timed out waiting for received data");
                    try
                    {
                        int read = _port.Read(buffer, 0, 1);
                        if (read > 0)
                        {
                            sb.Append(buffer[0]);
                            if (sb.Length >= termLen && sb.ToString(sb.Length - termLen, termLen) == Terminator)
                                break;
                        }
                    }
                    catch (TimeoutException)
                    {
                        // continue until deadline
                    }
                }
            }

            return sb.ToString();
        }

        // Receive terminated by a byte-array terminator
        public byte[] ReceiveTerminatedBinary(byte[] TerminatorBytes)
        {
            if (!_connected) throw new Exceptions.NotConnectedException("Serial port is not connected - you cannot use the Serial.ReceiveTerminatedBinary command");
            if (TerminatorBytes == null || TerminatorBytes.Length == 0) throw new Exceptions.InvalidValueException("ReceiveTerminatedBinary Terminator", "null/empty", "Byte array");

            var buffer = new List<byte>();
            var deadline = DateTime.UtcNow.AddMilliseconds(_receiveTimeoutMs);
            int matchIndex = 0;

            lock (_sync)
            {
                while (true)
                {
                    if (DateTime.UtcNow > deadline) throw new TimeoutException("Timed out waiting for received data");
                    try
                    {
                        int b = _port.ReadByte();
                        if (b < 0) continue;
                        byte bb = (byte)b;
                        buffer.Add(bb);

                        if (bb == TerminatorBytes[matchIndex])
                        {
                            matchIndex++;
                            if (matchIndex == TerminatorBytes.Length) break;
                        }
                        else
                        {
                            matchIndex = (bb == TerminatorBytes[0]) ? 1 : 0;
                        }
                    }
                    catch (TimeoutException)
                    {
                        // continue until deadline
                    }
                }
            }

            return buffer.ToArray();
        }

        // Returns list of available COM ports (includes forced/ignored not supported)
        public string[] AvailableCOMPorts
        {
            get
            {
                var names = SerialPort.GetPortNames().ToList();
                names.Sort((a, b) =>
                {
                    int na = ParseComNumber(a);
                    int nb = ParseComNumber(b);
                    if (na > 0 && nb > 0) return na.CompareTo(nb);
                    return string.Compare(a, b, StringComparison.OrdinalIgnoreCase);
                });
                return names.ToArray();
            }
        }

        private static int ParseComNumber(string s)
        {
            if (string.IsNullOrEmpty(s)) return -1;
            if (s.StartsWith("COM", StringComparison.OrdinalIgnoreCase) && int.TryParse(s.Substring(3), out int n)) return n;
            return -1;
        }

        // Dispose pattern
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                try
                {
                    if (_port != null)
                    {
                        try { if (_port.IsOpen) _port.Close(); } catch { }
                        try { _port.Dispose(); } catch { }
                        _port = null;
                    }
                }
                catch { }
                try { _serSemaphore?.Close(); } catch { }
            }
            _disposed = true;
        }

        ~Serial()
        {
            Dispose(false);
        }

        // helpers
        private static System.IO.Ports.Handshake HandshakeMapping(SerialHandshake h)
        {
            switch (h)
            {
                case SerialHandshake.None: return System.IO.Ports.Handshake.None;
                case SerialHandshake.XOnXOff: return System.IO.Ports.Handshake.XOnXOff;
                case SerialHandshake.RequestToSend: return System.IO.Ports.Handshake.RequestToSend;
                case SerialHandshake.RequestToSendXOnXOff: return System.IO.Ports.Handshake.RequestToSendXOnXOff;
                default: return System.IO.Ports.Handshake.None;
            }
        }

        // compatibility helper for .NET implementations where RtsEnable mapping is bool
        private static bool _rts_enable_helper(bool v) => v;
    }
}
