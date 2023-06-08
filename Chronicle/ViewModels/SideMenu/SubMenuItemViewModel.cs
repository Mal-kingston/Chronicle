using SQLitePCL;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using static Chronicle.DI;

namespace Chronicle
{
    /// <summary>
    /// View model for <see cref="SubMenuItemViewModel"/>
    /// </summary>
    public class SubMenuItemViewModel : BaseViewModel
    {

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

        /// <summary>
        /// Opens a file
        /// </summary>
        /// <param name="parameter">The name of the file to open</param>
        private async void OpenFile(object parameter)
        {
            // TODO: Get only the file requested

            // Get files in database
            var data = await ClientDataStore.GetFiles();

            // Go through data...
            foreach (var item in data)
            {
                // if we have a match with parameter...
                if(item.Header == parameter.ToString())
                    // Load it
                    TabControlVM.LoadNote(item);
                // Log 
                Logger.Log($"{item.Header} file opened");
            }

            // Show note file view
            MainVM.GotoPage(ApplicationPage.NoteFile);

        }

    }
}