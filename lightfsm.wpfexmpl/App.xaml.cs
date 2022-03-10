namespace Lightfsm.Wpfexmpl
{
    using Lightfsm.Classes;
    using Lightfsm.Wpfexmpl.Classes;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // instantiate statemachine
            var stateConfig = new ViewsStateConfiguration();
            DependencyResolver.RegisterType<IStateMachineManager<object>>(() => {
                return new StateMachineManager<ApplicationViewsStateEnum, object>(
                    stateConfig.GetConfiguration(),
                    stateConfig.StartState,
                    stateConfig.ExitState,
                    stateConfig.ExitState);
                });
            var machine = DependencyResolver.ResolveType<IStateMachineManager<object>>();
        }
    }
}
