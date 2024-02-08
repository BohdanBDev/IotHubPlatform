using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTConsole.Core.Contracts
{
    internal interface ISensor
    {
        string Name { get; }
        IOutputData GetValue();
    }
}