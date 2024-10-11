using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRPG;
using ConsoleRPG.Loactions;

namespace ConsoleRPG
{
    internal class Traders
    {
        private static Items shortSword = new Items("Short Sword", 12, 0, 1, 4, 7, 1.1F);
        private static Items longSword = new Items("Long Sword", 75, 0, 8, 12, 20, 1.1F);
        private static Items broadSword = new Items("Broad Sword", 240, 0, 15, 19, 33, 1.1F);
        private static Items roumenSword = new Items("Roumen Sword", 6000, 0, 20, 26, 44, 1.1F);
        private static Items bridgeSword = new Items("Bridge Sword", 18000, 0, 30, 45, 78, 1.1F);
        private static Items cutlasSword = new Items("Cutlas", 38000, 0, 40, 65, 112, 1.1F);
        private static Items edgedSword = new Items("Edged Sword", 69000, 0, 50, 85, 146, 1.1F);
        private static Items steelSword = new Items("Steel Sword", 6000, 0, 20, 61, 87, 1.3F);
        private static Items crusaderSword = new Items("Crusader", 18000, 0, 30, 108, 154, 1.3F);
        private static Items twohandedSword = new Items("Zweihander", 38000, 0, 40, 155, 221, 1.3F);
        private static Items busterSword = new Items("Buster Sword", 69000, 0, 50, 202, 287, 1.3F);
        private static Items steelAxe = new Items("Steel Axe", 6000, 0, 20, 96, 134, 1.5F);
        private static Items hideAxe = new Items("Hide Axe", 18000, 0, 30, 170, 235, 1.5F);
        private static Items twoHandedAxe = new Items("Two Handed Axe", 38000, 0, 40, 243, 337, 1.5F);
        private static Items poleAxe = new Items("Pole Axe", 69000, 0, 50, 316, 438, 1.5F);
        private static Items splitterSword = new Items("Splitter", 290000, 0, 60, 105, 181, 1.1F);
        private static Items avantSword = new Items("Avent Garde Sword", 440000, 0, 70, 131, 226, 1.1F);
        private static Items sperpentSword = new Items("Serpent Sword", 640000, 0, 80, 164, 282, 1.1F);
        private static Items claymoreSword = new Items("Claymore", 290000, 0, 60, 250, 356, 1.3F);
        private static Items flambergeSword = new Items("Flamberge", 440000, 0, 70, 312, 444, 1.3F);
        private static Items giantSword = new Items("Giand Sword", 640000, 0, 80, 389, 555, 1.3F);
        private static Items halbendAxe = new Items("Halberd", 290000, 0, 60, 392, 543, 1.5F);
        private static Items vikingAxe = new Items("Viking Axe", 440000, 0, 70, 490, 678, 1.5F);
        private static Items giantAxe = new Items("Giand Axe", 640000, 0, 80, 613, 850, 1.5F);
        private static Items vulcanSword = new Items("Vulcan Sword", 890000, 0, 90, 275, 423, 1.1F);
        private static Items hellasSword = new Items("Hellas Sword", 2230000, 0, 100, 412, 634, 1.1F);
        private static Items gedSword = new Items("Ged Sword", 3080000, 0, 108, 618, 951, 1.1F);
        private static Items titanicSword = new Items("Titanic Sword", 890000, 0, 90, 541, 832, 1.3F);
        private static Items valorSword = new Items("Valor Sword", 2230000, 0, 100, 811, 1248, 1.3F);
        private static Items gorgonSword = new Items("Gorgon Sword", 3080000, 0, 108, 1216, 1872, 1.3F);
        private static Items titanicAxe = new Items("Titanic Axe", 890000, 0, 90, 829, 1275, 1.5F);
        private static Items valorAxe = new Items("Valor Axe", 2230000, 0, 100, 1243, 1912, 1.5F);
        private static Items gorgonAxe = new Items("Gorgon Axe", 3080000, 0, 108, 1864, 2868, 1.5F);
        public List<Items> TraderItems { get; set; }

        char smithAction;
        public static bool backCheck = false;
        protected string TraderName {get; set;}

        public Traders(string name)
        {
            TraderItems = new List<Items>();
            TraderName = name;
        }
        public void AddItem(Items item)
        {
            TraderItems.Add(item);              
        }

