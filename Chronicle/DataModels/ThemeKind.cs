namespace Chronicle
{
    /// <summary>
    /// The types of themes available in this application
    /// 
    /// <remark>
    /// The default themes has light blue accent color
    /// </remark>
    /// </summary>
    public enum ThemeKind
    {
        /// <summary>
        /// Light theme
        /// </summary>
        LightTheme = 0,

        /// <summary>
        /// Dark theme
        /// </summary>
        DarkTheme = 1,

        /// <summary>
        /// Theme based on the mode of the machine this application is running on (Dark or Light)
        /// </summary>
        UseSystemSettings
    }
}
