using System.Windows.Input;
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
            // Create command
            OpenFileCommand = new RelayCommand(OpenFile);
        }

        /// <summary>
        /// Opens a file
        /// </summary>
        private void OpenFile()
        {
            // Simulate going opening a note file
            MainVM.GotoPage(ApplicationPage.NoteFile);
        }
    }
}
