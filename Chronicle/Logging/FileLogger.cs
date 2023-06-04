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
            var logDateAndTime = DateTimeOffset.Now.ToString("hh:mm:ss MM-dd-yyyy");

            FileManager.WriteTextToFile($"[{level}] : [{logDateAndTime}] {message}", FilePath);
        }
    }
}
