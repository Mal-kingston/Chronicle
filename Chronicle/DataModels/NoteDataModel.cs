using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// Data associated with file to be saved to database
    /// </summary>
    public class NoteDataModel
    {
        /// <summary>
        /// Unique id associated with this file as a 
        /// Unique id or primary key for db.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Header of this file
        /// </summary>
        public string Header { get; set; } = string.Empty;

        /// <summary>
        /// Title of this file
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Main content of this file
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// The template associated with this file
        /// </summary>
        public TabContentTemplates Template { get; set; }

        /// <summary>
        /// Flag indicating if this item is in recycle bin
        /// </summary>
        public bool IsInRecycle { get; set; } = false;

        /// <summary>
        /// Date time associated with this file
        /// (Such as date file was created, modified or deleted)
        /// </summary>
        public DateTime AssociatedDate { get; set; } 

    }

}
