namespace Core.Lightfsm.Wpfexmpl
{
    using System;
    using System.Windows;

    using Core.Lightfsm.Wpfexmpl.Classes;
    using Core.Lightfsm.Wpfexmpl.Classes.DataContext;
    using Core.Lightfsm.Wpfexmpl.Classes.DIContainer;

    using Core.Lightfsm.Interfaces;
    using Core.Lightfsm.Impl;

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

    internal class DITestClass : IDITestClass
    {
        public DITestClass(ITestOneInterface x, ITestTwoInterface y)
        {

        }
    }

    internal interface IDITestClass
    {
    }

    internal class InjectedClass : ITestOneInterface, ITestTwoInterface
    {

    }

    internal interface ITestTwoInterface
    {
    }

    internal interface ITestOneInterface
    {
    }
}