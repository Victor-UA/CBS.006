using System;

namespace CBS._006.Launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading external libraries...");
            CommandProcessor.LoadLibraries();
            Console.WriteLine($"{CommandProcessor.LibrariesCount} external libraries were loaded.");
            Console.WriteLine($"Executing {CommandName}...");
            CommandProcessor.ProcessCommand(CommandName);
            Console.WriteLine($"{CommandName} were executed");
            Console.ReadKey();
        }
        private static string CommandName => "Class1";
    }
}
