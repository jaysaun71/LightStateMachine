namespace Lightfsm.Wpfexmpl.ViewModels
{
    using Lightfsm.Wpfexmpl;
    using System;
    using System.Windows.Input;

    internal class SettingsPageViewModel : ViewModelBase
    {
        private ICommand ShowHomePageCommand;
        private ICommand ShowAppPageCommand;
        private ICommand GoToPreviousPageCommand;
        private ICommand GoToNextPageCommand;

        public SettingsPageViewModel()
        {
            this.ShowHomePageCommand = new DelegateCommand(x => this.ShowHomePage());
            this.ShowAppPageCommand = new DelegateCommand(x => this.ShowAppPage());
            this.GoToPreviousPageCommand = new DelegateCommand(x => this.GoToPreviousPage());
            this.GoToNextPageCommand = new DelegateCommand(x => this.GoToNextPage());
        }

        private void ShowHomePage()
        {
            throw new NotImplementedException();
        }

        private void ShowAppPage()
        {
            throw new NotImplementedException();
        }

        private void GoToPreviousPage()
        {
            throw new NotImplementedException();
        }

        private void GoToNextPage()
        {
            throw new NotImplementedException();
        }
    }
}