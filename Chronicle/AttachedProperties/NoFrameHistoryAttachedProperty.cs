using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Chronicle
{
	/// <summary>
	/// Attached property for a <see cref="Frame"/> to navigate content without visible frame navigation bar
	/// and navigation history
	/// </summary>
	public class NoFrameHistoryAttachedProperty : BaseAttachedProperty<NoFrameHistoryAttachedProperty, bool>
	{
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
			// Get the frame
			var frame = (sender as Frame);

			// If we have no frame
			if (frame == null)
				// Do nothing
				return;

			// Hide the UI navigation bar
			frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;

			// Clear the navigation history every single time we navigate
			frame.Navigated += (ss,ee) => ((Frame)ss).NavigationService.RemoveBackEntry();
        }
    }
}