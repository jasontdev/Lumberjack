public class ProgramConfig
{
    public required string scriptRoot { get; set; }
    public required ScriptConfig[] scripts { get; set; }
    public required bool prefixHostname { get; set; }
    public required string logPath { get; set; }
}


public class ScriptConfig
{
    public required string id { get; set; }
    public required string file { get; set; }
    public required string msgPrefix { get; set; }
    public required string outputType { get; set; }
}