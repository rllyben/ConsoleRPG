using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConsoleRPG;
using ConsoleRPG.Fighting;

namespace ConsoleRPG.Loactions
{
    internal class Location
    {
        public static Traders rohan = new Traders("Rohan");
        public static Traders marcudos = new Traders("Marcudos");

        char locationAction;
        public static bool backCheck = false;
        protected string LocationName { get; set; }
        protected int LevelZone { get; set; }
        protected static int _IDcounter = 1;
        public int ID { get; set; }
        public int TraderCount { get; set; }
        public List<Location> ConnectedLocations { get; set; }
        public List<Traders> Trader { get; set; }
        public Location(string locationname, int levelZone) { LocationName = locationname; LevelZone = levelZone; ID = _IDcounter; _IDcounter++; ConnectedLocations = new List<Location>(); Trader = new List<Traders>();}
        internal void IDcheck()
        {
            Console.WriteLine(ID + LocationName);
        }
        public void AddConnection(Location location)
        {
            ConnectedLocations.Add(location);
        }
        public void AddTrader(Traders trader)
        {
            Trader.Add(trader);
            TraderCount++;
        }
        internal void StandartLocationAction(Location currentLocation, bool isLocation = true, bool isSemiCityLocation = false)
        {
            if (isLocation && (currentLocation.ID == 1 || currentLocation.ID == 7 || currentLocation.ID == 18 || currentLocation.ID == 26))
            {
                City temp = currentLocation as City;
                temp.StandatCityAction(currentLocation);
            }
            else 
                Console.Clear();

            // geht nicht weil currentlocation keine City sondern eine Location ist            
            // currentLocation.StandartCityAction(currentLocation);

            backCheck = false;
            locationAction = ' ';

            while (locationAction == ' ')
            {
                if (currentLocation.ID == 8 || currentLocation.ID == 24)
                    isSemiCityLocation = true;
                Console.WriteLine($"You enter {currentLocation.LocationName}.");
                Console.WriteLine("What do you want to do?");
                if (isLocation == true)
                    Console.WriteLine($"1. Look for Quests           2. Fight a Monster");
                if (isLocation == false)
                {
                    Console.Write("1. Look for Quests           2. Go to the Healer\n");
                    Console.WriteLine($"3. Go to {currentLocation.Trader[TraderCount-1].GetTraderName()}");
                }
                if (isLocation)
                {
                    for (short count = 0; count < currentLocation.ConnectedLocations.Count; count++)
                    {
                        Console.WriteLine($"{count + 3}. Go to {currentLocation.ConnectedLocations[count].LocationName}");
                    }

                }
                else if (isSemiCityLocation)
                {
                    for (short count = 0; count < currentLocation.ConnectedLocations.Count; count++)
                    {
                        Console.WriteLine($"{count + 3}. Go to {currentLocation.ConnectedLocations[count].LocationName}");
                    }

                }
                else
                {
                    for (short count = 0; count < currentLocation.ConnectedLocations.Count; count++)
                    {
                        Console.WriteLine($"{count + 4}. Go to {currentLocation.ConnectedLocations[count].LocationName}");
                    }

                }

                if (isLocation == false)
                    return;

                Console.WriteLine();
                Console.WriteLine($"{Program.hero.Name}: Level: {Program.hero.Level}  XP: {Program.hero.Experience}/{Program.hero.Level * Program.hero.Level * 2}  HP: {Program.hero.MaxHealth}/{Program.hero.CurHealth} Money: {Program.hero.Cash}");
                Console.WriteLine();
                Console.WriteLine("0. Back");

                locationAction = Console.ReadKey().KeyChar;
            }

            switch (locationAction)
            {
                case '0': backCheck = true; break;
                case '1':
                    Console.WriteLine();
                    Console.WriteLine("Quests are currently unavailable.");
                    Thread.Sleep(2000);
                    StandartLocationAction(currentLocation); break;
                case '2':
                    Fight.Fighting(currentLocation.LevelZone, currentLocation.LevelZone*2, currentLocation.LevelZone*5 ,1);
                    StandartLocationAction(currentLocation);
                    break;
                default:
                    bool healer = false;
                    short action = (short)locationAction;
                    action -= 49;

                    if (action >= 2 && action < 2 + currentLocation.ConnectedLocations.Count)
                    {
                        Location nextLocation = currentLocation.ConnectedLocations[action-2];
                        StandartLocationAction(nextLocation);
                    }
                    else if (action != 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Wrong input please try again!");
                        Thread.Sleep(1000);
                        StandartLocationAction(currentLocation);
                    }
                    StandartLocationAction(currentLocation);
                    break;


            }

        }

    }

}