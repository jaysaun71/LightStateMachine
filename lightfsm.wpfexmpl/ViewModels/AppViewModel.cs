namespace Lightfsm.Wpfexmpl.ViewModels
{
    using System;
    using System.Windows.Input;
    internal class AppViewModel : ViewModelBase
    {
        public ICommand ShowHomePageCommand { get; private set; }
        public ICommand ShowSettingsPageCommand { get; private set; }
        public ICommand GoToNextPageCommand { get; private set; }
        public ICommand GoToPreviousPageCommand { get; private set; }

        public AppViewModel()
        {
            this.ShowHomePageCommand = new DelegateCommand(x => this.ShowHomePage());
            this.ShowSettingsPageCommand = new DelegateCommand(x => this.ShowSettingsPage());
            this.GoToPreviousPageCommand = new DelegateCommand(x => this.GoToPreviousPage());
            this.GoToNextPageCommand = new DelegateCommand(x => this.GoToNextPage());
        }

        private void ShowHomePage()
        {

        }

        private void ShowSettingsPage()
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
