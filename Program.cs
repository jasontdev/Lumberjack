using Microsoft.Extensions.Configuration;
using Serilog;

class Program
{
    static void Main(string[] args)
    {
        var log = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        var arguments = new CommandLineArgs(args);

        if (arguments.ConfigFile != null)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
            .AddJsonFile(arguments.ConfigFile).Build();
            var testConfigs = config.GetSection("TestConfigs").Get<List<TestConfig>>();
            var tests = new List<Test>();

            if (testConfigs?.Count > 0)
            {
                foreach (TestConfig testConfig in testConfigs)
                {
                    if (testConfig.Type == "ListFiles")
                    {
                        var test = new FindFiles(testConfig.Target);
                        test.AddObserver(new LogEach(log));
                        tests.Add(test);
                    }
                }
            }
            else
            {
                log.Error("Failed to load TestConfigs");
            }

            foreach (Test test in tests)
            {
                test.Execute();
            }
        }
    }
}