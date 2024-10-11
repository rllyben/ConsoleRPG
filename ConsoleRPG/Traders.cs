using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRPG;
using ConsoleRPG.Items;
using ConsoleRPG.Loactions;

namespace ConsoleRPG
{
    internal class Traders
    {
        private static Weapons shortSword = new Weapons("Short Sword", 12, 1, 4, 7, 1.1F);
        private static Weapons longSword = new Weapons("Long Sword", 75, 8, 12, 20, 1.1F);
        private static Weapons broadSword = new Weapons("Broad Sword", 240, 15, 19, 33, 1.1F);
        private static Armor leatherBoots = new Armor("Leatehr Boots", 13, 0, 1, 2, 0, 1, 0);
        private static Armor leatherHelmet = new Armor("Leatehr Helmet", 20, 0, 1, 4, 1, 2, 1);
        private static Armor leatherPants = new Armor("Leatehr Pants", 35, 0, 1, 6, 2, 4, 0);
        private static Armor leatherShirt = new Armor("Leatehr Shirt", 61, 50, 1, 9, 4, 7, 0);
        private static Armor chainBoots = new Armor("Chain Boots", 80, 0, 8, 9, 4, 8, 0);
        private static Armor chainHelmet = new Armor("Chain Helmet", 120, 0, 8, 11, 5, 10, 4);
        private static Armor chainPants = new Armor("Chain Pants", 200, 0, 8, 14, 7, 12, 0);
        private static Shield wooddenShield = new Shield("Wodden Shield", 10, 0, 1, 5, 0, 0, 0, 1);
        private static Shield buckler = new Shield("Buckler", 55, 0, 8, 14, 3, 0, 0, 2);
        private static Weapons roumenSword = new Weapons("Roumen Sword", 6000, 20, 26, 44, 1.1F);
        private static Weapons bridgeSword = new Weapons("Bridge Sword", 18000, 30, 45, 78, 1.1F);
        private static Weapons cutlasSword = new Weapons("Cutlas", 38000, 40, 65, 112, 1.1F);
        private static Weapons edgedSword = new Weapons("Edged Sword", 69000, 50, 85, 146, 1.1F);
        private static Weapons steelSword = new Weapons("Steel Sword", 6000, 20, 61, 87, 1.3F);
        private static Weapons crusaderSword = new Weapons("Crusader", 18000, 30, 108, 154, 1.3F);
        private static Weapons twohandedSword = new Weapons("Zweihander", 38000, 40, 155, 221, 1.3F);
        private static Weapons busterSword = new Weapons("Buster Sword", 69000, 50, 202, 287, 1.3F);
        private static Weapons steelAxe = new Weapons("Steel Axe", 6000, 20, 96, 134, 1.5F);
        private static Weapons hideAxe = new Weapons("Hide Axe", 18000, 30, 170, 235, 1.5F);
        private static Weapons twoHandedAxe = new Weapons("Two Handed Axe", 38000, 40, 243, 337, 1.5F);
        private static Weapons poleAxe = new Weapons("Pole Axe", 69000, 50, 316, 438, 1.5F);
        private static Weapons splitterSword = new Weapons("Splitter", 290000, 60, 105, 181, 1.1F);
        private static Weapons avantSword = new Weapons("Avent Garde Sword", 440000, 70, 131, 226, 1.1F);
        private static Weapons sperpentSword = new Weapons("Serpent Sword", 640000, 80, 164, 282, 1.1F);
        private static Weapons claymoreSword = new Weapons("Claymore", 290000, 60, 250, 356, 1.3F);
        private static Weapons flambergeSword = new Weapons("Flamberge", 440000, 70, 312, 444, 1.3F);
        private static Weapons giantSword = new Weapons("Giand Sword", 640000, 80, 389, 555, 1.3F);
        private static Weapons halbendAxe = new Weapons("Halberd", 290000, 60, 392, 543, 1.5F);
        private static Weapons vikingAxe = new Weapons("Viking Axe", 440000, 70, 490, 678, 1.5F);
        private static Weapons giantAxe = new Weapons("Giand Axe", 640000, 80, 613, 850, 1.5F);
        private static Weapons vulcanSword = new Weapons("Vulcan Sword", 890000, 90, 275, 423, 1.1F);
        private static Weapons hellasSword = new Weapons("Hellas Sword", 2230000, 100, 412, 634, 1.1F);
        private static Weapons gedSword = new Weapons("Ged Sword", 3080000, 108, 618, 951, 1.1F);
        private static Weapons titanicSword = new Weapons("Titanic Sword", 890000, 90, 541, 832, 1.3F);
        private static Weapons valorSword = new Weapons("Valor Sword", 2230000, 100, 811, 1248, 1.3F);
        private static Weapons gorgonSword = new Weapons("Gorgon Sword", 3080000, 108, 1216, 1872, 1.3F);
        private static Weapons titanicAxe = new Weapons("Titanic Axe", 890000, 90, 829, 1275, 1.5F);
        private static Weapons valorAxe = new Weapons("Valor Axe", 2230000, 100, 1243, 1912, 1.5F);
        private static Weapons gorgonAxe = new Weapons("Gorgon Axe", 3080000, 108, 1864, 2868, 1.5F);
        public List<Item> TraderItems { get; set; }

        char smithAction;
        public static bool backCheck = false;
        protected string TraderName {get; set;}

        public Traders(string name)
        {
            TraderItems = new List<Item>();
            TraderName = name;
        }
        public void AddItem(Item item)
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
                char posiChar = Convert.ToChar(count + 49);
                if (count + 49   >= 58)
                    posiChar = Convert.ToChar(count + 88);
                Console.WriteLine($"{posiChar}. {currentTrader.TraderItems[count].ItemName} Level: {currentTrader.TraderItems[count].Level}Dmg: {currentTrader.TraderItems[count].MinDamage} ~ {currentTrader.TraderItems[count].MaxDamage} Attack Rate: {currentTrader.TraderItems[count].ActionSpeed} Cost: {currentTrader.TraderItems[count].Cost}");
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
                    if (action > 8 && action < 48)
                    {
                        action -= 100;
                    }
                    else if (action >= 48)
                    {
                        action -= 39;
                    }

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
