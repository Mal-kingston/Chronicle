using System;
using System.Windows.Input;

namespace Chronicle
{
	/// <summary>
	/// Simple relay command with a parameter
	/// </summary>
	public class RelayParameterizedCommand : ICommand
	{
		#region Private Members

		/// <summary>
		/// The action to run when needed
		/// </summary>
		private Action<object> myAction;

		#endregion

		#region Public Events

		/// <summary>
		/// Event to fire/call
		/// </summary>
		public event EventHandler CanExecuteChanged = (sender, e) => { };

		#endregion

		#region Constructor 

		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <param name="action"></param>
		public RelayParameterizedCommand(Action<object> action)
		{
			myAction = action;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Configure can execute method to always be true
		/// </summary>
		/// <param name="parameter"></param>
		/// <returns></returns>
		public bool CanExecute(object parameter) => true;

		/// <summary>
		/// Run and action
		/// </summary>
		/// <param name="parameter">The passed in parameter</param>
		public void Execute(object parameter)
		{
			// Run action
			myAction(parameter);
		}

		#endregion
	}
}
