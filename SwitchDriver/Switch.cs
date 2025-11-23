// Decompiled with JetBrains decompiler
// Type: ASCOM.WandererBoxes.Switch
// Assembly: ASCOM.WandererBoxes.Switch, Version=6.6.0.0, Culture=neutral, PublicKeyToken=5a596dde3293c610
// MVID: E3106A5C-05F3-42C7-89F9-2A2C7253BE13
// Assembly location: C:\Program Files (x86)\Wanderer Astro\ASCOM.WandererBoxes.Switch.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASCOM.Common.DeviceInterfaces;
using ASCOM.Utilities;
using StateValue = ASCOM.Common.DeviceInterfaces.StateValue;
using Timer = System.Threading.Timer;
using TraceLogger = ASCOM.Tools.TraceLogger;

// ReSharper disable All

namespace ASCOM.WandererBoxes
{
 // [Guid("dd973766-cee6-4d96-8f21-c0c8382fd999")]
 // [ClassInterface(ClassInterfaceType.None)]
 [ComVisible(true)]
 [Guid("9e6a2caa-8269-4faf-aef0-f10b51a5eb2f")]
 [ProgId("ASCOM.naixxWanderer.Switch")]
 [ServedClassName("ASCOM Switch Driver for naixxWanderer")] // Driver description that appears in the Chooser, customise as required
 [ClassInterface(ClassInterfaceType.None)]
  public class Switch : ISwitchV2
  {
    private static int GET_SWITCH_VALUE_INTERVAL = 1000;
    private static int UPDATE_CHART_INTERVAL = 1000;
    
    internal static string driverID = "ASCOM.naixxWanderer.Switch";
    private static string driverDescription = "WandererBoxes All-in-one(1) 1.8";
    internal static string comPortProfileName = "COM Port";
    internal static string comPortDefault = "COM1";
    internal static string traceStateProfileName = "Trace Level";
    internal static string traceStateDefault = "false";
    internal static string comPort;
    private bool connectedState;
    internal static bool DHTTstate = false;
    internal static bool DHTHstate = false;
    internal static bool DSTstate = false;
    internal static bool response = true;
    internal static string data;
    internal static string firmware;
    internal static string DC1status;
    internal static string DC2status;
    internal static string DC3status;
    internal static string DC4status;
    internal static string DC5_8status;
    internal static string USB31status;
    internal static string USB32status;
    internal static string USB33status;
    internal static string USB21status;
    internal static string USB22status;
    internal static string USB23status;
    internal static string USB24status;
    internal static string USB25status;
    internal static string USB26status;
    internal static string[] datalist;
    internal static double voltage;
    internal static double current;
    internal static double DHTT;
    internal static double DHTH;
    internal static double DST;
    internal static int datacount;
    internal static string Sensortype = "None";
    internal static string AscomSensorType = "Sensortype";
    internal static string heater1Mode;
    internal static string heater2Mode;
    internal static string heater3Mode;
    internal static string Ascomheater1Mode = "Switch1";
    internal static string Ascomheater2Mode = "Switch2";
    internal static string Ascomheater3Mode = "Switch3";
    internal static string DC1name;
    internal static string DC2name;
    internal static string DC3name;
    internal static string DC4name;
    internal static string DC5_8name;
    internal static string DC9name;
    internal static string USB3_1name;
    internal static string USB3_2name;
    internal static string USB3_3name;
    internal static string USB2_1name;
    internal static string USB2_2name;
    internal static string USB2_3name;
    internal static string USB2_4name;
    internal static string USB2_5name;
    internal static string USB2_6name;
    internal static string AscomDC1name = "PWM 1";
    internal static string AscomDC2name = "PWM 2";
    internal static string AscomDC3name = "PWM 3";
    internal static string AscomDC4name = "DC OUT 4";
    internal static string AscomDC5_8name = "DC OUT 5-8";
    internal static string AscomDC9name = "DC OUT 9";
    internal static string AscomUSB3_1name = "USB3.1-1";
    internal static string AscomUSB3_2name = "USB3.1-2";
    internal static string AscomUSB3_3name = "USB3.1-3";
    internal static string AscomUSB2_1name = "USB2.0-1";
    internal static string AscomUSB2_2name = "USB2.0-2";
    internal static string AscomUSB2_3name = "USB2.0-3";
    internal static string AscomUSB2_4name = "USB2.0-4";
    internal static string AscomUSB2_5name = "USB2.0-5";
    internal static string AscomUSB2_6name = "USB2.0-6";
    internal static int dew1low;
    internal static int dew1high;
    internal static int dew1maximum;
    internal static int dew2low;
    internal static int dew2high;
    internal static int dew2maximum;
    internal static int dew3low;
    internal static int dew3high;
    internal static int dew3maximum;
    internal static int dew1t;
    internal static int dew2t;
    internal static int dew3t;
    internal static string Ascomdew1low = "1150";
    internal static string Ascomdew1high = "1190";
    internal static string Ascomdew1maximum = "1255";
    internal static string Ascomdew2low = "2150";
    internal static string Ascomdew2high = "2190";
    internal static string Ascomdew2maximum = "2255";
    internal static string Ascomdew3low = "3150";
    internal static string Ascomdew3high = "3190";
    internal static string Ascomdew3maximum = "3255";
    internal static string Ascomdew1t = "10040";
    internal static string Ascomdew2t = "20040";
    internal static string Ascomdew3t = "30040";
    internal static string Ascomdew1diff = "100015";
    internal static string Ascomdew2diff = "200015";
    internal static string Ascomdew3diff = "300015";
    internal static int i;
    private int DC1state;
    private int DC2state;
    private int DC3state;
    private int DC4state;
    private int DC5_8state;
    private int DC9state;
    private int USB3_1state;
    private int USB3_2state;
    private int USB3_3state;
    private int USB2_1state;
    private int USB2_2state;
    private int USB2_3state;
    private int USB2_4state;
    private int USB2_5state;
    private int USB2_6state;
    private int HEAT1;
    private int HEAT2;
    private int HEAT3;
    internal static int time;
    internal static int power1;
    internal static int power2;
    internal static string hum;
    internal static string dewpoint;
    internal static double dewpointnum;
    internal static string USBstatus;
    internal static double humnum;
    private int DC1_3state;
    private int USBstate;
    private int ao;
    internal static string DC1_3name;
    internal static string DC5name;
    internal static string DC6name;
    internal static string USBname;
    private selectmodel S;
    private SetupForUltimateV2 UltimateV2;
    private SetupForPlusV2 PlusV2;
    internal static string manualCOM;
    internal static string model;
    public static SerialPort SP = new SerialPort();
    public static Serial objSerial;
    private PlusV2Monitor M3;
    private UltimateV2Monitor2 M4;
    internal TraceLogger tl;
    internal static string selectedmodel = "none";
    internal static string lang = "en";

    public Switch()
    {
      this.tl = new TraceLogger( "WandererBoxes All-in-one(1) 1.8", true);
      tl.Enabled = true;
      tl.LogMessage(nameof (Switch), "test");
      this.ReadProfile();
      this.ReadSelectedModel();
      this.ReadCustomization();
      this.WriteCustomization();
      this.tl.LogMessage(nameof (Switch), "Starting initialisation");
      this.connectedState = false;
      this.tl.LogMessage(nameof (Switch), "Completed initialisation");
    }

    internal void Readdewpoint()
    {
      using (Profile profile = new Profile())
      {
        profile.DeviceType = "ObservingConditions";
        Switch.humnum = (double) Convert.ToInt16(profile.GetValue("ASCOM.WandererWeather.ObservingConditions", "humidityascom", string.Empty, "100"));
      }
    }

    public void SetupDialog()
    {
      if (!this.IsConnected)
      {
        using (this.S = new selectmodel())
        {
          if (this.S.ShowDialog() != DialogResult.OK)
            return;
          this.WriteSelectedModel();
        }
        this.WriteCustomization();
        this.ReadCustomization();
        switch (Switch.selectedmodel)
        {
          case "PlusV2":
            using (SetupForPlusV2 setupForPlusV2 = new SetupForPlusV2(this.tl))
            {
              if (setupForPlusV2.ShowDialog() != DialogResult.OK)
                break;
              this.WriteProfile();
              this.WriteCustomization();
              break;
            }
          case "UltimateV2":
            using (SetupForUltimateV2 setupForUltimateV2 = new SetupForUltimateV2())
            {
              if (setupForUltimateV2.ShowDialog() != DialogResult.OK)
                break;
              this.WriteProfile();
              this.WriteCustomization();
              break;
            }
        }
      }
      else
      {
        switch (Switch.selectedmodel)
        {
          case "PlusV2":
            using (SetupForPlusV2 setupForPlusV2 = new SetupForPlusV2(this.tl))
            {
              if (setupForPlusV2.ShowDialog() != DialogResult.OK)
                break;
              this.WriteProfile();
              this.WriteCustomization();
              break;
            }
          case "UltimateV2":
            using (SetupForUltimateV2 setupForUltimateV2 = new SetupForUltimateV2())
            {
              if (setupForUltimateV2.ShowDialog() != DialogResult.OK)
                break;
              this.WriteProfile();
              this.WriteCustomization();
              break;
            }
        }
      }
    }



    public string Action(string actionName, string actionParameters)
    {
      this.LogMessage("", "Action {0}, parameters {1} not implemented", (object) actionName, (object) actionParameters);
      throw new ActionNotImplementedException($"Action {actionName} is not implemented by this driver");
    }

    public void CommandBlind(string command, bool raw)
    {
      this.CheckConnected(nameof (CommandBlind));
      throw new MethodNotImplementedException(nameof (CommandBlind));
    }

    public bool CommandBool(string command, bool raw)
    {
      this.CheckConnected(nameof (CommandBool));
      throw new MethodNotImplementedException(nameof (CommandBool));
    }

    public string CommandString(string command, bool raw)
    {
      this.CheckConnected(nameof (CommandString));
      throw new MethodNotImplementedException(nameof (CommandString));
    }

    public void Dispose()
    {
      this.tl.Enabled = false;
      this.tl.Dispose();
      this.tl = (TraceLogger) null;
    }

    public void CancelAsync(short id)
    {
      throw new MethodNotImplementedException();
    }

