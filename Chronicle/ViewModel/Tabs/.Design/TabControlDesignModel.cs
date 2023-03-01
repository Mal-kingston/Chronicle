using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// Design model for tab control
    /// </summary>
    public class TabControlDesignModel : TabControlViewModel
    {
        /// <summary>
        /// A single instance of this class
        /// </summary>
        public static TabControlDesignModel Instance => new TabControlDesignModel();

        /// <summary>
        /// Default constructor
        /// </summary>
        public TabControlDesignModel()
        {
            TabHeader = "Push last code to github";
            IsSelected = true;
        }
    }
}
