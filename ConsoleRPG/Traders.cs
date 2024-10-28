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
        public List<Item> TraderItems { get; set; }

        char smithAction;
        public static bool backCheck = false;
        protected string TraderName { get; set; }

        public Traders(string name)
        {
            TraderItems = new List<Item>();
            TraderName = name;
        }
        public void AddItem(Item item)
        {
            TraderItems.Add(item);
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
                case '1': SmithBuyWeapons(currentTrader); break;
                default: StandartSmithAction(currentTrader); break;
            }

        }

        public void SmithBuyWeapons(Traders currentTrader)
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
                if (count + 49 >= 58)
                    posiChar = Convert.ToChar(count + 88);
                Console.WriteLine($"{posiChar}. {currentTrader.TraderItems[count].ItemName} Level: {currentTrader.TraderItems[count].Level} Dmg: {currentTrader.TraderItems[count].MinDamage} ~ {currentTrader.TraderItems[count].MaxDamage} Attack Rate: {currentTrader.TraderItems[count].ActionSpeed} Cost: {currentTrader.TraderItems[count].Cost}");
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
                            SmithBuyWeapons(currentTrader);
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
                        SmithBuyWeapons(currentTrader);
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
