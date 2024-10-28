using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConsoleRPG;
using ConsoleRPG.Fighting;
using Microsoft.VisualBasic.FileIO;

namespace ConsoleRPG.Loactions
{
    internal class Location
    {

        char locationAction;
        public static bool backCheck = false; // 4(116);7(203); 29DEF; 19(190); 26(260); 10DEF; 12(180); 16(240); 15DEF; 4(136); 6(204); 34DEF; 8(160); 10(200); 20DEF
        protected string LocationName { get; set; }
        protected int LevelZone { get; set; }
        protected static int _IDcounter = 1;
        public int ID { get; set; }
        public int TraderCount { get; set; }
        public List<Location> ConnectedLocations { get; set; }
        public List<Traders> Trader { get; set; }
        public List<Monster> Monsters { get; set; }
        public Location(string locationname, int levelZone)
        {

            LocationName = locationname;
            LevelZone = levelZone;
            ID = _IDcounter;
            _IDcounter++;
            ConnectedLocations = new List<Location>();
            Trader = new List<Traders>();
            Monsters = new List<Monster>();

        }
        internal void IDcheck()
        {
            Console.WriteLine(ID + LocationName);
        }
        public void AddConnection(Location location)
        {
            ConnectedLocations.Add(location);
        }
        public void AddMonster(Monster monsters)
        {
            Monsters.Add(monsters);
        }
        public void AddTrader(Traders trader)
        {
            Trader.Add(trader);
            TraderCount++;
        }
        internal void StandartLocationAction(bool isLocation = true, bool isSemiCityLocation = false, Location currentLocation = null)
        {
            if (isLocation && (ID == 1 || ID == 7 || ID == 18 || ID == 26))
            {
                City temp = currentLocation as City;
                temp.StandatCityAction();
            }
            else
                Console.Clear();

            // geht nicht weil currentlocation keine City sondern eine Location ist            
            // currentLocation.StandartCityAction(currentLocation);

            backCheck = false;
            locationAction = ' ';

            while (locationAction == ' ')
            {
                if (ID == 8 || ID == 24)
                {
                    isSemiCityLocation = true;
                    isLocation = false;
                }
                Console.WriteLine($"You enter {LocationName}.");
                Console.WriteLine("What do you want to do?");
                if (isSemiCityLocation)
                {
                    Console.WriteLine($"1. Look for Quests           2. Fight a Monster");
                    Console.WriteLine($"3. Go to {Trader[TraderCount - 1].GetTraderName()}");
                }
                else if (isLocation)
                    Console.WriteLine($"1. Look for Quests           2. Fight a Monster");
                else
                {
                    Console.Write("1. Look for Quests           2. Go to the Healer\n");
                    Console.WriteLine($"3. Go to {Trader[TraderCount - 1].GetTraderName()}");
                }
                if (isSemiCityLocation)
                {
                    for (short count = 0; count < ConnectedLocations.Count; count++)
                    {
                        Console.WriteLine($"{count + 4}. Go to {ConnectedLocations[count].LocationName}");
                    }

                }
                else if (isLocation)
                {
                    for (short count = 0; count < ConnectedLocations.Count; count++)
                    {
                        Console.WriteLine($"{count + 3}. Go to {ConnectedLocations[count].LocationName}");
                    }

                }
                else
                {
                    for (short count = 0; count < ConnectedLocations.Count; count++)
                    {
                        Console.WriteLine($"{count + 4}. Go to {ConnectedLocations[count].LocationName}");
                    }

                }

                if (isLocation || isSemiCityLocation) { }
                else
                {
                    return;
                }
                Console.WriteLine();
                Console.WriteLine($"{Program.hero.Name}: Level: {Program.hero.Level}  XP: {Program.hero.Experience}/{Program.hero.Level * Program.hero.Level * 2}  HP: {Program.hero.CurrentHealth} / {Program.hero.MaximalHealth} Money: {Program.hero.Cash}");
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
                    StandartLocationAction(); break;
                case '2':
                    Random rnd = new Random();
                    int monsterNumber = rnd.Next(0, Monsters.Count);
                    
                    if (Monsters[monsterNumber].MaxDamage <= 0)
                    {
                        Fight.Fighting(Monsters[monsterNumber]);
                    }
                    else
                        Fight.Fighting(Monsters[monsterNumber]);
                    
                    StandartLocationAction();
                    break;
                default:
                    short action = (short)locationAction;
                    action -= 49;

                    if (isSemiCityLocation && action >= 3 && action < 3 + ConnectedLocations.Count)
                    {
                        Location nextLocation = ConnectedLocations[action - 3];
                        nextLocation.StandartLocationAction(true, false, nextLocation);
                    }
                    else if (isLocation && action >= 2 && action < 2 + ConnectedLocations.Count)
                    {
                        Location nextLocation = ConnectedLocations[action - 2];
                        nextLocation.StandartLocationAction(true, false, nextLocation);
                    }
                    else if (action == 2)
                    {
                        Trader[TraderCount - 1].StandartSmithAction(Trader[TraderCount - 1]);
                    }
                    else if (action != 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Wrong input please try again!");
                        Thread.Sleep(1000);
                        StandartLocationAction();
                    }
                    StandartLocationAction();
                    break;

            }

        }

    }

}