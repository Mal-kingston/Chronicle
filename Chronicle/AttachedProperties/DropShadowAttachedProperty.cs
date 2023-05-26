using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Chronicle
{
    /// <summary>
    /// Applies drop shadow to an element
    /// </summary>
    public class DropShadowAttachedProperty : BaseAttachedProperty<DropShadowAttachedProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Get the element to attach to
            var element = (sender as FrameworkElement);

            // If element is null...
            if (element == null)
                // Do nothing
                return;

            // Create drop shadow effect
            var dropshadow = new DropShadowEffect
            {
                Opacity = 0.6,
                Color = (Color)Application.Current.FindResource("Blue"),
                Direction = 270,
                BlurRadius = 12,
                ShadowDepth = 0,
            };

            // Apply effect
            element.Effect = dropshadow;
        }
    }
}
