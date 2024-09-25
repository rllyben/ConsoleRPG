using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Loactions
{
    internal class Location
    {
        string _location;
        public Location(string locationname) { _location = locationname; }

        internal void StandartLocationAction()
        {
            char locationAction = ' ';

            while (locationAction == ' ')
            {
                Console.WriteLine($"You enter {_location}.\n" +
                    "What do you want to do?\n" +
                    "1. Look for Quests             2. Go to the Healer\n" +
                    "3.                             4.\n" +
                    "5.                             6.\n");
                Console.WriteLine("0. Back");

                locationAction = Console.ReadKey().KeyChar;
            }

            switch (locationAction)
            {
                case '0': break;

        }

    }

}