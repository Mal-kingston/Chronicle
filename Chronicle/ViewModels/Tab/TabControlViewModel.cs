﻿using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
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

        /// <summary>
        /// The tab id of tab that is currently selected
        /// </summary>
        private Guid _selectedTab_TabID => (Guid)(_tabs?.FirstOrDefault(x => x.TabIsSelected == true))?.TabID!;

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

        #region Public Events

        /// <summary>
        /// TODO: Get direct info from db that file has saved successfully
        /// --------------------------------------------------------------
        /// 
        /// 
        /// The event that gets fired when content of a tab is successfully saved to the database
        /// </summary>
        public event EventHandler<TabContentViewModel> ContentSaved;

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

            // Wire tabs UI and data
            _tabContent = TabItem.TabContent;
            ContextMenu = _tabContent.ContextMenu;

            // Create commands
            AddNewTabCommand = new RelayCommand(AddNewTab);
            CloseTabCommand = new ParameterizedRelayCommand((parameter) => CloseTab(parameter));
            SelectTabCommand = new ParameterizedRelayCommand((parameter) => SelectTab(parameter));

            // Event subscription
            ContentSaved += _tabContent.OnContentSaved!;

            // Transactional data store commands
            _tabContent.ContextMenu.SaveCommand = new ParameterizedRelayCommand(async (parameter) => await Save(parameter));
            _tabContent.ContextMenu.DeleteCommand = new ParameterizedRelayCommand(async (parameter) => await Delete(parameter));

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
        public async Task Save(object parameter)
        {
            // If we don't have anything to save...
            if (string.IsNullOrEmpty(_tabContent.Content) || TabItem?.TabID == null)
            {
                // Close context menu
                _tabContent.IsContextMenuOpen = false;

                // Do nothing
                return;
            }

            // Get the current tab id
            //var currentTabID = (Guid)(_tabs?.FirstOrDefault(x => x.TabIsSelected == true))?.TabID!;

            // TODO: If content doesn't have title or user want to save note with a specific name
            //       Invoke prompt window to give user the ability to enter desired name for the file before saving to database.

            // Save note data to database
            await ClientDataStore.SaveFile(new NoteDataModel
            {
                // TODO: Remeber template of note
                // Note_data | Id | Header | Title | Content |
                Id = _selectedTab_TabID,
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

            // notify user that file has been saved
            OnContentSaved(parameter);

        }

        /// <summary>
        /// Deletes a file from database
        /// </summary>
        public async Task Delete(object parameter)
        {
            // Get compatible format for looking infomation up in the database
            var fileInQuestion = (await ClientDataStore.GetFiles()).Find(x => x.Id == _selectedTab_TabID);

            // Check if Id it exists
            var result = await ClientDataStore.FileExists(fileInQuestion!);

            // If file exists...
            if(result && fileInQuestion != null)
            {
                // If default tab is being deleted...
                if (_tabs?.Count == 1)
                    // Add a new tab before removing the old tab
                    AddNewTab();

                // Close the tab
                CloseTab(fileInQuestion.Id);

                // Remove it
                await ClientDataStore.DeleteFile(fileInQuestion!);
            }

            // Update UI list
            SubMenuVM.UpdateNoteList();

            // Close context menu
            _tabContent.IsContextMenuOpen = false;

            // notify user that file has been deleted
            OnContentSaved(parameter);

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

            // Construct and add new tab
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
        public async void CloseTab(object parameter)
        {
            // Do not close the default tab
            if (_tabs?.Count == 1)
                return;

            // Make sure we have items
            if (_tabs == null)
                return;

            // TODO: Handle try saving a file with content and no title but 
            //       prompt user to enter title or suggest using the first few words as title of the note
            // ===========================================================================================


            // Status of selection of closing tab
            // (true if currently selected at the time of closing... false otherwise).
            var IsClosingTabSelected = false;

            #region Closing Prompt Set-up and Query

            // Configure prompt box buttons
            var buttons = new PromptBoxButtonsViewModel[]
            {
                new PromptBoxButtonsViewModel { ButtonContent = "Save", HighlightButton = true, },
                new PromptBoxButtonsViewModel { ButtonContent = "Ignore" },
                new PromptBoxButtonsViewModel { ButtonContent = "Cancel" },
            };

            // Prompt message
            var message = "Do you want to save this file";

            // Get the actual closing tab
            var closingTab = _tabs.Single(t => t.TabID == (Guid)parameter);

            // TODO: expand on the logic (also prompt user if they want to save changes made on an existing file)
            // If file has content...
            if (!(string.IsNullOrEmpty(closingTab.TabContent.Title) || string.IsNullOrEmpty(closingTab.TabContent.Content)))
            {
                // Get compatible format for looking infomation up in the database
                var FileInQuestion = (await ClientDataStore.GetFiles()).Find(x => x.Id == closingTab.TabID);

                // Check if Id it exists
                var result = await ClientDataStore.FileExists(FileInQuestion!);

                // If we have no record of the Id...
                if (!result)
                    // Spin-up prompt box 
                    DI.UIManager.InvokePromptBox(PromptBoxContent.PromptQueryContent, query: message, buttons: buttons);
            }

            #endregion

            // Go through tab...
            foreach (var tab in _tabs)
            {
                // Get the closing tab
                if ((Guid)parameter == tab.TabID && tab.TabIsSelected == true)
                    // Mark tab selected at the time closing is requested
                    IsClosingTabSelected = true;

            }

            // Close tab
            _tabs?.Remove(_tabs.Where(item => item.TabID == (Guid)parameter).Single());

            // Update tab selection if closing tab was selected 
            // at the time user wants to close it
            if (IsClosingTabSelected)
            {
                if(_tabs != null)
                    _tabs.LastOrDefault(TabItem).TabIsSelected = true;
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

        #region Event Definition

        /// <summary>
        /// Invokes the content-saved event
        /// </summary>
        public virtual void OnContentSaved(object parameter)
        {
            // Set the notificaiton text
            _tabContent.BriefNotificationText = (string)parameter;

            // Pass event down to subscribers
            ContentSaved?.Invoke(this, _tabContent);
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
            foreach (var tab in _tabs!)
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

            // TODO: handle opening unlimited tabs 
            if (_tabs?.Count == 4)
                return;

            // ==================================
            // --- Construct and load new tab ---
            // ==================================

            // Reset selection
            _tabs?.ToList().ForEach(item => item.TabIsSelected = false);

            // Construct and new file  to tab
            _tabs?.Add(new TabItemViewModel
            {
                // Set data
                TabIsSelected = true,
                TabID = note.Id,
                TabContent = new TabContentViewModel
                {
                    // Content detail
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