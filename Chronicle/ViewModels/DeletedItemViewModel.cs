using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Chronicle.DI;

namespace Chronicle
{
    /// <summary>
    /// View model for deleted item
    /// </summary>
    public class DeletedItemViewModel : BaseViewModel
    {
        /// <summary>
        /// The id of this item
        /// </summary>
        public Guid ItemId { get; set; }

        /// <summary>
        /// The name of this file
        /// </summary>
        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// The type of this file
        /// </summary>
        public FileType FileType { get; set; } = FileType.Note;

        /// <summary>
        /// The date this file was deleted
        /// </summary>
        public string DeletedDate { get; set; } = string.Empty;

        /// <summary>
        /// True if this file is selected
        /// Otherwise false
        /// </summary>
        public bool IsSelected { get; set; } = false;

        /// <summary>
        /// Command to select specific item(s)
        /// </summary>
        public ICommand SelectCommand { get; set; }

        /// <summary>
        /// The event to fire when property (IsSelected) of this item is true
        /// </summary>
        public event EventHandler SelectedChanged;

        /// <summary>
        /// Default constructor
        /// </summary>
        public DeletedItemViewModel(RecycleBinViewModel recycleBinViewModel)
        {
            // Create commands
            SelectCommand = new RelayCommand(() =>
            {
                // Toggle and set true | false value
                IsSelected ^= true;

                // Fire event 
                SelectedChanged?.Invoke(this, EventArgs.Empty);

            });

            // Subscribe to event
            SelectedChanged += recycleBinViewModel.OnSelectionChanged!;
        }

    }
}
