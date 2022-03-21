namespace Lightfsm.Wpfexmpl.ViewModels
{
    using Lightfsm.Classes;
    using Lightfsm.Wpfexmpl;
    using Lightfsm.Wpfexmpl.Classes;
    using System;
    using System.Windows.Input;

    internal class SettingsPageViewModel : ViewModelBase
    {
        public ICommand ShowHomePageCommand { get; private set; }
        public ICommand ShowAppPageCommand { get; private set; }
        public ICommand GoToNextCommand { get; private set; }
        public ICommand GoToPreviousCommand { get; private set; }

        private readonly IStateMachineManager<ApplicationViewsStateEnum, IViewStatePayload> stateMachineManager;
        public SettingsPageViewModel() : this(DependencyResolver.ResolveType<IStateMachineManager<ApplicationViewsStateEnum, IViewStatePayload>>())
        {
            this.ShowHomePageCommand = new DelegateCommand(x => this.ShowHomePage());
            this.ShowAppPageCommand = new DelegateCommand(x => this.ShowAppPage());
            this.GoToPreviousCommand = new DelegateCommand(x => this.GoToPreviousPage());
            this.GoToNextCommand = new DelegateCommand(x => this.GoToNextPage());
        }

        public SettingsPageViewModel(IStateMachineManager<ApplicationViewsStateEnum, IViewStatePayload> stateMachineManager)
        {
            this.stateMachineManager = stateMachineManager;
        }

        private void ShowHomePage()
        {
            this.stateMachineManager.PerformTransitionTo(ApplicationViewsStateEnum.HomePageState);
        }

        private void ShowAppPage()
        {
            this.stateMachineManager.PerformTransitionTo(ApplicationViewsStateEnum.AppPageState);
        }

        private void GoToPreviousPage()
        {
            this.stateMachineManager.GoToPreviousState();
        }

        private void GoToNextPage()
        {
            this.stateMachineManager.PerformTransition();
        }
    }
}