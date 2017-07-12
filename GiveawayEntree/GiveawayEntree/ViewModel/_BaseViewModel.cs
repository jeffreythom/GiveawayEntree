using System.ComponentModel;

namespace GiveawayEntree.ViewModel
{
    public class _BaseViewModel : INotifyPropertyChanged
    {
        protected _BaseViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
