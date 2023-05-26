using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Chronicle
{
    /// <summary>
    /// Apply styling to the context menu buttons
    /// </summary>
    public class ContexMenuButtonStyleAttachedProperties : BaseAttachedProperty<ContexMenuButtonStyleAttachedProperties, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Get the control
            var control = (sender as Panel);

            // If the control is null...
            if (control == null)
                // Do nothing
                return;

            // Wait for the control to load
            control.Loaded += (s, e) =>
            {
                // Go through child element of controls
                foreach (var child in control.Children)
                {
                    // If the child is of type button...
                    if(child is Button)
                        // Apply the defined styling
                        ((Button)child).Style = (Style)Application.Current.FindResource("ContextMenuButtonStyle");
                }
            };
        }
    }
}
