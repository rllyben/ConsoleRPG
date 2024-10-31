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
        private bool error = false;

        public City(string locationname, int levelZone) : base(locationname, levelZone) { }

        // Handels the player Actions done in a City
        internal void StandatCityAction()
        {
            Console.Clear();
            backCheck = false;
            char cityAction = ' ';

            while (cityAction == ' ')
            {
                // Checks if the Location is a City
                if (ID != 1 && ID != 7 && ID != 18 && ID != 26)
                {
                    StandartLocationAction(true);
                }
                // Goes for printing to the Standart Location Action and afterwords comes back
                StandartLocationAction(false);

                // prints the Main Menue option
                Console.WriteLine($"{ConnectedLocations.Count + 3}. open main menue");
                Console.WriteLine();
                // Prints the most important Player Stats
                Console.WriteLine($"{Program.hero}: Level: {Program.hero.Level} XP: {Program.hero.Experience}/{Program.hero.Level * Program.hero.Level * 2} " + 
                                  $"HP: {Program.hero.CurrentHealth} / {Program.hero.MaximalHealth} MP: {Program.hero.ManaPoints} / {Program.hero.MaxiamlManaPoints}\n" +
                                  $"Money: {Program.hero.Cash}");
                Console.WriteLine();
                Console.WriteLine("0. Back");

                cityAction = Console.ReadKey().KeyChar;
            }

            switch (cityAction)
            {
                // Handels the Back Option
                case '0': backCheck = true; break;
                // Handels the Quests Action
                case '1':
                    Console.WriteLine();
                    Console.WriteLine("Quests are currently unavailable.");
                    Thread.Sleep(2000);
                    StandatCityAction(); break;
                default:
                    // Makes the city Action char to Number
                    short action = (short)cityAction;
                    action -= 48;
                    // Hanels the Connected Locations
                    if (action >= 3 && action < 3 + ConnectedLocations.Count)
                    {
                        Location nextLocation = ConnectedLocations[action - 3];
                        nextLocation.StandartLocationAction();

                    }
                    // Handels the Trader Action
                    else if (action == 2)
                    {
                        StandartTraderAction();
                    }
                    // Handels the Main Menue
                    else if (action == 3 + ConnectedLocations.Count)
                    {
                        Program.MainMenue();
                    }
                    // Handels wrong Inputs
                    else if (action != 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Wrong input please try again!");
                        Thread.Sleep(1000);
                        StandartLocationAction();
                    }
                    StandatCityAction();
                    break;
            }

        }
        public void StandartTraderAction()
        {
            backCheck = false;
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
