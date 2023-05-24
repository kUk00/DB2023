using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaC
{
    internal class Genre
    {
        public string NameGenre { get; set; }
        public int idGenre { get; set; }

        public Genre(string ngenre, int idgenre)
        {
            this.NameGenre = ngenre;
            this.idGenre = idgenre;
        }
    }
}
