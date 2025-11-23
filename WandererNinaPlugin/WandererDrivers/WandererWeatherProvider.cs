using NINA.Core.Utility;
using NINA.Equipment.Interfaces;
using NINA.Equipment.Interfaces.ViewModel;
using NINA.Profile.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Naixx.NINA.Wanderer.WandererDrivers {
    /// <summary>
    /// This Class shows the basic principle on how to add a new Device driver to N.I.N.A. via the plugin interface
    /// When the application scans for equipment the "GetEquipment" method of a device provider is called.
    /// This method should then return the specific List of Devices that you can connect to
    /// </summary>
    [Export(typeof(IEquipmentProvider))]
    public class WandererWeatherProvider : IEquipmentProvider<ISwitchHub> {
        private IProfileService profileService;

        [ImportingConstructor]
        public WandererWeatherProvider(IProfileService profileService) {
            this.profileService = profileService;
        }

        public string Name => "Wanderer";

        public IList<ISwitchHub> GetEquipment() {
            var devices = new List<ISwitchHub>();
            devices.Add(new AscomSwitchHub("MyUniqueId", "Proxy for WandererBox Ultimate v2"));

            return devices;
        }
    }
}
