using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// The configuration of this application
    /// </summary>
    public class AppConfiguration
    {
        /// <summary>
        /// The actual configuration
        /// </summary>
        public Configuration AppConfig { get; set; }

        /// <summary>
        /// A single instance of this object
        /// </summary>
        public static AppConfiguration Instance => new AppConfiguration();

        /// <summary>
        /// Default constructor
        /// </summary>
        public AppConfiguration()
        {
            // Set configuration level
            AppConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // If we have no configuration...
            if (AppConfig.Sections["AppSettings"] == null)
                // Add / Create configuration
                AppConfig.Sections.Add("AppSettings", new AppSettings());
        }
    }
}
