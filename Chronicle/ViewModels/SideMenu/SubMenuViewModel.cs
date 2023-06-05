using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Chronicle.DI;

namespace Chronicle
{
    /// <summary>
    /// View model for the sub menu of this application
    /// </summary>
    public class SubMenuViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The list of book submenu
        /// </summary>
        public ObservableCollection<SubMenuItemViewModel> BookSubMenu { get; set; }

        /// <summary>
        /// The list of note submenu
        /// </summary>
        public ObservableCollection<SubMenuItemViewModel> NoteSubMenu { get; set; }

        /// <summary>
        /// True if note list is empty
        /// Otherwise false
        /// </summary>
        public bool IsNoteListEmpty { get; set; }

        /// <summary>
        /// True if note list is empty
        /// Otherwise false
        /// </summary>
        public bool IsBookListEmpty { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SubMenuViewModel()
        {
            // Set default properties
            BookSubMenu = new ObservableCollection<SubMenuItemViewModel>();
            NoteSubMenu = new ObservableCollection<SubMenuItemViewModel>();
            IsNoteListEmpty = false;
            IsBookListEmpty = false;

            // Update list of notes
            UpdateNoteList();

            // Update properties
            OnPropertyChanged(nameof(NoteSubMenu));
            OnPropertyChanged(nameof(BookSubMenu));
            OnPropertyChanged(nameof(IsNoteListEmpty));
            OnPropertyChanged(nameof(IsBookListEmpty));
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Fetch data from the data store and updates the list of notes
        /// based on data available in the data store
        /// </summary>
        public async void UpdateNoteList()
        {
            // Get data from data store
            var data = await ClientDataStore.GetFiles();

            // Go through all note data in the db.
            foreach (var file in data)
                // Add them to the list
                AddToNoteList(new SubMenuItemViewModel { SubMenuTitle = file.Header });

            // Log list updated
            Logger.Log("List of list updated");

            // If we have no note...
            if (NoteSubMenu.Count == 0)
                // Mark UI to be empty
                IsNoteListEmpty = true;
            // Otherwise...
            else
                // Mark UI to not be empty
                IsNoteListEmpty = false;

            // If we have no book...
            if (BookSubMenu.Count == 0)
                // Mark UI to be empty
                IsBookListEmpty = true;
            // Otherwise...
            else
                // Mark UI to not be empty
                IsBookListEmpty = false;

            // Update properties
            OnPropertyChanged(nameof(IsNoteListEmpty));
            OnPropertyChanged(nameof(IsBookListEmpty));
        }

        /// <summary>
        /// Adds a sub-menu item to the mote list
        /// </summary>
        /// <param name="subMenuItem">The item to add</param>
        public void AddToNoteList(SubMenuItemViewModel subMenuItem)
        {
            // If we dont have anything to add...
            if (subMenuItem == null)
                // Do nothing
                return;
            
            // Add item to the list
            NoteSubMenu.Add(subMenuItem);

            // Log sub-menu item added
            Logger.Log("Sub menu item added");
        }

        /// <summary>
        /// Removes a sub-menu item from the list if they exist
        /// </summary>
        /// <param name="subMenuItem">The item to remove</param>
        public void RemoveFromNoteList(SubMenuItemViewModel subMenuItem)
        {
            // If we dont have anything to remove...
            if (subMenuItem == null)
                // Do nothing
                return;

            // Remove item to the list
            NoteSubMenu.Remove(subMenuItem);

            // Log sub-menu item removed
            Logger.Log("Sub menu item removed");
        }

        #endregion

    }
}
