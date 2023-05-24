using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaC
{
    internal class Movie
    {
        public string NameMovie { get; set; }
        public int Production { get; set; }
        public int YearOfIssue { get; set; }
        public int Genre { get; set; }
        public int Duration { get; set; }

        public Movie(string namemovie, int production, int yearofissue, int genre, int duration)
        {
            this.NameMovie = namemovie;
            this.Production = production;
            this.YearOfIssue = yearofissue;
            this.Genre = genre;
            this.Duration = duration;
        }

    }
}
