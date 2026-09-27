using Meadow;
using Meadow.Devices;
using Meadow.Foundation.Sensors.Atmospheric;
using Meadow.Hardware;
using Meadow.Logging;
using Meadow.Peripherals.Displays;
using Meadow.Peripherals.Sensors.Buttons;
using Meadow.Peripherals.Sensors.Distance;

namespace RainWaterMonitor.Hardware
{
    // 2.x adaptation: composes ProjectLab.Create() instead of inheriting the (net9-era)
    // ProjectLab base class. See IWaterMonitorHardware for details.
    public class WaterMonitorHardwareBase : IWaterMonitorHardware
    {
        protected Logger? Logger => Resolver.Log;

        protected IProjectLabHardware Hardware { get; }

        protected II2cBus? I2cBus { get; }

        public IRangeFinder? DistanceSensor { get; protected set; }

        public Bme688? EnvironmentalSensor { get; }

        public IButton? UpButton => Hardware.UpButton;
        public IButton? DownButton => Hardware.DownButton;
        public IButton? LeftButton => Hardware.LeftButton;
        public IButton? RightButton => Hardware.RightButton;
        public IPixelDisplay? Display => Hardware.Display;
        public string RevisionString => Hardware.RevisionString;

        public WaterMonitorHardwareBase()
        {
            Hardware = ProjectLab.Create();

            I2cBus = Hardware.Qwiic?.I2cBus;

            if (I2cBus != null)
            {
                try
                {
                    EnvironmentalSensor = new Bme688(I2cBus, (byte)Bme68x.Addresses.Address_0x76);
                }
                catch
                {
                    Logger?.Info("BME688 not available on this hardware.");
                }
            }
        }
    }
}
