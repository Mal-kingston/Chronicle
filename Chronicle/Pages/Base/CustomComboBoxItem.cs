using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chronicle
{
    /// <summary>
    /// Combo-box item helper to simplify or shorten input-binding of bug standard <see cref="ComboBox"/> in vanilla WPF
    /// </summary>
    public class CustomComboBoxItem : ComboBoxItem
    {
        /// <summary>
        /// Mouse binding object
        /// </summary>
        private MouseBinding MouseBinding;

        /// <summary>
        /// Default constructor for this helper class
        /// </summary>
        public CustomComboBoxItem() : base()
        {
            // Initialize mouse binding
            MouseBinding = new MouseBinding();

            // Hook onto loaded event of this control
            Loaded += (s, e) =>
            {
                // Set mouse binding properties
                MouseBinding.MouseAction = MouseAction.LeftClick;
                MouseBinding.Command = (ICommand)GetValue(ControlCommandProperty);

                // Add mouse binding to input binding
                InputBindings.Add(MouseBinding);
            };
        }

        /// <summary>
        /// Bindable object 
        /// 
        /// <remark>
        /// Aid in routing command from datacontext of this control to the mouse binding command in this helper class
        /// </remark>
        /// </summary>
        public ICommand ControlCommand
        {
            get { return (ICommand)GetValue(ControlCommandProperty); }
            set { SetValue(ControlCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ControlCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ControlCommandProperty =
            DependencyProperty.Register("ControlCommand", typeof(ICommand), typeof(CustomComboBoxItem));

    }
}
