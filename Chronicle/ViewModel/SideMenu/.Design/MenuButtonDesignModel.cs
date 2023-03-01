using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chronicle
{
    /// <summary>
    /// Design time data for menu button
    /// </summary>
    public class MenuButtonDesignModel : MenuButtonViewModel
    {
        /// <summary>
        /// A single instance of this class
        /// </summary>
        public static MenuButtonDesignModel Instance => new MenuButtonDesignModel();

        /// <summary>
        /// Default constructor
        /// </summary>
        public MenuButtonDesignModel()
        {
            MenuIcon = IconType.Note;
            MenuTitle = "Note";
        }
    }
}
