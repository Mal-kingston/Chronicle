using System.Windows.Input;
using static Chronicle.DI;

namespace Chronicle
{
    /// <summary>
    /// View model for <see cref="SubMenuItemViewModel"/>
    /// </summary>
    public class SubMenuItemViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The title of a submenu item
        /// </summary>
        public string SubMenuTitle { get; set; }

        /// <summary>
        /// The icon type of a submenu item
        /// </summary>
        public IconType SubMenuIcon { get; set; }

        /// <summary>
        /// Command to open file
        /// </summary>
        public ICommand OpenFileCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SubMenuItemViewModel()
        {
            // Set properties
            SubMenuTitle = string.Empty;
            SubMenuIcon = IconType.Note;

            // Create commands
            OpenFileCommand = new ParameterizedRelayCommand((parameter) => OpenFile(parameter));

        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Opens a file
        /// </summary>
        /// <param name="parameter">The name of the file to open</param>
        private async void OpenFile(object parameter)
        {
            // Get the requested file from database
            var fileToOpen = (await ClientDataStore.GetFiles()).Find(x => x.Header == parameter.ToString()); 

            // Load it
            TabControlVM.LoadNote(fileToOpen!);

            // Log info
            Logger.Log($"{fileToOpen?.Header} file opened");

            // If main view current page isn't notefile...
            if(MainVM.CurrentPage != ApplicationPage.NoteFile)
                // Show notefile page
                MainVM.GotoPage(ApplicationPage.NoteFile);
            
        }

        #endregion

    }
}