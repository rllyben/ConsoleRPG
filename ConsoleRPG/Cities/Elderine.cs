using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Cities
{
    internal class Elderine
    {
        public static Blacksmith karl = new Blacksmith() { _name = "Karl" };
        public void ElderineAction()
        {
            char elderineAction = ' ';
            Console.Clear();

            while (elderineAction == ' ')
            {
                Console.WriteLine("\nYou enter Roumen. What do you want to do?\n" +
                                  "1. Search for Quests           2. Go to the Healer\n" +
                                  "3. Enter the Moonlight Tomb    4. Go to the Sea of Greed\n" +
                                  "6. Enter the Collapsed Prison  5. Go to the Blacksmith\n\n");
                Console.WriteLine("back with 0");

                elderineAction = Console.ReadKey().KeyChar;
            }

            switch (elderineAction)
            {
                case '0': break;
                case '1':
                    Console.WriteLine("\nQuests are currently unavailable");
                    Console.ReadKey(); ElderineAction(); break;
                case '2':
                    Program.hero.Healer(); Console.WriteLine("\nThe Healer heals you to your full HP");
                    Console.ReadKey(); ElderineAction(); break;
                case '3': break;
                case '4': break;
                case '5': break;
                case '6': ElderineBlacksmith(); break;
            }

        }
        public void ElderineBlacksmith()
        {
            char elderineBlacksmith = ' ';

            while (elderineBlacksmith == ' ')
            {
                karl.StandartAction();
                elderineBlacksmith = Console.ReadKey().KeyChar;
            }

            switch (elderineBlacksmith)
            {
                case '0': ElderineAction(); break;
                case '1': karl.BlacksmithWeapons(); break;
                case '2': karl.BlacksmithArmor(); break;
                case '3': break;
                case '4': break;
                case '5': break;
                case '6': break;
            }

        }

    }

}
