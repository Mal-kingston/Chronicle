using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public double MinimumHeight { get; set; } = 750;

        /// <summary>
        /// Minimum height of this application
        /// </summary>
        public double MinimumWidth { get; set; } = 1048;

        /// <summary>
        /// Shows list of notes on true
        /// </summary>
        public bool IsShowNotesList { get; set; } = false;

        /// <summary>
        /// Shows list of books on true
        /// </summary>
        public bool IsShowBooksList { get; set; } = false;

        /// <summary>
        /// The current page of this application
        /// default to note
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Note;

        /// <summary>
        /// The view model to use for the current page when the Current page changes
        /// </summary>
        public BaseViewModel CurrentPageViewModel { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// Command to show or hide list of notes
        /// </summary>
        public ICommand ShowNotesCommand { get; set; }

        /// <summary>
        /// Command to show or hide list of books
        /// </summary>
        public ICommand ShowBooksCommand { get; set; }


        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainViewModel()
        {
            // Create Commands
            ShowNotesCommand = new RelayCommand(ShowNotesList);
            ShowBooksCommand = new RelayCommand(ShowBooksList);

            // Update properties
            OnPropertyChanged(nameof(IsShowNotesList));
            OnPropertyChanged(nameof(IsShowBooksList));
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Show or close book list
        /// </summary>
        private void ShowBooksList()
        {
            // if note list is open
            if (IsShowNotesList == true || CurrentPage == ApplicationPage.Note)
                // Close it
                IsShowNotesList = false;

            // Toggle book list
            IsShowBooksList ^= true;

            // Update properties
            OnPropertyChanged(nameof(IsShowNotesList));
            OnPropertyChanged(nameof(IsShowBooksList));
        }

        /// <summary>
        /// Show or close note list
        /// </summary>
        private void ShowNotesList()
        {
            // If book list is open
            if (IsShowBooksList == true || CurrentPage == ApplicationPage.Book)
                // Close it
                IsShowBooksList = false;

            // Toggle note list
            IsShowNotesList ^= true;

            // Update properties
            OnPropertyChanged(nameof(IsShowNotesList));
            OnPropertyChanged(nameof(IsShowBooksList));
        }

        #endregion

        #region Public Helpers

        
        public void GotoPage(ApplicationPage page)
        {            
            // Sets current page value
            CurrentPage = page;

            // If page hasn't changed fire off notification to update page
            // Fire off a currentPage changed event
            OnPropertyChanged(nameof(CurrentPage));
          
        }

        #endregion

    }
}
