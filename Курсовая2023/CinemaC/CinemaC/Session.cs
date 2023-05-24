using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaC
{
    internal class Session
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int Hall { get; set; }
        public int Movie { get; set; }

        public Session(DateTime date, TimeSpan time, int hall, int movie)
        {
            this.Date = date;
            this.Time = time;
            this.Hall = hall;
            this.Movie = movie;
        }


    }
}
