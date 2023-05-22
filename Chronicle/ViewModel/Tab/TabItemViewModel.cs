using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Chronicle;
using static Chronicle.DI;

namespace Chronicle
{
    /// <summary>
    /// View model for tab item control
    /// </summary>
    public class TabItemViewModel : BaseViewModel
    {
        /// <summary>
        /// The content associated with this tab
        /// </summary>
        private TabContentViewModel _tabContent;

        /// <summary>
        /// The unique tab ID for each tab item
        /// </summary>
        public Guid TabID { get; set; }

        /// <summary>
        /// Title of tab to display
        /// </summary>
        public string TabHeader { get; set; }

        /// <summary>
        /// True if tab is currently selected in the view
        /// Otherwise false
        /// </summary>
        public bool TabIsSelected { get; set; }

        /// <summary>
        /// The content associated with this tab
        /// </summary>
        public TabContentViewModel TabContent  
        {
            get { return _tabContent; }
            set
            {
                // If content hasn't changed
                if (_tabContent == value)
                    // Do nothing
                    return;

                // Set content to value
                _tabContent = value;

            }

        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public TabItemViewModel()
        {
            // Set properties defaults
            TabIsSelected = true;
            TabHeader = string.Empty;
            TabID = Guid.NewGuid();
            _tabContent = new TabContentViewModel();
            
            // Default header for new tab
            if (string.IsNullOrEmpty(_tabContent.Title))
                TabHeader = "Untitled";
            else
                TabHeader = _tabContent.Title;

            // Update properties
            OnPropertyChanged(nameof(TabHeader));
            OnPropertyChanged(nameof(TabIsSelected));
            OnPropertyChanged(nameof(TabContent));
            OnPropertyChanged(nameof(_tabContent));
        }

    }
}
