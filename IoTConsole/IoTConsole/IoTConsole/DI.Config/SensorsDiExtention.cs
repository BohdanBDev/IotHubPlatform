using IoTConsole.Sensors;
using IoTConsole.Sensors._GPS;
using IoTConsole.Sensors._Thermometer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoTConsole.DI.Config
{
    internal static class SensorsDiExtention
    {
        public static IServiceCollection AddSensorsDi(this IServiceCollection services)
        {
            var config = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

            services.AddScoped<IGPS, GPS>();
            services.AddScoped<IThermometer, Thermometer>();

            return services;
        }
    }
}