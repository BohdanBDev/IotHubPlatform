using IoTConsole.Core.Contracts;
using IoTConsole.Sensors._Thermometer;

namespace IoTConsole.Sensors
{
    internal class Thermometer : IThermometer
    {
        public string Name => "Thermometer Sensor";

        public IOutputData GetValue()
        {
            return new ThermometerTelemetry(Name, Random.Shared.Next(-30, 80));
        }
    }
}