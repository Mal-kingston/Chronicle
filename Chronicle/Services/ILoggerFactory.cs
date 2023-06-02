using System.Runtime.CompilerServices;

namespace Chronicle
{
    /// <summary>
    /// Contains a bunch of different loggers and logs message for the user
    /// </summary>
    public interface ILogFactory
    {
        /// <summary>
        /// Level of the severity of the message to log
        /// </summary>
        LogLevel LogLevel { get; set; }

        /// <summary>
        /// Adds the given logger to log factory
        /// </summary>
        /// <param name="logger">The logger to add</param>
        void AddLogger(ILogger logger);

        /// <summary>
        /// Removes the given logger from log factory
        /// </summary>
        /// <param name="logger">The logger to remove</param>
        void RemoveLogger(ILogger logger);

        /// <summary>
        /// Logs message to all loggers in this factory
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="level">The level of the message to log</param>
        /// <param name="filePath">The name of the code file that this message was logged from</param>
        /// <param name="origin">The function this message is in</param>
        /// <param name="lineNumber">The line number in the code file to where this message was logged from</param>
        void Log(string message, LogLevel level = LogLevel.Information, [CallerFilePath]string filePath = "", [CallerMemberName] string origin = "", [CallerLineNumber]int lineNumber = 0);
    }
}
