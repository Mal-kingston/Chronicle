using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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
            SaveAs = "SaveAs";
            Delete = "Delete";
            Print = "Print";
            Share = "Share";
            Template = "Template";

            // Create commands
            //SaveCommand = new RelayCommand(SaveToDataStore);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Save data to the datastore
        /// </summary>
        //private void SaveToDataStore() { }

        #endregion

    }
}
