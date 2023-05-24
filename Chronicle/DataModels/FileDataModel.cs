using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// Data associated with file to be saved to database
    /// </summary>
    public class FileDataModel
    {
        /// <summary>
        /// Unique id associated with this file as a 
        /// Unique id or primary key for db.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Date and time file is created
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Header or title of this file
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Main content of this file
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public FileDataModel()
        {
            // Set properties
            Id = string.Empty;
            DateTime = DateTime.UtcNow;
            Header = string.Empty;
            Content = string.Empty;
        }
    }
}
