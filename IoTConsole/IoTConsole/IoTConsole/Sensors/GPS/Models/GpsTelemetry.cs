using IoTConsole.Core.Contracts;
using Microsoft.Azure.Devices.Shared;
using Newtonsoft.Json.Linq;

namespace IoTConsole.Sensors._GPS
{
    internal class GpsTelemetry : IOutputData
    {
        private string Name { get; set; }
        public int Latitude { get; private set; }
        public int Longitude { get; private set; }

        public GpsTelemetry(string name, int latitude, int longitude)
        {
            this.Name = name;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public string AsString()
        {
            return $"{Name} >>> {Latitude}:{Longitude}";
        }
    }
}