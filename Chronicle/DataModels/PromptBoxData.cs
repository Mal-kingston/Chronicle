namespace Chronicle
{
    /// <summary>
    /// Kinds of contents prompt box can have
    /// </summary>
    public enum PromptBoxContent
    {
        // Add content as needed
        // ----------------------------

        /// <summary>
        /// Prompt query prompt
        /// (Basic text prompts such as: Save before exit | Delete | Restore file )
        /// </summary>
        SaveAndExitContent = 1,

        /// <summary>
        /// Save-as prompt
        /// </summary>
        SaveAsContent = 2,

        /// <summary>
        /// Print prompt
        /// </summary>
        PrintContent = 3,
    }

    /// <summary>
    /// The types of feed back in prompt box
    /// </summary>
    public enum PromptBoxFeedBackType
    {
        /// <summary>
        /// No feedback
        /// </summary>
        None = 0,

        /// <summary>
        /// Save
        /// </summary>
        Save = 1,

        /// <summary>
        /// Do not save
        /// </summary>
        DontSave = 2,

        /// <summary>
        /// Cancel
        /// </summary>
        Cancel = 3,

        /// <summary>
        /// Ok (acknowledge)
        /// </summary>
        Ok = 4,
    }

}