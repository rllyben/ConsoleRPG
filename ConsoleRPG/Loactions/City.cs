using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRPG;

namespace ConsoleRPG.Loactions
{
    internal class City : Location
    {
        char cityAction;
        public static bool backCheck = false;
        public City(string locationname, int levelZone) : base(locationname, levelZone) { }
        public static Traders james = new Traders("James");
        public static Traders karl = new Traders("Karl");
        public static Traders hans = new Traders("Hans");
        public static Traders alexia = new Traders("Alexia");

        internal void StandatCityAction(Location currentLocation)
        {
            Console.Clear();
            backCheck = false;
            cityAction = ' ';

            while (cityAction == ' ')
            {
                if (currentLocation.ID != 1 && currentLocation.ID != 7 && currentLocation.ID != 18 && currentLocation.ID != 26)
                {
                    Location temp = currentLocation as Location;
                    temp.StandartLocationAction(currentLocation, true);
                }
                StandartLocationAction(currentLocation, false);
                Console.WriteLine($"{ConnectedLocations.Count + 4}. open inventory");                   
                Console.WriteLine();
                Console.WriteLine($"{Program.hero}: Level: {Program.hero.Level} XP: {Program.hero.Experience}/{Program.hero.Level * Program.hero.Level * 2} HP: {Program.hero.MaxHealth}/{Program.hero.CurHealth} Money: {Program.hero.Cash}");
                Console.WriteLine();
                Console.WriteLine("0. Back");

                cityAction = Console.ReadKey().KeyChar;
            }

            switch (cityAction)
            {
                case '0': backCheck = true; break;
                case '1':
                    Console.WriteLine();
                    Console.WriteLine("Quests are currently unavailable.");
                    Thread.Sleep(2000);
                    StandartLocationAction(currentLocation); break;
                default:
                    short action = (short)cityAction;
                    action -= 48;
                    if (action >= 4 && action < 4 + ConnectedLocations.Count)
                    {
                        Location nextLocation = currentLocation.ConnectedLocations[action - 4];
                        StandartLocationAction(nextLocation);
                    }
                    else if (action == 2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("The Healer Heals you to your full HP");
                        Program.hero.Healer();
                        Thread.Sleep(2000);
                        StandartLocationAction(currentLocation);
                    }
                    else if (action == 3)
                    {
                        currentLocation.Trader[TraderCount-1].StandartSmithAction(currentLocation.Trader[TraderCount-1]);
                    }
                    else if (action == 4 + ConnectedLocations.Count)
                    {

                    }
                    else if (action != 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Wrong input please try again!");
                        Thread.Sleep(1000);
                        StandartLocationAction(currentLocation);
                    }
                    StandatCityAction(currentLocation);
                    break;
            }

        }

    }

}
