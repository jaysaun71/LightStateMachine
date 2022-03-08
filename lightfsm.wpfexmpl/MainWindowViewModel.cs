namespace Lightfsm.Wpfexmpl
{
    using Lightfsm.Wpfexmpl.Classes.DataContext;
    using System.Windows.Input;

    /// <summary>
    /// MainWindowViewModel.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase currentViewModel;
        private string pageTitle;

        public ViewModelBase CurrentViewModel
        {
            get
            {
                return this.currentViewModel;
            }

            set
            {
                this.currentViewModel = value;
                this.OnPropertyChanged(nameof(this.CurrentViewModel));
            }
        }

        /// <summary>
        /// Gets or sets pageTitle.
        /// </summary>
        public string PageTitle {

            get
            {
                return this.pageTitle;
            }

            set
            {
                this.pageTitle = value;
                this.OnPropertyChanged(nameof(this.PageTitle));
            }
        }

        public ICommand LoadFirstPageCommand { get; private set; }

        public ICommand LoadSecondPageCommand { get; private set; }


        public MainWindowViewModel()
        {
            this.LoadFirstPageCommand = new DelegateCommand(x => this.LoadFirstPage());
            this.LoadSecondPageCommand = new DelegateCommand(x => this.LoadSecondPage());
            this.CurrentViewModel = new DefaultContext();
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
