using System;
using System.IO;
using UserProfile.Application.Logging;


namespace UserProfile.Data.Utilities
{
    public class FileLogger : ILogger
    {
        private readonly string _logFile;

        public FileLogger(string logFilePath)
        {
            _logFile = logFilePath;
        }

        private void Write(string level, string message)
        {
            var line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
            File.AppendAllLines(_logFile, new[] { line });
        }

        public void Info(string message) => Write("INFO", message);
        public void Warn(string message) => Write("WARN", message);
        public void Error(string message) => Write("ERROR", message);
        public void Error(string message, Exception ex)
            => Write("ERROR", $"{message} | Exception: {ex}");
    }
}
