using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Loactions
{
    internal class Location
    {
        char locationAction;
        public static bool backCheck = false;
        protected static string _location;
        protected static int _levelZone;
        public Location(string locationname, int levelZone) { _location = locationname; _levelZone = levelZone; }

        internal void StandartLocationAction()
        {
            backCheck = false;
            locationAction = ' ';

            while (locationAction == ' ')
            {
                Console.WriteLine($"You enter {_location}.\n" +
                    "What do you want to do?\n" +
                    "1. Look for Quests             2. \n" +
                    "3.                             4. \n" +
                    "5.                             6. \n");
                Console.WriteLine("0. Back");

                locationAction = Console.ReadKey().KeyChar;
            }

            switch (locationAction)
            {
                case '0': backCheck = true; break;
                case '1': 
                    Console.WriteLine("Quests are currently unavailable.");
                    Console.ReadKey();
                    StandartLocationAction(); break;
            }

        }

    }

}