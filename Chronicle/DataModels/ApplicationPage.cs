using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// The views of this application
    /// </summary>
    public enum ApplicationPage
    {
        /// <summary>
        /// No page
        /// </summary>
        None,

        /// <summary>
        /// Note file
        /// </summary>
        NoteFile,

        /// <summary>
        /// Book file
        /// </summary>
        BookFile,

        /// <summary>
        /// Calendar and (time) page
        /// </summary>
        Calendar,

        /// <summary>
        /// Share page
        /// </summary>
        Share,

        /// <summary>
        /// Settings page
        /// </summary>
        Settings,

        /// <summary>
        /// Trash page
        /// </summary>
        Trash,
    }
}
