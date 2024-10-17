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

        internal void StandatCityAction()
        {
            Console.Clear();
            backCheck = false;
            cityAction = ' ';

            while (cityAction == ' ')
            {
                if (ID != 1 && ID != 7 && ID != 18 && ID != 26)
                {
                    StandartLocationAction(true);
                }
                StandartLocationAction(false);
                Console.WriteLine($"{ConnectedLocations.Count + 4}. open main menue");
                Console.WriteLine();
                Console.WriteLine($"{Program.hero}: Level: {Program.hero.Level} XP: {Program.hero.Experience}/{Program.hero.Level * Program.hero.Level * 2} HP: {Program.hero.CurrentHealth} / {Program.hero.MaximalHealth} Money: {Program.hero.Cash}");
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
                    StandatCityAction(); break;
                default:
                    short action = (short)cityAction;
                    action -= 48;
                    if (action >= 4 && action < 4 + ConnectedLocations.Count)
                    {
                        Location nextLocation = ConnectedLocations[action - 4];
                        nextLocation.StandartLocationAction();

                    }
                    else if (action == 2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("The Healer Heals you to your full HP");
                        Program.hero.Healer();
                        Thread.Sleep(2000);
                        StandatCityAction();
                    }
                    else if (action == 3)
                    {
                        Trader[TraderCount - 1].StandartSmithAction(Trader[TraderCount - 1]);
                    }
                    else if (action == 4 + ConnectedLocations.Count)
                    {
                        Program.MainMenue();
                    }
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

    }

}
