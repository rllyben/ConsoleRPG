using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Loactions
{
    internal class City : Location
    {
        char cityAction;
        public static bool backCheck = false;
        public City(string locationname, int levelZone) : base(locationname, levelZone) { }

        Traders james = new Traders("James");
        Traders karl = new Traders("Karl");
        Traders hans = new Traders("Hans");
        Traders alexia = new Traders("Alexia");

        internal void StandatCityAction()
        {
            backCheck = false;
            cityAction = ' ';

            while (cityAction == ' ')
            {
                Console.WriteLine($"You enter {_location}.\n" +
                    "What do you want to do?\n" +
                    "1. Look for Quests             2. Go to the Healer\n" +
                    "3. 'Location1'                 4. 'Location2'\n" +
                    "5. 'Location3'                 6. 'Trader'\n");
                Console.WriteLine("0. Back");

                cityAction = Console.ReadKey().KeyChar;
            }

            switch (cityAction)
            {
                case '0': backCheck = true; break;
                case '1':
                    Console.WriteLine("Quests are currently unavailable.");
                    Console.ReadKey();
                    StandatCityAction(); break;
                case '2': Console.WriteLine("the Healer heals you to your full HP.");
                    Console.ReadKey(); 
                    Program.hero.Healer(); StandatCityAction(); break;

            }

        }

    }

}
