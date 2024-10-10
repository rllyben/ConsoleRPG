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
        public static void ItemDeclaration()
        {
            Items shortSword = new Items("Short Sword", 12, 0, 1, 4, 7, 1.1F);
            Items longSword = new Items("Long Sword", 75, 0, 8, 12, 20, 1.1F);
            Items broadSword = new Items("Broad Sword", 240, 0, 15, 19, 33, 1.1F);
            Items roumenSword = new Items("Roumen Sword", 6000, 0, 20, 26, 44, 1.1F);
            Items bridgeSword = new Items("Bridge Sword", 18000, 0, 30, 45, 78, 1.1F);
            Items cutlasSword = new Items("Cutlas", 38000, 0, 40, 65, 112, 1.1F);
            Items edgedSword = new Items("Edged Sword", 69000, 0, 50, 85, 146, 1.1F);
            Items steelSword = new Items("Steel Sword", 6000, 0, 20, 61, 87, 1.3F);
            Items crusaderSword = new Items("Crusader", 18000, 0, 30, 108, 154, 1.3F);
            Items twohandedSword = new Items("Zweihander", 38000, 0, 40, 155, 221, 1.3F);
            Items busterSword = new Items("Buster Sword", 69000, 0, 50, 202, 287, 1.3F);
            Items steelAxe = new Items("Steel Axe", 6000, 0, 20, 96, 134, 1.5F);
            Items hideAxe = new Items("Hide Axe", 18000, 0, 30, 170, 235, 1.5F);
            Items twoHandedAxe = new Items("Two Handed Axe", 38000, 0, 40, 243, 337, 1.5F);
            Items poleAxe = new Items("Pole Axe", 69000, 0, 50, 316, 438, 1.5F);
            Items splitterSword = new Items("Splitter", 290000, 0, 60, 105, 181, 1.1F);
            Items avantSword = new Items("Avent Garde Sword", 440000, 0, 70, 131, 226, 1.1F);
            Items sperpentSword = new Items("Serpent Sword", 640000, 0, 80, 164, 282, 1.1F);
            Items claymoreSword = new Items("Claymore", 290000, 0, 60, 250, 356, 1.3F);
            Items flambergeSword = new Items("Flamberge", 440000, 0, 70, 312, 444, 1.3F);
            Items giantSword = new Items("Giand Sword", 640000, 0, 80, 389, 555, 1.3F);
            Items halbendAxe = new Items("Halberd", 290000, 0, 60, 392, 543, 1.5F);
            Items vikingAxe = new Items("Viking Axe", 440000, 0, 70, 490, 678, 1.5F);
            Items giantAxe = new Items("Giand Axe", 640000, 0, 80, 613, 850, 1.5F);
            Items vulcanSword = new Items("Vulcan Sword", 890000, 0, 90, 275, 423, 1.1F);
            Items hellasSword = new Items("Hellas Sword", 2230000, 0, 100, 412, 634, 1.1F);
            Items gedSword = new Items("Ged Sword", 3080000, 0, 108, 618, 951, 1.1F);
            Items titanicSword = new Items("Titanic Sword", 890000, 0, 90, 541, 832, 1.3F);
            Items valorSword = new Items("Valor Sword", 2230000, 0, 100, 811, 1248, 1.3F);
            Items gorgonSword = new Items("Gorgon Sword", 3080000, 0, 108, 1216, 1872, 1.3F);
            Items titanicAxe = new Items("Titanic Axe", 890000, 0, 90, 829, 1275, 1.5F);
            Items valorAxe = new Items("Valor Axe", 2230000, 0, 100, 1243, 1912, 1.5F);
            Items gorgonAxe = new Items("Gorgon Axe", 3080000, 0, 108, 1864, 2868, 1.5F);
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
