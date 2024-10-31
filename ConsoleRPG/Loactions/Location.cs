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
        // Handels the player Actions done in an Location or Semi City
        internal void StandartLocationAction(bool isLocation = true, bool isSemiCityLocation = false, Location currentLocation = null)
        {
            // Checks if the current Location is a City
            if (isLocation && (ID == 1 || ID == 7 || ID == 18 || ID == 26))
            {
                City temp = currentLocation as City;
                temp.StandatCityAction();
            }
            else
                Console.Clear();

            backCheck = false;
            locationAction = ' ';

            while (locationAction == ' ')
            {
                // Checks if the current Location is a Semi City
                if (ID == 8 || ID == 24)
                {
                    isSemiCityLocation = true;
                    isLocation = false;
                }
                Console.WriteLine($"You enter {LocationName}.");
                Console.WriteLine("What do you want to do?");
                // Prints Looking for Quests, Fight Monsters and Go to the Local Trader if the Location is a Semi City
                if (isSemiCityLocation)
                {
                    Console.WriteLine($"1. Look for Quests           2. Fight a Monster");
                    Console.WriteLine($"3. Go to {Trader[TraderCount - 1].GetTraderName()}");
                }
                // Prints Looking for Quests and Fight Monsters if the Location is a normal Location
                else if (isLocation)
                    Console.WriteLine($"1. Look for Quests           2. Fight a Monster");
                // Prints Looking for Quests, go to the Healer and Go to the Local Trader if the Location is a City
                else
                {
                    Console.Write("1. Look for Quests           2. Look for Traders\n");
                }
                // Prints the available Locations to go to if the Location is a Semi City
                if (isSemiCityLocation)
                {
                    for (short count = 0; count < ConnectedLocations.Count; count++)
                    {
                        Console.WriteLine($"{count + 4}. Go to {ConnectedLocations[count].LocationName}");
                    }

                }
                // Prints the available Locations to go to if the Location is a normal Location
                else if (isLocation)
                {
                    for (short count = 0; count < ConnectedLocations.Count; count++)
                    {
                        Console.WriteLine($"{count + 3}. Go to {ConnectedLocations[count].LocationName}");
                    }

                }
                // Prints the available Locatons to go to if the Location is a City
                else
                {
                    for (short count = 0; count < ConnectedLocations.Count; count++)
                    {
                        Console.WriteLine($"{count + 3}. Go to {ConnectedLocations[count].LocationName}");
                    }

                }

                // Checks if the Location is a City and if yes returns to Standart City Action
                if (ID == 1 || ID == 7 || ID == 18 || ID == 26)
                    return;

                // Prints the important player stats
                Console.WriteLine();
                Console.WriteLine($"{Program.hero.Name}: Level: {Program.hero.Level}  XP: {Program.hero.Experience}/{Program.hero.Level * Program.hero.Level * 2}  " +
                                  $"HP: {Program.hero.CurrentHealth} / {Program.hero.MaximalHealth} MP: {Program.hero.ManaPoints} / {Program.hero.MaxiamlManaPoints}\n" +
                                  $"Money: {Program.hero.Cash}");
                Console.WriteLine();
                Console.WriteLine("0. Back");

                // saves the playerinput as locationAction
                locationAction = Console.ReadKey().KeyChar;
            }

            // switch to manage the location action
            switch (locationAction)
            {
                // manages the "Back" Action
                case '0': backCheck = true; break;
                // manages the looking for Quests Action
                case '1':
                    Console.WriteLine();
                    Console.WriteLine("Quests are currently unavailable.");
                    Thread.Sleep(2000);
                    StandartLocationAction(); break;
                // manages the Monster fight Action
                case '2':
                    Random rnd = new Random();
                    // selects a random Mob from the Location
                    int monsterNumber = rnd.Next(0, Monsters.Count);
                    // initialices the fight
                    Fight.Fighting(Monsters[monsterNumber]);
                    StandartLocationAction();
                    break;
                default:
                    // converts the location Action char into a number
                    short action = (short)locationAction;
                    action -= 49;

                    // Handels going into a connected Location from a Semi City
                    if (isSemiCityLocation && action >= 3 && action < 3 + ConnectedLocations.Count)
                    {
                        Location nextLocation = ConnectedLocations[action - 3];
                        nextLocation.StandartLocationAction(true, false, nextLocation);
                    }
                    // Handels going into a connected Location from a normal Location
                    else if (isLocation && action >= 2 && action < 2 + ConnectedLocations.Count)
                    {
                        Location nextLocation = ConnectedLocations[action - 2];
                        nextLocation.StandartLocationAction(true, false, nextLocation);
                    }
                    // Handels going to a Trader from a Semi City
                    else if (action == 3)
                    {
                        Trader[TraderCount - 1].TraderActionChoose(Trader[TraderCount - 1].GetJobName());
                    }
                    // Handels wrong inputs
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