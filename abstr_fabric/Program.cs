public class Program
{
    public static void Main(string[] args)
    {
        ILogger logger = LoggerFactory.CreateLogger(LoggerType.Formatted);
        logger.Log("This is a debug message", LogLevel.Debug);
        logger.Log("This is an info message", LogLevel.Info);
        logger.Log("This is an error message", LogLevel.Error);

        logger = LoggerFactory.CreateLogger(LoggerType.Colored);
        logger.Log("This is a debug message", LogLevel.Debug);
        logger.Log("This is an info message", LogLevel.Info);
        logger.Log("This is an error message", LogLevel.Error);

        Console.ReadLine();
    }
}