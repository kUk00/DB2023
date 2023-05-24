using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaC
{
    internal class Price
    {
        public int IDPrice { get; set; }
        public decimal price { get; set; }
        public int idHall { get; set; }

        public Price(int idprice, decimal Price, int idhall)
        {
            this.IDPrice = idprice;
            this.price = Price;
            this.idHall = idhall;
        }
    }
}
