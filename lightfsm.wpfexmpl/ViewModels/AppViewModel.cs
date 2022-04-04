using Core.Lightfsm.Classes.DIContainer;

namespace Core.Lightfsm.Wpfexmpl.ViewModels
{
    using Interfaces;
    using Lightfsm.Wpfexmpl.Classes;
    using System;
    using System.Windows.Input;

    internal class AppViewModel : ViewModelBase
    {
        public ICommand ShowHomePageCommand { get; private set; }

        public ICommand ShowSettingsPageCommand { get; private set; }

        public ICommand GoToNextCommand { get; private set; }

        public ICommand GoToPreviousCommand { get; private set; }

        private readonly IStateMachineManager<ApplicationViewsStateEnum, IViewStatePayload> stateMachineManager;

        public AppViewModel() : this(new DependencyResolver().ResolveType<IStateMachineManager<ApplicationViewsStateEnum, IViewStatePayload>>())
        {
            // bind methods from fsm to views
            // add go to exact state method in fsm
            this.ShowHomePageCommand = new DelegateCommand(x => this.ShowHomePage());
            this.ShowSettingsPageCommand = new DelegateCommand(x => this.ShowSettingsPage());
            this.GoToPreviousCommand = new DelegateCommand(x => this.GoToPreviousPage());
            this.GoToNextCommand = new DelegateCommand(x => this.GoToNextPage());
        }

        public AppViewModel(IStateMachineManager<ApplicationViewsStateEnum, IViewStatePayload> stateMachineManager)
        {
            this.stateMachineManager = stateMachineManager;
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
