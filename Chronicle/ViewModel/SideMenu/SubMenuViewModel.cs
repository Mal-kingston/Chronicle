using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
        }

    }
}
