using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chronicle
{
    /// <summary>
    /// View model for <see cref="PromptBoxButtonControl"/>
    /// </summary>
    public class PromptBoxButtonsViewModel : BaseViewModel
    {
        /// <summary>
        /// Button content
        /// </summary>
        public string ButtonContent { get; set; } = string.Empty;

        /// <summary>
        /// True if a button should be highlighted
        /// </summary>
        public bool HighlightButton { get; set; } 

        /// <summary>
        /// The size of highlight on this button 
        /// </summary>
        public double BorderThickness => HighlightButton ? 1 : 0;

        /// <summary>
        /// Function to run when button is clicked
        /// </summary>
        public ICommand? ButtonAction { get; set; } 
    }
}
