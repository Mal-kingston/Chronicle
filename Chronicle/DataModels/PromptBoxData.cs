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
        /// No content
        /// </summary>
        None = 0,

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

        /// <summary>
        /// Prompt for when user want to actually delete an item
        /// </summary>
        DeleteRecycledItemContent = 4,
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

        /// <summary>
        /// Yes proceed or Yes agree
        /// </summary>
        Yes = 5,

        /// <summary>
        /// No user don't approve
        /// </summary>
        No = 6,
    }

}