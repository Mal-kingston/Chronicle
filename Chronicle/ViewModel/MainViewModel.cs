using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        #region Side menu

        /// <summary>
        /// Side menu -> Note
        /// </summary>
        public SideMenuViewModel Note { get; set; }

        /// <summary>
        /// Side menu -> Book
        /// </summary>
        public SideMenuViewModel Book { get; set; }

        /// <summary>
        /// Side menu -> Calendar
        /// </summary>
        public SideMenuViewModel Calendar { get; set; }

        /// <summary>
        /// Side menu -> Share
        /// </summary>
        public SideMenuViewModel Share { get; set; }

        /// <summary>
        /// Side menu -> Settings
        /// </summary>
        public SideMenuViewModel Settings { get; set; }


        /// <summary>
        /// Side menu -> Trash
        /// </summary>
        public SideMenuViewModel Trash { get; set; }

        #endregion

        #endregion

        #region Public Commands


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

            // Note menu
            Note = new SideMenuViewModel
            {
                SubMenu = new ObservableCollection<SubMenuDesignModel>
                {
                    new SubMenuDesignModel
                    {
                        SubMenuIcon = IconType.NotesItem,
                        SubMenuTitle = "Astrophysics 101",
                    },

                    new SubMenuDesignModel
                    {
                        SubMenuIcon = IconType.NotesItem,
                        SubMenuTitle = "Genesis of People and culture",
                    },

                    new SubMenuDesignModel
                    {
                        SubMenuIcon = IconType.NotesItem,
                        SubMenuTitle = "The future of A.I",
                    },

                    new SubMenuDesignModel
                    {
                        SubMenuIcon = IconType.NotesItem,
                        SubMenuTitle = "Beauty and the beast",
                    },

                    new SubMenuDesignModel
                    {
                        SubMenuIcon = IconType.NotesItem,
                        SubMenuTitle = "The marchant ship",
                    },

                }
            };

            // Book menu
            Book = new SideMenuViewModel
            {
                SubMenu = new ObservableCollection<SubMenuDesignModel>
                {
                    new SubMenuDesignModel
                    {
                        SubMenuIcon = IconType.BooksItem,
                        SubMenuTitle = "Astrophysics 101",
                    },

                    new SubMenuDesignModel
                    {
                        SubMenuIcon = IconType.BooksItem,
                        SubMenuTitle = "Genesis of People and culture",
                    },

                    new SubMenuDesignModel
                    {
                        SubMenuIcon = IconType.BooksItem,
                        SubMenuTitle = "The future of A.I",
                    },

                    new SubMenuDesignModel
                    {
                        SubMenuIcon = IconType.BooksItem,
                        SubMenuTitle = "Beauty and the beast",
                    },

                    new SubMenuDesignModel
                    {
                        SubMenuIcon = IconType.BooksItem,
                        SubMenuTitle = "The marchant ship",
                    },

                    }
            };
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
