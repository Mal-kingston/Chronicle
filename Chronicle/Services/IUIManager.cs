using System.Threading.Tasks;
using System.Windows;

namespace Chronicle
{
    /// <summary>
    /// The UI manager of this application 
    /// </summary>
    public interface IUIManager
    {
        /// <summary>
        /// The prompt window
        /// </summary>
        Window PromptWindow { get; set; }

        /// <summary>
        /// Prompt box view model
        /// </summary>
        PromptBoxShellViewModel promptShell { get; set; }

        /// <summary>
        /// Result of feed back from user
        /// </summary>
        PromptBoxFeedBackType FeedBackResult { get; set; }

        /// <summary>
        /// Invoke the prompt box
        /// </summary>
        /// <param name="queryType">The type of prompt box</param>
        /// <param name="query">The optional message to show in the prompt</param>
        /// <param name="buttons">The buttons to be added as needed for the prompt box</param>
        Task InvokePromptBox(PromptBoxContent queryType, string query = null!, PromptBoxButtonsViewModel[] buttons = null!);

        /// <summary>
        /// Closes the prompt box
        /// </summary>
        void ClosePromptBox();
    }
}
