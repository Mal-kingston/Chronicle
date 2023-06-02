using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// Design model for <see cref="ContextMenuControl"/>
    /// </summary>
    public class ContextMenuDesignModel : ContextMenuViewModel
    {
        public static ContextMenuDesignModel Instance { get; set; }

        public ContextMenuDesignModel() 
        {
            // Set properties for design-time
            Save = "Save";
            Instance = new ContextMenuDesignModel();        
        }
    }
}
