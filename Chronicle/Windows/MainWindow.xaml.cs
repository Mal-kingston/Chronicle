using System;
using System.ComponentModel;
using System.Configuration;
using System.Windows;

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
            // Initialize 
            InitializeComponent();

            // Data context
            DataContext = DI.MainVM;

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

    }
}
