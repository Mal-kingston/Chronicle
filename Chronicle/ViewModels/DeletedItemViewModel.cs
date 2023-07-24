using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
        /// Default constructor
        /// </summary>
        public DeletedItemViewModel()
        {
            // Create commands
            SelectCommand = new RelayCommand(() => IsSelected ^= true);
        }

    }
}
