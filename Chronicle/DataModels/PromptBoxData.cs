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
        PromptQueryContent = 1,

        /// <summary>
        /// Save-as prompt
        /// </summary>
        SaveAsContent = 2,

        /// <summary>
        /// Print prompt
        /// </summary>
        PrintContent = 3,
    }

}
