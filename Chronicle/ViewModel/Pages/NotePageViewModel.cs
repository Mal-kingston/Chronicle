using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// View model for the note page view
    /// </summary>
    public class NotePageViewModel : BaseViewModel
    {
        /// <summary>
        /// Header or title of a note
        /// </summary>
        public string NoteHeader { get; set; }

        /// <summary>
        /// The body of note
        /// </summary>
        public string NoteBody { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public NotePageViewModel()
        {
            // Initialize 
            NoteHeader = string.Empty;
            NoteBody = string.Empty;

            // Update Properties
            OnPropertyChanged(nameof(NoteHeader));
            OnPropertyChanged(nameof(NoteBody));
        }
    }
}
