using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Chronicle.DI;

namespace Chronicle
{
    /// <summary>
    /// View model for menu button
    /// </summary>
    public class MenuButtonViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The icon for each button 
        /// </summary>
        public IconType MenuIcon { get; set; }

        /// <summary>
        /// The title of each menu button
        /// </summary>
        public string MenuTitle { get; set; }

        public bool OpenList { get; set; }

        public bool OpenNoteList { get; set; }
        public bool OpenBookList { get; set; }

        /// <summary>
        /// List of notes
        /// </summary>
        public ObservableCollection<NotesListControlViewModel> NotesFiles { get; set; }

        /// <summary>
        /// List of books
        /// of type BOOKS
        /// </summary>
        public ObservableCollection<BooksListControlViewModel> BooksFiles { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// Command to select menu item
        /// </summary>
        public ICommand MenuCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public MenuButtonViewModel()
        {
            // Create commands
            MenuCommand = new RelayCommand(SelectMenuItem);

            // Set properties
            OpenList = false;
            OpenNoteList = false;
            OpenBookList = false;

            // Update properties
            OnPropertyChanged(nameof(OpenNoteList));
            OnPropertyChanged(nameof(MenuTitle));
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Sort menu item that is selected in the view
        /// </summary>
        private void SelectMenuItem()
        {
            // Get value ready
            OpenList ^= true;
            OnPropertyChanged(nameof(OpenList));


            // Sort and change view
            switch (MenuTitle)
            {

                case "Note":
                    // MainAppViewModel.GotoPage(ApplicationPage.Note);

                    OpenNoteList = OpenList;
                    OnPropertyChanged(nameof(OpenNoteList));
                    return;

                case "Book":
                    MainAppViewModel.GotoPage(ApplicationPage.Book);
                    return;

                case "Calendar":
                    MainAppViewModel.GotoPage(ApplicationPage.Calendar);
                    return;

                case "Share":
                    MainAppViewModel.GotoPage(ApplicationPage.Share);
                    return;

                case "Settings":
                    MainAppViewModel.GotoPage(ApplicationPage.Settings);
                    return;

                case "Trash":
                    MainAppViewModel.GotoPage(ApplicationPage.Trash);
                    return;
            }
        }

        #endregion

    }
}
