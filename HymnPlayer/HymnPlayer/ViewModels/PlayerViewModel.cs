using System.ComponentModel;
using System.Runtime.CompilerServices;
using HymnPlayer.Annotations;
using HymnPlayer.Models;

namespace HymnPlayer.ViewModels
{
    public class PlayerViewModel : INotifyPropertyChanged
    {
        private Hymn _hymn;

        public Hymn Hymn
        {
            get => _hymn;
            set
            {
                _hymn = value;
                OnPropertyChanged();
            }
        }

        public PlayerViewModel() { }

        public PlayerViewModel(Hymn hymn)
        {
            Hymn = hymn;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}