using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chronicle
{
    /// <summary>
    /// Interaction logic for ContextMenu.xaml
    /// </summary>
    public partial class ContextMenuControl : UserControl
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ContextMenuControl()
        {
            InitializeComponent();

            // Hook up to visibility changed event
            IsVisibleChanged += (s, e) =>
            {
                // If we're not visible...
                if (!IsVisible)
                    // Reset our template button (toggle button) checked state to not checked
                    TemplateButton.IsChecked = false;
            };
        }
    }
}
