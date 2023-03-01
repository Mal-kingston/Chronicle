using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// Design model for the Notes list control 
    /// </summary>
    public class NotesListControlDesignModel : NotesListControlViewModel
    {
        /// <summary>
        /// A single instance of this class
        /// </summary>
        public static NotesListControlDesignModel Instance => new NotesListControlDesignModel();

        /// <summary>
        /// Default constructor
        /// </summary>
        public NotesListControlDesignModel()
        {
            // Dummy data
            NoteListItems = new ObservableCollection<ListControlItemViewModel>
            {
                new ListControlItemViewModel
                {
                    FileName = "Walk the dog after work.",
                    Icon = IconType.NotesItem
                },

                new ListControlItemViewModel
                {
                    FileName = "Grocery list.",
                    Icon = IconType.NotesItem
                },

                new ListControlItemViewModel
                {
                    FileName = "Tasks to complete at work.",
                    Icon = IconType.NotesItem
                },

                new ListControlItemViewModel
                {
                    FileName = "Meeting at 10am with CEO.",
                    Icon = IconType.NotesItem
                },

                new ListControlItemViewModel
                {
                    FileName = "This year meditation session times.",
                    Icon = IconType.NotesItem
                },

                new ListControlItemViewModel
                {
                    FileName = "Gym membership code.",
                    Icon = IconType.NotesItem
                },

            };
        }

    }
}
