using System;

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
        /// True if tab is currently selected in the view
        /// Otherwise false
        /// </summary>
        public bool TabIsSelected { get; set; }

        /// <summary>
        /// Flag indicating if this item is in recycle bin
        /// </summary>
        public bool IsInRecycle { get; set; } = false;

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

                // Update tabcontent
                OnPropertyChanged(nameof(TabContent));
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public TabItemViewModel()
        {
            // Set properties defaults
            TabIsSelected = true;
            TabID = Guid.NewGuid();
            _tabContent = new TabContentViewModel();
            _tabContent.Template = DI.TabContentVM.Template;

            // Update properties
            OnPropertyChanged(nameof(TabIsSelected));
            OnPropertyChanged(nameof(TabContent));
            OnPropertyChanged(nameof(_tabContent));
        }

    }
}
