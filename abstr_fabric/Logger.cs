public interface ILogger
{
    void Log(string message, LogLevel level);
}

public class FormattedLogger : ILogger
{
    public void Log(string message, LogLevel level)
    {
        string formattedMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
        Console.WriteLine(formattedMessage);
    }
}

public class ColoredLogger : ILogger
{
    private static Dictionary<LogLevel, ConsoleColor> colors = new Dictionary<LogLevel, ConsoleColor>
    {
        { LogLevel.Debug, ConsoleColor.Gray },
        { LogLevel.Info, ConsoleColor.Green },
        { LogLevel.Error, ConsoleColor.Red }
    };

    public void Log(string message, LogLevel level)
    {
        ConsoleColor originalColor = Console.ForegroundColor;
        Console.ForegroundColor = colors[level];
        Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}");
        Console.ForegroundColor = originalColor;
    }
}

public enum LoggerType
{
    Formatted,
    Colored
}

public static class LoggerFactory
{
    public static ILogger CreateLogger(LoggerType type)
    {
        switch (type)
        {
            case LoggerType.Formatted:
                return new FormattedLogger();
            case LoggerType.Colored:
                return new ColoredLogger();
            default:
                throw new ArgumentException("Invalid logger type");
        }
    }
}

public enum LogLevel
{
    Debug,
    Info,
    Error
}