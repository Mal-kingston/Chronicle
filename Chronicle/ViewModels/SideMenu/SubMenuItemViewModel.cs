using System;
using System.Linq;
using System.Windows.Controls;
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

        #endregion

        #region Public Commands

        /// <summary>
        /// Command to open file
        /// </summary>
        public ICommand OpenFileCommand { get; set; }

        /// <summary>
        /// Command to delete a file from list of files
        /// </summary>
        public ICommand DeleteFileCommand { get; set; }

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
            DeleteFileCommand = new ParameterizedRelayCommand((parameter) => DeleteFile(parameter));
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Opens a file
        /// </summary>
        /// <param name="parameter">The name of the file to open</param>
        private void OpenFile(object parameter)
        {
            // Get the requested file from database
            var fileToOpen = AccessInMemoryDb.InMemoryData?.ToList().Find(x => x.Value.Header == parameter.ToString()); 

            // Load it
            TabControlVM.LoadNote(fileToOpen!.Value.Value);

            // Log info
            Logger.Log($"{fileToOpen.Value.Value?.Header} file opened");

            // If main view current page isn't notefile...
            if(MainVM.CurrentPage != ApplicationPage.NoteFile)
            {
                // Show notefile page
                MainVM.GotoPage(ApplicationPage.NoteFile);
                // Mark note button as checked
                MainVM.IsNoteChecked = true;
            }

        }

        /// <summary>
        /// Deletes a file from list of files on submenu list
        /// </summary>
        /// <param name="parameter">The signature of the file to delete</param>
        private void DeleteFile(object parameter)
        {
            // Get the requested file from in memory db
            var fileToDelete = AccessInMemoryDb.InMemoryData?.FirstOrDefault(x => x.Value.Header == parameter.ToString());

            // Make sure we have data to work with
            if (fileToDelete == null)
                // If not, do nothing
                return;

            // If the file to delete is currently open or if it is the only tab open... 
            if (TabControlVM.Tabs!.ToList().Exists(t => t.TabID == fileToDelete.Value.Value.Id))
                // Close it
                TabControlVM?.CloseTab(fileToDelete.Value.Value.Id);

            // Send file to recycle 
            AccessInMemoryDb.ProcessAndDataForRecycling(fileToDelete);

            // Update our sub menu list
            SubMenuVM.UpdateNoteList();
        }


        #endregion

        #region Public Methods

        ///// <summary>
        ///// Helper to convert database data into format that can be worked with
        ///// </summary>
        ///// <param name="model">The data to convert</param>
        ///// <returns>The converted format for use</returns>
        //public static TabItemViewModel ConvertToTabItem(NoteDataModel? model)
        //{
        //    // Assign data properties as needed
        //    var tabContent = new TabContentViewModel
        //    {
        //        Title = model!.Title,
        //        Header = model.Header,
        //        Content = model.Content,
        //    };

        //    // Assign data properties as needed
        //    var tabItemViewModel = new TabItemViewModel
        //    {
        //        TabID = model.Id,
        //        TabContent = tabContent,
        //    };

        //    // Return the converted format for use
        //    return tabItemViewModel;
        //}

        #endregion

    }
}