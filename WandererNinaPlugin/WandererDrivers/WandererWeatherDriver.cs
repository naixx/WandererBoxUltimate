using ASCOM.Alpaca.Discovery;
using ASCOM.Common.DeviceInterfaces;
using ASCOM.WandererBoxes;
using CommunityToolkit.Mvvm.ComponentModel;
using NINA.Core.Locale;
using NINA.Core.Utility;
using NINA.Equipment.Equipment;
using NINA.Equipment.Equipment.MySwitch.Ascom;
using NINA.Equipment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
// using Switch = ASCOM.naixxWanderer.Switch.Switch;
using Switch = ASCOM.WandererBoxes.Switch;

namespace Naixx.NINA.Wanderer.WandererDrivers {
    
    internal class AscomWritableSwitch : AscomSwitch, IWritableSwitch {

        public AscomWritableSwitch(ISwitchV2 s, short id) : base(s, id) {
            Maximum = ascomSwitchHub.MaxSwitchValue(id);
            Minimum = ascomSwitchHub.MinSwitchValue(id);
            StepSize = ascomSwitchHub.SwitchStep(id);
            this.TargetValue = this.Value;
        }

        public void SetValue() {
            Logger.Trace($"Try setting value {TargetValue} for switch id {Id}");
            ascomSwitchHub.SetSwitchValue(Id, TargetValue);
        }

        public double Maximum { get; }

        public double Minimum { get; }

        public double StepSize { get; }

        private double targetValue;

        public double TargetValue {
            get => targetValue;
            set {
                var adjustedValue = CoreUtil.GetClosestNumber(value, StepSize);
                if(adjustedValue < Minimum) { adjustedValue = Minimum; }
                if(adjustedValue > Maximum) { adjustedValue = Maximum; }
                targetValue = adjustedValue;
                RaisePropertyChanged();
            }
        }
    }
    
    internal class AscomV1Switch : BaseINPC, ISwitch {

        public AscomV1Switch(ISwitchV2 s, short id) {
            Id = id;
            ascomSwitchHub = s;

            this.Name = ascomSwitchHub.GetSwitchName(Id);
            this.Description = string.Empty;
            this.Value = ascomSwitchHub.GetSwitch(Id) ? 1d : 0d;
        }

        public bool Poll() {
            try {
                this.Value = ascomSwitchHub.GetSwitch(Id) ? 1d : 0d;
                Logger.Trace($"Retrieved values for switch id {Id}: {this.Value}");
                RaisePropertyChanged(nameof(Value));
            } catch (Exception) {
                Logger.Trace($"Failed to retrieve value sfor switch id {Id}");
                return false;
            }
            return true;
        }

        protected ISwitchV2 ascomSwitchHub;

        public short Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public double Value { get; private set; }
    }
    
    internal class AscomWritableV1Switch : AscomV1Switch, IWritableSwitch {

        public AscomWritableV1Switch(ISwitchV2 s, short id) : base(s, id) {
            Minimum = 0;
            Maximum = 1;
            StepSize = 1;
            this.TargetValue = this.Value;
        }

        public void SetValue() {
            Logger.Trace($"Try setting value {TargetValue} for switch id {Id}");
            var val = TargetValue == 1 ? true : false;
            ascomSwitchHub.SetSwitch(Id, val);
        }

        public double Maximum { get; }

        public double Minimum { get; }

        public double StepSize { get; }

        private double targetValue;

        public double TargetValue {
            get => targetValue;
            set {
                targetValue = value;
                RaisePropertyChanged();
            }
        }
    }
    
    internal class AscomSwitch : BaseINPC, ISwitch {

        public AscomSwitch(ISwitchV2 s, short id) {
            Id = id;
            ascomSwitchHub = s;

            this.Name = ascomSwitchHub.GetSwitchName(Id);
            this.Description = ascomSwitchHub.GetSwitchDescription(Id);
            this.Value = ascomSwitchHub.GetSwitchValue(Id);
        }

        protected ISwitchV2 ascomSwitchHub;

        public short Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public double Value { get; private set; }

        public bool Poll() {
            try {
                this.Name = ascomSwitchHub.GetSwitchName(Id);
                this.Value = ascomSwitchHub.GetSwitchValue(Id);
                Logger.Trace($"Retrieved values for switch id {Id}: {this.Value}");
                RaisePropertyChanged(nameof(Name));
                RaisePropertyChanged(nameof(Value));
                return true;
            } catch (Exception) {
                Logger.Trace($"Failed to retrieve value sfor switch id {Id}");
                return false;
            }
        }
    }
    
     public partial class AscomSwitchHub : AscomDevice<ISwitchV2>, ISwitchHub, IDisposable {
        public AscomSwitchHub(string id, string name) : base(id, name) {
            switches = new AsyncObservableCollection<ISwitch>();
        }
        public AscomSwitchHub(AscomDevice deviceMeta) : base(deviceMeta) {
            switches = new AsyncObservableCollection<ISwitch>();
        }

        [ObservableProperty]
        private ICollection<ISwitch> switches;
        
        

        protected override string ConnectionLostMessage => Loc.Instance["LblSwitchConnectionLost"];

        private async Task ScanForSwitches() {
            Logger.Trace("Scanning for Ascom Switches");
            var numberOfSwitches = device.MaxSwitch;
            for (short i = 0; i < numberOfSwitches; i++) {
                try {
                    var canWrite = device.CanWrite(i);

                    if (canWrite) {
                        Logger.Trace($"Writable Switch found for index {i}");
                        var s = new AscomWritableSwitch(device, i);
                        Switches.Add(s);
                    } else {
                        Logger.Trace($"Readable Switch found for index {i}");
                        var s = new AscomSwitch(device, i);
                        Switches.Add(s);
                    }
                } catch (ASCOM.MethodNotImplementedException e) {
                    Logger.Trace($"MethodNotImplementedException for Switch index {i}: {e.Message}");
                    //ISwitchV1 Fallbacks
                    try {                        
                        var s = new AscomWritableV1Switch(device, i);
                        s.TargetValue = s.Value;
                        s.SetValue();
                        Logger.Trace($"Writable v1 Switch found for index {i}");
                        Switches.Add(s);
                    } catch (Exception e2) {
                        Logger.Trace($"Error occurred for Switch index {i} and it is thus most likely a readable v1 Switch: {e2.Message}");
                        var s = new AscomV1Switch(device, i);
                        Switches.Add(s);
                    }
                }
            }
        }

        protected override async Task PreConnect() {
            Switches = new AsyncObservableCollection<ISwitch>();
        }

        protected override async Task PostConnect() {
            await ScanForSwitches();
        }

        protected override void PostDisconnect() {
            Switches = new AsyncObservableCollection<ISwitch>();
        }

        protected override ISwitchV2 GetInstance() {
                return new Switch();
           
        }
    }
}