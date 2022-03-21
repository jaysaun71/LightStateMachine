namespace Lightfsm.Wpfexmpl
{
    using Lightfsm.Classes;
    using Lightfsm.Wpfexmpl.Classes;
    using Lightfsm.Wpfexmpl.ViewModels;
    using System;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Initialize();
        }

        private static void Initialize()
        {
            // state machine init 
            var stateConfig = new ViewsStateConfiguration();
            DependencyResolver.RegisterType<IStateMachineManager<ApplicationViewsStateEnum, IViewStatePayload>>(() =>
            {
                return new StateMachineManager<ApplicationViewsStateEnum, IViewStatePayload>(
                    stateConfig.GetConfiguration(),
                    stateConfig.StartState,
                    stateConfig.ExitState,
                    stateConfig.ExitState);
            });
        }

        private void StartupApp(object sender, StartupEventArgs e)
        {
            App.Current.MainWindow = new MainWindow();
            App.Current.MainWindow.Show();
        }
    }
}