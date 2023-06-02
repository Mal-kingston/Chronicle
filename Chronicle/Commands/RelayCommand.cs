using System;
using System.Windows.Input;

namespace Chronicle
{
	/// <summary>
	/// A simple relay command 
	/// </summary>
	public class RelayCommand : ICommand
	{
		#region Private Properties

		/// <summary>
		/// An action to run
		/// </summary>
		private Action mAction;

        #endregion

        #region Public Events

        /// <summary>
        /// The event that gets fired 
        /// </summary>
        public event EventHandler? CanExecuteChanged = (sender, e) => { };

		#endregion

		#region Command Methods

		/// <summary>
		/// Can always execute 
		/// </summary>
		/// <param name="parameter"></param>
		/// <returns></returns>
		public bool CanExecute(object? parameter)
		{
			return true;
		}

		/// <summary>
		/// Runs the action
		/// </summary>
		/// <param name="parameter"></param>
		public void Execute(object? parameter)
		{
			// The action
			mAction();
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Defualt constructor
		/// </summary>
		public RelayCommand(Action action)
		{
			mAction = action;
		}

        #endregion
    }
}
