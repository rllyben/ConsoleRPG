using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Loactions
{
    internal class City : Location
    {
        public City(string locationname) : base(locationname) { }

        Traders james = new Traders("James");
        Traders karl = new Traders("Karl");
        Traders hans = new Traders("Hans");
        Traders alexia = new Traders("Alexia");



    }

}
