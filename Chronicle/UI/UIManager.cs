using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Chronicle
{
    /// <summary>
    /// The UI manager of this application
    /// </summary>
    public class UIManager : IUIManager
    {
        #region Public Properties

        /// <summary>
        /// The prompt window
        /// </summary>
        public PromptBoxWindow PromptWindow { get; set; } = null!;

        /// <summary>
        /// Prompt box view model
        /// </summary>
        public PromptBoxShellViewModel PromptShell { get; set; } = null!;

        /// <summary>
        /// Result of feed back from user
        /// </summary>
        public PromptBoxFeedBackType FeedBackResult { get; set; } = PromptBoxFeedBackType.None;

        /// <summary>
        /// Decides when invoked prompt box call is completed
        /// Set to true to complete this call. 
        /// </summary>
        public TaskCompletionSource<bool> Conditioner { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UIManager()
        {
            // Set properties
            Conditioner = new TaskCompletionSource<bool>();
            PromptShell = new PromptBoxShellViewModel();

            // Hook up to events
            PromptShell.FeedBackReceived += OnFeedBackReceived;

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Closes the prompt box
        /// </summary>
        public void ClosePromptBox()
        {
            try
            {
                // Reset the shell and message of the prompt 
                DI.BasicPromptVM.Query = null;
                PromptShell.PromptBoxContent = PromptBoxContent.None;
                PromptShell.Buttons.Clear();
                PromptWindow.Content = new PromptBoxShell { DataContext = PromptShell }; ;
            }
            finally
            {
                // Jump on main thread
                Application.Current.Dispatcher.Invoke(()
                    // Close the window
                    => PromptWindow?.Close());
            }
        }

        /// <summary>
        /// Invoke the prompt box
        /// </summary>
        /// <param name="queryType">The type of prompt box</param>
        /// <param name="query">The optional message to show in the prompt</param>
        /// <param name="buttons">The buttons to be added as needed for the prompt box</param>
        public async Task InvokePromptBox(PromptBoxContent queryType, string query = null!, PromptBoxButtonsViewModel[] buttons = null!)
        {
            // Create a window for the prompt
            PromptWindow = new PromptBoxWindow();

            // Set prompt window content
            PromptWindow.Content = new PromptBoxShell { DataContext = PromptShell };
            // Set main window as owner of prompt box window
            PromptWindow.Owner = Application.Current.MainWindow;
            // Make sure we show in the center of the application
            PromptWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            // If we have a simple query...
            if (query != null)
                // Set it
                DI.BasicPromptVM.Query = query;

            // Set content of the shell
            PromptShell.PromptBoxContent = queryType;
            // Make sure we are using our button
            PromptShell.Buttons.Clear();
            // Add button
            PromptShell.AddButtons(buttons);

            // Get all the buttons
            foreach (var button in buttons)
                // Wire button commands
                button.ButtonAction = PromptShell.FeedbackCommand;

            // Show the window
            PromptWindow.ShowDialog();

            // Return task result
            await Conditioner.Task;

        }

        #endregion

        #region Event Methods

        /// <summary>
        /// Completes and closes prompt box once user feedback has been received
        /// </summary>
        /// <param name="sender">Origin of the call</param>
        /// <param name="e">Event argument</param>
        private void OnFeedBackReceived(object? sender, System.EventArgs e)
        {
            // Make sure we get feed back from user before proceeding
            if (FeedBackResult != PromptBoxFeedBackType.None)
            {
                // Done
                Conditioner.TrySetResult(true);

                // Close prompt box
                ClosePromptBox();
            }

        }

        #endregion

    }
}
