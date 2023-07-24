using System;
using System.Threading.Tasks;
using System.Windows.Input;
using static Chronicle.DI;

namespace Chronicle
{
    /// <summary>
    /// View model for the <see cref="ContextMenuControl"/>
    /// </summary>
    public class ContextMenuViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Content of the Save button of the context menu
        /// </summary>
        public string Save { get; set; }

        /// <summary>
        /// Content of the Save-as button of the context menu
        /// </summary>
        public string SaveAs { get; set; }

        /// <summary>
        /// Content of the Delete button of the context menu
        /// </summary>
        public string Delete { get; set; }

        /// <summary>
        /// Content of the Print button of the context menu
        /// </summary>
        public string Print { get; set; }

        /// <summary>
        /// Content of the Share button of the context menu
        /// </summary>
        public string Share { get; set; }

        /// <summary>
        /// Content of the Template button of the context menu
        /// </summary>
        public string Template { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// Command to save file to the database
        /// </summary>
        public ICommand SaveCommand { get; set; }

        /// <summary>
        /// Command to save a file to the database 
        /// with a specified name by user
        /// </summary>
        public ICommand SaveAsCommand { get; set; }

        /// <summary>
        /// Command to delete file from the database
        /// </summary>
        public ICommand DeleteCommand { get; set; }

        /// <summary>
        /// Command to print a file
        /// </summary>
        public ICommand PrintCommand { get; set; }

        /// <summary>
        /// Command to share a file (via internet)
        /// </summary>
        public ICommand ShareCommand { get; set; }

        /// <summary>
        /// Command to select a preferred template
        /// </summary>
        public ICommand ChooseTemplateCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ContextMenuViewModel()
        {
            // Set properties
            Save = "Save";
            SaveAs = "Save as";
            Delete = "Delete";
            Print = "Print";
            Share = "Share";
            Template = "Template";

            // Create commands
            SaveCommand = new ParameterizedRelayCommand(async (parameter) => await SaveData(parameter));
            DeleteCommand  = new ParameterizedRelayCommand(async (parameter) => await DeleteData(parameter));

        }

        #endregion

        #region Public Command Methods

        /// <summary>
        /// Deletes data from data base
        /// </summary>
        /// <param name="parameter">Signature of data to delete</param>
        /// <returns></returns>
        private async Task DeleteData(object parameter)
        {
            await TabControlVM.Delete(parameter);
        }

        /// <summary>
        /// Saves data to database
        /// </summary>
        /// <param name="parameter">Signature of data to save</param>
        /// <returns></returns>
        private async Task SaveData(object parameter)
        {
            await TabControlVM.Save(parameter);
        }

        #endregion


    }
}
