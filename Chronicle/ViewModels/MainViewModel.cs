using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
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
        /// True if note menu button is checked
        /// (Button is checked by default)
        /// </summary>
        public bool IsNoteChecked { get; set; } = true;

        /// <summary>
        /// True if book sub menu should be shown,
        /// Otherwise false
        /// </summary>
        public bool IsBookSubMenuOpen { get; set; }

        /// <summary>
        /// True if book menu button is checked
        /// </summary>
        public bool IsBookChecked { get; set; }

        /// <summary>
        /// The current page of this application
        /// default to note
        /// </summary>
        public ApplicationPage CurrentPage { get; set; }

        #endregion

        #region Public Events

        /// <summary>
        /// Event that fires whenever current page changes
        /// </summary>
        public event EventHandler<ApplicationPage> CurrentPageChanged;

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
        public ICommand RecycleBinMenuCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainViewModel()
        {
            // Set default properties
            MinimumHeight = 750;
            MinimumWidth = 1182;
            CurrentPage = ApplicationPage.NoteFile;
            IsNoteSubMenuOpen = false;
            IsBookSubMenuOpen = false;

            // Create Commands
            NoteMenuCommand = new RelayCommand(OpenNotes);
            BookMenuCommand = new RelayCommand(OpenBooks);
            CalendarMenuCommand = new RelayCommand(() => { GotoPage(ApplicationPage.Calendar); });
            ShareMenuCommand = new RelayCommand(() => { GotoPage(ApplicationPage.Share); });
            SettingsMenuCommand = new RelayCommand(() => { GotoPage(ApplicationPage.Settings); });
            RecycleBinMenuCommand = new RelayCommand(() => { GotoPage(ApplicationPage.RecycleBin); });

            // Hook up events
            CurrentPageChanged += DI.TabControlVM.OnCurrentPageChanged;
            CurrentPageChanged += DI.RecycleVM.OnCurrentPageChanged;

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
            // If current view is not book view...
            if (CurrentPage != ApplicationPage.BookFile)
            {
                // Just show the book view
                GotoPage(ApplicationPage.BookFile);

                // Do nothing else
                return;
            }

            // If note sub menu is already open
            if (IsNoteSubMenuOpen)
                // Close it
                IsNoteSubMenuOpen = false;

            // Toggle book sub menu as needed
            IsBookSubMenuOpen ^= true;

            // Set book as checked
            IsBookChecked = true;

            // Update properties
            OnPropertyChanged(nameof(IsNoteSubMenuOpen));
            OnPropertyChanged(nameof(IsBookSubMenuOpen));
            OnPropertyChanged(nameof(IsBookChecked));

        }

        /// <summary>
        /// Command method to open notes
        /// </summary>
        private void OpenNotes()
        {
            // If current view is not note view...
            if (CurrentPage != ApplicationPage.NoteFile)
            {
                // Just show the note view
                GotoPage(ApplicationPage.NoteFile);

                // Do nothing else
                return;
            }

            // If book sub menu is already open
            if (IsBookSubMenuOpen)
                // Close it
                IsBookSubMenuOpen = false;

            // Toggle note sub menu as needed
            IsNoteSubMenuOpen ^= true;

            // Set note button as checked
            IsNoteChecked = true; 

            // Update properties
            OnPropertyChanged(nameof(IsNoteSubMenuOpen));
            OnPropertyChanged(nameof(IsBookSubMenuOpen));
            OnPropertyChanged(nameof(IsNoteChecked));
        }

        #endregion

        #region Public Helpers

        /// <summary>
        /// Navigates to a specified page
        /// </summary>
        /// <param name="page">The page to navigate to</param>
        public void GotoPage(ApplicationPage page)
        {
            // Sets current page value
            CurrentPage = page;

            // Update property value
            OnPropertyChanged(nameof(CurrentPage));

            // Raise event whenever page changes
            OnCurrentPageChanged(this);
        }

        #endregion

        #region Public Event Definition

        /// <summary>
        /// Invokes event whenever current page changes
        /// </summary>
        /// <param name="sender">Origin of this event</param>
        public virtual void OnCurrentPageChanged(object sender)
        {
            // Invoke the event
            CurrentPageChanged?.Invoke(this, CurrentPage);
        }

        #endregion

    }
}
