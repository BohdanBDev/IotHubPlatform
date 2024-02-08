using IoTConsole.Core.Contracts;
using IoTConsole.Sensors._GPS;
using IoTConsole.Sensors._Thermometer;
using Microsoft.Azure.Devices.Client;  
using Microsoft.Azure.Devices.Shared;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace IoTConsole.Output
{
    internal interface ITwinOutput: IOutput {}

    internal class TwinOutput : ITwinOutput
    {
        private DeviceClient Client = null;
        
        public TwinOutput(IConfiguration configuration)
        {
            Client = DeviceClient.CreateFromConnectionString(configuration.GetValue<string>("DeviceConnectionString"), TransportType.Mqtt);
        }

        public void Print(IOutputData data)
        {
            TwinCollection reportedProperties, connectivity, sensorData;

            reportedProperties = new TwinCollection();
            connectivity = new TwinCollection();
            sensorData = new TwinCollection();

            if (data is ThermometerTelemetry)
            {
                var _tempData = data as ThermometerTelemetry;
                sensorData["Temperature"] = _tempData.Temperature;

            }
            else if (data is GpsTelemetry)
            {
                var _gpsData = data as GpsTelemetry;
                sensorData["Longtitude"] = _gpsData.Longitude;
                sensorData["Latitude"] = _gpsData.Latitude;
            } // mapper improving

            reportedProperties["sensors"] = sensorData;
            Client.UpdateReportedPropertiesAsync(reportedProperties);
        }
    }    
}