    public bool Connected
    {
      get
      {
        this.LogMessage(nameof (Connected), "Get {0}", (object) this.IsConnected);
        return this.IsConnected;
      }
      set
      {
        switch (Switch.selectedmodel)
        {
          case "UltimateV2":
            this.tl = new TraceLogger( "WandererBoxUltimate", true);
            this.ReadProfile();
            this.ReadCustomization();
            this.tl.LogMessage(nameof (Switch), "Starting initialisation");
            Thread.Sleep(10);
            this.DC4state = !(Switch.DC4status == "On") ? 0 : 1;
            Thread.Sleep(10);
            this.DC5_8state = !(Switch.DC5_8status == "On") ? 0 : 1;
            Thread.Sleep(10);
            this.DC9state = 1;
            Thread.Sleep(10);
            this.USB3_1state = !(Switch.USB31status == "On") ? 0 : 1;
            Thread.Sleep(10);
            this.USB3_2state = !(Switch.USB32status == "On") ? 0 : 1;
            Thread.Sleep(10);
            this.USB3_3state = !(Switch.USB33status == "On") ? 0 : 1;
            Thread.Sleep(10);
            this.USB2_1state = !(Switch.USB21status == "On") ? 0 : 1;
            Thread.Sleep(10);
            this.USB2_2state = !(Switch.USB22status == "On") ? 0 : 1;
            Thread.Sleep(10);
            this.USB2_3state = !(Switch.USB23status == "On") ? 0 : 1;
            Thread.Sleep(10);
            this.USB2_4state = !(Switch.USB24status == "On") ? 0 : 1;
            Thread.Sleep(10);
            this.USB2_5state = !(Switch.USB25status == "On") ? 0 : 1;
            Thread.Sleep(10);
            this.USB2_6state = !(Switch.USB26status == "On") ? 0 : 1;
            Thread.Sleep(10);
            if (Switch.heater1Mode == "Switch1")
            {
              this.DC1state = !(Switch.DC1status == "On") ? 0 : 1;
            }
            else
            {
              try
              {
                this.HEAT1 = Convert.ToInt32(Switch.DC1status);
              }
              catch (Exception ex)
              {
                Switch.DC1status = "3";
                this.HEAT1 = 3;
              }
            }
            if (Switch.heater2Mode == "Switch2")
            {
              this.DC2state = !(Switch.DC2status == "On") ? 0 : 1;
            }
            else
            {
              try
              {
                this.HEAT2 = Convert.ToInt32(Switch.DC2status);
              }
              catch (Exception ex)
              {
                Switch.DC2status = "3";
                this.HEAT2 = 3;
              }
            }
            if (Switch.heater3Mode == "Switch3")
            {
              this.DC3state = !(Switch.DC3status == "On") ? 0 : 1;
            }
            else
            {
              try
              {
                this.HEAT3 = Convert.ToInt32(Switch.DC3status);
              }
              catch (Exception ex)
              {
                Switch.DC3status = "3";
                this.HEAT3 = 3;
              }
            }
            Switch.i = 0;
            Switch.datacount = 0;
            this.connectedState = false;
            this.tl.LogMessage(nameof (Switch), "Completed initialisation");
            break;
          case "PlusV2":
            this.ReadCustomization();
            this.tl = new TraceLogger( "WandererSwitch", true);
            this.ReadProfile();
            this.ReadCustomization();
            this.connectedState = false;
            Thread.Sleep(10);
            this.DC1_3state = !(Switch.DC3status == "On") ? 0 : 1;
            Thread.Sleep(10);
            this.USBstate = !(Switch.USBstatus == "On") ? 0 : 1;
            Thread.Sleep(10);
            this.ao = 1;
            if (Switch.heater1Mode == "Switch1")
            {
              this.DC1state = !(Switch.DC1status == "On") ? 0 : 1;
            }
            else
            {
              try
              {
                this.HEAT1 = Convert.ToInt32(Switch.DC1status);
              }
              catch (Exception ex)
              {
                Switch.DC1status = "0";
                this.HEAT1 = 0;
              }
            }
            if (Switch.heater2Mode == "Switch2")
            {
              this.DC2state = !(Switch.DC2status == "On") ? 0 : 1;
            }
            else
            {
              try
              {
                this.HEAT2 = Convert.ToInt32(Switch.DC2status);
              }
              catch (Exception ex)
              {
                Switch.DC2status = "0";
                this.HEAT2 = 0;
              }
            }
            Switch.i = 0;
            this.tl.LogMessage(nameof (Switch), "Completed initialisation");
            break;
          default:
            int num1 = (int) MessageBox.Show("Please select the model in setup!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return;
        }
        if (value == this.IsConnected)
        {
          switch (Switch.selectedmodel)
          {
            case "PlusV2":
              this.M3.Close();
              break;
            case "UltimateV2":
              if (this.M4 != null)
              this.M4.Close();
              break;
          }
          Switch.objSerial.Connected = false;
          Switch.objSerial.Dispose();
          this.connectedState = false;
          Switch.SP.Close();
          Switch.objSerial.Connected = false;
          this.connectedState = false;
          Application.DoEvents();
          this.LogMessage("Connected Set", "Disconnecting from port {0}", (object) Switch.comPort);
        }
        if (Switch.selectedmodel == "UltimateV2")
        {
          if (Switch.manualCOM == "false")
          {
            this.tl.LogMessage(nameof (Connected), @"Set {value}");
            if (value == this.IsConnected)
              return;
            if (value)
            {
              Switch.i = 1;
              string s = "";
              string str1 = "";
              this.LogMessage("Connected Set", "Connecting to port {0}", (object) Switch.comPort);
              string[] portNames = SerialPort.GetPortNames();
              int length = portNames.Length;
              for (int index = 0; length > index; ++index)
              {
                try
                {
                  Switch.SP.PortName = portNames[index];
                  Switch.SP.BaudRate = 19200;
                  Switch.SP.DtrEnable = false;
                  Switch.SP.RtsEnable = false;
                  Switch.SP.Open();
                }
                catch (Exception ex)
                {
                  Switch.SP.Close();
                  continue;
                }
                Thread.Sleep(1500);
                Switch.SP.DiscardInBuffer();
                string str2;
                try
                {
                  Switch.SP.ReadTimeout = 1000;
                  str2 = Switch.SP.ReadTo("F");
                }
                catch (Exception ex)
                {
                  Switch.SP.Close();
                  continue;
                }
                string str3;
                try
                {
                  Switch.datalist = str2.Split('A', 'B', 'C', 'D', 'E', 'A', 'F');
                  Switch.current = Convert.ToDouble(Switch.datalist[3], (IFormatProvider) CultureInfo.GetCultureInfo("en-US").NumberFormat);
                  Switch.voltage = Convert.ToDouble(Switch.datalist[4], (IFormatProvider) CultureInfo.GetCultureInfo("en-US").NumberFormat);
                  str3 = Switch.datalist[5];
                  Switch.firmware = Switch.datalist[6];
                }
                catch (Exception ex)
                {
                  Switch.SP.Close();
                  continue;
                }
                if (str3 == "UltimateV2")
                {
                  str1 = portNames[index];
                  Switch.SP.Close();
                  break;
                }
                Switch.SP.Close();
              }
              for (int index = 0; index < str1.Length; ++index)
              {
                char ch = str1[index];
                if (ch >= '0' & ch <= '9')
                  s += ch.ToString();
              }
              if (s == "")
                return;
              Switch.objSerial = new Serial()
              {
                Port = int.Parse(s),
                Speed = SerialSpeed.ps19200,
                Connected = true
              };
              this.connectedState = true;
              if (Switch.heater1Mode == "Dew Heater1")
              {
                switch (this.HEAT1)
                {
                  case 0:
                    Switch.objSerial.Transmit("1000a");
                    break;
                  case 1:
                    Switch.objSerial.Transmit((Switch.dew1low + 1000).ToString() + "a");
                    break;
                  case 2:
                    Switch.objSerial.Transmit((Switch.dew1high + 1000).ToString() + "a");
                    break;
                  case 3:
                    Switch.objSerial.Transmit((Switch.dew1maximum + 1000).ToString() + "a");
                    break;
                  case 4:
                    if (Switch.Sensortype == "DHT22")
                    {
                      Switch.objSerial.Transmit("400001a");
                      break;
                    }
                    int num2 = (int) MessageBox.Show("You need to connect the DHT22 sensor and check 'DHT22 Sensor' in the configuration interface to activate this function.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                  case 5:
                    if (Switch.Sensortype == "DS18B20")
                    {
                      Switch.objSerial.Transmit((411000 + Switch.dew1t).ToString() + "a");
                      break;
                    }
                    int num3 = (int) MessageBox.Show("You need to connect the DS18B20 probe and check 'DS18B20 probe' in the configuration interface to activate this function.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                }
              }
              if (Switch.heater2Mode == "Dew Heater2")
              {
                switch (this.HEAT2)
                {
                  case 0:
                    Switch.objSerial.Transmit("2000a");
                    break;
                  case 1:
                    Switch.objSerial.Transmit((Switch.dew2low + 2000).ToString() + "a");
                    break;
                  case 2:
                    Switch.objSerial.Transmit((Switch.dew2high + 2000).ToString() + "a");
                    break;
                  case 3:
                    Switch.objSerial.Transmit((Switch.dew2maximum + 2000).ToString() + "a");
                    break;
                  case 4:
                    if (Switch.Sensortype == "DHT22")
                    {
                      Switch.objSerial.Transmit("400002a");
                      break;
                    }
                    int num4 = (int) MessageBox.Show("You need to connect the DHT22 sensor and check 'DHT22 Sensor' in the configuration interface to activate this function.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                  case 5:
                    if (Switch.Sensortype == "DS18B20")
                    {
                      Switch.objSerial.Transmit((412000 + Switch.dew2t).ToString() + "a");
                      break;
                    }
                    int num5 = (int) MessageBox.Show("You need to connect the DS18B20 probe and check 'DS18B20 probe' in the configuration interface to activate this function.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                }
              }
              if (Switch.heater3Mode == "Dew Heater3")
              {
                switch (this.HEAT3)
                {
                  case 0:
                    Switch.objSerial.Transmit("3000a");
                    break;
                  case 1:
                    Switch.objSerial.Transmit((Switch.dew3low + 3000).ToString() + "a");
                    break;
                  case 2:
                    Switch.objSerial.Transmit((Switch.dew3high + 3000).ToString() + "a");
                    break;
                  case 3:
                    Switch.objSerial.Transmit((Switch.dew3maximum + 3000).ToString() + "a");
                    break;
                  case 4:
                    if (Switch.Sensortype == "DHT22")
                    {
                      Switch.objSerial.Transmit("400003a");
                      break;
                    }
                    int num6 = (int) MessageBox.Show("You need to connect the DHT22 sensor and check 'DHT22 Sensor' in the configuration interface to activate this function.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                  case 5:
                    if (Switch.Sensortype == "DS18B20")
                    {
                      Switch.objSerial.Transmit((413000 + Switch.dew3t).ToString() + "a");
                      break;
                    }
                    int num7 = (int) MessageBox.Show("You need to connect the DS18B20 probe and check 'DS18B20 probe' in the configuration interface to activate this function.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                }
              }
              this.SetSwitch((short) 4, this.GetSwitch((short) 4));
              Switch.comPort = "COM" + Switch.objSerial.Port.ToString();
              this.WriteProfile();
              this.OnTimedEvent3();
              Application.DoEvents();
            }
            else
            {
              this.M4.Close();
              this.LogMessage("Connected Set", "Disconnecting from port {0}", (object) Switch.comPort);
              Switch.objSerial.Connected = false;
              this.connectedState = false;
            }
          }
          else
          {
            this.tl.LogMessage(nameof (Connected), @"Set {value}");
            if (value == this.IsConnected)
              return;
            if (value)
            {
              this.ReadCustomization();
              this.LogMessage("Connected Set", "Connecting to port {0}", (object) Switch.comPort);
              string comPort = Switch.comPort;
              string s = "";
              for (int index = 0; index < comPort.Length; ++index)
              {
                char ch = comPort[index];
                if (ch >= '0' & ch <= '9')
                  s += ch.ToString();
              }
              Switch.objSerial = new Serial()
              {
                Port = int.Parse(s),
                Speed = SerialSpeed.ps19200,
                RTSEnable = true,
                DTREnable = true,
                Connected = true
              };
              string terminated;
              try
              {
                Switch.objSerial.ReceiveTimeout = 2;
                terminated = Switch.objSerial.ReceiveTerminated("F");
              }
              catch (Exception ex)
              {
                Switch.objSerial.Connected = false;
                this.connectedState = false;
                Switch.objSerial.Dispose();
                return;
              }
              try
              {
                Switch.datalist = terminated.Split('A', 'B', 'C', 'D', 'E', 'A', 'F');
                Switch.current = Convert.ToDouble(Switch.datalist[3], (IFormatProvider) CultureInfo.GetCultureInfo("en-US").NumberFormat);
                Switch.voltage = Convert.ToDouble(Switch.datalist[4], (IFormatProvider) CultureInfo.GetCultureInfo("en-US").NumberFormat);
                string str = Switch.datalist[5];
                Switch.firmware = Switch.datalist[6];
              }
              catch
              {
                Switch.objSerial.Connected = false;
                this.connectedState = false;
                Switch.objSerial.Dispose();
                return;
              }
              Switch.comPort = "COM" + Switch.objSerial.Port.ToString();
              this.WriteProfile();
              Application.DoEvents();
              this.connectedState = true;
              Switch.objSerial.ClearBuffers();
              this.connectedState = true;
              if (Switch.heater1Mode == "Dew Heater1")
              {
                switch (this.HEAT1)
                {
                  case 0:
                    Switch.objSerial.Transmit("1000a");
                    break;
                  case 1:
                    Switch.objSerial.Transmit((Switch.dew1low + 1000).ToString() + "a");
                    break;
                  case 2:
                    Switch.objSerial.Transmit((Switch.dew1high + 1000).ToString() + "a");
                    break;
                  case 3:
                    Switch.objSerial.Transmit((Switch.dew1maximum + 1000).ToString() + "a");
                    break;
                  case 4:
                    if (Switch.Sensortype == "DHT22")
                    {
                      Switch.objSerial.Transmit("400001a");
                      break;
                    }
                    int num8 = (int) MessageBox.Show("You need to connect the DHT22 sensor and check 'DHT22 Sensor' in the configuration interface to activate this function.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                  case 5:
                    if (Switch.Sensortype == "DS18B20")
                    {
                      Switch.objSerial.Transmit((411000 + Switch.dew1t).ToString() + "a");
                      break;
                    }
                    int num9 = (int) MessageBox.Show("You need to connect the DS18B20 probe and check 'DS18B20 probe' in the configuration interface to activate this function.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                }
              }
              if (Switch.heater2Mode == "Dew Heater2")
              {
                switch (this.HEAT2)
                {
                  case 0:
                    Switch.objSerial.Transmit("2000a");
                    break;
                  case 1:
                    Switch.objSerial.Transmit((Switch.dew2low + 2000).ToString() + "a");
                    break;
                  case 2:
                    Switch.objSerial.Transmit((Switch.dew2high + 2000).ToString() + "a");
                    break;
                  case 3:
                    Switch.objSerial.Transmit((Switch.dew2maximum + 2000).ToString() + "a");
                    break;
                  case 4:
                    if (Switch.Sensortype == "DHT22")
                    {
                      Switch.objSerial.Transmit("400002a");
                      break;
                    }
                    int num10 = (int) MessageBox.Show("You need to connect the DHT22 sensor and check 'DHT22 Sensor' in the configuration interface to activate this function.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                  case 5:
                    if (Switch.Sensortype == "DS18B20")
                    {
                      Switch.objSerial.Transmit((412000 + Switch.dew2t).ToString() + "a");
                      break;
                    }
                    int num11 = (int) MessageBox.Show("You need to connect the DS18B20 probe and check 'DS18B20 probe' in the configuration interface to activate this function.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                }
              }
              if (Switch.heater3Mode == "Dew Heater3")
              {
                switch (this.HEAT3)
                {
                  case 0:
                    Switch.objSerial.Transmit("3000a");
                    break;
                  case 1:
                    Switch.objSerial.Transmit((Switch.dew3low + 3000).ToString() + "a");
                    break;
                  case 2:
                    Switch.objSerial.Transmit((Switch.dew3high + 3000).ToString() + "a");
                    break;
                  case 3:
                    Switch.objSerial.Transmit((Switch.dew3maximum + 3000).ToString() + "a");
                    break;
                  case 4:
                    if (Switch.Sensortype == "DHT22")
                    {
                      Switch.objSerial.Transmit("400003a");
                      break;
                    }
                    int num12 = (int) MessageBox.Show("You need to connect the DHT22 sensor and check 'DHT22 Sensor' in the configuration interface to activate this function.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                  case 5:
                    if (Switch.Sensortype == "DS18B20")
                    {
                      Switch.objSerial.Transmit((413000 + Switch.dew3t).ToString() + "a");
                      break;
                    }
                    int num13 = (int) MessageBox.Show("You need to connect the DS18B20 probe and check 'DS18B20 probe' in the configuration interface to activate this function.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                }
              }
              this.SetSwitch((short) 4, this.GetSwitch((short) 4));
              Switch.comPort = "COM" + Switch.objSerial.Port.ToString();
              this.WriteProfile();
              this.OnTimedEvent3();
              Application.DoEvents();
            }
            else
            {
              this.M4.Close();
              this.LogMessage("Connected Set", "Disconnecting from port {0}", (object) Switch.comPort);
              Switch.objSerial.Connected = false;
              this.connectedState = false;
            }
          }
        }
        else
        {
          this.tl.LogMessage(nameof (Connected), @"Set {value}");
          if (value == this.IsConnected)
            return;
          if (value)
          {
            Switch.i = 1;
            string s = "";
            string str4 = "";
            this.LogMessage("Connected Set", "Connecting to port {0}", (object) Switch.comPort);
            string[] portNames = SerialPort.GetPortNames();
            int length = portNames.Length;
            for (int index = 0; length > index; ++index)
            {
              try
              {
                Switch.SP.PortName = portNames[index];
                Switch.SP.BaudRate = 19200;
                Switch.SP.DtrEnable = true;
                Switch.SP.RtsEnable = false;
                Switch.SP.Open();
              }
              catch (Exception ex)
              {
                Switch.SP.Close();
                continue;
              }
              Thread.Sleep(1500);
              Switch.SP.DiscardInBuffer();
              string str5 = "";
              try
              {
                Switch.SP.ReadTimeout = 1000;
                str5 = Switch.SP.ReadTo("F");
              }
              catch (Exception ex)
              {
                Switch.SP.Close();
                continue;
              }
              string str6;
              try
              {
                Switch.SP.ReadTimeout = 1000;
                str6 = Switch.SP.ReadTo("F");
              }
              catch (Exception ex)
              {
                Switch.SP.Close();
                continue;
              }
              string str7;
              try
              {
                Switch.datalist = str6.Split('D', 'E', 'A', 'F');
                Switch.current = Convert.ToDouble(Switch.datalist[0], (IFormatProvider) CultureInfo.GetCultureInfo("en-US").NumberFormat);
                Switch.voltage = Convert.ToDouble(Switch.datalist[1], (IFormatProvider) CultureInfo.GetCultureInfo("en-US").NumberFormat);
                str7 = Switch.datalist[2];
              }
              catch (Exception ex)
              {
                Switch.SP.Close();
                continue;
              }
              if (str7 == "PlusV2")
              {
                str4 = portNames[index];
                Switch.SP.Close();
                break;
              }
              Switch.SP.Close();
            }
            for (int index = 0; index < str4.Length; ++index)
            {
              char ch = str4[index];
              if (ch >= '0' & ch <= '9')
                s += ch.ToString();
            }
            if (s == "")
              return;
            Switch.objSerial = new Serial()
            {
              Port = int.Parse(s),
              Speed = SerialSpeed.ps19200,
              Connected = true
            };
            this.connectedState = true;
            this.OnTimedEvent3();
            Application.DoEvents();
            if (Switch.heater1Mode == "Dew Heater1")
            {
              switch (this.HEAT1)
              {
                case 0:
                  Switch.objSerial.Transmit("1000a");
                  break;
                case 1:
                  Switch.objSerial.Transmit((Switch.dew1low + 1000).ToString() + "a");
                  break;
                case 2:
                  Switch.objSerial.Transmit((Switch.dew1high + 1000).ToString() + "a");
                  break;
                case 3:
                  Switch.objSerial.Transmit((Switch.dew1maximum + 1000).ToString() + "a");
                  break;
                case 4:
                  if (Switch.Sensortype == "Weather")
                  {
                    this.Readdewpoint();
                    if (Switch.humnum >= 85.0)
                      Switch.power1 = Switch.dew1maximum;
                    if (Switch.humnum < 85.0 && Switch.humnum >= 75.0)
                      Switch.power1 = Switch.dew1high;
                    if (Switch.humnum < 75.0 && Switch.humnum >= 65.0)
                      Switch.power1 = Switch.dew1low;
                    if (Switch.humnum < 65.0)
                    {
                      Switch.power1 = 0;
                      break;
                    }
                    break;
                  }
                  int num14 = (int) MessageBox.Show("You need to connect the Wanderer Weather Station Mini as well as  check  'Wanderer Weather Station Mini' in the configuration interface to activate this function.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  break;
              }
            }
            if (!(Switch.heater2Mode == "Dew Heater2"))
              return;
            switch (this.HEAT2)
            {
              case 0:
                Switch.objSerial.Transmit("2000a");
                break;
              case 1:
                Switch.objSerial.Transmit((Switch.dew2low + 2000).ToString() + "a");
                break;
              case 2:
                Switch.objSerial.Transmit((Switch.dew2high + 2000).ToString() + "a");
                break;
              case 3:
                Switch.objSerial.Transmit((Switch.dew2maximum + 2000).ToString() + "a");
                break;
              case 4:
                if (Switch.Sensortype == "Weather")
                {
                  this.Readdewpoint();
                  if (Switch.humnum >= 85.0)
                    Switch.power2 = Switch.dew2maximum;
                  if (Switch.humnum < 85.0 && Switch.humnum >= 75.0)
                    Switch.power2 = Switch.dew2high;
                  if (Switch.humnum < 75.0 && Switch.humnum >= 65.0)
                    Switch.power2 = Switch.dew2low;
                  if (Switch.humnum >= 65.0)
                    break;
                  Switch.power2 = 0;
                  break;
                }
                int num15 = (int) MessageBox.Show("You need to connect the Wanderer Weather Station Mini as well as  check  'Wanderer Weather Station Mini' in the configuration interface to activate this function.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                break;
            }
          }
          else
          {
            this.M3.Close();
            this.LogMessage("Connected Set", "Disconnecting from port {0}", (object) Switch.comPort);
            Switch.objSerial.Connected = false;
            this.connectedState = false;
          }
        }
      }
    }

    // private void OnTimedEvent3()
    // {
    //   switch (Switch.selectedmodel)
    //   {
    //     case "PlusV2":
    //       this.M3 = new PlusV2Monitor();
    //       int num1;
    //       Task.Run((System.Action) (() => num1 = (int) this.M3.ShowDialog()));
    //       break;
    //     case "UltimateV2":
    //       this.M4 = new UltimateV2Monitor2();
    //       int num2;
    //       Task.Run((System.Action) (() => num2 = (int) this.M4.ShowDialog()));
    //       break;
    //   }
    // }

    private Timer updateTimer;
    private Thread monitorThread;
    
    private void OnTimedEvent3()
    {
        // Создаем окно если его нет
        if (monitorThread == null || !monitorThread.IsAlive)
        {
            monitorThread = new Thread(() =>
            {
                switch (Switch.selectedmodel)
                {
                    case "PlusV2":
                        this.M3 = new PlusV2Monitor();
                        Application.Run(this.M3);
                        break;
                        
                    case "UltimateV2":
                        this.M4 = new UltimateV2Monitor2();
                        Application.Run(this.M4);
                        break;
                }
            });
            
            monitorThread.SetApartmentState(ApartmentState.STA);
            monitorThread.IsBackground = true;
            monitorThread.Start();
            
            // Даем время на создание формы
            Thread.Sleep(500);
            
            // Запускаем таймер обновления данных
            StartUpdateTimer();
        }
    }
    
    private void StartUpdateTimer()
    {
        if (updateTimer == null)
        {
            updateTimer = new System.Threading.Timer(UpdateMonitorData, null, 0, UPDATE_CHART_INTERVAL); // Каждую секунду
        }
    }
    
    private void UpdateMonitorData(object state)
    {
        try
        {
            switch (Switch.selectedmodel)
            {
                case "PlusV2":
                    if (this.M3 != null && !this.M3.IsDisposed)
                    {
                        // // Передаем данные в форму
                        // this.M3.UpdateData(
                        //     Switch.voltage, 
                        //     Switch.current, 
                        //     Switch.DHTTstate ? Switch.DHTT : Switch.DSTstate ? Switch.DST : (double?)null,
                        //     Switch.DHTHstate ? Switch.DHTH : (double?)null,
                        //     Switch.DHTTstate,
                        //     Switch.DSTstate,
                        //     Switch.DHTHstate,
                        //     Switch.Sensortype
                        // );
                    }
                    break;
                    
                case "UltimateV2":
                    if (this.M4 != null && !this.M4.IsDisposed)
                    {
                        // Передаем данные в форму
                        this.M4.OnTimedEvent(null,null);
                    }
                    break;
            }
        }
        catch (Exception ex)
        {
            // Логируем ошибку
            System.Diagnostics.Debug.WriteLine($"Error updating monitor: {ex.Message}");
        }
    }
    
    public string Description
    {
      get
      {
        this.tl.LogMessage("Description Get", Switch.driverDescription);
        return Switch.driverDescription;
      }
    }

    public string DriverInfo => "WandererBoxes All-in-one(1) 1.8";

    public string DriverVersion => "1.8";

    public short InterfaceVersion
    {
      get
      {
        this.LogMessage("InterfaceVersion Get", "2");
        return Convert.ToInt16("2");
      }
    }

    public string Name => "WandererBoxes All-in-one(1) 1.8";
    public IList<string> SupportedActions { get; }

    public short MaxSwitch
    {
      get
      {
        switch (Switch.selectedmodel)
        {
          case "UltimateV2":
            return 15;
          case "PlusV2":
            return 5;
          default:
            return 0;
        }
      }
    }

    public bool Connecting { get; }
    public List<StateValue> DeviceState { get; }

    public string GetSwitchName(short id)
    {
      switch (Switch.selectedmodel)
      {
        case "UltimateV2":
          switch (id)
          {
            case 0:
              return "Dual Mode DC1: " + Switch.DC1name;
            case 1:
              return "Dual Mode DC2: " + Switch.DC2name;
            case 2:
              return "Dual Mode DC3: " + Switch.DC3name;
            case 3:
              return "DC4: " + Switch.DC4name;
            case 4:
              return "DC5-8: " + Switch.DC5_8name;
            case 5:
              return "Always ON DC9: " + Switch.DC9name;
            case 6:
              return "USB3.1-1: " + Switch.USB3_1name;
            case 7:
              return "USB3.1-2: " + Switch.USB3_2name;
            case 8:
              return "USB3.1-3: " + Switch.USB3_3name;
            case 9:
              return "USB2.0-1: " + Switch.USB2_1name;
            case 10:
              return "USB2.0-2: " + Switch.USB2_2name;
            case 11:
              return "USB2.0-3: " + Switch.USB2_3name;
            case 12:
              return "USB2.0-4: " + Switch.USB2_4name;
            case 13:
              return "USB2.0-5: " + Switch.USB2_5name;
            case 14:
              return "USB2.0-6: " + Switch.USB2_6name;
            default:
              return "none";
          }
        case "PlusV2":
          switch (id)
          {
            case 0:
              return Switch.DC1_3name;
            case 1:
              return Switch.DC4name;
            case 2:
              return Switch.DC5name;
            case 3:
              return Switch.DC6name;
            case 4:
              return Switch.USBname;
            default:
              return "none";
          }
        default:
          return "none";
      }
    }

    public void SetSwitchName(short id, string name)
    {
      int num = Switch.selectedmodel == "UltimateV2" ? 1 : 0;
    }

    public string GetSwitchDescription(short id)
    {
      switch (Switch.selectedmodel)
      {
        case "UltimateV2":
          return id == (short) 0 && Switch.heater1Mode == "Dew Heater1" || id == (short) 1 && Switch.heater2Mode == "Dew Heater2" || id == (short) 2 && Switch.heater3Mode == "Dew Heater3" ? "0:OFF    1:Low Power    2:High Power    3:Maximum Power \n4:dewpoint Mode (DHT 22) 5:Constant Temperature Mode (DS18B20)" : "None";
        case "PlusV2":
          return id == (short) 2 || id == (short) 1 ? "0:OFF    1:Low Power    2:High Power    3:Maximum Power \n4:dewpoint Mode (WandererWeather)" : "None";
        default:
          return "none";
      }
    }

    public bool CanWrite(short id)
    {
      switch (Switch.selectedmodel)
      {
        case "UltimateV2":
          return id != (short) 5;
        case "PlusV2":
          return id != (short) 3;
        default:
          return false;
      }
    }

    public bool GetSwitch(short id)
    {
      switch (Switch.selectedmodel)
      {
        case "UltimateV2":
          if (id == (short) 3 && this.DC4state == 0)
            return false;
          if (id == (short) 3 && this.DC4state == 1)
            return true;
          if (id == (short) 4 && this.DC5_8state == 0)
            return false;
          if (id == (short) 4 && this.DC5_8state == 1)
            return true;
          if (id == (short) 5 && this.DC9state == 0)
            return false;
          if (id == (short) 5 && this.DC9state == 1)
            return true;
          if (id == (short) 6 && this.USB3_1state == 0)
            return false;
          if (id == (short) 6 && this.USB3_1state == 1)
            return true;
          if (id == (short) 7 && this.USB3_2state == 0)
            return false;
          if (id == (short) 7 && this.USB3_2state == 1)
            return true;
          if (id == (short) 8 && this.USB3_3state == 0)
            return false;
          if (id == (short) 8 && this.USB3_3state == 1)
            return true;
          if (id == (short) 9 && this.USB2_1state == 0)
            return false;
          if (id == (short) 9 && this.USB2_1state == 1)
            return true;
          if (id == (short) 10 && this.USB2_2state == 0)
            return false;
          if (id == (short) 10 && this.USB2_2state == 1)
            return true;
          if (id == (short) 11 && this.USB2_3state == 0)
            return false;
          if (id == (short) 11 && this.USB2_3state == 1)
            return true;
          if (id == (short) 12 && this.USB2_4state == 0)
            return false;
          if (id == (short) 12 && this.USB2_4state == 1)
            return true;
          if (id == (short) 13 && this.USB2_5state == 0)
            return false;
          if (id == (short) 13 && this.USB2_5state == 1)
            return true;
          if (id == (short) 14 && this.USB2_6state == 0)
            return false;
          if (id == (short) 14 && this.USB2_6state == 1)
            return true;
          if (id == (short) 0 && Switch.heater1Mode == "Switch1" && this.DC1state == 0)
            return false;
          if (id == (short) 0 && Switch.heater1Mode == "Switch1" && this.DC1state == 1)
            return true;
          if (id == (short) 1 && Switch.heater2Mode == "Switch2" && this.DC2state == 0)
            return false;
          if (id == (short) 1 && Switch.heater2Mode == "Switch2" && this.DC2state == 1)
            return true;
          if (id == (short) 2 && Switch.heater3Mode == "Switch3" && this.DC3state == 0)
            return false;
          if (id == (short) 2 && Switch.heater3Mode == "Switch3" && this.DC3state == 1)
            return true;
          throw new MethodNotImplementedException(nameof (GetSwitch));
        case "PlusV2":
          if (Switch.Sensortype == "Weather")
          {
            this.Readdewpoint();
            Switch.dewpointnum = Convert.ToDouble(Switch.dewpoint);
          }
          if (id == (short) 0 && this.DC1_3state == 0)
            return false;
          if (id == (short) 0 && this.DC1_3state == 1)
            return true;
          if (id == (short) 4 && this.USBstate == 0)
            return false;
          if (id == (short) 4 && this.USBstate == 1)
            return true;
          if (id == (short) 3 && this.ao == 0)
          {
            this.ao = 1;
            return false;
          }
          if (id == (short) 3 && this.ao == 1)
            return true;
          if (id == (short) 1 && Switch.heater1Mode == "Switch1" && this.DC1state == 0)
            return false;
          if (id == (short) 1 && Switch.heater1Mode == "Switch1" && this.DC1state == 1)
            return true;
          if (id == (short) 2 && Switch.heater2Mode == "Switch2" && this.DC2state == 0)
            return false;
          if (id == (short) 2 && Switch.heater2Mode == "Switch2" && this.DC2state == 1)
            return true;
          throw new MethodNotImplementedException(nameof (GetSwitch));
        default:
          return false;
      }
    }

    public void SetSwitch(short id, bool state)
    {
      switch (Switch.selectedmodel)
      {
        case "UltimateV2":
          Switch.objSerial.ClearBuffers();
          this.Validate(nameof (SetSwitch), id);
          if (!this.CanWrite(id))
          {
            string str = $"SetSwitch({id}) - Cannot Write";
            this.tl.LogMessage(nameof (SetSwitch), str);
            throw new MethodNotImplementedException(str);
          }
          if (id == (short) 3 && state)
          {
            this.DC4state = 1;
            Switch.objSerial.Transmit("141a");
            Switch.DC4status = "On";
            Thread.Sleep(10);
          }
          if (id == (short) 3 && !state)
          {
            this.DC4state = 0;
            Switch.objSerial.Transmit("140a");
            Switch.DC4status = "Off";
            Thread.Sleep(10);
          }
          if (id == (short) 4 && state)
          {
            this.DC5_8state = 1;
            Switch.objSerial.Transmit("151a");
            Switch.DC5_8status = "On";
            Thread.Sleep(10);
          }
          if (id == (short) 4 && !state)
          {
            this.DC5_8state = 0;
            Switch.objSerial.Transmit("150a");
            Switch.DC5_8status = "Off";
            Thread.Sleep(10);
          }
          if (id == (short) 6 && state)
          {
            this.USB3_1state = 1;
            Switch.objSerial.Transmit("311a");
            Switch.USB31status = "On";
            Thread.Sleep(500);
          }
          if (id == (short) 6 && !state)
          {
            this.USB3_1state = 0;
            Switch.objSerial.Transmit("310a");
            Switch.USB31status = "Off";
            Thread.Sleep(500);
          }
          if (id == (short) 7 && state)
          {
            this.USB3_2state = 1;
            Switch.objSerial.Transmit("321a");
            Switch.USB32status = "On";
            Thread.Sleep(500);
          }
          if (id == (short) 7 && !state)
          {
            this.USB3_2state = 0;
            Switch.objSerial.Transmit("320a");
            Switch.USB32status = "Off";
            Thread.Sleep(500);
          }
          if (id == (short) 8 && state)
          {
            this.USB3_3state = 1;
            Switch.objSerial.Transmit("331a");
            Switch.USB33status = "On";
            Thread.Sleep(500);
          }
          if (id == (short) 8 && !state)
          {
            this.USB3_3state = 0;
            Switch.objSerial.Transmit("330a");
            Switch.USB33status = "Off";
            Thread.Sleep(500);
          }
          if (id == (short) 9 && state)
          {
            this.USB2_1state = 1;
            Switch.objSerial.Transmit("211a");
            Switch.USB21status = "On";
            Thread.Sleep(500);
          }
          if (id == (short) 9 && !state)
          {
            this.USB2_1state = 0;
            Switch.objSerial.Transmit("210a");
            Switch.USB21status = "Off";
            Thread.Sleep(500);
          }
          if (id == (short) 10 && state)
          {
            this.USB2_2state = 1;
            Switch.objSerial.Transmit("221a");
            Switch.USB22status = "On";
            Thread.Sleep(500);
          }
          if (id == (short) 10 && !state)
          {
            this.USB2_2state = 0;
            Switch.objSerial.Transmit("220a");
            Switch.USB22status = "Off";
            Thread.Sleep(500);
          }
          if (id == (short) 11 && state)
          {
            this.USB2_3state = 1;
            Switch.objSerial.Transmit("231a");
            Switch.USB23status = "On";
            Thread.Sleep(500);
          }
          if (id == (short) 11 && !state)
          {
            this.USB2_3state = 0;
            Switch.objSerial.Transmit("230a");
            Switch.USB23status = "Off";
            Thread.Sleep(500);
          }
          if (id == (short) 12 && state)
          {
            this.USB2_4state = 1;
            Switch.objSerial.Transmit("241a");
            Switch.USB24status = "On";
            Thread.Sleep(500);
          }
          if (id == (short) 12 && !state)
          {
            this.USB2_4state = 0;
            Switch.objSerial.Transmit("240a");
            Switch.USB24status = "Off";
            Thread.Sleep(500);
          }
          if (id == (short) 13 && state)
          {
            this.USB2_5state = 1;
            Switch.objSerial.Transmit("251a");
            Switch.USB25status = "On";
            Thread.Sleep(500);
          }
          if (id == (short) 13 && !state)
          {
            this.USB2_5state = 0;
            Switch.objSerial.Transmit("250a");
            Switch.USB25status = "Off";
            Thread.Sleep(500);
          }
          if (id == (short) 14 && state)
          {
            this.USB2_6state = 1;
            Switch.objSerial.Transmit("261a");
            Switch.USB26status = "On";
            Thread.Sleep(500);
          }
          if (id == (short) 14 && !state)
          {
            this.USB2_6state = 0;
            Switch.objSerial.Transmit("260a");
            Switch.USB26status = "Off";
            Thread.Sleep(500);
          }
          if (id == (short) 0 && state && Switch.heater1Mode == "Switch1")
          {
            this.DC1state = 1;
            Switch.objSerial.Transmit("1255a");
            Switch.DC1status = "On";
            Thread.Sleep(10);
          }
          if (id == (short) 0 && !state && Switch.heater1Mode == "Switch1")
          {
            this.DC1state = 0;
            Switch.objSerial.Transmit("1000a");
            Switch.DC1status = "Off";
            Thread.Sleep(10);
          }
          if (id == (short) 1 && state && Switch.heater2Mode == "Switch2")
          {
            this.DC2state = 1;
            Switch.objSerial.Transmit("2255a");
            Switch.DC2status = "On";
            Thread.Sleep(10);
          }
          if (id == (short) 1 && !state && Switch.heater2Mode == "Switch2")
          {
            this.DC2state = 0;
            Switch.objSerial.Transmit("2000a");
            Switch.DC2status = "Off";
            Thread.Sleep(10);
          }
          if (id == (short) 2 && state && Switch.heater3Mode == "Switch3")
          {
            this.DC3state = 1;
            Switch.objSerial.Transmit("3255a");
            Switch.DC3status = "On";
            Thread.Sleep(10);
          }
          if (id == (short) 2 && !state && Switch.heater3Mode == "Switch3")
          {
            this.DC3state = 0;
            Switch.objSerial.Transmit("3000a");
            Switch.DC3status = "Off";
            Thread.Sleep(10);
          }
          this.WriteCustomization();
          break;
        case "PlusV2":
          if (id == (short) 0 && state)
          {
            this.DC1_3state = 1;
            Switch.objSerial.Transmit("311a");
            Switch.DC3status = "On";
            Thread.Sleep(10);
          }
          if (id == (short) 0 && !state)
          {
            this.DC1_3state = 0;
            Switch.objSerial.Transmit("310a");
            Switch.DC3status = "Off";
            Thread.Sleep(10);
          }
          if (id == (short) 4 && state)
          {
            this.USBstate = 1;
            Switch.objSerial.Transmit("320a");
            Switch.USBstatus = "On";
            Thread.Sleep(10);
          }
          if (id == (short) 4 && !state)
          {
            this.USBstate = 0;
            Switch.objSerial.Transmit("321a");
            Switch.USBstatus = "Off";
            Thread.Sleep(10);
          }
          if (id == (short) 3 && state)
          {
            this.ao = 1;
            Thread.Sleep(10);
          }
          if (id == (short) 3 && !state)
          {
            this.ao = 0;
            Thread.Sleep(10);
          }
          if (id == (short) 1 && state && Switch.heater1Mode == "Switch1")
          {
            this.DC1state = 1;
            Switch.objSerial.Transmit("1255a");
            Switch.DC1status = "On";
            Thread.Sleep(10);
          }
          if (id == (short) 1 && !state && Switch.heater1Mode == "Switch1")
          {
            this.DC1state = 0;
            Switch.objSerial.Transmit("1000a");
            Switch.DC1status = "Off";
            Thread.Sleep(10);
          }
          if (id == (short) 2 && state && Switch.heater2Mode == "Switch2")
          {
            this.DC2state = 1;
            Switch.objSerial.Transmit("2255a");
            Switch.DC2status = "On";
            Thread.Sleep(10);
          }
          if (id == (short) 2 && !state && Switch.heater2Mode == "Switch2")
          {
            this.DC2state = 0;
            Switch.objSerial.Transmit("2000a");
            Switch.DC2status = "Off";
            Thread.Sleep(10);
          }
          this.WriteCustomization();
          break;
      }
    }

    public double MaxSwitchValue(short id)
    {
      switch (Switch.selectedmodel)
      {
        case "UltimateV2":
          return id == (short) 6 || id == (short) 7 || id == (short) 8 || id == (short) 3 || id == (short) 4 || id == (short) 5 || id == (short) 9 || id == (short) 10 || id == (short) 11 || id == (short) 12 || id == (short) 13 || id == (short) 14 || id == (short) 0 && Switch.heater1Mode == "Switch1" || id == (short) 1 && Switch.heater2Mode == "Switch2" || id == (short) 2 && Switch.heater3Mode == "Switch3" ? 1.0 : 5.0;
        case "PlusV2":
          return id == (short) 0 || id == (short) 3 || id == (short) 4 || id == (short) 1 && Switch.heater1Mode == "Switch1" || id == (short) 2 && Switch.heater2Mode == "Switch2" ? 1.0 : 4.0;
        default:
          return 1.0;
      }
    }

    public double MinSwitchValue(short id) => 0.0;

    public double SwitchStep(short id) => 1.0;

    private DateTime lastDate = DateTime.MinValue;
    public double GetSwitchValue(short id)
    {
      switch (Switch.selectedmodel)
      {
        case "UltimateV2":
          if ((DateTime.Now - lastDate).TotalMilliseconds > GET_SWITCH_VALUE_INTERVAL )
          {
            Console.WriteLine("------------------------");
            this.WriteCustomization();
            try
            {
              Switch.objSerial.ClearBuffers();
              Switch.data = Switch.objSerial.ReceiveTerminated("F");
              Switch.datalist = Switch.data.Split('A', 'B', 'C', 'D', 'E', 'A', 'F');
              Switch.current = Convert.ToDouble(Switch.datalist[3], (IFormatProvider) CultureInfo.GetCultureInfo("en-US").NumberFormat);
              Switch.voltage = Convert.ToDouble(Switch.datalist[4], (IFormatProvider) CultureInfo.GetCultureInfo("en-US").NumberFormat);
              if (Switch.datalist[2] != "nan")
              {
                Switch.DHTTstate = true;
                Switch.DHTT = Convert.ToDouble(Switch.datalist[2], (IFormatProvider) CultureInfo.GetCultureInfo("en-US").NumberFormat);
              }
              else
              {
                Switch.DHTT = 0.0;
                Switch.DHTTstate = false;
              }
              if (Switch.datalist[1] != "nan")
              {
                Switch.DHTHstate = true;
                Switch.DHTH = Convert.ToDouble(Switch.datalist[1], (IFormatProvider) CultureInfo.GetCultureInfo("en-US").NumberFormat);
              }
              else
              {
                Switch.DHTH = 0.0;
                Switch.DHTHstate = false;
              }
              if (Convert.ToDouble(Switch.datalist[0], (IFormatProvider) CultureInfo.GetCultureInfo("en-US").NumberFormat) > -50.0)
              {
                Switch.DSTstate = true;
                Switch.DST = Convert.ToDouble(Switch.datalist[0], (IFormatProvider) CultureInfo.GetCultureInfo("en-US").NumberFormat);
              }
              else
              {
                Switch.DSTstate = false;
                Switch.DST = 0.0;
              }
            }
            catch (Exception ex)
            {
            }
            lastDate = DateTime.Now;
          }
          ++Switch.datacount;
          if (Switch.datacount >= 100)
            Switch.datacount = 15;
          if (Switch.current < 0.0)
            Switch.current = 0.0;
          if (id == (short) 0 && Switch.heater1Mode == "Dew Heater1")
            return (double) this.HEAT1;
          if (id == (short) 1 && Switch.heater2Mode == "Dew Heater2")
            return (double) this.HEAT2;
          if (id == (short) 2 && Switch.heater3Mode == "Dew Heater3")
            return (double) this.HEAT3;
          throw new MethodNotImplementedException(nameof (GetSwitchValue));
        case "PlusV2":
          this.WriteCustomization();
          Switch.objSerial.ClearBuffers();
          try
          {
            Switch.data = Switch.objSerial.ReceiveTerminated("F");
            Switch.datalist = Switch.data.Split('D', 'E', 'A', 'F');
            Switch.current = Convert.ToDouble(Switch.datalist[0], (IFormatProvider) CultureInfo.GetCultureInfo("en-US").NumberFormat);
            Switch.voltage = Convert.ToDouble(Switch.datalist[1], (IFormatProvider) CultureInfo.GetCultureInfo("en-US").NumberFormat);
          }
          catch (Exception ex)
          {
          }
          if (this.HEAT2 == 4 || this.HEAT1 == 4)
          {
            Serial objSerial = Switch.objSerial;
            int num = Switch.power1 + 410000;
            string str1 = num.ToString();
            num = Switch.power2 + 420000;
            string str2 = num.ToString();
            string Data = $"{str1}a{str2}a";
            objSerial.Transmit(Data);
          }
          if (Switch.current < 0.0)
            Switch.current = 0.0;
          if (id == (short) 1 && Switch.heater1Mode == "Dew Heater1")
            return (double) this.HEAT1;
          if (id == (short) 2 && Switch.heater2Mode == "Dew Heater2")
            return (double) this.HEAT2;
          throw new MethodNotImplementedException(nameof (GetSwitchValue));
        default:
          return 0.0;
      }
    }

    public void SetSwitchValue(short id, double value)
    {
      switch (Switch.selectedmodel)
      {
        case "UltimateV2":
          int num1;
          if (id == (short) 0 && Switch.heater1Mode == "Dew Heater1")
          {
            if (value != 0.0)
            {
              if (value != 1.0)
              {
                if (value != 2.0)
                {
                  if (value != 3.0)
                  {
                    if (value != 4.0)
                    {
                      if (value == 5.0)
                      {
                        if (Switch.Sensortype == "DS18B20")
                        {
                          Serial objSerial = Switch.objSerial;
                          num1 = 411000 + Switch.dew1t;
                          string Data = num1.ToString() + "a";
                          objSerial.Transmit(Data);
                          this.HEAT1 = (int) value;
                          Switch.DC1status = value.ToString();
                        }
                        else
                        {
                          int num2 = (int) MessageBox.Show("You need to connect the DS18B20 probe and check 'DS18B20 probe' in the configuration interface to activate this function.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                      }
                    }
                    else if (Switch.Sensortype == "DHT22")
                    {
                      Switch.objSerial.Transmit("400001a");
                      this.HEAT1 = (int) value;
                      Switch.DC1status = value.ToString();
                    }
                    else
                    {
                      int num3 = (int) MessageBox.Show("You need to connect the DHT22 sensor and check 'DHT22 Sensor' in the configuration interface to activate this function.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                  }
                  else
                  {
                    Serial objSerial = Switch.objSerial;
                    num1 = Switch.dew1maximum + 1000;
                    string Data = num1.ToString() + "a";
                    objSerial.Transmit(Data);
                    this.HEAT1 = (int) value;
                    Switch.DC1status = value.ToString();
                  }
                }
                else
                {
                  Serial objSerial = Switch.objSerial;
                  num1 = Switch.dew1high + 1000;
                  string Data = num1.ToString() + "a";
                  objSerial.Transmit(Data);
                  this.HEAT1 = (int) value;
                  Switch.DC1status = value.ToString();
                }
              }
              else
              {
                Serial objSerial = Switch.objSerial;
                num1 = Switch.dew1low + 1000;
                string Data = num1.ToString() + "a";
                objSerial.Transmit(Data);
                this.HEAT1 = (int) value;
                Switch.DC1status = value.ToString();
              }
            }
            else
            {
              Switch.objSerial.Transmit("1000a");
              this.HEAT1 = (int) value;
              Switch.DC1status = value.ToString();
            }
            this.WriteCustomization();
          }
          if (id == (short) 1 && Switch.heater2Mode == "Dew Heater2")
          {
            if (value != 0.0)
            {
              if (value != 1.0)
              {
                if (value != 2.0)
                {
                  if (value != 3.0)
                  {
                    if (value != 4.0)
                    {
                      if (value == 5.0)
                      {
                        if (Switch.Sensortype == "DS18B20")
                        {
                          Serial objSerial = Switch.objSerial;
                          num1 = 412000 + Switch.dew2t;
                          string Data = num1.ToString() + "a";
                          objSerial.Transmit(Data);
                          this.HEAT2 = (int) value;
                          Switch.DC2status = value.ToString();
                        }
                        else
                        {
                          int num4 = (int) MessageBox.Show("You need to connect the DS18B20 probe and check 'DS18B20 probe' in the configuration interface to activate this function.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                      }
                    }
                    else if (Switch.Sensortype == "DHT22")
                    {
                      Switch.objSerial.Transmit("400002a");
                      this.HEAT2 = (int) value;
                      Switch.DC2status = value.ToString();
                    }
                    else
                    {
                      int num5 = (int) MessageBox.Show("You need to connect the DHT22 sensor and check 'DHT22 Sensor' in the configuration interface to activate this function.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                  }
                  else
                  {
                    Serial objSerial = Switch.objSerial;
                    num1 = Switch.dew2maximum + 2000;
                    string Data = num1.ToString() + "a";
                    objSerial.Transmit(Data);
                    this.HEAT2 = (int) value;
                    Switch.DC2status = value.ToString();
                  }
                }
                else
                {
                  Serial objSerial = Switch.objSerial;
                  num1 = Switch.dew2high + 2000;
                  string Data = num1.ToString() + "a";
                  objSerial.Transmit(Data);
                  this.HEAT2 = (int) value;
                  Switch.DC2status = value.ToString();
                }
              }
              else
              {
                Serial objSerial = Switch.objSerial;
                num1 = Switch.dew2low + 2000;
                string Data = num1.ToString() + "a";
                objSerial.Transmit(Data);
                this.HEAT2 = (int) value;
                Switch.DC2status = value.ToString();
              }
            }
            else
            {
              Switch.objSerial.Transmit("2000a");
              this.HEAT2 = (int) value;
              Switch.DC2status = value.ToString();
            }
            this.WriteCustomization();
          }
          if (id == (short) 2 && Switch.heater3Mode == "Dew Heater3")
          {
            if (value != 0.0)
            {
              if (value != 1.0)
              {
                if (value != 2.0)
                {
                  if (value != 3.0)
                  {
                    if (value != 4.0)
                    {
                      if (value == 5.0)
                      {
                        if (Switch.Sensortype == "DS18B20")
                        {
                          Serial objSerial = Switch.objSerial;
                          num1 = 413000 + Switch.dew3t;
                          string Data = num1.ToString() + "a";
                          objSerial.Transmit(Data);
                          this.HEAT3 = (int) value;
                          Switch.DC3status = value.ToString();
                        }
                        else
                        {
                          int num6 = (int) MessageBox.Show("You need to connect the DS18B20 probe and check 'DS18B20 probe' in the configuration interface to activate this function.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                      }
                    }
                    else if (Switch.Sensortype == "DHT22")
                    {
                      Switch.objSerial.Transmit("400003a");
                      this.HEAT3 = (int) value;
                      Switch.DC3status = value.ToString();
                    }
                    else
                    {
                      int num7 = (int) MessageBox.Show("You need to connect the DHT22 sensor and check 'DHT22 Sensor' in the configuration interface to activate this function.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                  }
                  else
                  {
                    Serial objSerial = Switch.objSerial;
                    num1 = Switch.dew3maximum + 3000;
                    string Data = num1.ToString() + "a";
                    objSerial.Transmit(Data);
                    this.HEAT3 = (int) value;
                    Switch.DC3status = value.ToString();
                  }
                }
                else
                {
                  Serial objSerial = Switch.objSerial;
                  num1 = Switch.dew3high + 3000;
                  string Data = num1.ToString() + "a";
                  objSerial.Transmit(Data);
                  this.HEAT3 = (int) value;
                  Switch.DC3status = value.ToString();
                }
              }
              else
              {
                Serial objSerial = Switch.objSerial;
                num1 = Switch.dew3low + 3000;
                string Data = num1.ToString() + "a";
                objSerial.Transmit(Data);
                this.HEAT3 = (int) value;
                Switch.DC3status = value.ToString();
              }
            }
            else
            {
              Switch.objSerial.Transmit("3000a");
              this.HEAT3 = (int) value;
              Switch.DC3status = value.ToString();
            }
            this.WriteCustomization();
          }
          if (id == (short) 3 && value == 1.0)
          {
            this.DC4state = 1;
            Switch.objSerial.Transmit("141a");
            Switch.DC4status = "On";
            Thread.Sleep(10);
          }
          if (id == (short) 3 && value == 0.0)
          {
            this.DC4state = 0;
            Switch.objSerial.Transmit("140a");
            Switch.DC4status = "Off";
            Thread.Sleep(10);
          }
          if (id == (short) 4 && value == 1.0)
          {
            this.DC5_8state = 1;
            Switch.objSerial.Transmit("151a");
            Switch.DC5_8status = "On";
            Thread.Sleep(10);
          }
          if (id == (short) 4 && value == 0.0)
          {
            this.DC5_8state = 0;
            Switch.objSerial.Transmit("150a");
            Switch.DC5_8status = "Off";
            Thread.Sleep(10);
          }
          if (id == (short) 6 && value == 1.0)
          {
            this.USB3_1state = 1;
            Switch.objSerial.Transmit("311a");
            Switch.USB31status = "On";
            Thread.Sleep(500);
          }
          if (id == (short) 6 && value == 0.0)
          {
            this.USB3_1state = 0;
            Switch.objSerial.Transmit("310a");
            Switch.USB31status = "Off";
            Thread.Sleep(500);
          }
          if (id == (short) 7 && value == 1.0)
          {
            this.USB3_2state = 1;
            Switch.objSerial.Transmit("321a");
            Switch.USB32status = "On";
            Thread.Sleep(500);
          }
          if (id == (short) 7 && value == 0.0)
          {
            this.USB3_2state = 0;
            Switch.objSerial.Transmit("320a");
            Switch.USB32status = "Off";
            Thread.Sleep(500);
          }
          if (id == (short) 8 && value == 1.0)
          {
            this.USB3_3state = 1;
            Switch.objSerial.Transmit("331a");
            Switch.USB33status = "On";
            Thread.Sleep(500);
          }
          if (id == (short) 8 && value == 0.0)
          {
            this.USB3_3state = 0;
            Switch.objSerial.Transmit("330a");
            Switch.USB33status = "Off";
            Thread.Sleep(500);
          }
          if (id == (short) 9 && value == 1.0)
          {
            this.USB2_1state = 1;
            Switch.objSerial.Transmit("211a");
            Switch.USB21status = "On";
            Thread.Sleep(500);
          }
          if (id == (short) 9 && value == 0.0)
          {
            this.USB2_1state = 0;
            Switch.objSerial.Transmit("210a");
            Switch.USB21status = "Off";
            Thread.Sleep(500);
          }
          if (id == (short) 10 && value == 1.0)
          {
            this.USB2_2state = 1;
            Switch.objSerial.Transmit("221a");
            Switch.USB22status = "On";
            Thread.Sleep(500);
          }
          if (id == (short) 10 && value == 0.0)
          {
            this.USB2_2state = 0;
            Switch.objSerial.Transmit("220a");
            Switch.USB22status = "Off";
            Thread.Sleep(500);
          }
          if (id == (short) 11 && value == 1.0)
          {
            this.USB2_3state = 1;
            Switch.objSerial.Transmit("231a");
            Switch.USB23status = "On";
            Thread.Sleep(500);
          }
          if (id == (short) 11 && value == 0.0)
          {
            this.USB2_3state = 0;
            Switch.objSerial.Transmit("230a");
            Switch.USB23status = "Off";
            Thread.Sleep(500);
          }
          if (id == (short) 12 && value == 1.0)
          {
            this.USB2_4state = 1;
            Switch.objSerial.Transmit("241a");
            Switch.USB24status = "On";
            Thread.Sleep(500);
          }
          if (id == (short) 12 && value == 0.0)
          {
            this.USB2_4state = 0;
            Switch.objSerial.Transmit("240a");
            Switch.USB24status = "Off";
            Thread.Sleep(500);
          }
          if (id == (short) 13 && value == 1.0)
          {
            this.USB2_5state = 1;
            Switch.objSerial.Transmit("251a");
            Switch.USB25status = "On";
            Thread.Sleep(500);
          }
          if (id == (short) 13 && value == 0.0)
          {
            this.USB2_5state = 0;
            Switch.objSerial.Transmit("250a");
            Switch.USB25status = "Off";
            Thread.Sleep(500);
          }
          if (id == (short) 14 && value == 1.0)
          {
            this.USB2_6state = 1;
            Switch.objSerial.Transmit("261a");
            Switch.USB26status = "On";
            Thread.Sleep(500);
          }
          if (id == (short) 14 && value == 0.0)
          {
            this.USB2_6state = 0;
            Switch.objSerial.Transmit("260a");
            Switch.USB26status = "Off";
            Thread.Sleep(500);
          }
          if (id == (short) 0 && value == 1.0 && Switch.heater1Mode == "Switch1")
          {
            this.DC1state = 1;
            Switch.objSerial.Transmit("1255a");
            Switch.DC1status = "On";
            Thread.Sleep(10);
          }
          if (id == (short) 0 && value == 0.0 && Switch.heater1Mode == "Switch1")
          {
            this.DC1state = 0;
            Switch.objSerial.Transmit("1000a");
            Switch.DC1status = "Off";
            Thread.Sleep(10);
          }
          if (id == (short) 1 && value == 1.0 && Switch.heater2Mode == "Switch2")
          {
            this.DC2state = 1;
            Switch.objSerial.Transmit("2255a");
            Switch.DC2status = "On";
            Thread.Sleep(10);
          }
          if (id == (short) 1 && value == 0.0 && Switch.heater2Mode == "Switch2")
          {
            this.DC2state = 0;
            Switch.objSerial.Transmit("2000a");
            Switch.DC2status = "Off";
            Thread.Sleep(10);
          }
          if (id == (short) 2 && value == 1.0 && Switch.heater3Mode == "Switch3")
          {
            this.DC3state = 1;
            Switch.objSerial.Transmit("3255a");
            Switch.DC3status = "On";
            Thread.Sleep(10);
          }
          if (id == (short) 2 && value == 0.0 && Switch.heater3Mode == "Switch3")
          {
            this.DC3state = 0;
            Switch.objSerial.Transmit("3000a");
            Switch.DC3status = "Off";
            Thread.Sleep(10);
          }
          this.WriteCustomization();
          break;
        case "PlusV2":
          int num8;
          if (id == (short) 1 && Switch.heater1Mode == "Dew Heater1")
          {
            if (value != 0.0)
            {
              if (value != 1.0)
              {
                if (value != 2.0)
                {
                  if (value != 3.0)
                  {
                    if (value == 4.0)
                    {
                      if (Switch.Sensortype == "Weather")
                      {
                        this.Readdewpoint();
                        this.HEAT1 = (int) value;
                        Switch.DC1status = value.ToString();
                        if (Switch.humnum >= 85.0)
                          Switch.power1 = Switch.dew1maximum;
                        if (Switch.humnum < 85.0 && Switch.humnum >= 75.0)
                          Switch.power1 = Switch.dew1high;
                        if (Switch.humnum < 75.0 && Switch.humnum >= 65.0)
                          Switch.power1 = Switch.dew1low;
                        if (Switch.humnum < 65.0)
                          Switch.power1 = 0;
                      }
                      else
                      {
                        int num9 = (int) MessageBox.Show("You need to connect the Wanderer Weather Station Mini as well as  check  'Wanderer Weather Station Mini' in the configuration interface to activate this function.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                      }
                    }
                  }
                  else
                  {
                    Serial objSerial = Switch.objSerial;
                    num8 = Switch.dew1maximum + 1000;
                    string Data = num8.ToString() + "a";
                    objSerial.Transmit(Data);
                    this.HEAT1 = (int) value;
                    Switch.power1 = Switch.dew1maximum;
                    Switch.DC1status = value.ToString();
                  }
                }
                else
                {
                  Serial objSerial = Switch.objSerial;
                  num8 = Switch.dew1high + 1000;
                  string Data = num8.ToString() + "a";
                  objSerial.Transmit(Data);
                  this.HEAT1 = (int) value;
                  Switch.power1 = Switch.dew1high;
                  Switch.DC1status = value.ToString();
                }
              }
              else
              {
                Serial objSerial = Switch.objSerial;
                num8 = Switch.dew1low + 1000;
                string Data = num8.ToString() + "a";
                objSerial.Transmit(Data);
                this.HEAT1 = (int) value;
                Switch.power1 = Switch.dew1low;
                Switch.DC1status = value.ToString();
              }
            }
            else
            {
              Switch.objSerial.Transmit("1000a");
              this.HEAT1 = (int) value;
              Switch.power1 = 0;
              Switch.DC1status = value.ToString();
            }
            this.WriteCustomization();
          }
          if (id != (short) 2 || !(Switch.heater2Mode == "Dew Heater2"))
            break;
          if (value != 0.0)
          {
            if (value != 1.0)
            {
              if (value != 2.0)
              {
                if (value != 3.0)
                {
                  if (value == 4.0)
                  {
                    if (Switch.Sensortype == "Weather")
                    {
                      this.Readdewpoint();
                      this.HEAT2 = (int) value;
                      Switch.DC2status = value.ToString();
                      if (Switch.humnum >= 85.0)
                        Switch.power2 = Switch.dew2maximum;
                      if (Switch.humnum < 85.0 && Switch.humnum >= 75.0)
                        Switch.power2 = Switch.dew2high;
                      if (Switch.humnum < 75.0 && Switch.humnum >= 65.0)
                        Switch.power2 = Switch.dew2low;
                      if (Switch.humnum < 65.0)
                        Switch.power2 = 0;
                    }
                    else
                    {
                      int num10 = (int) MessageBox.Show("You need to connect the Wanderer Weather Station Mini as well as  check  'Wanderer Weather Station Mini' in the configuration interface to activate this function.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                  }
                }
                else
                {
                  Serial objSerial = Switch.objSerial;
                  num8 = Switch.dew2maximum + 2000;
                  string Data = num8.ToString() + "a";
                  objSerial.Transmit(Data);
                  this.HEAT2 = (int) value;
                  Switch.power2 = Switch.dew2maximum;
                  Switch.DC2status = value.ToString();
                }
              }
              else
              {
                Serial objSerial = Switch.objSerial;
                num8 = Switch.dew2high + 2000;
                string Data = num8.ToString() + "a";
                objSerial.Transmit(Data);
                this.HEAT2 = (int) value;
                Switch.power2 = Switch.dew2high;
                Switch.DC2status = value.ToString();
              }
            }
            else
            {
              Serial objSerial = Switch.objSerial;
              num8 = Switch.dew2low + 2000;
              string Data = num8.ToString() + "a";
              objSerial.Transmit(Data);
              this.HEAT2 = (int) value;
              Switch.power2 = Switch.dew2low;
              Switch.DC2status = value.ToString();
            }
          }
          else
          {
            Switch.objSerial.Transmit("2000a");
            this.HEAT2 = (int) value;
            Switch.power2 = 0;
            Switch.DC2status = value.ToString();
          }
          this.WriteCustomization();
          break;
      }
    }

    public void Connect()
    {
      throw new MethodNotImplementedException();
    }

    public void Disconnect()
    {
      throw new MethodNotImplementedException();
    }

    public void SetAsync(short id, bool state)
    {
      throw new MethodNotImplementedException();
    }

    public void SetAsyncValue(short id, double value)
    {
      throw new MethodNotImplementedException();
    }

    public bool CanAsync(short id)
    {
      return false;
    }

    public bool StateChangeComplete(short id)
    {
      throw new MethodNotImplementedException();
    }

    private void Validate(string message, short id)
    {
      switch (Switch.selectedmodel)
      {
        case "UltimateV2":
          if (id >= (short) 0 && id < (short) 15)
            break;
          this.tl.LogMessage(message, $"Switch {id} not available, range is 0 to {14}");
          throw new InvalidValueException(message, id.ToString(), $"0 to {14}");
        case "PlusV2":
          if (id >= (short) 0 && id < (short) 5)
            break;
          this.tl.LogMessage(message, $"Switch {id} not available, range is 0 to {4}");
          throw new InvalidValueException(message, id.ToString(), $"0 to {4}");
      }
    }

    private void Validate(string message, short id, double value)
    {
      this.Validate(message, id);
      double num1 = this.MinSwitchValue(id);
      double num2 = this.MaxSwitchValue(id);
      if (value < num1 || value > num2)
      {
        this.tl.LogMessage(message, string.Format("Value {1} for Switch {0} is out of the allowed range {2} to {3}", (object) id, (object) value, (object) num1, (object) num2));
        throw new InvalidValueException(message, value.ToString(), $"Switch({id}) range {num1} to {num2}");
      }
    }

    private static void RegUnregASCOM(bool bRegister)
    {
      using (Profile profile = new Profile())
      {
        profile.DeviceType = nameof (Switch);
      //  if (bRegister)
          //profile.Register(Switch.driverID, Switch.driverDescription);
       // else
        //  profile.Unregister(Switch.driverID);
      }
    }

    [ComRegisterFunction]
    public static void RegisterASCOM(Type t) => Switch.RegUnregASCOM(true);

    [ComUnregisterFunction]
    public static void UnregisterASCOM(Type t) => Switch.RegUnregASCOM(false);

    private bool IsConnected => this.connectedState;

    private void CheckConnected(string message)
    {
      if (!this.IsConnected)
        throw new NotConnectedException(message);
    }

    internal void ReadProfile()
    {
      using (Profile profile = new Profile())
      {
        profile.DeviceType = nameof (Switch);
        this.tl.Enabled = Convert.ToBoolean(profile.GetValue(Switch.driverID, Switch.traceStateProfileName, string.Empty, Switch.traceStateDefault));
        Switch.comPort = profile.GetValue(Switch.driverID, Switch.comPortProfileName, string.Empty, Switch.comPortDefault);
      }
    }

    internal void WriteProfile()
    {
      using (Profile profile = new Profile())
      {
        profile.DeviceType = nameof (Switch);
        profile.WriteValue(Switch.driverID, Switch.traceStateProfileName, this.tl.Enabled.ToString());
        if (Switch.comPort == null)
          return;
        profile.WriteValue(Switch.driverID, Switch.comPortProfileName, Switch.comPort.ToString());
      }
    }

    internal void LogMessage(string identifier, string message, params object[] args)
    {
      string Message = string.Format(message, args);
      this.tl.LogMessage(identifier, Message);
    }

    public void ReadCustomization()
    {
      using (Profile profile = new Profile())
      {
        profile.DeviceType = nameof (Switch);
        Switch.manualCOM = profile.GetValue(Switch.driverID, "ManualCOM", string.Empty, "false");
      }
      switch (Switch.selectedmodel)
      {
        case "UltimateV2":
          using (Profile profile = new Profile())
          {
            profile.DeviceType = nameof (Switch);
            Switch.DC1name = profile.GetValue(Switch.driverID, Switch.AscomDC1name, string.Empty, "PWM 1");
            Switch.DC2name = profile.GetValue(Switch.driverID, Switch.AscomDC2name, string.Empty, "PWM 2");
            Switch.DC3name = profile.GetValue(Switch.driverID, Switch.AscomDC3name, string.Empty, "PWM 3");
            Switch.DC4name = profile.GetValue(Switch.driverID, Switch.AscomDC4name, string.Empty, "DC OUT 4");
            Switch.DC5_8name = profile.GetValue(Switch.driverID, Switch.AscomDC5_8name, string.Empty, "DC OUT 5-8");
            Switch.DC9name = profile.GetValue(Switch.driverID, Switch.AscomDC9name, string.Empty, "DC9 Always ON");
            Switch.USB3_1name = profile.GetValue(Switch.driverID, Switch.AscomUSB3_1name, string.Empty, "USB3.1-1");
            Switch.USB3_2name = profile.GetValue(Switch.driverID, Switch.AscomUSB3_2name, string.Empty, "USB3.1-2");
            Switch.USB3_3name = profile.GetValue(Switch.driverID, Switch.AscomUSB3_3name, string.Empty, "USB3.1-3");
            Switch.USB2_1name = profile.GetValue(Switch.driverID, Switch.AscomUSB2_1name, string.Empty, "USB2.0-1");
            Switch.USB2_2name = profile.GetValue(Switch.driverID, Switch.AscomUSB2_2name, string.Empty, "USB2.0-2");
            Switch.USB2_3name = profile.GetValue(Switch.driverID, Switch.AscomUSB2_3name, string.Empty, "USB2.0-3");
            Switch.USB2_4name = profile.GetValue(Switch.driverID, Switch.AscomUSB2_4name, string.Empty, "USB2.0-4");
            Switch.USB2_5name = profile.GetValue(Switch.driverID, Switch.AscomUSB2_5name, string.Empty, "USB2.0-5");
            Switch.USB2_6name = profile.GetValue(Switch.driverID, Switch.AscomUSB2_6name, string.Empty, "USB2.0-6");
            Switch.heater1Mode = profile.GetValue(Switch.driverID, Switch.Ascomheater1Mode, string.Empty, "Dew Heater1");
            Switch.heater2Mode = profile.GetValue(Switch.driverID, Switch.Ascomheater2Mode, string.Empty, "Dew Heater2");
            Switch.heater3Mode = profile.GetValue(Switch.driverID, Switch.Ascomheater3Mode, string.Empty, "Switch3");
            Switch.dew1low = Convert.ToInt32(profile.GetValue(Switch.driverID, Switch.Ascomdew1low, string.Empty, "1150")) - 1000;
            Switch.dew2low = Convert.ToInt32(profile.GetValue(Switch.driverID, Switch.Ascomdew2low, string.Empty, "2150")) - 2000;
            Switch.dew3low = Convert.ToInt32(profile.GetValue(Switch.driverID, Switch.Ascomdew3low, string.Empty, "3150")) - 3000;
            Switch.dew1high = Convert.ToInt32(profile.GetValue(Switch.driverID, Switch.Ascomdew1high, string.Empty, "1190")) - 1000;
            Switch.dew2high = Convert.ToInt32(profile.GetValue(Switch.driverID, Switch.Ascomdew2high, string.Empty, "2190")) - 2000;
            Switch.dew3high = Convert.ToInt32(profile.GetValue(Switch.driverID, Switch.Ascomdew3high, string.Empty, "3190")) - 3000;
            Switch.dew1maximum = Convert.ToInt32(profile.GetValue(Switch.driverID, Switch.Ascomdew1maximum, string.Empty, "1255")) - 1000;
            Switch.dew2maximum = Convert.ToInt32(profile.GetValue(Switch.driverID, Switch.Ascomdew2maximum, string.Empty, "2255")) - 2000;
            Switch.dew3maximum = Convert.ToInt32(profile.GetValue(Switch.driverID, Switch.Ascomdew3maximum, string.Empty, "3255")) - 3000;
            Switch.dew1t = Convert.ToInt32(profile.GetValue(Switch.driverID, Switch.Ascomdew1t, string.Empty, "10040")) - 10000;
            Switch.dew2t = Convert.ToInt32(profile.GetValue(Switch.driverID, Switch.Ascomdew2t, string.Empty, "20040")) - 20000;
            Switch.dew3t = Convert.ToInt32(profile.GetValue(Switch.driverID, Switch.Ascomdew3t, string.Empty, "30040")) - 30000;
            Switch.Sensortype = profile.GetValue(Switch.driverID, Switch.AscomSensorType, string.Empty, "None");
            Switch.DC1status = profile.GetValue(Switch.driverID, "DC1status", string.Empty, "3");
            Switch.DC2status = profile.GetValue(Switch.driverID, "DC2status", string.Empty, "3");
            Switch.DC3status = profile.GetValue(Switch.driverID, "DC3status", string.Empty, "On");
            Switch.DC4status = profile.GetValue(Switch.driverID, "DC4status", string.Empty, "On");
            Switch.DC5_8status = profile.GetValue(Switch.driverID, "DC5_8status", string.Empty, "On");
            Switch.USB31status = profile.GetValue(Switch.driverID, "USB31status", string.Empty, "On");
            Switch.USB32status = profile.GetValue(Switch.driverID, "USB32status", string.Empty, "On");
            Switch.USB33status = profile.GetValue(Switch.driverID, "USB33status", string.Empty, "On");
            Switch.USB21status = profile.GetValue(Switch.driverID, "USB21status", string.Empty, "On");
            Switch.USB22status = profile.GetValue(Switch.driverID, "USB22status", string.Empty, "On");
            Switch.USB23status = profile.GetValue(Switch.driverID, "USB23status", string.Empty, "On");
            Switch.USB24status = profile.GetValue(Switch.driverID, "USB24status", string.Empty, "On");
            Switch.USB25status = profile.GetValue(Switch.driverID, "USB25status", string.Empty, "On");
            Switch.USB26status = profile.GetValue(Switch.driverID, "USB26status", string.Empty, "On");
            break;
          }
        case "PlusV2":
          using (Profile profile = new Profile())
          {
            profile.DeviceType = nameof (Switch);
            Switch.DC1_3name = profile.GetValue(Switch.driverID, "1-3", string.Empty, "DC 1-3");
            Switch.DC4name = profile.GetValue(Switch.driverID, "4", string.Empty, "PWM 1");
            Switch.DC5name = profile.GetValue(Switch.driverID, "5", string.Empty, "PWM 2");
            Switch.DC6name = profile.GetValue(Switch.driverID, "6", string.Empty, "DC6 Always On");
            Switch.USBname = profile.GetValue(Switch.driverID, "USB", string.Empty, "USB Device");
            Switch.heater1Mode = profile.GetValue(Switch.driverID, "1mode", string.Empty, "Dew Heater1");
            Switch.heater2Mode = profile.GetValue(Switch.driverID, "2mode", string.Empty, "Dew Heater2");
            Switch.dew1low = Convert.ToInt32(profile.GetValue(Switch.driverID, "1low", string.Empty, "1150")) - 1000;
            Switch.dew2low = Convert.ToInt32(profile.GetValue(Switch.driverID, "2low", string.Empty, "2150")) - 2000;
            Switch.dew1high = Convert.ToInt32(profile.GetValue(Switch.driverID, "1high", string.Empty, "1190")) - 1000;
            Switch.dew2high = Convert.ToInt32(profile.GetValue(Switch.driverID, "2high", string.Empty, "2190")) - 2000;
            Switch.dew1maximum = Convert.ToInt32(profile.GetValue(Switch.driverID, "1max", string.Empty, "1255")) - 1000;
            Switch.dew2maximum = Convert.ToInt32(profile.GetValue(Switch.driverID, "2max", string.Empty, "2255")) - 2000;
            Switch.DC1status = profile.GetValue(Switch.driverID, "DC1status", string.Empty, "0");
            Switch.DC2status = profile.GetValue(Switch.driverID, "DC2status", string.Empty, "0");
            Switch.DC3status = profile.GetValue(Switch.driverID, "DC3status", string.Empty, "On");
            Switch.USBstatus = profile.GetValue(Switch.driverID, "USBstatus", string.Empty, "On");
            Switch.Sensortype = profile.GetValue(Switch.driverID, "type", string.Empty, "None");
            break;
          }
      }
    }

    internal void WriteCustomization()
    {
      using (Profile profile = new Profile())
      {
        profile.DeviceType = nameof (Switch);
        profile.WriteValue(Switch.driverID, "ManualCOM", Switch.manualCOM);
      }
      switch (Switch.selectedmodel)
      {
        case "UltimateV2":
          using (Profile profile = new Profile())
          {
            profile.DeviceType = nameof (Switch);
            profile.WriteValue(Switch.driverID, "lang", Switch.lang);
            profile.WriteValue(Switch.driverID, Switch.AscomDC1name, Switch.DC1name);
            profile.WriteValue(Switch.driverID, Switch.AscomDC2name, Switch.DC2name);
            profile.WriteValue(Switch.driverID, Switch.AscomDC3name, Switch.DC3name);
            profile.WriteValue(Switch.driverID, Switch.AscomDC4name, Switch.DC4name);
            profile.WriteValue(Switch.driverID, Switch.AscomDC5_8name, Switch.DC5_8name);
            profile.WriteValue(Switch.driverID, Switch.AscomDC9name, Switch.DC9name);
            profile.WriteValue(Switch.driverID, Switch.AscomUSB3_1name, Switch.USB3_1name);
            profile.WriteValue(Switch.driverID, Switch.AscomUSB3_2name, Switch.USB3_2name);
            profile.WriteValue(Switch.driverID, Switch.AscomUSB3_3name, Switch.USB3_3name);
            profile.WriteValue(Switch.driverID, Switch.AscomUSB2_1name, Switch.USB2_1name);
            profile.WriteValue(Switch.driverID, Switch.AscomUSB2_2name, Switch.USB2_2name);
            profile.WriteValue(Switch.driverID, Switch.AscomUSB2_3name, Switch.USB2_3name);
            profile.WriteValue(Switch.driverID, Switch.AscomUSB2_4name, Switch.USB2_4name);
            profile.WriteValue(Switch.driverID, Switch.AscomUSB2_5name, Switch.USB2_5name);
            profile.WriteValue(Switch.driverID, Switch.AscomUSB2_6name, Switch.USB2_6name);
            profile.WriteValue(Switch.driverID, Switch.Ascomheater1Mode, Switch.heater1Mode);
            profile.WriteValue(Switch.driverID, Switch.Ascomheater2Mode, Switch.heater2Mode);
            profile.WriteValue(Switch.driverID, Switch.Ascomheater3Mode, Switch.heater3Mode);
            profile.WriteValue(Switch.driverID, Switch.Ascomdew1low, (Switch.dew1low + 1000).ToString());
            profile.WriteValue(Switch.driverID, Switch.Ascomdew2low, (Switch.dew2low + 2000).ToString());
            profile.WriteValue(Switch.driverID, Switch.Ascomdew3low, (Switch.dew3low + 3000).ToString());
            profile.WriteValue(Switch.driverID, Switch.Ascomdew1high, (Switch.dew1high + 1000).ToString());
            profile.WriteValue(Switch.driverID, Switch.Ascomdew2high, (Switch.dew2high + 2000).ToString());
            profile.WriteValue(Switch.driverID, Switch.Ascomdew3high, (Switch.dew3high + 3000).ToString());
            profile.WriteValue(Switch.driverID, Switch.Ascomdew1maximum, (Switch.dew1maximum + 1000).ToString());
            profile.WriteValue(Switch.driverID, Switch.Ascomdew2maximum, (Switch.dew2maximum + 2000).ToString());
            profile.WriteValue(Switch.driverID, Switch.Ascomdew3maximum, (Switch.dew3maximum + 3000).ToString());
            profile.WriteValue(Switch.driverID, Switch.Ascomdew1t, (Switch.dew1t + 10000).ToString());
            profile.WriteValue(Switch.driverID, Switch.Ascomdew2t, (Switch.dew2t + 20000).ToString());
            profile.WriteValue(Switch.driverID, Switch.Ascomdew3t, (Switch.dew3t + 30000).ToString());
            profile.WriteValue(Switch.driverID, Switch.AscomSensorType, Switch.Sensortype);
            profile.WriteValue(Switch.driverID, "DC1status", Switch.DC1status);
            profile.WriteValue(Switch.driverID, "DC2status", Switch.DC2status);
            profile.WriteValue(Switch.driverID, "DC3status", Switch.DC3status);
            profile.WriteValue(Switch.driverID, "DC4status", Switch.DC4status);
            profile.WriteValue(Switch.driverID, "DC5_8status", Switch.DC5_8status);
            profile.WriteValue(Switch.driverID, "USB31status", Switch.USB31status);
            profile.WriteValue(Switch.driverID, "USB32status", Switch.USB32status);
            profile.WriteValue(Switch.driverID, "USB33status", Switch.USB33status);
            profile.WriteValue(Switch.driverID, "USB21status", Switch.USB21status);
            profile.WriteValue(Switch.driverID, "USB22status", Switch.USB22status);
            profile.WriteValue(Switch.driverID, "USB23status", Switch.USB23status);
            profile.WriteValue(Switch.driverID, "USB24status", Switch.USB24status);
            profile.WriteValue(Switch.driverID, "USB25status", Switch.USB25status);
            profile.WriteValue(Switch.driverID, "USB26status", Switch.USB26status);
            break;
          }
        case "PlusV2":
          using (Profile profile = new Profile())
          {
            profile.DeviceType = nameof (Switch);
            profile.WriteValue(Switch.driverID, "lang", Switch.lang);
            profile.WriteValue(Switch.driverID, "1-3", Switch.DC1_3name);
            profile.WriteValue(Switch.driverID, "4", Switch.DC4name);
            profile.WriteValue(Switch.driverID, "5", Switch.DC5name);
            profile.WriteValue(Switch.driverID, "6", Switch.DC6name);
            profile.WriteValue(Switch.driverID, "USB", Switch.USBname);
            profile.WriteValue(Switch.driverID, "1mode", Switch.heater1Mode);
            profile.WriteValue(Switch.driverID, "2mode", Switch.heater2Mode);
            profile.WriteValue(Switch.driverID, "1low", (Switch.dew1low + 1000).ToString());
            profile.WriteValue(Switch.driverID, "2low", (Switch.dew2low + 2000).ToString());
            profile.WriteValue(Switch.driverID, "1high", (Switch.dew1high + 1000).ToString());
            profile.WriteValue(Switch.driverID, "2high", (Switch.dew2high + 2000).ToString());
            profile.WriteValue(Switch.driverID, "1max", (Switch.dew1maximum + 1000).ToString());
            profile.WriteValue(Switch.driverID, "2max", (Switch.dew2maximum + 2000).ToString());
            profile.WriteValue(Switch.driverID, "DC1status", Switch.DC1status);
            profile.WriteValue(Switch.driverID, "DC2status", Switch.DC2status);
            profile.WriteValue(Switch.driverID, "DC3status", Switch.DC3status);
            profile.WriteValue(Switch.driverID, "USBstatus", Switch.USBstatus);
            profile.WriteValue(Switch.driverID, "type", Switch.Sensortype);
            break;
          }
      }
    }

    internal void WriteSelectedModel()
    {
      using (Profile profile = new Profile())
      {
        profile.DeviceType = nameof (Switch);
        profile.WriteValue(Switch.driverID, "SelectModel", Switch.selectedmodel);
      }
    }

    internal void ReadSelectedModel()
    {
      using (Profile profile = new Profile())
      {
        profile.DeviceType = nameof (Switch);
        Switch.selectedmodel = profile.GetValue(Switch.driverID, "SelectModel", string.Empty, "UltimateV2");
      }
    }
  }
}
