using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    internal class Blacksmith
    {
        public string _name;

        public void StandartAction()
        {
            Console.Clear();

            Console.WriteLine($"\nYou go to the {_name} the Blacksmith");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Buy a Weapon          2. Buy an Armor\n" +
                              "3. Sell loot             4. Smith a Weapon\n" +
                              "5. Smith an Armor        6. upgrade your Weapon\n");
            Console.WriteLine("back with 0");
        }

        public void BlacksmithWeapons()
        {
            Console.Clear();

            Console.WriteLine($"\n{_name} has the following Weapons for you");
            Console.WriteLine("1. Adventurer Bow (lvl: 1; dmg: 5; actionSpeed: 2) 10$\n" +
                              "2. Iron Sword (lvl: 5; dmg: 15; actionSpeed: 1) 20$\n" +
                              "3. Iron Hammer (lvl: 15; dmg: 80 actionSpeed: 5)  40$");
            Console.WriteLine("which one do you want to buy?\n\nback with 0");
            Console.ReadKey();
        }
        public void BlacksmithArmor()
        {
            Console.WriteLine($"\n{_name} has the following Armor for you");
            Console.WriteLine("1. Lether Helmet (lvl: 1; max hp: 5;) 10$\n" +
                              "2. Lether Chestplate (lvl: 1; max hp: 15;) 20$\n" +
                              "3. Lether Leggins (lvl: 1; max hp: 10)  15$\n" +
                              "4. Lether Boots (lvl: 1; max hp 5;) 10$");
            Console.WriteLine("which one do you want to buy?\n\nback with 0");
            Console.ReadKey();

        }

    }

}
