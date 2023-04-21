using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
        #region Public Properties

        /// <summary>
        /// List of tabs 
        /// </summary>
        public ObservableCollection<TabItemViewModel>? Items { get; }

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
                // Default dummy tab item
                new TabItemViewModel
                {
                    TabHeader = "Untitled",
                    IsSelected = true,
                }
            };

            // Create commands
            AddNewTabCommand = new RelayCommand(AddNewTab);
            CloseTabCommand = new ParameterizedRelayCommand((parameter) => CloseTab(parameter));
            SelectTabCommand = new ParameterizedRelayCommand((parameter) => SelectTab(parameter));

            // Update properties
            OnPropertyChanged(nameof(Items));
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

            // Add new tab
            Items?.Add(new TabItemViewModel { TabHeader = $"Untitled-{Items.Count}" });
        }

        /// <summary>
        /// Remove tab from the collection
        /// </summary>
        /// <param name="parameter">The specific unique tab header of the tab to be removed / closed</param>
        private void CloseTab(object parameter)
        {
            // Close tab
            Items?.Remove(Items.Where(item => item.TabHeader == parameter.ToString()).Single());
        }

        /// <summary>
        /// Selects a specific tab item
        /// </summary>
        /// <param name="parameter">Unique header of the tab item to select</param>
        private void SelectTab(object parameter)
        {

            if (Items == null)
                return;

            foreach(var item in Items)
            {
                if(item.TabHeader == parameter.ToString())
                    item.IsSelected = true;
                else
                    item.IsSelected = false;
            }
        }

        #endregion
    }
}
