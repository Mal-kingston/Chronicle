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
        public double MinimumHeight { get; set; }

        /// <summary>
        /// Minimum height of this application
        /// </summary>
        public double MinimumWidth { get; set; }

        /// <summary>
        /// The current page of this application
        /// default to note
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.NoteFile;

        /// <summary>
        /// The view model to use for the current page when the Current page changes
        /// </summary>
        public BaseViewModel? CurrentPageViewModel { get; set; }

        #endregion

        #region Public Commands

 
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainViewModel()
        {
            MinimumHeight = 750;
            MinimumWidth = 1048;
            CurrentPage = ApplicationPage.NoteFile;
        }

        #endregion

        #region Command Methods

  
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
