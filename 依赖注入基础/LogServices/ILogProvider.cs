namespace LogServices;

public interface ILogProvider
{
    public void LogError(string msg);

    public void Log(string msg);
}