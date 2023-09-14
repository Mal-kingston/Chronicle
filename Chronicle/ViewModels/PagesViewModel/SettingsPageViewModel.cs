using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chronicle
{
    /// <summary>
    /// View model for the settings view
    /// </summary>
    public class SettingsPageViewModel : BaseViewModel
    {
        /// <summary>
        /// Command to set tab template to use lined template
        /// </summary>
        public ICommand LinedTemplateCommand { get; set; }

        /// <summary>
        /// Command to set tab template to use plain template
        /// </summary>
        public ICommand PlainTemplateCommand { get; set; }

        /// <summary>
        /// Command to set tab template to use lined with margin template
        /// </summary>
        public ICommand LinedWithMarginTemplateCommand { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public SettingsPageViewModel()
        {
            // Create commands
            LinedTemplateCommand = new RelayCommand(() => DI.TabContentVM.Template = TabContentTemplates.Lined);
            PlainTemplateCommand = new RelayCommand(() => DI.TabContentVM.Template = TabContentTemplates.Plain);
            LinedWithMarginTemplateCommand = new RelayCommand(() => DI.TabContentVM.Template = TabContentTemplates.LinedWithMargin);
        }
    }
}
