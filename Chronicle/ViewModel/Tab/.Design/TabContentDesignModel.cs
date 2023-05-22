using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// Design-model for <see cref="TabContentControl"/>
    /// </summary>
    public class TabContentDesignModel : TabContentViewModel
    {
        /// <summary>
        /// Single instance of this class
        /// </summary>
        public static TabContentDesignModel Instance { get; set; } = new TabContentDesignModel();

        /// <summary>
        /// Default constructor
        /// </summary>
        public TabContentDesignModel() 
        {
            TitleLabel = "Title";
        }
    }
}
