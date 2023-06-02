using System;
using static Chronicle.DI;

namespace Chronicle
{
    public class FileLogger : ILogger
    {
        public string FilePath { get; set; }

        public FileLogger(string filePath)
        {
            // Set properties
            FilePath = filePath;
        }

        public void LogInformation(string message, LogLevel level)
        {
            // Use current time to log the message
            var logTime = DateTimeOffset.Now.ToString("MM-dd-yyyyy");

            FileManager.WriteTextToFile($"[{level}] : [{logTime}] {message}", FilePath);
        }
    }
}
