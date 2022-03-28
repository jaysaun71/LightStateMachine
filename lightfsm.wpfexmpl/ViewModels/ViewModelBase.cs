namespace Core.Lightfsm.Wpfexmpl
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// ViewModelBase.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        
        /// <summary>
        /// PropertyChanged event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// OnPropertyChanged.
        /// </summary>
        /// <param name="propertyName">param</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}