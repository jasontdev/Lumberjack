// See https://aka.ms/new-console-template for more information
using Serilog;

class Program
{
    static void Main()
    {
        var log = new LoggerConfiguration().WriteTo.Console().CreateLogger();

        // TODO: load config
        // TODO: build Test[]
        // TODO: execute Test[]
    }
}