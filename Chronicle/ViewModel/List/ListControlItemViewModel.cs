using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chronicle
{
    /// <summary>
    /// View model for list item
    /// </summary>
    public class ListControlItemViewModel : BaseViewModel
    {
        /// <summary>
        /// Name of each file
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Type of icon to use
        /// </summary>
        public IconType Icon { get; set; }

    }
}
