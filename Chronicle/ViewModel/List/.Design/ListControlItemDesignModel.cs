using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// Design model for the list control item
    /// </summary>
    public class ListControlItemDesignModel : ListControlItemViewModel
    {
        /// <summary>
        /// A single instance of this class
        /// </summary>
        public static ListControlItemDesignModel Instance => new();

        /// <summary>
        /// Default constructor
        /// </summary>
        public ListControlItemDesignModel()
        {
            // For design-time
            FileName = "Walk the dog";
            Icon = IconType.NotesItem;
        }
    }
}
