
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace Chronicle
{
    /// <summary>
    /// Contains a bunch of different loggers and logs message for the user
    /// </summary>
    public class LogFactory : ILogFactory
    {
        /// <summary>
        /// The list of loggers contained in this log factory
        /// </summary>
        protected List<ILogger> _loggers;

        /// <summary>
        /// Level of the severity of the message to log
        /// </summary>
        public LogLevel LogLevel { get; set; }

        public LogFactory(ILogger[] loggers = null!)
        {
            // Initialize fields
            _loggers = new List<ILogger>();

            // Add debug logger by default
            AddLogger(new DebugLogger());

            // Add any others passed in
            if (loggers != null)
                foreach (var logger in loggers)
                    AddLogger(logger);
        }

        /// <summary>
        /// Adds the given logger to log factory
        /// </summary>
        /// <param name="logger">The logger to add</param>
        public void AddLogger(ILogger logger)
        {
            // If the given logger is not in the logger factory yet...
            if(!_loggers.Contains(logger))
                // Add it to the factory
                _loggers.Add(logger);
        }

        /// <summary>
        /// Removes the given logger from log factory
        /// </summary>
        /// <param name="logger">The logger to remove</param>
        public void RemoveLogger(ILogger logger)
        {
            // If the given logger is in the logger factory ...
            if (_loggers.Contains(logger))
                // Remove it from the factory
                _loggers.Remove(logger);
        }

        /// <summary>
        /// Logs message to all loggers in this factory
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="level">The level of the message to log</param>
        /// <param name="filePath">The name of the code file that this message was logged from</param>
        /// <param name="origin">The function this message is in</param>
        /// <param name="lineNumber">The line number in the code file to where this message was logged from</param>
        public void Log(string message, LogLevel level = LogLevel.Information, [CallerFilePath] string filePath = "", [CallerMemberName] string origin = "", [CallerLineNumber] int lineNumber = 0)
        {
            // Format message
            message = $"{message} > [{Path.GetFileName(filePath)}] > {origin}() > Line : {lineNumber} {Environment.NewLine}";

            // Send out message to all loggers in the factory
            _loggers.ForEach(logger => logger.LogInformation(message, level));
        }

    }
}
