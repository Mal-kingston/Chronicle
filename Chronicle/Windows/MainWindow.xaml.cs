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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {
            // Initailize 
            InitializeComponent();
            
            // Data context
            DataContext = new MainViewModel();

            // Listen for window size changing
            this.SizeChanged += MainWindow_SizeChanged;
                
        }

        /// <summary>
        /// Update side menu size whenever size of the window changes
        /// </summary>
        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Update side menu height
            SideMenu.Height = this.ActualHeight - AppTitle.ActualHeight;
        }

        private void Main_Activated(object sender, EventArgs e)
        {
            
        }

        private void Main_Deactivated(object sender, EventArgs e)
        {

        }
    }
}