        public static void TraderItemInitilation()
        {
            City.james.AddItem(shortSword);
            City.james.AddItem(longSword);
            City.james.AddItem(broadSword);
            City.karl.AddItem(roumenSword);
            City.karl.AddItem(bridgeSword);
            City.karl.AddItem(cutlasSword);
            City.karl.AddItem(edgedSword);
            City.karl.AddItem(steelSword);
            City.karl.AddItem(crusaderSword);
            City.karl.AddItem(twohandedSword);
            City.karl.AddItem(busterSword);
            City.karl.AddItem(steelAxe);
            City.karl.AddItem(hideAxe);
            City.karl.AddItem(twoHandedAxe);
            City.karl.AddItem(poleAxe);
            Location.rohan.AddItem(roumenSword);
            Location.rohan.AddItem(bridgeSword);
            Location.rohan.AddItem(cutlasSword);
            Location.rohan.AddItem(edgedSword);
            Location.rohan.AddItem(steelSword);
            Location.rohan.AddItem(crusaderSword);
            Location.rohan.AddItem(twohandedSword);
            Location.rohan.AddItem(busterSword);
            Location.rohan.AddItem(steelAxe);
            Location.rohan.AddItem(hideAxe);
            Location.rohan.AddItem(twoHandedAxe);
            Location.rohan.AddItem(poleAxe);
            City.hans.AddItem(splitterSword);
            City.hans.AddItem(avantSword);
            City.hans.AddItem(sperpentSword);
            City.hans.AddItem(claymoreSword);
            City.hans.AddItem(flambergeSword);
            City.hans.AddItem(giantSword);
            City.hans.AddItem(halbendAxe);
            City.hans.AddItem(vikingAxe);
            City.hans.AddItem(giantAxe);
            Location.marcudos.AddItem(vulcanSword);
            Location.marcudos.AddItem(hellasSword);
            Location.marcudos.AddItem(gedSword);
            Location.marcudos.AddItem(titanicSword);
            Location.marcudos.AddItem(valorSword);
            Location.marcudos.AddItem(gorgonSword);
            Location.marcudos.AddItem(titanicAxe);
            Location.marcudos.AddItem(valorAxe);
            Location.marcudos.AddItem(gorgonAxe);
            City.alexia.AddItem(splitterSword);
            City.alexia.AddItem(avantSword);
            City.alexia.AddItem(sperpentSword);
            City.alexia.AddItem(claymoreSword);
            City.alexia.AddItem(flambergeSword);
            City.alexia.AddItem(giantSword);
            City.alexia.AddItem(halbendAxe);
            City.alexia.AddItem(vikingAxe);
            City.alexia.AddItem(giantAxe);

            if (false)
            {
                Console.WriteLine("james:" + City.james.TraderItems.Count);
                Console.WriteLine("karl:" + City.karl.TraderItems.Count);
                Console.WriteLine("rohan:" + Location.rohan.TraderItems.Count);
                Console.WriteLine("hans:" + City.hans.TraderItems.Count);
                Console.WriteLine("marcudos:" + Location.marcudos.TraderItems.Count);
                Console.WriteLine("alexia:" + City.alexia.TraderItems.Count);
            }
        }

        public string GetTraderName()
        {
            return TraderName;
        }

        public void StandartSmithAction(Traders currentTrader)
        {
            if (false)
            {
                Console.WriteLine(currentTrader.TraderItems.Count);
            }
            backCheck = false;
            smithAction = ' ';
            Console.Clear();

            Console.WriteLine($"\nYou go to the {TraderName} the Blacksmith");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Buy a Weapon          2. Buy an Armor\n" +
                              "3. Sell loot             4. Smith a Weapon\n" +
                              "5. Smith an Armor        6. upgrade your Weapon\n");
            Console.WriteLine();
            Console.WriteLine("back with 0");

            smithAction = Console.ReadKey().KeyChar;

            switch (smithAction)
            {
                case '0': backCheck = true; break;
                case '1': SmithWeapons(currentTrader); break;
                default: StandartSmithAction(currentTrader); break;
            }

        }

        public void SmithWeapons(Traders currentTrader)
        {

            if (false)
            {
                Console.WriteLine(currentTrader.TraderItems.Count);
            }
            backCheck = false;
            smithAction = ' ';
            Console.Clear();

            Console.WriteLine($"\n{currentTrader.TraderName} has the following Weapons for you");
            for (byte count = 0; count < currentTrader.TraderItems.Count; count++)
            {
                Console.WriteLine($"{count + 1}. {currentTrader.TraderItems[count].ItemName} Level: {currentTrader.TraderItems[count].Level}Dmg: {currentTrader.TraderItems[count].MinDamage} ~ {currentTrader.TraderItems[count].MaxDamage} Attack Rate: {currentTrader.TraderItems[count].ActionSpeed} Cost: {currentTrader.TraderItems[count].Cost}");
            }
            Console.WriteLine();
            Console.WriteLine($"You have {Program.hero.ReadCash()} Money");
            Console.WriteLine();
            Console.WriteLine("which one do you want to buy?\n\nback with 0");
            smithAction = Console.ReadKey().KeyChar;

            switch (smithAction)
            {
                case '0': backCheck = true; break;
                default:
                    short action = (short)smithAction;
                    action -= 49;
                    if (action >= 0 && action < 0 + currentTrader.TraderItems.Count)
                    {
                        if (Program.hero.ReadCash() < currentTrader.TraderItems[action].Cost)
                        {
                            Console.WriteLine("You don't have enough money!");
                            Thread.Sleep(1000);
                            SmithWeapons(currentTrader);
                        }
                        else
                        {
                            Program.hero.GetItem(currentTrader.TraderItems[action]);
                            Program.hero.PayCash(currentTrader.TraderItems[action].Cost);
                        }
                            
                    }
                    else if (action != 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Wrong input please try again!");
                        Thread.Sleep(1000);
                        SmithWeapons(currentTrader);
                    }


                    StandartSmithAction(currentTrader); break;
            }

        }
        public void SmithArmor(Traders currentTrader)
        {
            if (true)
            {
                Console.WriteLine($"\n{TraderName} has at the moment sadly no Armor, maybe later.");
                Thread.Sleep(2000);
                StandartSmithAction(currentTrader);
            }

            backCheck = false;
            smithAction = ' ';
            Console.WriteLine($"\n{TraderName} has the following Armor for you");
            Console.WriteLine("1. Lether Helmet (lvl: 1; max hp: 5;) 10$\n" +
                              "2. Lether Chestplate (lvl: 1; max hp: 15;) 20$\n" +
                              "3. Lether Leggins (lvl: 1; max hp: 10)  15$\n" +
                              "4. Lether Boots (lvl: 1; max hp 5;) 10$");
            Console.WriteLine("which one do you want to buy?\n\nback with 0");
            Console.ReadKey();

            switch (smithAction)
            {
                case '0': backCheck = true; break;
                default: StandartSmithAction(currentTrader); break;
            }

        }

    }

}
