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
        /// <summary>
        /// The list of book submenu
        /// </summary>
        public ObservableCollection<SubMenuItemViewModel> BookSubMenu { get; set; }

        /// <summary>
        /// The list of note submenu
        /// </summary>
        public ObservableCollection<SubMenuItemViewModel> NoteSubMenu { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public SubMenuViewModel()
        {
            // Set default properties
            BookSubMenu = new ObservableCollection<SubMenuItemViewModel>();
            NoteSubMenu = new ObservableCollection<SubMenuItemViewModel>();

            // Update list of notes
            UpdateNoteList();
        }

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


    }
}
