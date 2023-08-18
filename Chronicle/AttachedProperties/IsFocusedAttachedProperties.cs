using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Chronicle
{
    /// <summary>
    /// Sets focus om a <see cref="FrameworkElement"/>
    /// </summary>
    public class IsFocusedAttachedProperties : BaseAttachedProperty<IsFocusedAttachedProperties, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Define element
            var control = (sender as FrameworkElement);

            // If element in null...
            if (control == null)
                // Do nothing
                return;

            // Focus the element 
            control.Focus();

            // If element is a text box and has text...
            if(((TextBox)control).Text.Length > 0)
                // Set the carat index to the very end of the text
                ((TextBox)control).CaretIndex = ((TextBox)control).Text.Length;
        }

    }
}
