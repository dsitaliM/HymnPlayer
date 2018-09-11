using System.ComponentModel;
using System.Runtime.CompilerServices;
using HymnPlayer.Annotations;
using HymnPlayer.Models;
using MvvmHelpers;

namespace HymnPlayer.ViewModels
{
    public class HymnDetailViewModel : INotifyPropertyChanged
    {

        public HymnDetailViewModel()
        {

        }
        public HymnDetailViewModel(Hymn hymn)
        {
            Hymn = hymn;
        }

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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}