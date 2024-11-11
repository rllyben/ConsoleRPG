using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConsoleRPG.Fighting;
using ConsoleRPG.Heros;
using Microsoft.VisualBasic.FileIO;

namespace ConsoleRPG.Loactions
{
    internal class Location
    {
        Hero hero = Program.hero;
        protected bool error = false;
        private char locationAction = ' ';
        public static bool backCheck = false;
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

        internal void PrintConnectedLocations(bool isSemiCity = false)
        {
            // Prints the available Locations to go to if the Location is a Semi City
            if (isSemiCity)
            {
                for (short count = 0; count < ConnectedLocations.Count; count++)
                {
                    Console.WriteLine($"{count + 4}. Go to {ConnectedLocations[count].LocationName}");
                }

            }
            // Prints the available Locations to go to if the Location is a normal Location or a City
            else
            {
                for (short count = 0; count < ConnectedLocations.Count; count++)
                {
                    Console.WriteLine($"{count + 3}. Go to {ConnectedLocations[count].LocationName}");
                }

            }
            return;
        }
        // Handels the player Actions done in an Location or Semi City
        internal void StandartLocationAction(bool runtest = false)
        {
            bool isSemiCity = false;
            // Checks if the current Location is a Semi City
            if (ID == 8 || ID == 24)
            {
                isSemiCity = true;
            }
            // Checks if the current Location is a City
            if (this.GetType() == typeof(City) && runtest == true)
            {
                City temp = this as City;
                temp.StandatCityAction();
            }

            do
            {
                Console.Clear();
                Console.WriteLine($"You enter {LocationName}.");
                Console.WriteLine("What do you want to do?");
                // Prints Looking for Quests, Fight Monsters and Go to the Local Trader if the Location is a Semi City
                if (isSemiCity)
                {
                    Console.WriteLine("1. Look for Quests           2. Fight a Monster" +
                                     $"\n3. Go to {Trader[TraderCount - 1].GetTraderName()}");
                }
                // Prints Looking for Quests and Fight Monsters if the Location is a normal Location
                else
                    Console.WriteLine("1. Look for Quests           2. Fight a Monster");

                PrintConnectedLocations(isSemiCity);

                Console.WriteLine("\n0. Back\n\n");
                hero.PrintHeroInformation();

                // saves the playerinput as locationAction
                locationAction = Console.ReadKey().KeyChar;

                // switch to manage the location action
                switch (locationAction)
                {
                    // manages the "Back" Action
                    case '0': error = false; return;

                    // manages the looking for Quests Action
                    case '1':
                        Console.WriteLine("\nQuests are currently unavailable.");
                        Thread.Sleep(2000);
                        error = true; break;

                    // manages the Monster fight Action
                    case '2':
                        Random rnd = new Random();
                        // selects a random Mob from the Location
                        int monsterNumber = rnd.Next(0, Monsters.Count);
                        // initialices the fight
                        Fight.Fighting(Monsters[monsterNumber]);
                        StandartLocationAction();
                        error = true; break;

                    default:
                        // converts the location Action char into a number
                        short action = (short)locationAction;
                        action -= 49;

                        // Handels going into a connected Location from a Semi City
                        if (isSemiCity && action >= 3 && action < 3 + ConnectedLocations.Count)
                        {
                            error = false;
                            ConnectedLocations[action - 3].StandartLocationAction(true);
                            break;
                        }
                        // Handels going into a connected Location from a normal Location
                        else if (action >= 2 && action < 2 + ConnectedLocations.Count)
                        {
                            error = false;
                            ConnectedLocations[action - 2].StandartLocationAction(true);
                            break;
                        }
                        // Handels going to a Trader from a Semi City
                        else if (action == 3)
                        {
                            error = false;
                            Trader[TraderCount - 1].TraderActionChoose(Trader[TraderCount - 1].GetJobName());
                            break;
                        }
                        // Handels wrong inputs
                        else
                        {
                            error = true;
                            Console.WriteLine("\nWrong input please try again!");
                            Thread.Sleep(1000);
                            break;
                        }

                }

            } while (error);

        }

    }

}