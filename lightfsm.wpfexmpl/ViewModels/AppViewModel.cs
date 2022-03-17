namespace Lightfsm.Wpfexmpl.ViewModels
{
    using Lightfsm.Classes;
    using Lightfsm.Wpfexmpl.Classes;
    using System;
    using System.Windows.Input;

    internal class AppViewModel : ViewModelBase
    {
        public ICommand ShowHomePageCommand { get; private set; }

        public ICommand ShowSettingsPageCommand { get; private set; }

        public ICommand GoToNextCommand { get; private set; }

        public ICommand GoToPreviousCommand { get; private set; }

        private readonly IStateMachineManager<ApplicationViewsStateEnum, IViewStatePayload> stateMachineManager = DependencyResolver.ResolveType<IStateMachineManager<ApplicationViewsStateEnum, IViewStatePayload>>();

        public AppViewModel()
        {
            // bind methods from fsm to views
            // add go to exact state method in fsm
            this.ShowHomePageCommand = new DelegateCommand(x => this.ShowHomePage());
            this.ShowSettingsPageCommand = new DelegateCommand(x => this.ShowSettingsPage());
            this.GoToPreviousCommand = new DelegateCommand(x => this.GoToPreviousPage());
            this.GoToNextCommand = new DelegateCommand(x => this.GoToNextPage());
        }

        private void ShowHomePage()
        {
            this.stateMachineManager.PerformTransitionTo(ApplicationViewsStateEnum.HomePageState);
        }

        private void ShowSettingsPage()
        {
            this.stateMachineManager.PerformTransitionTo(ApplicationViewsStateEnum.SettingsPageState);
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
