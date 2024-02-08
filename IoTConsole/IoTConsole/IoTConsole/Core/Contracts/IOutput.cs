using Newtonsoft.Json.Linq;

namespace IoTConsole.Core.Contracts
{
    internal interface IOutputData 
    {
        string AsString();
    }

    internal interface IOutput
    {
        void Print(IOutputData data);
    }
}