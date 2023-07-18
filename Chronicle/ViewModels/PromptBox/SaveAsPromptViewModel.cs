namespace Chronicle
{
    /// <summary>
    /// View model for <see cref="SaveAsControl"/> content of promptbox
    /// </summary>
    public class SaveAsPromptViewModel : BaseViewModel
    {

        /// <summary>
        /// Label
        /// </summary>
        public string TextBoxLabel { get; set; } = "File name : ";

        /// <summary>
        /// Place holder text for text box
        /// </summary>
        public string PlaceHolderText { get; set; } = "Enter file name";

        /// <summary>
        /// The file name entered
        /// </summary>
        public string FileName { get; set; } = string.Empty; 

    }
}
