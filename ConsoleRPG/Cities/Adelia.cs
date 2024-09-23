using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Cities
{
    internal class Adelia
    {
        public static Blacksmith alexia = new Blacksmith() { _name = "Alexia" };
        public void AdeliaAction()
        {
            char adeliaAction = ' ';
            Console.Clear();

            while (adeliaAction == ' ')
            {
                Console.WriteLine("\nYou enter Roumen. What do you want to do?\n" +
                                  "1. Search for Quests           2. Go to the Healer\n" +
                                  "3. Enter the Moonlight Tomb    4. Go to the Sandy Beach\n" +
                                  "6. Enter the Collapsed Prison  5. Go to the Blacksmith\n\n");
                Console.WriteLine("back with 0");

                adeliaAction = Console.ReadKey().KeyChar;
            }

            switch (adeliaAction)
            {
                case '0': break;
                case '1':
                    Console.WriteLine("\nQuests are currently unavailable");
                    Console.ReadKey(); AdeliaAction(); break;
                case '2':
                    Program.hero.Healer(); Console.WriteLine("\nThe Healer heals you to your full HP");
                    Console.ReadKey(); AdeliaAction(); break;
                case '3': break;
                case '4': break;
                case '5': break;
                case '6': AdeliaBlacksmith(); break;
            }

        }
        public void AdeliaBlacksmith()
        {
            char adeliaBlacksmith = ' ';

            while (adeliaBlacksmith == ' ')
            {
                alexia.StandartAction();
                adeliaBlacksmith = Console.ReadKey().KeyChar;
            }

            switch (adeliaBlacksmith)
            {
                case '0': AdeliaAction(); break;
                case '1': alexia.BlacksmithWeapons(); break;
                case '2': alexia.BlacksmithArmor(); break;
                case '3': break;
                case '4': break;
                case '5': break;
                case '6': break;
            }

        }
    }
}
