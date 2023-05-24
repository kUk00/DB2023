using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaC
{
    internal class Hall
    {
        public int IDhall { get; set; }
        public string NameHall { get; set; }

        public Hall(int idhall, string namehall)
        {
            this.IDhall = idhall;
            this.NameHall = namehall;
        }
    }
}
