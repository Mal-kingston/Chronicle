using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

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
                if (_title.Length > 0)
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
        /// True if the context menu is open
        /// Otherwise false
        /// </summary>
        public bool IsContextMenuOpen { get; set; }

        /// <summary>
        /// The context menu to allow saving, sharing, printing of files
        /// as well as other functions
        /// </summary>
        public ContextMenuViewModel ContextMenu { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// Opens and also closes context menu
        /// </summary>
        public ICommand OpenFileContextMenuCommand { get; set; }

        /// <summary>
        /// Closes context menu if open
        /// </summary>
        public ICommand CloseContextMenuCommand { get; set; }

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
            ContextMenu = new ContextMenuViewModel();

            // Create commands
            OpenFileContextMenuCommand = new RelayCommand(OpenFileContextMenu);
            CloseContextMenuCommand = new RelayCommand(() => IsContextMenuOpen = false);

            // Update properties
            OnPropertyChanged(nameof(Content));
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Header));
            OnPropertyChanged(nameof(_title));
            OnPropertyChanged(nameof(ContextMenu));
            
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Opens / Closes file context menu
        /// </summary>
        private void OpenFileContextMenu() => IsContextMenuOpen ^= true;

        #endregion
    }
}