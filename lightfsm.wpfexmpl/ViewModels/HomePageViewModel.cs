namespace Lightfsm.Wpfexmpl.ViewModels
{
    using Lightfsm.Wpfexmpl;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    internal class HomePageViewModel : ViewModelBase
    {
        private ICommand ShowHomePageCommand;
        private ICommand ShowSettingsPageCommand;
        private ICommand GoToPreviousPageCommand;
        private ICommand GoToNextPageCommand;

        public HomePageViewModel()
        {
            this.ShowHomePageCommand = new DelegateCommand(x => this.ShowHomePage());
            this.ShowSettingsPageCommand = new DelegateCommand(x => this.ShowSettingsPage());
            this.GoToPreviousPageCommand = new DelegateCommand(x => this.GoToPreviousPage());
            this.GoToNextPageCommand = new DelegateCommand(x => this.GoToNextPage());
        }

        private void ShowHomePage()
        {
            throw new NotImplementedException();
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
