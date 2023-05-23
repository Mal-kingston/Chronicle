using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Windows.Input;
using System.Windows.Threading;
using static Chronicle.DI;

namespace Chronicle
{
    /// <summary>
    /// View model for tab control
    /// </summary>
    public class TabControlViewModel : BaseViewModel
    {
        /// <summary>
        /// Collection of tabs 
        /// </summary>
        private ObservableCollection<TabItemViewModel>? _tabs;

        /// <summary>
        /// Content of the tabs
        /// </summary>
        private TabContentViewModel _tabContent;

        #region Public Properties

        /// <summary>
        /// Collection of tabs 
        /// </summary>
        public ObservableCollection<TabItemViewModel>? Tabs 
        {
            get { return _tabs; }
            set
            {
                // If value hasn't changed...
                if (_tabs == value)
                    // Do nothing
                    return;

                // Set value
                _tabs = value;
            }
        }

        /// <summary>
        /// Each tab item
        /// </summary>
        public TabItemViewModel TabItem { get; set; }

        /// <summary>
        /// Content of the tabs
        /// </summary>
        public TabContentViewModel TabContent 
        {
            get { return _tabContent; } 
            set
            {
                // If content is the same...
                if(_tabContent == value) 
                    // Do nothing 
                    return;

                // Set value
                _tabContent = value;

                // Update content
                OnPropertyChanged(nameof(TabContent));
            }
        }

        #endregion

        #region Public Commands

        /// <summary>
        /// Command to add a new tab to tab collection
        /// </summary>
        public ICommand? AddNewTabCommand { get; set; }

        /// <summary>
        /// Command to remove tab from tab collection
        /// </summary>
        public ICommand CloseTabCommand { get; set; }

        /// <summary>
        /// Command to select a specific tab item
        /// </summary>
        public ICommand SelectTabCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TabControlViewModel()
        {
            // Set properties default
            TabItem = new TabItemViewModel();
            _tabs = new ObservableCollection<TabItemViewModel>
            {
                // Default tab item
                TabItem
            };

            // Set tab content
            _tabContent = TabItem.TabContent;
            
            // Create commands
            AddNewTabCommand = new RelayCommand(AddNewTab);
            CloseTabCommand = new ParameterizedRelayCommand((parameter) => CloseTab(parameter));
            SelectTabCommand = new ParameterizedRelayCommand((parameter) => SelectTab(parameter));

            // Update properties
            OnPropertyChanged(nameof(Tabs));
            OnPropertyChanged(nameof(_tabs));
            OnPropertyChanged(nameof(TabContent));
            OnPropertyChanged(nameof(_tabContent));
            OnPropertyChanged(nameof(TabItem));
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Add new tab to the collection
        /// </summary>
        private void AddNewTab()
        {
            // Make sure tab isn't null
            if (Tabs == null)
                return;

            // TODO: handle opening unlimited tabs
            if (Tabs?.Count == 4)
                return;

            // Reset selection
            Tabs?.ToList().ForEach(item => item.TabIsSelected = false);

            // Add new tab
            Tabs?.Add(new TabItemViewModel
            {
                TabIsSelected = true,
                TabID = Guid.NewGuid(),
                TabContent = new TabContentViewModel(),
            });

            // Update tab content
            UpdateTabContent();
        }

        /// <summary>
        /// Remove tab from the collection
        /// </summary>
        /// <param name="parameter">The specific unique tab header of the tab to be removed / closed</param>
        private void CloseTab(object parameter)
        {
            // Do not close the default tab
            if (Tabs?.Count == 1)
                return;

            // Make sure we have items
            if (Tabs == null)
                return;

            // Go through items in the collections...
            foreach (var item in Tabs)
            {
                // If tab ID matched... and item being closed is selected
                if (item.TabID == (Guid)parameter && item.TabIsSelected == true)
                    // Set new selection to the last tab added to the collection
                    Tabs[Tabs.Count - 2].TabIsSelected = true;
            }

            // Close tab
            Tabs?.Remove(Tabs.Where(item => item.TabID == (Guid)parameter).Single());

        }

        /// <summary>
        /// Selects a specific tab item
        /// </summary>
        /// <param name="parameter">Unique header of the tab item to select</param>
        private void SelectTab(object parameter)
        {
            // Make sure we have tabs
            if (Tabs == null)
                return;

            // Reset selection
            Tabs.ToList().ForEach(item => item.TabIsSelected = false);

            // For every tabs in the collection
            foreach (var item in Tabs)
            {
                // If tab header match
                if (item.TabID == (Guid)parameter)
                {
                    // Set new selection 
                    item.TabIsSelected = true;
                }
            }

            // Update tab content
            UpdateTabContent();
        }

        /// <summary>
        /// Updates the view with the current content of the tab selected
        /// </summary>
        public void UpdateTabContent()
        {
            // Go through all tabs in the collection...
            foreach (var item in Tabs!)
            {
                // If tab is selected...
                if (item.TabIsSelected == true)
                {
                    // Set it's content to the view
                    _tabContent = item.TabContent;

                    // Update UI
                    OnPropertyChanged(nameof(TabContent));
                }
            }
        }

        #endregion
    }
}
