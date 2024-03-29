﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.TextFormatting;

namespace Chronicle
{
    /// <summary>
    /// View model for tab content
    /// </summary>
    public class TabContentViewModel : BaseViewModel
    {
        #region Private Fields

        /// <summary>
        /// Title of this content
        /// </summary>
        private string _title;

        #endregion

        #region Public Properties

        /// <summary>
        /// Label for title
        /// </summary>
        public string TitleLabel { get; set; }

        /// <summary>
        /// The title
        /// </summary>
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title == value)
                    return;

                _title = value;

                // Set header
                if (!string.IsNullOrWhiteSpace(_title))
                    Header = _title;
                else Header = "Untitled";
            }
        }

        /// <summary>
        /// Main content 
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Header of tab content
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// The text for a notification that appears for a short period of time
        /// </summary>
        public string BriefNotificationText { get; set; }

        /// <summary>
        /// Notifies user when file has been successfully saved to the database
        /// </summary>
        public bool NotifyUser { get; set; } = false;

        /// <summary>
        /// True if the context menu is open
        /// Otherwise false
        /// </summary>
        public bool IsContextMenuOpen { get; set; }

        /// <summary>
        /// True if template option control is open
        /// Otherwise, false if not open
        /// </summary>
        public bool IsTemplateOptionsOpen { get; set; }

        /// <summary>
        /// The context menu to allow saving, sharing, printing of files
        /// as well as other functions
        /// </summary>
        public ContextMenuViewModel ContextMenu { get; set; }

        /// <summary>
        /// Template of the UI this view model controls
        /// </summary>
        public TabContentTemplates Template { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// Opens and also closes context menu
        /// </summary>
        public ICommand OpenContextMenuCommand { get; set; }

        /// <summary>
        /// Closes context menu if open
        /// </summary>
        public ICommand CloseContextMenuCommand { get; set; }

        /// <summary>
        /// Command to select a preferred template
        /// </summary>
        public ICommand OpenTemplateOptionsCommand { get; set; }

        /// <summary>
        /// Command to select plain template
        /// </summary>
        public ICommand SelectPlainCommand { get; set; }

        /// <summary>
        /// Command to select lined template
        /// </summary>
        public ICommand SelectLinedCommand { get; set; }

        /// <summary>
        /// Command to select margin lined template
        /// </summary>
        public ICommand SelectMarginLinedCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TabContentViewModel()
        {
            // Set default properties values
            TitleLabel = "Title";
            Header = "Untitled";
            _title = string.Empty;
            Content = string.Empty;
            IsContextMenuOpen = false;
            IsTemplateOptionsOpen = false;
            Template = TabContentTemplates.Plain;
            ContextMenu = new ContextMenuViewModel();

            // Create commands
            OpenContextMenuCommand = new RelayCommand(() => { IsContextMenuOpen ^= true; if (!IsContextMenuOpen) IsTemplateOptionsOpen = false; });
            CloseContextMenuCommand = new RelayCommand(() => IsTemplateOptionsOpen = IsContextMenuOpen = false);
            OpenTemplateOptionsCommand = new RelayCommand(() => IsTemplateOptionsOpen ^= true);
            SelectPlainCommand = new RelayCommand(() => {Template = TabContentTemplates.Plain; IsTemplateOptionsOpen = IsContextMenuOpen = false; });
            SelectLinedCommand = new RelayCommand(() => { Template = TabContentTemplates.Lined; IsTemplateOptionsOpen = IsContextMenuOpen = false; });
            SelectMarginLinedCommand = new RelayCommand(() => { Template = TabContentTemplates.LinedWithMargin; IsTemplateOptionsOpen = IsContextMenuOpen = false; });


            // Update properties
            OnPropertyChanged(nameof(Content));
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Header));
            OnPropertyChanged(nameof(_title));
            OnPropertyChanged(nameof(ContextMenu));
            OnPropertyChanged(nameof(Template));
            
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Opens / Closes file context menu
        /// </summary>
        //private void OpenFileContextMenu() => IsContextMenuOpen ^= true;

        #endregion

        #region Event Methods

        /// <summary>
        /// Pushes notification to user when content of this object is saved to the database
        /// </summary>
        /// <param name="sender">The publisher of this event</param>
        /// <param name="tabContent">The property to change</param>
        public void OnContentUpdated(object sender, TabContentViewModel tabContent)
        {
            // If we haven't notified user yet
            if (tabContent.NotifyUser == false)
            {
                // Notify user for few seconds and then reset to original value
                Task.Run(async () => 
                {
                    tabContent.NotifyUser = true;
                    await Task.Delay(1500);
                    tabContent.NotifyUser = false;
                });
            }

        }

        #endregion
    }
}