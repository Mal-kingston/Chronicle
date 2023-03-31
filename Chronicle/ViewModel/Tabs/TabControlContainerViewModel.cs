using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chronicle
{
    /// <summary>
    /// View model for container of tab control
    /// </summary>
    public class TabControlContainerViewModel : BaseViewModel
    {
        /// <summary>
        /// List of tabs 
        /// </summary>
        public ObservableCollection<TabControlViewModel>? Items { get; set; }

        /// <summary>
        /// Command to add a new tab
        /// </summary>
        public ICommand? AddTabCommand { get; set; }
    }
}
