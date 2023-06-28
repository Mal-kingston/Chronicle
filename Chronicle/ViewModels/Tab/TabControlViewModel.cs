using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
        #region Private Fields

        /// <summary>
        /// Collection of tabs 
        /// </summary>
        private ObservableCollection<TabItemViewModel>? _tabs;

        /// <summary>
        /// Content of the tabs
        /// </summary>
        private TabContentViewModel _tabContent;

        #endregion

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
                UpdateTabContent();
            }
        }

        /// <summary>
        /// Each tab item
        /// </summary>
        public TabItemViewModel TabItem { get; set; }

        /// <summary>
        /// The context menu to allow saving, sharing, printing of files
        /// as well as other functions
        /// </summary>
        public ContextMenuViewModel ContextMenu { get; set; }

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

            // Wire tab features
            _tabContent = TabItem.TabContent;
            ContextMenu = _tabContent.ContextMenu;

            // Create commands
            AddNewTabCommand = new RelayCommand(AddNewTab);
            CloseTabCommand = new ParameterizedRelayCommand((parameter) => CloseTab(parameter));
            SelectTabCommand = new ParameterizedRelayCommand((parameter) => SelectTab(parameter));

            // Transactional data store commands
            _tabContent.ContextMenu.SaveCommand = new RelayCommand(async () => await Save());

            // Update properties
            OnPropertyChanged(nameof(Tabs));
            OnPropertyChanged(nameof(_tabs));
            OnPropertyChanged(nameof(TabContent));
            OnPropertyChanged(nameof(_tabContent));
            OnPropertyChanged(nameof(TabItem));
        }

        

        #endregion

        #region Transactional Data Store Commands

        /// <summary>
        /// Saves a tab content to the data store
        /// </summary>
        public async Task Save()
        {
            // If we don't have anything to save...
            if (string.IsNullOrEmpty(_tabContent.Content) || TabItem?.TabID == null)
            {
                // Close context menu
                _tabContent.IsContextMenuOpen = false;

                // Do nothing
                return;
            }

            // TODO: If content doesn't have title or user want to save note with a specific name
            //       Invoke prompt window to give user the ability to enter desired name for the file before saving to database.

            // Save note data to database
            await ClientDataStore.SaveFile(new NoteDataModel
            {
                // TODO: Remeber template of note
                // Note data | Id | Header | Title | Content |
                Id = TabItem.TabID,
                Header = _tabContent.Header,
                Title = _tabContent.Title,
                Content = _tabContent.Content,
            });

            // Log data
            Logger.Log("Note information saved to database");

            // Update UI list 
            SubMenuVM.UpdateNoteList();

            // Close context menu
            _tabContent.IsContextMenuOpen = false;

            // TODO: notify user in the UI that file has been saved
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Add new tab to the collection
        /// </summary>
        public void AddNewTab()
        {
            // Make sure tab isn't null
            if (_tabs == null)
                return;

            // TODO: handle opening unlimited tabs
            if (_tabs?.Count == 4)
                return;

            // Reset selection
            _tabs?.ToList().ForEach(item => item.TabIsSelected = false);

            // Add new tab
            _tabs?.Add(new TabItemViewModel
            {
                // Set defaults
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
        public void CloseTab(object parameter)
        {
            // Do not close the default tab
            if (Tabs?.Count == 1)
                return;

            // Make sure we have items
            if (Tabs == null)
                return;

            // Status of selection of closing tab
            // (true if currently selected at the time of closing... false otherwise).
            var IsClosingTabSelected = false;

            // Configure prompt box buttons
            var buttons = new PromptBoxButtonsViewModel[]
            {
                new PromptBoxButtonsViewModel { ButtonContent = "Save", HighlightButton = true, },
                new PromptBoxButtonsViewModel { ButtonContent = "Ignore" },
                new PromptBoxButtonsViewModel { ButtonContent = "Cancel" },
            };

            // Prompt
            var message = "Do you want to save file";


            // Go through tab...
            foreach (var tab in Tabs)
            {
                // If closing tab is currently selected...
                if ((Guid)parameter == tab.TabID && tab.TabIsSelected == true)
                    // Set in-memo variable
                    IsClosingTabSelected = true;

            }

            // Close tab
            Tabs?.Remove(Tabs.Where(item => item.TabID == (Guid)parameter).Single());

            // Update tab selection if closing tab was selected 
            // at the time user wants to close it
            if (IsClosingTabSelected)
            {
                if(Tabs != null)
                    Tabs.LastOrDefault(TabItem).TabIsSelected = true;
            }

            // Update tab content
            UpdateTabContent();

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

        #endregion

        #region Public Methods

        /// <summary>
        /// Constructs and load saved file by adding it to the tabs
        /// </summary>
        /// <param name="note">The data to construct the file with</param>
        public void LoadNote(NoteDataModel note)
        {
            // Make sure we have data
            if(note == null) 
                return;

           // Check every tab in the view...
           foreach(var tab in _tabs!)
           {
              // If note is already loaded...
              if (tab.TabID == note.Id)
              {
                  // Reset selection
                  _tabs?.ToList().ForEach(item => item.TabIsSelected = false);
                  // Select the tab
                  tab.TabIsSelected = true;
                  // Update UI
                  UpdateTabContent();
                  // Do nothing else
                  return;
              }
           }

            // Construct and load new tab
            // ----------------------------

            // Reset selection
            _tabs?.ToList().ForEach(item => item.TabIsSelected = false);

            // Add new tab
            _tabs?.Add(new TabItemViewModel
            {
                // Set data
                TabIsSelected = true,
                TabID = note.Id,
                TabContent = new TabContentViewModel
                {
                    Header = note.Header,
                    Title = note.Title,
                    Content = note.Content,
                },
            });

            // Update tab content
            UpdateTabContent();

        }

        /// <summary>
        /// Updates the view with the current content of the tab selected
        /// </summary>
        public void UpdateTabContent()
        {
            // Go through all tabs in the collection...
            foreach (var item in _tabs!)
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