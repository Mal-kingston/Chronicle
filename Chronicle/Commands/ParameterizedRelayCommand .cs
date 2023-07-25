using System;
using System.Windows.Input;

namespace Chronicle
{
	/// <summary>
	/// Parameterized relay command 
	/// </summary>
	public class ParameterizedRelayCommand : ICommand
	{
		#region Private Properties

		/// <summary>
		/// An action to run
		/// </summary>
		private Action<object> mAction;

        #endregion

        #region Public Events

        /// <summary>
        /// The event that gets fired 
        /// </summary>
        public event EventHandler? CanExecuteChanged = (sender, e) => { };

		#endregion

		#region Constructor

		/// <summary>
		/// Default constructor
		/// </summary>
		public ParameterizedRelayCommand(Action<object> action)
		{
			mAction = action;
		}

        #endregion

        #region Command Methods

        /// <summary>
        /// Can always execute 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public virtual bool CanExecute(object? parameter)
        {
           return true;
        }

        /// <summary>
        /// Runs the action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object? parameter)
        {
            if (parameter == null)
                return;

            // Run the action
            mAction(parameter);
        }

        #endregion

    }
}
