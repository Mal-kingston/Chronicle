using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;

namespace Chronicle
{
    /// <summary>
    /// Design-model for <see cref="PromptBoxShell"/> control
    /// </summary>
    public class PromptBoxShellDesignModel : PromptBoxShellViewModel
    {
        /// <summary>
        /// The content for the design instance
        /// </summary>
        public static TextBlock? DesignContent { get; set; } 

        /// <summary>
        /// Single instance of this object
        /// </summary>
        public static PromptBoxShellDesignModel Instance = new PromptBoxShellDesignModel();

        /// <summary>
        /// Default constructor
        /// </summary>
        public PromptBoxShellDesignModel()
        {
            // Sample buttons
            Buttons = new ObservableCollection<PromptBoxButtonsViewModel>
            {
                new PromptBoxButtonsViewModel { ButtonContent = "Save", HighlightButton = true }, 
                new PromptBoxButtonsViewModel { ButtonContent = "Don't save" }, 
                new PromptBoxButtonsViewModel { ButtonContent = "Cancel" }
            };

            // Configuration of the content to display
            DesignContent = new TextBlock
            {
                Text = "Do you want to save this file ?",
                Foreground = new SolidColorBrush(Colors.Gray),
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                FontFamily = (FontFamily)Application.Current.FindResource("JostFont"),
                FontSize = (double)Application.Current.FindResource("Regular"),
            };
        }
    }
}
