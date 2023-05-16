using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows.Input;
using static Chronicle.DI;

namespace Chronicle
{
    /// <summary>
    /// View model for tab control
    /// </summary>
    public class TabControlViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// List of tabs 
        /// </summary>
        public ObservableCollection<TabItemViewModel>? Items { get; set; }

        /// <summary>
        /// Unique identification for each tab in the collection
        ///         NOTE: Use GUID
        /// </summary>
        public int TabId { get; set; }

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
            Items = new ObservableCollection<TabItemViewModel>
            {
                // Default tab item
                new TabItemViewModel()
            };

            TabId = 1;


            // Create commands
            AddNewTabCommand = new RelayCommand(AddNewTab);
            CloseTabCommand = new ParameterizedRelayCommand((parameter) => CloseTab(parameter));
            SelectTabCommand = new ParameterizedRelayCommand((parameter) => SelectTab(parameter));

            // Update properties
            OnPropertyChanged(nameof(Items));
            OnPropertyChanged(nameof(TabId));
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Add new tab to the collection
        /// </summary>
        private void AddNewTab()
        {
            if (Items?.Count == 4)
                return;

            // Reset selection
            Items?.ToList().ForEach(item => item.TabIsSelected = false);

            //TODO: Update id properly when item is removed or added
            TabId = TabId + 1;
            

            // Add new tab
            Items?.Add(new TabItemViewModel
            {
                TabHeader = $"Untitled-{TabId}",
                TabIsSelected = true,
            });
        }

        /// <summary>
        /// Remove tab from the collection
        /// </summary>
        /// <param name="parameter">The specific unique tab header of the tab to be removed / closed</param>
        private void CloseTab(object parameter)
        {
            if (Items?.Count == 1)
                return;

            // Close tab
            Items?.Remove(Items.Where(item => item.TabHeader == parameter.ToString()).Single());

            //TODO:  Update untitled tab header sequence


            /* TODO: Keep track of the history of tab selection 
                     and select the most recently selected, when a currently selected tab is closed
            
            Select the default tab for now   */
            foreach (var item in Items)
            {
                // If tab header match
                if (item.TabHeader == "Untitled")
                    // Set new selection
                    item.TabIsSelected = true;
            }

        }

        /// <summary>
        /// Selects a specific tab item
        /// </summary>
        /// <param name="parameter">Unique header of the tab item to select</param>
        private void SelectTab(object parameter)
        {
            // Make sure we have tabs
            if (Items == null)
                return;

            // Reset selection
            Items.ToList().ForEach(item => item.TabIsSelected = false);

            // For every tabs in the collection
            foreach (var item in Items)
            {
                // If tab header match
                if (item.TabHeader == parameter.ToString())
                    // Set new selection
                    item.TabIsSelected = true;
            }

            // switch between different tabs and set their view models

        }

        #endregion
    }
}
