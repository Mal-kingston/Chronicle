using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// View model for the settings view
    /// </summary>
    public class SettingsPageViewModel : BaseViewModel
    {
        public string Label { get; set; } 

        public SettingsPageViewModel()
        {
            Label = "SETTINGS PAGE UNDER CONSTRUCTION";
        }
    }
}
