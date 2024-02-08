using IoTConsole.Core.Contracts;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTConsole.Core.App
{
    internal interface IIoTApp
    {
        IIoTApp AddSensor<T>() where T: ISensor;
        IIoTApp AddOutput<T>() where T : IOutput;
        IIoTApp Run();
    }
}