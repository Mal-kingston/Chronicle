using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace Chronicle
{
    /// <summary>
    /// View model for the list control
    /// </summary>
    public class NotesListControlViewModel : BaseViewModel
    {
        /// <summary>
        /// Message to display to users if list is empty
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// False is list injected is not empty
        /// Otherwise list is empty
        /// </summary>
        public bool IsListEmpty { get; set; } = true;

        /// <summary>
        /// List of notes to display 
        /// </summary>
        public ObservableCollection<ListControlItemViewModel> NoteListItems { get; set; }

        public Visibility ShowList { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public NotesListControlViewModel()
        {
            ShowList = Visibility.Collapsed;

            OnPropertyChanged(nameof(ShowList));
        }
    }
}
