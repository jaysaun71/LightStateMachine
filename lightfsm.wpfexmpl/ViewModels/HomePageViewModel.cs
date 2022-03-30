namespace Core.Lightfsm.Wpfexmpl.ViewModels
{
    using Lightfsm.Classes.DIContainer;
    using Interfaces;
    using Lightfsm.Wpfexmpl;
    using Lightfsm.Wpfexmpl.Classes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    internal class HomePageViewModel : ViewModelBase
    {
        public ICommand ShowAppPageCommand { get; private set; }
        public ICommand ShowSettingsPageCommand { get; private set; }
        public ICommand GoToNextCommand { get; private set; }
        public ICommand GoToPreviousCommand { get; private set; }

        private readonly IStateMachineManager<ApplicationViewsStateEnum, IViewStatePayload> stateMachineManager;
        public HomePageViewModel() : this(DependencyResolver.ResolveType<IStateMachineManager<ApplicationViewsStateEnum, IViewStatePayload>>())
        {
            this.ShowAppPageCommand = new DelegateCommand(x => this.ShowAppPage());
            this.ShowSettingsPageCommand = new DelegateCommand(x => this.ShowSettingsPage());
            this.GoToPreviousCommand = new DelegateCommand(x => this.GoToPreviousPage());
            this.GoToNextCommand = new DelegateCommand(x => this.GoToNextPage());
        }

        public HomePageViewModel(IStateMachineManager<ApplicationViewsStateEnum, IViewStatePayload> stateMachineManager)
        {
            // TODO: some null exception strategy
            this.stateMachineManager = stateMachineManager;
        }

        public void ShowAppPage()
        {
            this.stateMachineManager.PerformTransitionTo(ApplicationViewsStateEnum.AppPageState);
        }

        public void ShowSettingsPage()
        {
            this.stateMachineManager.PerformTransitionTo(ApplicationViewsStateEnum.SettingsPageState);
        }

        public void GoToPreviousPage()
        {
            this.stateMachineManager.GoToPreviousState();
        }

        public void GoToNextPage()
        {
            this.stateMachineManager.PerformTransition();
        }
    }
}
