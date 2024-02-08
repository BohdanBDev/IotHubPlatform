using IoTConsole.Core.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace IoTConsole.Core.App
{
    internal class IoTApp: IIoTApp
    {
        private List<ISensor> _sensors;
        private List<IOutput> _outputs;


        private IConfiguration _configuration;
        private IServiceProvider _serviceProvider;
        private Timer _timer;

        public IoTApp(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _configuration = configuration;
            _serviceProvider = serviceProvider;

            _sensors = new List<ISensor>();
            _outputs = new List<IOutput>();
        }

        public IIoTApp AddSensor<T>() where T : ISensor
        {
            if (_sensors.Any(s => nameof(s) == nameof(T)))
                return this;

            using var services = _serviceProvider.CreateScope();
            var sensor = services.ServiceProvider.GetRequiredService<T>();

            _sensors.Add(sensor);

            return this;
        }

        public IIoTApp AddOutput<T>() where T : IOutput
        {
            if (_outputs.Any(s => nameof(s) == nameof(T)))
                return this;

            using var services = _serviceProvider.CreateScope();
            var output = services.ServiceProvider.GetRequiredService<T>();

            _outputs.Add(output);

            return this;
        }

        public IIoTApp Run()
        {
            _timer = new Timer((obj) =>
            {
                _sensors.ForEach(sensor =>
                {
                    _outputs.ForEach(output =>
                    {
                        output.Print(sensor.GetValue());
                    });
                });
            }, null, 3000, _configuration.GetValue<int>("PollingFrequency"));

            return this;
        }
    }
}