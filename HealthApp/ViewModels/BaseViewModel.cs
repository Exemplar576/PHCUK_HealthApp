using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HealthApp.ViewModels
{
    class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanges([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected void SetPropertyValue<T>(ref T set, T value, [CallerMemberName] string propertyName = null)
        {
            set = value;
            OnPropertyChanges(propertyName);
        }
    }
}
