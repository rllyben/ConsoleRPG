using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Cities
{
    internal class Uruga
    {
        public static Blacksmith hans = new Blacksmith() { _name = "Hans" };
        public void UrugaAction()
        {
            char uruaAction = ' ';
            Console.Clear();

            while (uruaAction == ' ')
            {
                Console.WriteLine("\nYou enter Uruga. What do you want to do?\n" +
                                  "1. Search for Quests                     2. Go to the Healer\n" +
                                  "3. Enter the Dark Passage                4. Enter the Ancient Elven Woods");
                Console.Write("5. Enter the ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Dungon ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(" Crystal Castle      ");
                Console.ResetColor();
                Console.Write("6. Go to the Blacksmith\n\n");
                Console.WriteLine("back with 0");

                uruaAction = Console.ReadKey().KeyChar;
            }

            switch (uruaAction)
            {
                case '0': break;
                case '1':
                    Console.WriteLine("\nQuests are currently unavailable");
                    Console.ReadKey(); UrugaAction(); break;
                case '2':
                    Program.hero.Healer(); Console.WriteLine("\nThe Healer heals you to your full HP");
                    Console.ReadKey(); UrugaAction(); break;
                case '3': break;
                case '4': break;
                case '5': break;
                case '6': UruhgaBlacksmith(); break;
            }

        }
        public void UruhgaBlacksmith()
        {
            char urugaBlacksmith = ' ';

            while (urugaBlacksmith == ' ')
            {
                hans.StandartAction();
                urugaBlacksmith = Console.ReadKey().KeyChar;
            }

            switch (urugaBlacksmith)
            {
                case '0': UrugaAction(); break;
                case '1': hans.BlacksmithWeapons(); break;
                case '2': hans.BlacksmithArmor(); break;
                case '3': break;
                case '4': break;
                case '5': break;
                case '6': break;
            }

        }
    }
}
