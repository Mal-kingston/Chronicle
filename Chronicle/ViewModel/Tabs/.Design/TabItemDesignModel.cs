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
    public class TabItemDesignModel : TabItemViewModel
    {
        /// <summary>
        /// A single instance of this class
        /// </summary>
        public static TabItemDesignModel Instance => new TabItemDesignModel();

        /// <summary>
        /// Default constructor
        /// </summary>
        public TabItemDesignModel()
        {
            TabHeader = "Untitled";
            IsSelected = true;
        }
    }
}
