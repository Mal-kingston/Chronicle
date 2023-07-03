using System.Windows;

namespace Chronicle
{
    /// <summary>
    /// The UI manager of this application 
    /// </summary>
    public interface IUIManager
    {
        Window PromptWindow { get; set; }

        /// <summary>
        /// Invoke the prompt box
        /// </summary>
        /// <param name="queryType">The type of prompt box</param>
        /// <param name="query">The optional message to show in the prompt</param>
        /// <param name="buttons">The buttons to be added as needed for the prompt box</param>
        void InvokePromptBox(PromptBoxContent queryType, string query = null!, PromptBoxButtonsViewModel[] buttons = null!);
        void ClosePromptBox();
    }
}
