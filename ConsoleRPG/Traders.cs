using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRPG;

namespace ConsoleRPG
{
    internal class Traders
    {
        if (true)
        {
        public static Items shortSword = new Items("Short Sword", 12);
        public static Items longSword = new Items("Long Sword", 75);
        public static Items broadSword = new Items("Broad Sword", 240);
        public static Items shortSword = new Items("Short Sword", 12);
        public static Items shortSword = new Items("Short Sword", 12);
        public static Items shortSword = new Items("Short Sword", 12);
        public static Items shortSword = new Items("Short Sword", 12);
        public static Items shortSword = new Items("Short Sword", 12);
        public static Items shortSword = new Items("Short Sword", 12);
        public static Items shortSword = new Items("Short Sword", 12);
        public static Items shortSword = new Items("Short Sword", 12);
        public static Items shortSword = new Items("Short Sword", 12);
        public static Items shortSword = new Items("Short Sword", 12);
        public static Items shortSword = new Items("Short Sword", 12);
        public static Items shortSword = new Items("Short Sword", 12);
        }
        char smithAction;
        public static bool backCheck = false;
        string _name;

        public Traders(string name)
        {
            _name = name;
        }

        public void StandartSmithAction()
        {
            backCheck = false;
            smithAction = ' ';
            Console.Clear();

            Console.WriteLine($"\nYou go to the {_name} the Blacksmith");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Buy a Weapon          2. Buy an Armor\n" +
                              "3. Sell loot             4. Smith a Weapon\n" +
                              "5. Smith an Armor        6. upgrade your Weapon\n");
            Console.WriteLine("back with 0");

            switch (smithAction)
            {
                case '0': backCheck = true; break;
            }

        }

        public void SmithWeapons()
        {
            backCheck = false;
            smithAction = ' ';
            Console.Clear();

            Console.WriteLine($"\n{_name} has the following Weapons for you");
            Console.WriteLine("which one do you want to buy?\n\nback with 0");
            Console.ReadKey();

            switch (smithAction)
            {
                case '0': backCheck = true; break;
            }

        }
        public void SmithArmor()
        {
            backCheck = false;
            smithAction = ' ';
            Console.WriteLine($"\n{_name} has the following Armor for you");
            Console.WriteLine("1. Lether Helmet (lvl: 1; max hp: 5;) 10$\n" +
                              "2. Lether Chestplate (lvl: 1; max hp: 15;) 20$\n" +
                              "3. Lether Leggins (lvl: 1; max hp: 10)  15$\n" +
                              "4. Lether Boots (lvl: 1; max hp 5;) 10$");
            Console.WriteLine("which one do you want to buy?\n\nback with 0");
            Console.ReadKey();

            switch (smithAction)
            {
                case '0': backCheck = true; break;
            }

        }

    }

}
