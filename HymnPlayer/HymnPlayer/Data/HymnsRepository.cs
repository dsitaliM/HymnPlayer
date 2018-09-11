using System.Collections.Generic;
using HymnPlayer.Models;

namespace HymnPlayer.Data
{
    public class HymnsRepository
    {
        public IList<Hymn> GetHymns { get; }

        public HymnsRepository()
        {
            GetHymns = new List<Hymn>
            {
                new Hymn
                {
                    HymnNumber = 1,
                    Title = "All Your Anxiety",
                    Author = "Edward H. Joy",
                    Year = "1920",
                    Key = "Eb"
                },

                new Hymn
                {
                    HymnNumber = 2,
                    Title = "Come Unto Me",
                    Author = "Charles P. Jones",
                    Year = "1908",
                    Key = "C"
                },
                new Hymn
                {
                    HymnNumber = 3,
                    Title = "Impatient Heart",
                    Author = "George A. Warburton",
                    Year = "1896",
                    Key = "A"
                },
                new Hymn
                {
                    HymnNumber = 4,
                    Title = "Leave It There",
                    Author = "Charles A. Tindley",
                    Year = "1916",
                    Key = "G"
                },
                new Hymn
                {
                    HymnNumber = 5,
                    Title = "Never Give Up",
                    Author = "Fanny Crosby",
                    Year = "1903",
                    Key = "Bb"
                }

            };
        }
    }
}