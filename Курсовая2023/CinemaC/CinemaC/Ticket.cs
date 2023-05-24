using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaC
{
    internal class Ticket
    {
        public int Row { get; set; }
        public int Place { get; set; }
        public bool Sold { get; set; }
        public int Session { get; set; }
        public int idPrice { get; set; }

        public Ticket(int row, int place, bool sold, int sessions, int idprice)
        {
            this.Row = row;
            this.Place = place;
            this.Sold = sold;
            this.Session = sessions;
            this.idPrice = idprice;
        }
    }
}
