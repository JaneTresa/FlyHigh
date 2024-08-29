using FlyHigh.Interfaces;

namespace FlyHigh.Services
{
    public class LoggerService : ILoggerService
    {
        public static object _lock = new();
        public readonly string _logFilePath;
        public LoggerService() 
        {
            _logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "log.txt");
        }

        public void Log(string message)
        {
            lock (_lock)
            {
                try
                {
                    var logDirectory = Path.GetDirectoryName(_logFilePath);
                    if (!Directory.Exists(logDirectory))
                    {
                        Directory.CreateDirectory(logDirectory);
                    }

                    if (!File.Exists(_logFilePath))
                    {
                        using (StreamWriter sw = File.CreateText(_logFilePath))
                        {
                            sw.WriteLine(message);
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(_logFilePath))
                        {
                            sw.WriteLine(message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error writing to log file: {ex.Message}");
                }
            }
        }
    }
}
