using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRPG;
using ConsoleRPG.Cities;
using ConsoleRPG.Outlands;

namespace ConsoleRPG.Cities
{
    internal class Roumen
    {
        public static Blacksmith james = new Blacksmith() { _name = "James" };
        public static ForestOfMist mist = new ForestOfMist();
        public void RoumenAction()
        {
            char roumenAction = ' ';
            Console.Clear();

            while (roumenAction == ' ')
            {
                Console.WriteLine("\nYou enter Roumen. What do you want to do?\n" +
                                  "1. Search for Quests           2. Go to the Healer\n" +
                                  "3. Enter the Forest of Mist    4. Go to the Sandy Beach\n" +
                                  "5. Go to the Blacksmith");
                Console.WriteLine("back with 0");

                roumenAction = Console.ReadKey().KeyChar;
            }

            switch (roumenAction)
            {
                case '0': break;
                case '1':
                    Console.WriteLine("\nQuests are currently unavailable");
                    Console.ReadKey(); RoumenAction(); break;
                case '2':
                    Program.hero.Healer(); Console.WriteLine("\nThe Healer heals you to your full HP");
                    Console.ReadKey(); RoumenAction(); break;
                case '3': mist.MistAction(); break;
                case '4': break;
                case '5': RoumenBlacksmith(); break;
                default: RoumenAction(); break;
            }

        }
        public void RoumenBlacksmith()
        {
            char roumenBlacksmith = ' ';

            while (roumenBlacksmith == ' ')
            {
                james.StandartAction();
                roumenBlacksmith = Console.ReadKey().KeyChar;
            }

            switch (roumenBlacksmith)
            {
                case '0': RoumenAction(); break;
                case '1': james.BlacksmithWeapons(); break;
                case '2': james.BlacksmithArmor(); break;
                case '3': break;
                case '4': break;
                case '5': break;
                case '6': break;
                default : RoumenBlacksmith(); break;
            }

        }

    }

}
