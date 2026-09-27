using Meadow.Foundation.Sensors.Atmospheric;
using Meadow.Peripherals.Displays;
using Meadow.Peripherals.Sensors.Buttons;
using Meadow.Peripherals.Sensors.Distance;

namespace RainWaterMonitor.Hardware
{
    // 2.x adaptation: the original (net9-era) interface extended IProjectLabHardware and the
    // base class inherited ProjectLab. In the released 2.x packages, ProjectLab is a static
    // factory (ProjectLab.Create()), so the hardware is composed instead and only the members
    // this app actually uses are surfaced here.
    public interface IWaterMonitorHardware
    {
        IRangeFinder? DistanceSensor { get; }
        Bme688? EnvironmentalSensor { get; }
        IButton? UpButton { get; }
        IButton? DownButton { get; }
        IButton? LeftButton { get; }
        IButton? RightButton { get; }
        IPixelDisplay? Display { get; }
        string RevisionString { get; }
    }
}
