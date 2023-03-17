using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Chronicle
{
	/// <summary>
	/// A base view model that fires a property changed event 
	/// </summary>
	public class BaseViewModel : INotifyPropertyChanged
	{
		/// <summary>
		/// The event that gets fired when needed
		/// </summary>
		public event PropertyChangedEventHandler? PropertyChanged = (sender, e) => { };

		/// <summary>
		/// Call this to run <see cref="PropertyChanged"/> event
		/// </summary>
		/// <param name="PropertyName"></param>
		public void OnPropertyChanged(string PropertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
		}

		#region Command Helpers

		/// <summary>
		/// Runs a command if the updating flag is not set.
		/// If the flag is true (indicating the function is already running) then the action is not run.
		/// If the flag is false (indicating no running function) then the action is run.
		/// Once the action is finished, if it was run, then the flag is reset to false.
		/// </summary>
		/// <param name="updatingFlag">The boolean property flag defining if the command is already running</param>
		/// <param name="action">The action to run if the command is not already running</param>
		/// <returns></returns>
		//protected async Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action)
		//{
		//	// Lock to ensure single access to check
		//	lock(updatingFlag)
		//	{
		//		// Check if the updating flag is true Meaning the function is already running
		//		if (updatingFlag.GetPropertyValue())
		//			// If the function is already running do nothing
		//			return;

		//		// Set the property flag to true to indicate function is running
		//		updatingFlag.SetPropertyValue(true);
  //          }

  //          try
  //          {
		//		// Run the passed in action
		//		await action();
		//	}
		//	finally
		//	{
		//		// Reset the property flag to false when it's done
		//		updatingFlag.SetPropertyValue(false);
		//	}
		//}

        /// <summary>
        /// Runs a command if the updating flag is not set.
        /// If the flag is true (indicating the function is already running) then the action is not run.
        /// If the flag is false (indicating no running function) then the action is run.
        /// Once the action is finished, if it was run, then the flag is reset to false.
        /// </summary>
        /// <param name="updatingFlag">The boolean property flag defining if the command is already running</param>
        /// <param name="action">The action to run if the command is not already running</param>
		/// <typeparam name="T">The type the action returns</typeparam>
        /// <returns></returns>
        //protected async Task<T> RunCommand<T>(Expression<Func<bool>> updatingFlag, Func<Task<T>> action, T defaultValue = default(T))
        //{
        //    // Lock to ensure single access to check
        //    lock (updatingFlag)
        //    {
        //        // Check if the updating flag is true Meaning the function is already running
        //        if (updatingFlag.GetPropertyValue())
        //            // If the function is already running do nothing
        //            return defaultValue;

        //        // Set the property flag to true to indicate function is running
        //        updatingFlag.SetPropertyValue(true);
        //    }

        //    try
        //    {
        //        // Run the passed in action
        //        return await action();
        //    }
        //    finally
        //    {
        //        // Reset the property flag to false when it's done
        //        updatingFlag.SetPropertyValue(false);
        //    }
        //}


        #endregion
    }
}
