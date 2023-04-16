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
    /// View model for tab control
    /// </summary>
    public class TabControlViewModel : BaseViewModel
    {
        /// <summary>
        /// List of tabs 
        /// </summary>
        public ObservableCollection<TabItemViewModel>? Items { get; set; }

        /// <summary>
        /// Command to add a new tab
        /// </summary>
        public ICommand? AddNewTabCommand { get; set; }

        public TabControlViewModel()
        {
            AddNewTabCommand = new RelayCommand(AddNewTab);
        }

        private void AddNewTab()
        {
            Items?.Add(new TabItemViewModel { TabHeader = "Untitled" });
        }
    }
}
