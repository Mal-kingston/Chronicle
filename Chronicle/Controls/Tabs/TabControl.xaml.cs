using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Chronicle
{
    /// <summary>
    /// Interaction logic for TabControl.xaml
    /// </summary>
    public partial class TabControl : UserControl
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public TabControl()
        {
            InitializeComponent();

            // The main window of this application
            var mainWindow = (MainWindow)Application.Current.MainWindow;

            // Whenever scroll changes
            scrollViewer.ScrollChanged += (s, e) =>
            {
                // Check if a new tab is added, if true...
                if (ViewModelLocator.Instance.LocateTabControlVM?.NewTabAdded == true)
                {
                    // Scroll scroll-viewer content to the right end
                    scrollViewer.ScrollToRightEnd();
                    // Reset the tab added flag
                    ViewModelLocator.Instance.LocateTabControlVM.NewTabAdded = false;
                }

                // Adjust scrolling controls accordingly
                AdjustScrollControls();
            };

            //  Adjust scrolling controls accordingly whenever window size changes (maximize | normal)
            mainWindow.SizeChanged += (s, e) => AdjustScrollControls();

            // Adjust tabs 
            AdjustTabs();
        }

        /// <summary>
        /// Hides and shows the scroll-viewer buttons when needed
        /// </summary>
        public Visibility ScrollViewerButtonVisibility
        {
            get { return (Visibility)GetValue(ScrollViewerButtonVisibilityProperty); }
            set { SetValue(ScrollViewerButtonVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ScrollViewerButtonVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScrollViewerButtonVisibilityProperty =
            DependencyProperty.Register("ScrollViewerButtonVisibility", typeof(Visibility), typeof(TabControl), new PropertyMetadata(defaultValue:Visibility.Collapsed));

        /// <summary>
        /// Scroll contents to the right
        /// Therefore bringing contents hidden on the left side into view
        /// </summary>
        private void LeftButtonContentScroller(object sender, RoutedEventArgs e) => scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - 160);

        /// <summary>
        /// Scroll contents to the left
        /// Therefore bringing contents hidden on the right side into view
        /// </summary>
        private void RightButtonContentScroller(object sender, RoutedEventArgs e) => scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset + 160);

        /// <summary>
        /// Adjust scrolling controls accordingly
        /// </summary>
        private void AdjustScrollControls()
        {
            if (topRow.ActualWidth < (scrollViewer.ExtentWidth + 144))
            {
                ScrollViewerButtonVisibility = Visibility.Visible;
                scrollColumn.Width = new GridLength(1, GridUnitType.Star);
            }
            else
            {
                ScrollViewerButtonVisibility = Visibility.Collapsed;
                scrollColumn.Width = new GridLength(0, GridUnitType.Auto);
            }
        }

        /// <summary>
        /// Adjust tabs when either of the semi-hidden far end tabs are selected
        /// </summary>
        private void AdjustTabs()
        {
            // TODO: Find a better way to react to tabs collection when user clicks on a tab that is not fully visible
            scrollViewer.PreviewMouseDown += (s, e) =>
            {
                var pos = Mouse.GetPosition(Application.Current.MainWindow).X;

                if(Application.Current.MainWindow.WindowState == WindowState.Maximized)
                {
                    if (pos >= 312 && pos <= 380)
                        scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - 75);
                    else if(pos >= 1750 && pos <= 1830)
                        scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset + 75);
                }
                else if (pos >= 312 && pos <= 380)
                    scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - 89);
                else if (pos >= 1111 && pos <= 1180)
                    scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset + 89);

            };

        }

    }
}
