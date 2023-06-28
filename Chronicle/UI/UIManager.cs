﻿using System.Threading.Tasks;
using System.Windows;

namespace Chronicle
{
    /// <summary>
    /// The UI manager of this application
    /// </summary>
    public class UIManager : IUIManager
    {
        /// <summary>
        /// Invoke the prompt box
        /// </summary>
        /// <param name="queryType">The type of prompt box</param>
        /// <param name="query">The optional message to show in the prompt</param>
        /// <param name="buttons">The buttons to be added as needed for the prompt box</param>
        public void InvokePromptBox(PromptBoxContent queryType, string query = null!, PromptBoxButtonsViewModel[] buttons = null!)
        {
            // TODO: Turn this function into TASK 

            // If query we have query...
            if(query != null)
                // Set it
                DI.PromptQueryVM.Query = query;
            
            // Get prompt window
            var window = new PromptBoxWindow();

            // Get prompt box shell view-model
            var promptShell = new PromptBoxShellViewModel();

            // Set content of the shell
            promptShell.PromptBoxContent = queryType;
            // Make sure we are using our button
            promptShell.Buttons.Clear();
            // Add button
            promptShell.AddButtons(buttons);

            foreach (var button in buttons)
                button.ButtonAction = promptShell.FeedbackCommand;
            
            // Set prompt window content
            window.Content = new PromptBoxShell { DataContext = promptShell };
            
            // Set main window as owner of prompt box window
            window.Owner = Application.Current.MainWindow;
            // Make sure we show in the center of the application
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            // Show the window
            window.Show();

        }
    }
}
