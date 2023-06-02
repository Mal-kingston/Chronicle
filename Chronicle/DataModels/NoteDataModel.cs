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
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Header or title of this file
        /// </summary>
        public string Header { get; set; } = string.Empty;

        /// <summary>
        /// Main content of this file
        /// </summary>
        public string Content { get; set; } = string.Empty;

    }

}
