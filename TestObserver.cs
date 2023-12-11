interface TestObserver
{
    void Update(List<string> output);
}

class GetFileObjects : TestObserver
{
    private Serilog.Core.Logger log;

    public GetFileObjects(Serilog.Core.Logger logger)
    {
        log = logger;
    }
    public void Update(List<string> output)
    {
        foreach (string file in output)
        {
            log.Warning(file);
        }
    }
}