interface Test
{
    void AddObserver(TestObserver observer);
    void Execute();
}

class FindFiles : Test
{
    private readonly string path;
    private readonly int hoursOld;
    private readonly bool recursive;
    private readonly string parent;
    private readonly string extension;
    private List<TestObserver> observers = new List<TestObserver>();

    public FindFiles(String path,
                     int hoursOld = 0,
                     Boolean recursive = false,
                     String parent = "",
                     String extension = "")
    {
        this.path = path;
        this.hoursOld = hoursOld;
        this.recursive = recursive;
        this.parent = parent;
        this.extension = extension;
    }

    public void AddObserver(TestObserver observer)
    {
        observers.Add(observer);
    }

    public void Execute()
    {
        var results = new List<string>();

        if (extension.Length > 0)
        {
            if (recursive)
            {
                results = Directory.EnumerateFiles(path, $"*.{extension}", searchOption: SearchOption.AllDirectories).ToList();
            }
            else
            {
                results = Directory.EnumerateFiles(path, $"*.{extension}").ToList();
            }
        }
        else
        {
            if (recursive)
            {
                results = Directory.EnumerateFiles(path, "*", searchOption: SearchOption.AllDirectories).ToList();
            }
            else
            {
                results = Directory.EnumerateFiles(path, "*").ToList();
            }
        }

        if (parent.Length > 0)
        {
            results = results.Where(file => new FileInfo(file).Directory?.Name == parent).ToList();
        }

        if (hoursOld > 0)
        {
            results = results.Where(file => new FileInfo(file).LastWriteTime < DateTime.Now.AddHours(-hoursOld)).ToList();
        }

        foreach (TestObserver observer in observers)
        {
            observer.Update(results);
        }
    }
}