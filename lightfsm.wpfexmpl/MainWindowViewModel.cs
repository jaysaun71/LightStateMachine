namespace Lightfsm.Wpfexmpl
{
    using Lightfsm.Classes;
    using Lightfsm.Wpfexmpl.Classes;
    using Lightfsm.Wpfexmpl.Classes.DataContext;
    using Lightfsm.Wpfexmpl.ViewModels;
    using System.Windows.Input;

    /// <summary>
    /// MainWindowViewModel.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase, IViewStatePayload
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
            this.CurrentViewModel = new HomePageViewModel();

            var machine = DependencyResolver.ResolveType<IStateMachineManager<ApplicationViewsStateEnum, IViewStatePayload>>();
            machine.Initialize(this);
        }

        private void LoadFirstPage()
        {
            //TODO: implement set page title as title of the current child view
            this.PageTitle = "A";
            //this.CurrentViewModel = new AppViewModel();
        }

        private void LoadSecondPage()
        {
            this.PageTitle = "B";
            //this.CurrentViewModel = new SettingsPageViewModel();
        }
    }
}
