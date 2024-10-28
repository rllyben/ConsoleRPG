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
        public List<Weapons> TraderWeapons { get; set; }
        public List<Armor> TraderArmor { get; set; }

        char smithAction;
        public static bool backCheck = false;
        protected string TraderName { get; set; }

        public Traders(string name)
        {
            TraderItems = new List<Item>();
            TraderWeapons = new List<Weapons>();
            TraderArmor = new List<Armor>();
            TraderName = name;
        }
        public void AddItem(Item item)
        {
            TraderItems.Add(item);
        }
        public void AddWeapon(Weapons item)
        {
            TraderWeapons.Add(item);
        }
        public void AddArmor(Armor item)
        {
            TraderArmor.Add(item);
        }
        public string GetTraderName()
        {
            return TraderName;
        }

        public void StandartSmithAction(Traders currentTrader)
        {
            if (false)
            {
                Console.WriteLine(currentTrader.TraderWeapons.Count);
            }
            backCheck = false;
            smithAction = ' ';
            Console.Clear();

            Console.WriteLine($"\nYou go to the {TraderName} the Blacksmith");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Buy a Weapon          2. Buy an Armor\n" +
                              "3. Sell loot             4. Smith a Weapon\n" +
                              "5. Smith an Armor        6. upgrade your Weapon\n");
            Console.WriteLine("\nback with 0");

            smithAction = Console.ReadKey().KeyChar;

            switch (smithAction)
            {
                case '0': backCheck = true; break;
                case '1': SmithBuyWeapons(currentTrader); break;
                case '2': SmithArmor(currentTrader); break;
                default: StandartSmithAction(currentTrader); break;
            }

        }

        public void SmithBuyWeapons(Traders currentTrader)
        {
            if (false)
            {
                Console.WriteLine(currentTrader.TraderWeapons.Count);
            }
            backCheck = false;
            smithAction = ' ';
            Console.Clear();

            Console.WriteLine($"\n{currentTrader.TraderName} has the following Weapons for you");
            for (byte count = 0; count < currentTrader.TraderWeapons.Count; count++)
            {
                char posiChar = Convert.ToChar(count + 49);
                if (count + 49 >= 58)
                    posiChar = Convert.ToChar(count + 88);
                Console.WriteLine($"{posiChar}. {currentTrader.TraderWeapons[count].ItemName} " +
                                  $"Level: {currentTrader.TraderWeapons[count].Level} " +
                                  $"Dmg: {currentTrader.TraderWeapons[count].MinDamage} ~ {currentTrader.TraderWeapons[count].MaxDamage} " +
                                  $"Attack Rate: {currentTrader.TraderWeapons[count].ActionSpeed} " +
                                  $"Cost: {currentTrader.TraderWeapons[count].Cost}");
            }
            Console.WriteLine($"You have {Program.hero.ReadCash()} Money\n" +
                               "which one do you want to buy?\n\nback with 0");
            smithAction = Console.ReadKey().KeyChar;

            switch (smithAction)
            {
                case '0': backCheck = true; break;
                default:
                    short action = (short)smithAction;
                    action -= 49;
                    if (action > 8 && action < 48)
                        action -= 100;
                    else if (action >= 48)
                        action -= 39;

                    if (action >= 0 && action < 0 + currentTrader.TraderWeapons.Count)
                    {
                        if (Program.hero.ReadCash() < currentTrader.TraderWeapons[action].Cost)
                        {
                            Console.WriteLine("You don't have enough money!");
                            Thread.Sleep(1000);
                            SmithBuyWeapons(currentTrader);
                        }
                        else
                        {
                            Program.hero.GetItem(currentTrader.TraderWeapons[action]);
                            Program.hero.PayCash(currentTrader.TraderWeapons[action].Cost);
                        }

                    }
                    else if (action != 0)
                    {
                        Console.WriteLine("\nWrong input please try again!");
                        Thread.Sleep(1000);
                        SmithBuyWeapons(currentTrader);
                    }


                    StandartSmithAction(currentTrader); break;
            }

        }
        public void SmithArmor(Traders currentTrader)
        {
            if (false)
            {
                Console.WriteLine(currentTrader.TraderArmor.Count);
            }
            backCheck = false;
            smithAction = ' ';
            Console.Clear();

            Console.WriteLine($"\n{currentTrader.TraderName} has the following Weapons for you");
            for (byte count = 0; count < currentTrader.TraderArmor.Count; count++)
            {
                char posiChar = Convert.ToChar(count + 49);
                if (count + 49 >= 58)
                    posiChar = Convert.ToChar(count + 88);
                Console.WriteLine($"{posiChar}. {currentTrader.TraderArmor[count].ItemName} " +
                                  $"Level: {currentTrader.TraderArmor[count].Level} " +
                                  $"Defance: {currentTrader.TraderArmor[count].Defance} " +
                                  $"Magical Defance: {currentTrader.TraderArmor[count].MagicalDefance} ");
                if (currentTrader.TraderArmor[count].GetType() == typeof(Shield))
                {
                    Shield shield = currentTrader.TraderArmor[count] as Shield;
                    Console.Write($"Block Rate: {shield.BlockRate} ");
                }
                Console.Write($"Cost: {currentTrader.TraderArmor[count].Cost}\n");
            }
            Console.WriteLine($"You have {Program.hero.ReadCash()} Money\n" +
                               "which one do you want to buy?\n\nback with 0");
            smithAction = Console.ReadKey().KeyChar;

            switch (smithAction)
            {
                case '0': backCheck = true; break;
                default:
                    short action = (short)smithAction;
                    action -= 49;
                    if (action > 8 && action < 48)
                        action -= 100;
                    else if (action >= 48)
                        action -= 39;

                    if (action >= 0 && action < 0 + currentTrader.TraderArmor.Count)
                    {
                        if (Program.hero.ReadCash() < currentTrader.TraderArmor[action].Cost)
                        {
                            Console.WriteLine("You don't have enough money!");
                            Thread.Sleep(1000);
                            SmithBuyWeapons(currentTrader);
                        }
                        else
                        {
                            Program.hero.GetItem(currentTrader.TraderArmor[action]);
                            Program.hero.PayCash(currentTrader.TraderArmor[action].Cost);
                        }

                    }
                    else if (action != 0)
                    {
                        Console.WriteLine("\nWrong input please try again!");
                        Thread.Sleep(1000);
                        SmithBuyWeapons(currentTrader);
                    }


                    StandartSmithAction(currentTrader); break;
            }

        }

    }

}
