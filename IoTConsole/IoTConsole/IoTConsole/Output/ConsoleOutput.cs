using IoTConsole.Core.Contracts;

namespace IoTConsole.Output
{
    internal interface IConsoleOutput: IOutput { }
    internal class ConsoleOutput : IConsoleOutput
    {
        public void Print(IOutputData data)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(data.AsString());

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("##############");
        }
    }
}