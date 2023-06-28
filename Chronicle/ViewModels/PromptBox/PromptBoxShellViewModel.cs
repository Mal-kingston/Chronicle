using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace Chronicle
{
    /// <summary>
    /// View model for the <see cref="PromptBoxShell"/> of this applicaiton
    /// </summary>
    public class PromptBoxShellViewModel : BaseViewModel
    {
        /// <summary>
        /// Buttons for the prompt box
        /// </summary>
        private ObservableCollection<PromptBoxButtonsViewModel> _buttons;

        /// <summary>
        /// The height of this prompt box
        /// </summary>
        public double PromptBoxHeight { get; set; } = 160;

        /// <summary>
        /// The width of this prompt box
        /// </summary>
        public double PromptBoxWidth { get; set; } = 360;

        /// <summary>
        /// Content of this prompt-box
        /// </summary>
        public PromptBoxContent PromptBoxContent { get; set; }

        /// <summary>
        /// Buttons for the prompt box
        /// </summary>
        public ObservableCollection<PromptBoxButtonsViewModel> Buttons 
        {
            // Get button
            get => _buttons;
            set
            {
                // Set buttons 
                _buttons = value;

                // Update button
                OnPropertyChanged(nameof(_buttons));
            }
        }

        /// <summary>
        /// Command for when button is clicked
        /// </summary>
        public ICommand FeedbackCommand { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public PromptBoxShellViewModel()
        {
            // Set properties default
            PromptBoxContent = PromptBoxContent.PromptQueryContent;
            _buttons = new ObservableCollection<PromptBoxButtonsViewModel>();

            // Create commands 
            FeedbackCommand = new ParameterizedRelayCommand((parameter) => Feedback(parameter));
        }

        private void Feedback(object parameter)
        {
            // TODO: render UI in-accessible if we haven't gotten feedback from user
        }

        /// <summary>
        /// Adds button controls to the prompt box
        /// Note: Max buttons prompt can have at a time is 3
        /// </summary>
        /// <param name="button">The buttons to add</param>
        public void AddButtons(PromptBoxButtonsViewModel[] button)
        {
            // UI optimized for up to 3 buttons at a time
            if (button.Count() > 3)
                return;

            // Add buttons to list
            button.ToList().ForEach(btn => _buttons.Add(btn));
        }
        
    }
}
