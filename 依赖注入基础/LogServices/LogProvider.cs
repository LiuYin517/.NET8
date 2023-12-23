namespace LogServices;

public class LogProvider:ILogProvider
{
    public void LogError(string msg)
    {
        Console.WriteLine($"ERROR:{msg}");
    }

    public void Log(string msg)
    {
        Console.WriteLine($"Info:{msg}");
    }
}