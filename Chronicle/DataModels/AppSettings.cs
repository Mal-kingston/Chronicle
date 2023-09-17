using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// The configuartion data about this application to save
    /// </summary>
    public class AppSettings : ConfigurationSection
    {
        /// <summary>
        /// The theme 
        /// </summary>
        [ConfigurationProperty("Theme", DefaultValue = ThemeKind.DarkTheme)]
        public ThemeKind? Theme 
        {
            get { return (ThemeKind)this["Theme"]; }
            set { this["Theme"] = value; }
        }

        /// <summary>
        /// Tab content template
        /// </summary>
        [ConfigurationProperty("Template", DefaultValue = TabContentTemplates.Plain)]
        public TabContentTemplates? Template 
        {
            get { return (TabContentTemplates)this["Template"]; }
            set { this["Template"] = value; }
        }

    }
}
