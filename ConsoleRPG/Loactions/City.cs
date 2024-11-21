using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRPG.Heros;

namespace ConsoleRPG.Loactions
{
    internal class City : Location
    {
        char cityAction = ' ';
        Hero hero = Program.hero;
        public City(string locationname, int levelZone) : base(locationname, levelZone) { }

        // Handels the player Actions done in a City lag ist da und jeder ist crazy again
        internal void StandatCityAction()
        {
            int selection = 0;
            var selectionSwitch = ConsoleKey.NoName;
            do
            {
                Console.Clear();
                Console.WriteLine($"You enter {LocationName}.");
                Console.WriteLine("What do you want to do?");
                switch (selection)
                {
                    case 0:
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write("Look for Quests");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("         Look for Traders\n");
                        PrintConnectedLocations();
                        Console.WriteLine($"open main menue [ESC]");
                        break;
                    case 1:
                        Console.Write("Look for Quests         ");
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write("Look for Traders");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine();
                        PrintConnectedLocations();
                        Console.WriteLine("open main menue [ESC]");
                        break;
                    default:
                        Console.WriteLine("Look for Quests         Look for Traders");
                        for (short count = 2; count < ConnectedLocations.Count + 2; count++)
                        {
                            if (count == selection)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.WriteLine($"Go to {ConnectedLocations[count - 2].GetLocationName()}");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                Console.WriteLine($"Go to {ConnectedLocations[count - 2].GetLocationName()}");
                            }

                        }
                        if (selection == ConnectedLocations.Count + 2)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("open main menue [ESC]");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                            Console.WriteLine("open main menue [ESC]");
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
                    case ConsoleKey.Escape:
                        selection = ConnectedLocations.Count + 2;
                        break;
                }
                if (selection > ConnectedLocations.Count + 2)
                    selection = ConnectedLocations.Count + 2;
            } while (selectionSwitch != ConsoleKey.Enter && selectionSwitch != ConsoleKey.Escape);

            switch (selection)
            {
                // Handels the Quests Action
                case 0:
                    Console.WriteLine("\nQuests are currently unavailable.");
                    Thread.Sleep(2000);
                    error = true; break;
                case 1:
                    StandartTraderAction();
                    break;
                default:
                    if (selection == ConnectedLocations.Count + 2)
                        Program.MainMenue();
                    else if (selection > 1)
                        ConnectedLocations[selection - 2].StandartLocationAction();
                    break;

            }

        }
        public void StandartTraderAction()
        {
            char traderAction = ' ';
            Console.Clear();

            Console.WriteLine($"As you look for some stores in {LocationName}, you find:");
            for (short count = 0; count < Trader.Count; count++)
            {
                Console.WriteLine($"{count + 1}. {Trader[count].GetTraderName()} the {Trader[count].GetJobName()}");
            }
            Console.WriteLine("\nWhere do you want to go?\n\n" +
                              "Back with 0.");

            do
            {
                traderAction = Console.ReadKey().KeyChar;
                switch (traderAction)
                {
                    case '0': backCheck = true; break;
                    default:
                        int actionNumber = traderAction - 49;
                        if (actionNumber > (Trader.Count - 1) || actionNumber < 0)
                        {
                            Console.WriteLine("Wrong input!");
                            error = true;
                            Thread.Sleep(1000);
                        }
                        else if (actionNumber < TraderCount)
                        {
                            Trader[actionNumber].TraderActionChoose(Trader[actionNumber].GetJobName());
                        }
                        else
                        {
                            Console.WriteLine("Wrong input!");
                            error = true;
                            Thread.Sleep(1000);
                        }
                        break;
                }

            } while (error);

        }

    }

}
