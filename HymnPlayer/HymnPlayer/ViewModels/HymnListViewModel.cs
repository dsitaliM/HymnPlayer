using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using HymnPlayer.Annotations;
using HymnPlayer.Data;
using HymnPlayer.Models;
using MvvmHelpers;
using Xamarin.Forms;

namespace HymnPlayer.ViewModels
{
    public class HymnListViewModel : INotifyPropertyChanged
    {

        private List<Hymn> _hymns;
        public List<Hymn> Hymns
        {
            get => _hymns;
            set
            {
                _hymns = value;
                OnPropertyChanged();
            }
        }

        private List<Hymn> _suggestions;
        public List<Hymn> Suggestions
        {
            get => _suggestions;
            set
            {
                _suggestions = value;
                OnPropertyChanged();
            }
        }

        public HymnListViewModel()
        {
            var hymnsRepo = new HymnsRepository();

            _hymns = new List<Hymn>();
            _hymns.AddRange(hymnsRepo.GetHymns);

            Suggestions = Hymns.ToList();
        }

        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
            }
        }

        public Command SearchCommand => new Command(Search);

        public void Search()
        {
            if (_searchQuery.Length >= 1)
            {
                Suggestions = Hymns.Where(hymn =>
                    hymn.Title.ToLower().Contains(_searchQuery.ToLower()) || hymn.HymnNumber.ToString().Contains(_searchQuery)).ToList();
            }
            else
            {
                Suggestions = Hymns.ToList();

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