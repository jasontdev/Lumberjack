// See https://aka.ms/new-console-template for more information
using Serilog;

class Program
{
    static void Main(string[] args)
    {
        var log = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        var arguments = new CommandLineArgs(args);

        if (arguments.ConfigFile != null)
        {
            // load config
        }
    }
}