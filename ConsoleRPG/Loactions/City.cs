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

        // Handels the player Actions done in a City
        internal void StandatCityAction()
        {
            do
            {
                Console.Clear();
                Console.WriteLine($"You enter {LocationName}.");
                Console.WriteLine("What do you want to do?");

                Console.Write("1. Look for Quests           2. Look for Traders\n");
                PrintConnectedLocations();

                Console.WriteLine($"{ConnectedLocations.Count + 3}. open main menue");
                Console.WriteLine("\n0. Back");

                hero.PrintHeroInformation();

                cityAction = Console.ReadKey().KeyChar;

                switch (cityAction)
                {
                    // Handels the Back Option
                    case '0': error = false; break;
                    // Handels the Quests Action
                    case '1':
                        Console.WriteLine("\nQuests are currently unavailable.");
                        Thread.Sleep(2000);
                        error = true; break;
                    default:
                        // Makes the city Action char to Number
                        short action = (short)cityAction;
                        action -= 48;
                        // Hanels the Connected Locations
                        if (action >= 3 && action < 3 + ConnectedLocations.Count)
                        {
                            error = false;
                            ConnectedLocations[action - 3].StandartLocationAction();
                            break;
                        }
                        // Handels the Trader Action
                        else if (action == 2)
                        {
                            error = true;
                            StandartTraderAction();
                            break;
                        }
                        // Handels the Main Menue
                        else if (action == 3 + ConnectedLocations.Count)
                        {
                            error = false;
                            Program.MainMenue();
                            break;
                        }
                        // Handels wrong Inputs
                        else
                        {
                            error = true;
                            Console.WriteLine("\nWrong input please try again!");
                            Thread.Sleep(1000);
                            StandartLocationAction();
                            break;
                        }

                }

            } while (error);

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
                        else if (actionNumber < TraderCount )
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
