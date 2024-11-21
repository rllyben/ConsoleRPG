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
        public string GetLocationName()
        {
            return LocationName;
        }
        internal void PrintConnectedLocations()
        {
            for (short count = 0; count < ConnectedLocations.Count; count++)
            {
                Console.WriteLine($"Go to {ConnectedLocations[count].LocationName}");
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

            int selection = 0;
            var selectionSwitch = ConsoleKey.NoName;

            do
            {
                Console.Clear();
                Console.WriteLine($"You enter {LocationName}.");
                Console.WriteLine("What do you want to do?");
                // Prints Looking for Quests, Fight Monsters and Go to the Local Trader if the Location is a Semi City
                if (isSemiCity)
                {
                    switch (selection)
                    {
                        case 0:
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write("Look for Quests");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("           Fight a Monster" +
                                             $"\nGo to {Trader[TraderCount - 1].GetTraderName()}");
                            PrintConnectedLocations();
                            break;
                        case 1:
                            Console.Write("Look for Quests           ");
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write("Fight a Monster");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine($"\nGo to {Trader[TraderCount - 1].GetTraderName()}");
                            PrintConnectedLocations();
                            break;
                        case 2:
                            Console.Write("Look for Quests           ");
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write("Fight a Monster");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine($"\nGo to {Trader[TraderCount - 1].GetTraderName()}");
                            PrintConnectedLocations();
                            break;
                        default:
                            Console.WriteLine("Look for Quests           Fight a Monster\n" +
                                              $"Go to {Trader[TraderCount - 1].GetTraderName()}");
                            for (int count = 3; count < ConnectedLocations.Count + 3; count++)
                            {
                                if (count == selection)
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                                    Console.WriteLine($"Go to {ConnectedLocations[count - 3].LocationName}");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                }
                                else
                                    Console.WriteLine($"Go to {ConnectedLocations[count - 3].LocationName}");
                            }
                            break;

                    }
                    hero.PrintHeroInformation();

                    selectionSwitch = Console.ReadKey().Key;
                    switch (selectionSwitch)
                    {
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                            if (selection > 2)
                            {
                                selection--;
                            }
                            else if (selection == 2)
                                selection = 0;
                            break;
                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow:
                            if (selection == 0)
                                selection = 2;
                            else if (selection > ConnectedLocations.Count + 3)
                                selection = ConnectedLocations.Count + 3;
                            else
                                selection++;
                            break;
                        case ConsoleKey.D:
                        case ConsoleKey.RightArrow:
                            if (selection == 0 || selection == 2)
                                selection = 1;
                            break;
                        case ConsoleKey.A:
                        case ConsoleKey.LeftArrow:
                            if (selection == 1)
                                selection--;
                            break;
                        case ConsoleKey.D1:
                            selection = 0;
                            break;
                    }

                }
                else
                {
                    switch (selection)
                    {
                        case 0:
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write("Look for Quests");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("           Fight a Monster");
                            PrintConnectedLocations();
                            break;
                        case 1:
                            Console.Write("Look for Quests           ");
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write("Fight a Monster");
                            Console.BackgroundColor = ConsoleColor.Black;
                            PrintConnectedLocations();
                            break;
                        default:
                            Console.WriteLine("Look for Quests           Fight a Monster");
                            for (int count = 2; count < ConnectedLocations.Count + 2; count++)
                            {
                                if (count == selection)
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                                    Console.WriteLine($"Go to {ConnectedLocations[count - 2].LocationName}");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                }
                                else
                                    Console.WriteLine($"Go to {ConnectedLocations[count - 2].LocationName}");
                            }
                            break;

                    }
                    hero.PrintHeroInformation();

                    selectionSwitch = Console.ReadKey().Key;
                    switch (selectionSwitch)
                    {
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                            if (selection > 2)
                            {
                                selection--;
                            }
                            else if (selection == 2)
                                selection = 0;
                            break;
                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow:
                            if (selection == 0)
                                selection = 2;
                            else if (selection > ConnectedLocations.Count + 2)
                                selection = ConnectedLocations.Count + 2;
                            else
                                selection++;
                            break;
                        case ConsoleKey.D:
                        case ConsoleKey.RightArrow:
                            if (selection == 0 || selection == 2)
                                selection = 1;
                            break;
                        case ConsoleKey.A:
                        case ConsoleKey.LeftArrow:
                            if (selection == 1)
                                selection--;
                            break;
                        case ConsoleKey.D1:
                            selection = 0;
                            break;
                    }

                }

            } while (selectionSwitch != ConsoleKey.Enter);

            // switch to manage the location action
            switch (selection)
            {
                // manages the looking for Quests Action
                case 0:
                    Console.WriteLine("\nQuests are currently unavailable.");
                    Thread.Sleep(2000);
                    break;

                // manages the Monster fight Action
                case 1:
                    Random rnd = new Random();
                    // selects a random Mob from the Location
                    int monsterNumber = rnd.Next(0, Monsters.Count);
                    // initialices the fight
                    Fight.Fighting(Monsters[monsterNumber]);
                    StandartLocationAction();
                    break;

                default:
                    // Handels going into a connected Location from a Semi City
                    if (isSemiCity && selection >= 3 && selection < 3 + ConnectedLocations.Count)
                    {
                        error = false;
                        ConnectedLocations[selection - 3].StandartLocationAction(true);
                        break;
                    }
                    // Handels going into a connected Location from a normal Location
                    else if (selection >= 2 && selection < 2 + ConnectedLocations.Count)
                    {
                        error = false;
                        ConnectedLocations[selection - 2].StandartLocationAction(true);
                        break;
                    }
                    // Handels going to a Trader from a Semi City
                    else if (selection == 3)
                    {
                        error = false;
                        Trader[TraderCount - 1].TraderActionChoose(Trader[TraderCount - 1].GetJobName());
                        break;
                    }
                    break;

            }

        }

    }

}