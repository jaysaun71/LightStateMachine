namespace LightStateMachine.WpfExample
{
    using System.Windows.Input;

    /// <summary>
    /// MainWindowViewModel.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        private string _pageTitle;

        public ViewModelBase CurrentViewModel
        {
            get
            {
                return this._currentViewModel;
            }

            set
            {
                this._currentViewModel = value;
                this.OnPropertyChanged(nameof(this.CurrentViewModel));
            }
        }

        /// <summary>
        /// Gets or sets pageTitle.
        /// </summary>
        public string PageTitle {

            get
            {
                return this._pageTitle;
            }

            set
            {
                this._pageTitle = value;
                this.OnPropertyChanged(nameof(this.PageTitle));
            }
        }

        public ICommand LoadFirstPageCommand { get; private set; }

        public ICommand LoadSecondPageCommand { get; private set; }


        public MainWindowViewModel()
        {
            this.LoadFirstPageCommand = new DelegateCommand(x => this.LoadFirstPage());
            this.LoadSecondPageCommand = new DelegateCommand(x => this.LoadSecondPage());
        }

        private void LoadFirstPage()
        {
            this.PageTitle = "A";
        }

        private void LoadSecondPage()
        {
            this.PageTitle = "B";
        }
    }
}
