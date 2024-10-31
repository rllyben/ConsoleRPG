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
        public static bool backCheck = false;
        protected string TraderName { get; set; }
        protected string Job {  get; set; }
        private bool error = false;

        public Traders(string name, string job)
        {
            TraderItems = new List<Item>();
            TraderWeapons = new List<Weapons>();
            TraderArmor = new List<Armor>();
            TraderName = name;
            Job = job;
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
        public string GetJobName() 
        { 
            return Job; 
        
        }
        public void TraderActionChoose(string job)
        {
            switch (job)
                {
                case "Smith": StandartSmithAction(); break;
                case "Healer": StandartHealerAction(); break;
                case "": 
                    Console.Clear(); 
                    Console.WriteLine("An error acured please report..."); 
                    Thread.Sleep(1000); 
                    break;
            }
        }
        public void StandartHealerAction()
        {
            backCheck = false;
            char healerAction = ' ';
            Console.Clear();

            Console.WriteLine($"\nYou go to {TraderName} the Healer\n" +
                              $"What do you want to do?\n" +
                              $"1. Get Healed           2. Buy energy stomes\n\n" +
                              $"Back with 0.");

            do
            {
                healerAction = Console.ReadKey().KeyChar;

                switch (healerAction)
                {
                    case '0': error = false; backCheck = true; break;
                    case '1': error = false; 
                        Program.hero.Healer();
                        Console.WriteLine($"{TraderName} heals you to full HP and MP");
                        Thread.Sleep(1000);
                        break;
                    case '2': error = false; HealerSelling(); break;
                    default:
                        Console.WriteLine("Wrong input");
                        error = true;
                        break;
                }
            } while (error);

        }
        public void HealerSelling()
        {
            int cost = 5;
            Console.Clear();
            Console.WriteLine("What do you want to buy?\n" +
                              "1. HP Stones         2. MP Stones\n" +
                              "\nBack with 0.");
           
            char healerAction = ' ';

            do
            {
                healerAction = Console.ReadKey().KeyChar;
                switch (healerAction)
                    {
                    case '0': error = false; backCheck= true; break;
                    case '1': error = false; break;
                    case '2': error = false; break;
                    default: 
                        error = true;
                        Console.WriteLine("Wrong input");
                        Thread.Sleep(1000);
                        break;
                }

            }while (error);

            if (healerAction == '1')
            {
                ConsoleKey action = ConsoleKey.NoName;
                int buyCount = 0;
                do
                {
                    Console.Clear();
                    Console.WriteLine("How many HP Stones do you want to buy?");
                    Console.WriteLine($"{buyCount} HP Stones for {cost * buyCount}");
                    action = Console.ReadKey().Key;
                    switch (action)
                    {
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.W: buyCount++; break;
                        case ConsoleKey.DownArrow:
                        case ConsoleKey.S: buyCount--; break;
                    }
                    if (buyCount < 0)
                        buyCount = 0;
                } while (action != ConsoleKey.Enter);

                Program.hero.PayCash(cost * buyCount);
                Program.hero.GetHPStones(buyCount);
            }
            if (healerAction == '2')
            {
                ConsoleKey action = ConsoleKey.NoName;
                int buyCount = 0;
                do
                {
                    Console.Clear();
                    Console.WriteLine("How many MP Stones do you want to buy?");
                    Console.WriteLine($"{buyCount} MP Stones for {cost * buyCount}");
                    action = Console.ReadKey().Key;
                    switch (action)
                    {
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.W: buyCount++; break;
                        case ConsoleKey.DownArrow:
                        case ConsoleKey.S: buyCount--; break;
                    }
                    if (buyCount < 0)
                        buyCount = 0;
                } while (action != ConsoleKey.Enter);

                Program.hero.PayCash(cost * buyCount);
                Program.hero.GetMPStones(buyCount);
            }

        }
        private void StandartSmithAction()
        {
            backCheck = false;
            char smithAction = ' ';
            Console.Clear();

            Console.WriteLine($"\nYou go to {TraderName} the Blacksmith");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Buy a Weapon          2. Buy an Armor\n" +
                              "3. Sell loot             4. Smith a Weapon\n" +
                              "5. Smith an Armor        6. upgrade your Weapon\n");
            Console.WriteLine("\nback with 0");

            smithAction = Console.ReadKey().KeyChar;

            switch (smithAction)
            {
                case '0': backCheck = true; break;
                case '1': SmithBuyWeapons(); break;
                case '2': SmithArmor(); break;
                default: StandartSmithAction(); break;
            }

        }

        private void SmithBuyWeapons()
        {
            backCheck = false;
            char smithAction = ' ';
            Console.Clear();

            Console.WriteLine($"\n{TraderName} has the following Weapons for you");
            for (byte count = 0; count < TraderWeapons.Count; count++)
            {
                char posiChar = Convert.ToChar(count + 49);
                if (count + 49 >= 58)
                    posiChar = Convert.ToChar(count + 88);
                Console.WriteLine($"{posiChar}. {TraderWeapons[count].ItemName} " +
                                  $"Level: {TraderWeapons[count].Level} " +
                                  $"Dmg: {TraderWeapons[count].MinDamage} ~ {TraderWeapons[count].MaxDamage} " +
                                  $"Attack Rate: {TraderWeapons[count].ActionSpeed} " +
                                  $"Cost: {TraderWeapons[count].Cost}");
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

                    if (action >= 0 && action < 0 + TraderWeapons.Count)
                    {
                        if (Program.hero.ReadCash() < TraderWeapons[action].Cost)
                        {
                            Console.WriteLine("You don't have enough money!");
                            Thread.Sleep(1000);
                            SmithBuyWeapons();
                        }
                        else
                        {
                            Program.hero.GetItem(TraderWeapons[action]);
                            Program.hero.PayCash(TraderWeapons[action].Cost);
                        }

                    }
                    else if (action != 0)
                    {
                        Console.WriteLine("\nWrong input please try again!");
                        Thread.Sleep(1000);
                        SmithBuyWeapons();
                    }


                    StandartSmithAction(); break;
            }

        }
        public void SmithArmor()
        {
            backCheck = false;
            char smithAction = ' ';
            Console.Clear();

            Console.WriteLine($"\n{TraderName} has the following Weapons for you");
            for (byte count = 0; count < TraderArmor.Count; count++)
            {
                char posiChar = Convert.ToChar(count + 49);
                if (count + 49 >= 58)
                    posiChar = Convert.ToChar(count + 88);
                Console.WriteLine($"{posiChar}. {TraderArmor[count].ItemName} " +
                                  $"Level: {TraderArmor[count].Level} " +
                                  $"Defance: {TraderArmor[count].Defance} " +
                                  $"Magical Defance: {TraderArmor[count].MagicalDefance} ");
                if (TraderArmor[count].GetType() == typeof(Shield))
                {
                    Shield shield = TraderArmor[count] as Shield;
                    Console.Write($"Block Rate: {shield.BlockRate} ");
                }
                Console.Write($"Cost: {TraderArmor[count].Cost}\n");
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

                    if (action >= 0 && action < 0 + TraderArmor.Count)
                    {
                        if (Program.hero.ReadCash() < TraderArmor[action].Cost)
                        {
                            Console.WriteLine("You don't have enough money!");
                            Thread.Sleep(1000);
                            SmithBuyWeapons();
                        }
                        else
                        {
                            Program.hero.GetItem(TraderArmor[action]);
                            Program.hero.PayCash(TraderArmor[action].Cost);
                        }

                    }
                    else if (action != 0)
                    {
                        Console.WriteLine("\nWrong input please try again!");
                        Thread.Sleep(1000);
                        SmithBuyWeapons();
                    }


                    StandartSmithAction(); break;
            }

        }

    }

}
