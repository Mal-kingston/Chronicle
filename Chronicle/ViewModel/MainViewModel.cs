using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Data;
using System.Windows.Input;

namespace Chronicle
{
    /// <summary>
    /// The main view model for this application 
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Minimum width of this application 
        /// </summary>
        public double MinimumHeight { get; set; }

        /// <summary>
        /// Minimum height of this application
        /// </summary>
        public double MinimumWidth { get; set; }

        /// <summary>
        /// True if note sub menu should be shown,
        /// Otherwise false
        /// </summary>
        public bool IsNoteSubMenuOpen { get; set; }

        /// <summary>
        /// True if book sub menu should be shown,
        /// Otherwise false
        /// </summary>
        public bool IsBookSubMenuOpen { get; set; }

        /// <summary>
        /// The current page of this application
        /// default to note
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } 

        /// <summary>
        /// The view model to use for the current page when the Current page changes
        /// </summary>
        public BaseViewModel? CurrentPageViewModel { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// Command to select note menu item
        /// </summary>
        public ICommand NoteMenuCommand { get; set; }

        /// <summary>
        /// Command to select book menu item
        /// </summary>
        public ICommand BookMenuCommand { get; set; }

        /// <summary>
        /// Command to select calendar menu item
        /// </summary>
        public ICommand CalendarMenuCommand { get; set; }

        /// <summary>
        /// Command to select share menu item
        /// </summary>
        public ICommand ShareMenuCommand { get; set; }

        /// <summary>
        /// Command to select settings menu item
        /// </summary>
        public ICommand SettingsMenuCommand { get; set; }

        /// <summary>
        /// Command to select trash menu item
        /// </summary>
        public ICommand TrashMenuCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainViewModel()
        {
            // Set default properties
            MinimumHeight = 750;
            MinimumWidth = 1048;
            CurrentPage = ApplicationPage.NoteFile;
            IsNoteSubMenuOpen = false;
            IsBookSubMenuOpen = false;

            // Create Commands
            NoteMenuCommand = new RelayCommand(OpenNotes);
            BookMenuCommand = new RelayCommand(OpenBooks);
            CalendarMenuCommand = new RelayCommand(() => { DI.MainVM.GotoPage(ApplicationPage.Calendar); });
            ShareMenuCommand = new RelayCommand(() => { DI.MainVM.GotoPage(ApplicationPage.Share); });
            SettingsMenuCommand = new RelayCommand(() => { DI.MainVM.GotoPage(ApplicationPage.Settings); });
            TrashMenuCommand = new RelayCommand(() => { DI.MainVM.GotoPage(ApplicationPage.Trash); });

            // Update properties
            OnPropertyChanged(nameof(IsNoteSubMenuOpen));
            OnPropertyChanged(nameof(IsBookSubMenuOpen));
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Command method to open books
        /// </summary>
        private void OpenBooks()
        {
            // If note sub menu is already open
            if (IsNoteSubMenuOpen)
                // Close it
                IsNoteSubMenuOpen = false;

            // Toggle book sub menu as needed
            IsBookSubMenuOpen ^= true;

            // Update properties
            OnPropertyChanged(nameof(IsNoteSubMenuOpen));
            OnPropertyChanged(nameof(IsBookSubMenuOpen));
        }

        /// <summary>
        /// Command method to open notes
        /// </summary>
        private void OpenNotes()
        {
            // If book sub menu is already open
            if (IsBookSubMenuOpen)
                // Close it
                IsBookSubMenuOpen = false;

            // Toggle note sub menu as needed
            IsNoteSubMenuOpen ^= true;

            // Update properties
            OnPropertyChanged(nameof(IsNoteSubMenuOpen));
            OnPropertyChanged(nameof(IsBookSubMenuOpen));
        }

        #endregion

        #region Public Helpers


        public void GotoPage(ApplicationPage page)
        {            
            // Sets current page value
            CurrentPage = page;
          
        }

        #endregion

    }
}
