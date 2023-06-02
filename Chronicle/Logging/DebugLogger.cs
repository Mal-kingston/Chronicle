using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// Logs messages to debug log
    /// </summary>
    public class DebugLogger : ILogger
    {
        /// <summary>
        /// Takes care of logging information as needed for the application
        /// </summary>
        /// <param name="message">The emessage to be logged</param>
        /// <param name="level">The level of the severity of the message being logged</param>
        public void LogInformation(string message, LogLevel level)
        {
            // The default category
            var category = default(string);

            // Color console based on level
            switch (level)
            {
                // Debug
                case LogLevel.Debug:
                    category = "debug";
                    break;

                // Verbose
                case LogLevel.Information:
                    category = "information";
                    break;

                // Warning
                case LogLevel.Warning:
                    category = "warning";
                    break;

                // Error
                case LogLevel.Error:
                    category = "error";
                    break;

                // Success
                case LogLevel.None:
                    category = "-----";
                    break;
            }

            // Write message to console
            Debug.WriteLine(message, category);
        }
    }
}
