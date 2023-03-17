using System;
using System.Windows;

namespace Chronicle
{
    /// <summary>
    /// A base attached Property to replace the WPF Vanilla attached property
    /// </summary>
    /// <typeparam name="Parent">The parent class to be the attached property</typeparam>
    /// <typeparam name="Property">The type of this attached property</typeparam>
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : new()
    {
        #region Public Events

        /// <summary>
        /// The event that gets called whenever value changes
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        /// <summary>
        /// The event that gets called whenever value is updated even if it's the same value
        /// </summary>
        public event Action<DependencyObject, object> ValueUpdated = (sender, value) => { };

        #endregion

        #region Public Properties

        /// <summary>
        /// A single instance of this parent class
        /// </summary>
        public static Parent Instance { get; set; } = new Parent();

        #endregion

        #region Attached Property Definitions

        /// <summary>
        /// The attached property for this class
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached("Value", typeof(Property), typeof(BaseAttachedProperty<Parent, Property>),
                new PropertyMetadata(default(Property), new PropertyChangedCallback(OnValuePropertyChanged), new CoerceValueCallback(OnValuePropertyUpdated)));

        /// <summary>
        /// The callback event when the <see cref="ValueProperty"/> is changed
        /// </summary>
        /// <param name="d">The UI element that had it's property changed</param>
        /// <param name="e">The argument for the event</param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Call the parent function
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueChanged(d, e);

            // Call event listeners
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueChanged(d, e);
        }

        /// <summary>
        /// The callback event when the <see cref="ValueProperty"/> is changed, even if it's the same value
        /// </summary>
        /// <param name="d">The UI element that had it's property changed</param>
        /// <param name="e">The argument for the event</param>
        private static object OnValuePropertyUpdated(DependencyObject d, object value)
        {
            // Call the parent function
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueUpdated(d, value);

            // Call event listeners
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueUpdated(d, value);

            // Return the value
            return value;
        }

        /// <summary>
        /// Gets the attached Property
        /// </summary>
        /// <param name="d">The element to get property from</param>
        /// <returns></returns>
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);

        /// <summary>
        /// Sets the attached property
        /// </summary>
        /// <param name="d">The element to get value from</param>
        /// <param name="value">The value to set the property to</param>
        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);

        #endregion

        #region Event Methods

        /// <summary>
        /// The method that is called when any attached property of this type is changed
        /// </summary>
        /// <param name="sender">The UI element that this property is changed for</param>
        /// <param name="e">The argument for the event</param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }

        /// <summary>
        /// The method that is called when any attached property of this type is changed, even i it's the same value
        /// </summary>
        /// <param name="sender">The UI element that this property is changed for</param>
        /// <param name="e">The argument for the event</param>
        public virtual void OnValueUpdated(DependencyObject sender, object value) { }

        #endregion
    }
}
