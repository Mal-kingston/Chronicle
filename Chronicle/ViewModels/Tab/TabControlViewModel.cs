using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading;
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

                OnPropertyChanged(nameof(TabContent));
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

        /// <summary>
        /// The tab id of tab that is currently selected
        /// </summary>
        public Guid SelectedTabTabID => (Guid)(_tabs?.FirstOrDefault(x => x.TabIsSelected == true))?.TabID!;

        /// <summary>
        /// Flag indicating that a tab was added
        /// </summary>
        public bool NewTabAdded { get; set; }

        /// <summary>
        /// Used to direct focus on tab content when needed
        /// </summary>
        public bool SetFocusOnTabContent{ get; set; }

        #endregion

        #region Public Events

        /// <summary>
        /// TODO: Get direct info from db that file has saved successfully
        /// --------------------------------------------------------------
        /// 
        /// 
        /// The event that gets fired when content of a tab is successfully saved to the database
        /// </summary>
        public event EventHandler<TabContentViewModel> ContentUpdated;

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
            NewTabAdded = true;
            SetFocusOnTabContent = false;
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
            CloseTabCommand = new ParameterizedRelayCommand( async (parameter) => await CloseTab(parameter));
            SelectTabCommand = new ParameterizedRelayCommand((parameter) => SelectTab(parameter));

            // Event subscription
            ContentUpdated += _tabContent.OnContentUpdated!;

            // Update properties
            OnPropertyChanged(nameof(Tabs));
            OnPropertyChanged(nameof(_tabs));
            OnPropertyChanged(nameof(TabContent));
            OnPropertyChanged(nameof(_tabContent));
            OnPropertyChanged(nameof(TabItem));
            OnPropertyChanged(nameof(ContextMenu));
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

            // TODO: If content doesn't have title or user want to save note with a specific name
            //       Invoke prompt window to give user the ability to enter desired name for the file before saving to database.

            // Save note data to database
            await ClientDataStore.SaveFile(new NoteDataModel
            {
                // TODO: Remember template of note
                // Note_data | Id | Header | Title | Content |
                Id = SelectedTabTabID,
                Header = _tabContent.Header,
                Title = _tabContent.Title,
                Content = _tabContent.Content,
                AssociatedDate = DateTime.Now,
            });


            // TODO: Remove once db calls has been channeled to the in memory db clone class
            // Update in memory db 
            AccessInMemoryDb.GetCopyOfDbData();

            // Log data
            Logger.Log("Note information saved to database");

            // Update UI list 
            SubMenuVM.UpdateNoteList();

            // Close context menu
            _tabContent.IsContextMenuOpen = false;

            // notify user that file has been saved
            OnContentUpdated(parameter);

        }

        /// <summary>
        /// Deletes a file from database
        /// </summary>
        public async Task Delete(object parameter)
        {
            // Get in memory db clone
            var fileInQuestion = AccessInMemoryDb.InMemoryData?.FirstOrDefault(x => x.Key == SelectedTabTabID);

            // If file doesn't exist...
            if (fileInQuestion!.Value.Key == Guid.Empty)
            {
                // Close context menu
                _tabContent.IsContextMenuOpen = false;

                // Do nothing
                return;

            }

            // Close the tab
            await CloseTab(fileInQuestion.Value.Key);

            // Remove it
            AccessInMemoryDb.ProcessAndDataForRecycling(fileInQuestion);

            // Update UI list
            SubMenuVM.UpdateNoteList();

            // Close context menu
            _tabContent.IsContextMenuOpen = false;

            // notify user that file has been deleted
            OnContentUpdated(parameter);

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
        public async Task CloseTab(object parameter)
        {
            // Do not close the default tab
            if (_tabs?.Count == 1 && string.IsNullOrEmpty(_tabContent.Title) && string.IsNullOrEmpty(_tabContent.Content))
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
                new PromptBoxButtonsViewModel { ButtonContent = "Save", FeedBackType = PromptBoxFeedBackType.Save, HighlightButton = true, },
                new PromptBoxButtonsViewModel { ButtonContent = "Don't save", FeedBackType = PromptBoxFeedBackType.DontSave },
                new PromptBoxButtonsViewModel { ButtonContent = "Cancel" , FeedBackType = PromptBoxFeedBackType.Cancel },
            };

            // Get the actual closing tab
            var closingTab = _tabs.Single(t => t.TabID == (Guid)parameter);

            // TODO: expand on this logic (also prompt user if they want to save changes made on an existing file)
            // If file has content...
            if (!(string.IsNullOrEmpty(closingTab.TabContent.Title) || string.IsNullOrEmpty(closingTab.TabContent.Content)))
            {
                // Get compatible format for looking information up in the database
                var FileInQuestion = (await ClientDataStore.GetFiles()).Find(x => x.Id == closingTab.TabID);

                // Check if Id exists on database
                var result = await ClientDataStore.FileExists(FileInQuestion!);

                var query = "Do you want to save this file ?";

                // If we have no record of the Id...
                if (!result)
                {
                    // Spin-up prompt box
                    await DI.UIManager.InvokePromptBox(PromptBoxContent.SaveAndExitContent, query: query, buttons: buttons);

                    // Parameter for saving data in this function before exiting
                    var saveFunctionParameter = "File saved";

                    // Handle user feedback accordingly
                    switch (DI.UIManager.FeedBackResult)
                    {
                        case PromptBoxFeedBackType.Cancel:
                            return;

                        case PromptBoxFeedBackType.DontSave:
                            break;

                        case PromptBoxFeedBackType.Save:
                            SaveClosingFile(closingTab, saveFunctionParameter);
                            break;

                    }

                }
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

            // If default tab is being closed...
            if (_tabs?.Count == 1)
                // Add a new tab before removing the old tab
                AddNewTab();

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
            if (_tabs == null)
                return;

            // Reset selection
            _tabs.ToList().ForEach(item => item.TabIsSelected = false);

            // For every tabs in the collection
            foreach (var item in _tabs)
            {
                // If tab header match
                if (item.TabID == (Guid)parameter)
                    // Set new selection 
                    item.TabIsSelected = true;
            }

            // Update tab content
            UpdateTabContent();

            // Reset flags 
            NewTabAdded = false;
            SetFocusOnTabContent = false;

            // Update property
            OnPropertyChanged(nameof(NewTabAdded));
            OnPropertyChanged(nameof(SetFocusOnTabContent));

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

                // Turn off context menu for tabs that are not currently selected
                if (item.TabIsSelected == false)
                    item.TabContent.IsContextMenuOpen = false;

            }

            // Set flags for UI to gain focus accordingly
            if (_tabContent.Title.Count() == 0)
            {
                NewTabAdded = true;
                SetFocusOnTabContent = false;
            }
            else
            {
                NewTabAdded = false;
                SetFocusOnTabContent = true;
            }

            // Update property
            OnPropertyChanged(nameof(NewTabAdded));
            OnPropertyChanged(nameof(SetFocusOnTabContent));
            // Update selected tab unique id
            OnPropertyChanged(nameof(SelectedTabTabID));

        }

        /// <summary>
        /// Saves closing tab
        /// </summary>
        /// <param name="closingTab">The tab to save</param>
        /// <param name="closingParameter">the signature of the closing tab</param>
        private void SaveClosingFile(TabItemViewModel closingTab, string closingParameter)
        {
            // Get the tab in question
            var tabInQuestion = _tabs?.FirstOrDefault(t => t.TabID == closingTab?.TabID);

            // Make sure tab is not null
            if (tabInQuestion != null)
                // Select the tab
                SelectTab(tabInQuestion.TabID);

            // Try and save the closing tab
            tabInQuestion?.TabContent.ContextMenu.SaveCommand.Execute(closingParameter);

            // Log information
            Logger.Log("File saved before exit");
        }

        #endregion

        #region Event Definition And Methods

        /// <summary>
        /// Invokes the content-saved event
        /// </summary>
        public virtual void OnContentUpdated(object parameter)
        {
            // Set the notification text
            _tabContent.BriefNotificationText = (string)parameter;

            // Pass event down to subscribers
            ContentUpdated?.Invoke(this, _tabContent);
        }

        /// <summary>
        /// Turn off context menu for each tab
        /// </summary>
        /// <param name="sender">Origin of this event</param>
        /// <param name="page">The current page of this application</param>
        public void OnCurrentPageChanged(object? sender, ApplicationPage page)
        {
            // Make sure tab isn't null
            if(_tabs == null)
                // If it is, do nothing
                return;

            // If current page is not note-view
            if(page != ApplicationPage.NoteFile)
            {
                // Go through tabs
                foreach (var tab in _tabs)
                {
                    // Turn off context menu
                    if (tab.TabContent.IsContextMenuOpen == true)
                        tab.TabContent.IsContextMenuOpen = false;
                }

            }

        }

        #endregion

    }
}