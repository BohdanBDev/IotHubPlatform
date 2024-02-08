using IoTConsole.Core.Contracts;
using IoTConsole.Output;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoTConsole.DI.Config
{
    internal static class OutputDiExtention
    {
        public static IServiceCollection AddOutputDi(this IServiceCollection services)
        {
            var config = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            
            services.AddScoped<IConsoleOutput, ConsoleOutput>();
            services.AddScoped<ITwinOutput, TwinOutput>();

            return services;
        }
    }
}