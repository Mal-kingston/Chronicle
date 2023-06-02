using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// Facilitate logging of informations / messages
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Takes care of logging information as needed for the application
        /// </summary>
        /// <param name="message">The emessage to be logged</param>
        /// <param name="level">The level of the severity of the message being logged</param>
        void LogInformation(string message, LogLevel level);
    }
}
