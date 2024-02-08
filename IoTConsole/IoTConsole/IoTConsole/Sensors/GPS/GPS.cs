using IoTConsole.Core.Contracts;
using IoTConsole.Sensors._GPS;

namespace IoTConsole.Sensors
{
    internal class GPS : IGPS
    {
        public string Name => "GPS Sensor";

        public IOutputData GetValue()
        {
            return new GpsTelemetry(Name, Random.Shared.Next(-90, 90), Random.Shared.Next(-180, 180));
        }
    }
}