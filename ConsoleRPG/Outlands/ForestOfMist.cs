using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRPG.Outlands;
using ConsoleRPG.Cities;
using ConsoleRPG;

namespace ConsoleRPG.Outlands
{
    internal class ForestOfMist
    {
        public void MistAction()
        {
            char mistAction = ' ';
            Console.Clear();

            while (mistAction == ' ')
            {
                Console.WriteLine("\nYou enter the Forest of Mist. What do you want to do?\n" +
                                  "1. Search for Quests           2. Fight with Monsters\n" +
                                  "3. Go to the Sea of Greed      4. Go to the Sandy Beach\n\n");
                Console.WriteLine("back with 0");

                mistAction = Console.ReadKey().KeyChar;
            }

            switch (mistAction)
            {
                case '0': Program.roumen.RoumenAction(); break;
                case '1':
                    Console.WriteLine("\nQuests are currently unavailable");
                    Console.ReadKey(); MistAction(); break;
                case '2': break;
                default: MistAction(); break;
            }

        }

    }

}
