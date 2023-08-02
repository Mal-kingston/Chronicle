namespace Chronicle
{
    /// <summary>
    /// View model for basic prompt
    /// (Basic prompt message)
    /// </summary>
    public class BasicPromptViewModel : BaseViewModel
    {
        private string _query = string.Empty;

        /// <summary>
        /// Query for user
        /// </summary>
        public string? Query 
        {
            get => _query;
            set
            {
                if (value == null)
                    return;

                _query = value;

                OnPropertyChanged(nameof(Query));
            }
        } 
    }
}
