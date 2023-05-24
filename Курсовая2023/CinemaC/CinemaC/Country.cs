using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaC
{
    internal class Country
    {
        public string NameCountry { get; set; }
        public int idProduction { get; set; }

        public Country(string ncountry, int idprod)
        {
            this.NameCountry = ncountry;
            this.idProduction = idprod;
        }
    }
}
