using IoTConsole.Core.App;
using IoTConsole.DI.Config;
using IoTConsole.Output;
using IoTConsole.Sensors._GPS;
using IoTConsole.Sensors._Thermometer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
// jobject


internal class Program
{ 

    private static async Task Main(string[] args)
    {
        using IHost host = Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
        {
            services.AddScoped<IIoTApp, IoTApp>();
            services.AddSensorsDi();
            services.AddOutputDi();
        }).ConfigureAppConfiguration(config =>
        {
            config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .AddCommandLine(args)
            .Build();
        }).Build();



        var app = host.Services.GetRequiredService<IIoTApp>()
            .AddSensor<IGPS>()
            .AddSensor<IThermometer>()
            .AddOutput<IConsoleOutput>()
            .AddOutput<ITwinOutput>()
            .Run();

        await host.RunAsync();
    }


    // private static async void InitClient()
    // {
    //     try
    //     {
    //         Console.WriteLine("Connecting to hub");
    //         Client = DeviceClient.CreateFromConnectionString(DeviceConnectionString, TransportType.Mqtt);
    //         Console.WriteLine("Retrieving twin");
    //         await Client.GetTwinAsync();
    //     }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine();
    //         Console.WriteLine("Error in sample: {0}", ex.Message);
    //     }
    // }



    // public static async void ReportConnectivity()  
    // {  
    //     try  
    //     {  
    //         Console.WriteLine("Sending connectivity data as reported property");  

    //         TwinCollection reportedProperties, connectivity;  
    //         reportedProperties = new TwinCollection();  
    //         connectivity = new TwinCollection();  
    //         connectivity["type"] = "cellular";
    //         reportedProperties["connectivity"] = connectivity;
    //         await Client.UpdateReportedPropertiesAsync(reportedProperties);  
    //     }  
    //     catch (Exception ex)  
    //     {  
    //         Console.WriteLine();
    //         Console.WriteLine("Error in sample: {0}", ex.Message);  
    //     }  
    // }  
}