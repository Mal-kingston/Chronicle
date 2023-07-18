namespace Chronicle
{
    /// <summary>
    /// View model for <see cref="SaveAndExitControl"/>
    /// (Basic prompt message)
    /// </summary>
    public class SaveAndExitPromptViewModel
    {
        /// <summary>
        /// Query for user
        /// </summary>
        public string? Query { get; set; } = "Do you want to save this file ?";
    }
}
