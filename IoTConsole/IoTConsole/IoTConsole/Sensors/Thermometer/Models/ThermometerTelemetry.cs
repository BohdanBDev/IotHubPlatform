using IoTConsole.Core.Contracts;
using Newtonsoft.Json.Linq;

namespace IoTConsole.Sensors._Thermometer
{
    internal class ThermometerTelemetry : IOutputData
    {
        private string Name { get; set; }
        public int Temperature { get; private set; }

        public ThermometerTelemetry(string name, int temperature)
        {
            this.Name = name;
            this.Temperature = temperature;
        }

        public string AsString()
        {
            return $"{Name} >>> {Temperature}C";
        }
    }
}