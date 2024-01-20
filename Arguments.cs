public class CommandLineArgs
{
    static void ShowHelp()
    {
        Console.WriteLine("Usage: Lumberjack [options]:\n");
        Console.WriteLine("  Options:");
        Console.WriteLine("    -c, --config\t Config filepath\n");
    }

    public string? ConfigFile { get; set; }

    public CommandLineArgs(string[] args)
    {
        if (args.Length > 1)
        {
            if (args[0] == "-c" || args[0] == "--config")
            {
                try
                {
                    ConfigFile = System.IO.Path.GetFullPath(args[1]);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                ShowHelp();
            }
        }
        else
        {
            ShowHelp();
        }
    }
}