using Meadow;
using Meadow.Devices;
using Meadow.Foundation.Sensors.Distance;
using Meadow.Gateways.Bluetooth;

namespace RainWaterMonitor.Hardware
{
    public class LabProtoWaterMonitorHardware : WaterMonitorHardwareBase
    {
        public LabProtoWaterMonitorHardware() : base()
        {
                        //---- instantiate the distance sensor
            Logger?.Info("Instantiating distance sensor.");
            DistanceSensor = new MaxBotix(Resolver.Device, Resolver.Device.PlatformOS.GetSerialPortName("COM1"), MaxBotix.SensorType.XL);
            Logger?.Info("Distance sensor up.");
        }
    }
}
