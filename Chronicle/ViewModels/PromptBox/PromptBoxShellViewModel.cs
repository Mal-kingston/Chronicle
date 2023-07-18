using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Chronicle
{
    /// <summary>
    /// View model for the <see cref="PromptBoxShell"/> of this application
    /// </summary>
    public class PromptBoxShellViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Buttons for the prompt box
        /// </summary>
        private ObservableCollection<PromptBoxButtonsViewModel> _buttons;

        /// <summary>
        /// The height of this prompt box
        /// </summary>
        public double PromptBoxHeight { get; set; } = 180;

        /// <summary>
        /// The width of this prompt box
        /// </summary>
        public double PromptBoxWidth { get; set; } = 400;

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

        #endregion

        #region Public Events

        /// <summary>
        /// Event that is fired when feed back is received from user
        /// </summary>
        public event EventHandler FeedBackReceived;

        #endregion

        #region Public Commands

        /// <summary>
        /// Command for when button on prompt box is clicked
        /// </summary>
        public ICommand FeedbackCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PromptBoxShellViewModel()
        {
            // Set properties default
            PromptBoxContent = PromptBoxContent.SaveAndExitContent;
            _buttons = new ObservableCollection<PromptBoxButtonsViewModel>();

            // Create commands 
            FeedbackCommand = new ParameterizedRelayCommand(async (parameter) => await Feedback(parameter));
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Sort and respond to user feedback as needed
        /// </summary>
        /// <param name="parameter">The signature of user feedback</param>
        public async Task Feedback(object parameter)
        {
            // TODO: render UI in-accessible if we haven't gotten feedback from user
            switch (PromptBoxContent)
            {
                case PromptBoxContent.SaveAndExitContent:
                    HandleSaveAndExitPromptFeedBack(parameter);
                    break;

                case PromptBoxContent.SaveAsContent:
                    //HandleSaveAsPromptFeedBack(parameter);
                    break;

                default:
                    break;
            }

            // Fire off feedback received event
            OnFeedBackReceived();

            // Return true once done
            await Task.Run(() => true);

        }

        #endregion

        #region Methods

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

        /// <summary>
        /// Handles the save and exit type feedback only
        /// </summary>
        /// <param name="parameter"></param>
        private void HandleSaveAndExitPromptFeedBack(object parameter)
        {
            // If feedback is not of the type made for this function...
            if (PromptBoxContent != PromptBoxContent.SaveAndExitContent)
                // Do nothing
                return;

            // Get the button that was pressed
            var pressedButton = _buttons.FirstOrDefault(btn => btn.FeedBackType.ToString()?.ToLower() == parameter.ToString()?.ToLower());

            // Let UI manager know what type of feedback received
            DI.UIManager.FeedBackResult = pressedButton!.FeedBackType;
        }

        #endregion

        #region Public Event Methods

        /// <summary>
        /// Event call 
        /// </summary>
        public void OnFeedBackReceived()
        {
            // Invoke the feedback received event
            FeedBackReceived?.Invoke(this, EventArgs.Empty);
        }

        #endregion

    }
}
