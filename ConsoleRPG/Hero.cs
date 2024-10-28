using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using ConsoleRPG;
using ConsoleRPG.Fighting;
using System.Runtime.CompilerServices;
using System.Collections;
using ConsoleRPG.Items;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace ConsoleRPG
{
    internal class Hero
    {
        
        public List<Item> Inventory { get; set; }
        public Item[] EquiptItems { get; set; }
        public string CharacterClass { get; set; } = "null";
        public int Cash { get; set; } = 0;
        public string Name { get; set; }
        public int CurrentHealth { get; set; }
        public int STR { get; set; } = 0;
        public int STRIncreased { get; set; } = 0;
        public int DEX { get; set; } = 0;
        public int DEXIncreased { get; set; } = 0;
        public int END { get; set; } = 0;
        public int ENDIncreased { get; set; } = 0;
        public int INT { get; set; } = 0;
        public int INTIncreased { get; set; } = 0;
        public int SPR { get; set; } = 0;
        public int SPRIncreased { get; set; } = 0;
        public int Level { get; set; } = 0;
        public int Experience { get; set; } = 0;
        public float ActionSpeed { get; set; } = 0.5F;
        public int StatPoints { get; set; } = 0;
        public int MinDamage { get; set; } = 0;
        public int MaxDamage { get; set; } = 0;
        public int Aim { get; set; } = 0;
        public int MinMagicalDamage { get; set; } = 0;
        public int MaxMagicalDamage { get; set; } = 0;
        public int MagicalDefanse { get; set; } = 0;
        public int Defanse { get; set; } = 0;
        public int Evasion { get; set; } = 0;
        public float CritChance { get; set; } = 0;
        public float BlockChance { get; set; } = 0;
        public int MaximalHealth { get; set; } = 0;
        public int MaxiamlManaPoints { get; set; } = 0;
        public int ManaPoints { get; set; } = 0;
        public bool RangedFighter { get; set; } = false;
        public int NewItem { get; set; } = 0;
        public int ItemID { get; set; } = 0;
        public int ItemSTR { get; set; } = 0;
        public int ItemDEX { get; set; } = 0;
        public int ItemEND { get; set; } = 0;
        public int ItemINT { get; set; } = 0;
        public int ItemSPR { get; set; } = 0;
        public int ItemMinDmg { get; set; } = 0;
        public int ItemMaxDmg { get; set; } = 0;
        public int ItemDefance { get; set; } = 0;
        public int ItemMinMDmg { get; set; } = 0;
        public int ItemMaxMDmg { get; set; } = 0;
        public int ItemMDefance { get; set; } = 0;
        public int ItemMaxHealth { get; set; } = 0;
        public float ItemActionSpeed { get; set; } = 0;
        public float ItemCritChance { get; set; } = 0;
        public float ItemBlockChance { get; set; } = 0;
        public int ItemMaxManaPoints { get; set; } = 0;
        public int ItemEvation {  get; set; } = 0;
        public int ItemAim { get; set; } = 0;
        
        public Hero(string name)
        {
            Inventory = new List<Item>();
                       EquiptItems = new Item[10];
            Name = name;
            
                       switch (Program.characterClass)
                       {
                           case '1': CharacterClass = "Fighter"; break;
                           case '2': CharacterClass = "Archer"; break;
                           case '3': CharacterClass = "Cleric"; break;
                           case '4': CharacterClass = "Mage"; break;
                       }
                       switch (CharacterClass)
                       {
                           case "Fighter":
                               STRIncrease(8);
                               DEXIncrease(4);
                               ENDIncrease(12);
                               INTIncrease(1);
                               SPRIncrease(4);
                               break;
                           case "Archer":
                               STRIncrease(6);
                               DEXIncrease(10);
                               ENDIncrease(10);
                               INTIncrease(2);
                               SPRIncrease(6);
                               RangedFighter = true;
                               break;
                           case "Cleric":
                               STRIncrease(5);
                               DEXIncrease(6);
                               ENDIncrease(12);
                               INTIncrease(4);
                               SPRIncrease(8);
                               break;
                           case "Mage":
                               STRIncrease(2);
                               DEXIncrease(4);
                               ENDIncrease(10);
                               INTIncrease(14);
                               SPRIncrease(10);
                               RangedFighter = true;
                               break;
                       }

                       MinDamage = (STR + ItemSTR) + ItemMinDmg;
                       float MaxCalcPhy = (STR + ItemSTR) * 1.2F + ItemMaxDmg;
                       MaxDamage = (int)MaxCalcPhy;
                       Aim = (DEX + ItemDEX) + ItemAim;
                       MinMagicalDamage = (INT + ItemINT) + ItemMinMDmg;
                       float MaxCalcMag = (INT + ItemINT) * 1.2F + ItemMaxMDmg;
                       MaxMagicalDamage = (int)MaxCalcMag;
                       MagicalDefanse = (SPR + ItemSPR) + ItemMDefance;
                       Defanse = (END + ItemEND) * 2 + ItemDefance;
                       Evasion = (DEX +  ItemDEX) + ItemEvation;
                       CritChance = SPRIncreased * 0.2F + ItemCritChance;
                       MaximalHealth = (END + ItemEND) * 10 + ItemMaxHealth;
                       MaxiamlManaPoints = (SPR + ItemSPR) * 10 + ItemMaxManaPoints;
                       ManaPoints = MaxiamlManaPoints;
                       CurrentHealth = MaximalHealth;
                   
        }

        public override string ToString()
        {
            return Name;
        }
        public void SaveHero()
        {
            string filePath = $"player_hero.json";
            string jsonData = JsonSerializer.Serialize(this);
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine($"Hero saved to {filePath}");
        }
        public static Hero LoadHero(string name)
        {
            string filePath = $"{name}_hero.json";

            if (!File.Exists(filePath))
            {
                throw new Exception("Hero not found!");
            }
            string jsonData = File.ReadAllText(filePath);
            if (false) Console.WriteLine(jsonData);
            return JsonSerializer.Deserialize<Hero>(jsonData);
        }
        
        internal void GetItem(Item item)
        {
            Inventory.Add(item);
            ItemID = NewItem;
            NewItem++;
        }
        internal void EqipItem(int item)
        {
            int slot = Inventory[item].GetSlot() - 1;
            try
            {
                if (EquiptItems[slot] != null && Inventory[item].GetClass() == CharacterClass && Inventory[item].GetLevel() <= Level)
                {
                    UnEqipItem(slot);
                    throw new Exception();
                }
                else
                {
                    throw new Exception();
                }

            }
            catch 
            {

                if (Inventory[item].GetClass() == CharacterClass && Inventory[item].GetLevel() <= Level)
                {
                    STR += Inventory[item].STR;
                    DEX += Inventory[item].DEX;
                    END += Inventory[item].END;
                    INT += Inventory[item].INT;
                    SPR += Inventory[item].SPR;
                    MinDamage += Inventory[item].MinDamage;
                    MaxDamage += Inventory[item].MaxDamage;
                    ActionSpeed = Inventory[item].ActionSpeed;
                    Defanse += Inventory[item].Defance;
                    MagicalDefanse += Inventory[item].MagicalDefance;
                    MaximalHealth += Inventory[item].MaxHealth;
                    Evasion += Inventory[item].Evation;
                    Aim += Inventory[item].Aim;
                    EquiptItems[slot] = Inventory[item];
                }
                else if (Inventory[item].GetClass() == CharacterClass && Inventory[item].GetLevel() > Level)
                {
                    Console.WriteLine("You can't equip this item, your level is too low!");
                }
                else if (Inventory[item].GetClass() != CharacterClass)
                {
                    Console.WriteLine("That item is not for your class, you can't equip it!");
                }

            }

        }
        internal void UnEqipItem(int item)
        {
            try
            {
                item = Inventory[item].GetSlot() - 1;
                ItemSTR -= EquiptItems[item].STR;
                ItemDEX -= EquiptItems[item].DEX;
                ItemEND -= EquiptItems[item].END;
                ItemINT -= EquiptItems[item].INT;
                ItemSPR -= EquiptItems[item].SPR;
                ItemMinDmg -= EquiptItems[item].MinDamage;
                ItemMaxDmg -= EquiptItems[item].MaxDamage;
                ItemEvation -= EquiptItems[item].Evation;
                ItemAim -= EquiptItems[item].Aim;
                ItemDefance -= EquiptItems[item].Defance;
                ItemMaxHealth -= EquiptItems[item].MaxHealth;
                if (EquiptItems[item].GetType() == typeof(Shield))
                {
                    Shield shield = (Shield)EquiptItems[item];
                    ItemBlockChance -= shield.BlockRate; 
                }
                ItemMinMDmg -= EquiptItems[item].MinMDamage;
                ItemMaxMDmg -= EquiptItems[item].MaxMDamage;
                ItemCritChance -= EquiptItems[item].CritChance;
                ItemMDefance -= EquiptItems[item].MagicalDefance;
                ItemMaxManaPoints -= EquiptItems[item].MaxManaPoints;
                
                EquiptItems[item] = null;
            }
            catch 
            {
                Console.WriteLine("This item is not equipt");
                Thread.Sleep(1000);
            }
        }
        internal void RefreshStats()
        {
            MinDamage = (STR + ItemSTR) + ItemMinDmg;
            float MaxCalcPhy = (STR + ItemSTR) * 1.2F + ItemMaxDmg;
            MaxDamage = (int)MaxCalcPhy;
            Aim = (DEX + ItemDEX) + ItemAim;
            MinMagicalDamage = (INT + ItemINT) + ItemMinMDmg;
            float MaxCalcMag = (INT + ItemINT) * 1.2F + ItemMaxMDmg;
            MaxMagicalDamage = (int)MaxCalcMag;
            MagicalDefanse = (SPR + ItemSPR) + ItemMDefance;
            Defanse = (END + ItemEND) * 2 + ItemDefance;
            Evasion = (DEX + ItemDEX) + ItemEvation;
            CritChance = SPRIncreased * 0.2F + ItemCritChance;
            MaximalHealth = (END + ItemEND) * 10 + ItemMaxHealth;
            MaxiamlManaPoints = (SPR + ItemSPR) * 10 + ItemMaxManaPoints;
        }
        internal int ReadCash()
        {
            return Cash;
        }
        internal void GetCash(int amount)
        {
            Cash += amount;
        }

        internal void PayCash(int amount)
        {
            if (Cash < amount)
            {
                return;
            }
            Cash -= amount;
        }

        internal void ShowInventory()
        {
            char selection = ' ';
            Console.WriteLine();
            Console.WriteLine("Inventorry");
            Console.WriteLine();
            for (int count = 0; count < Inventory.Count; count++)
            {
                if (Inventory[count] == EquiptItems[Inventory[count].GetSlot() - 1])
                {
                    switch (Inventory[count].Rarety)
                    {
                        case "normal": Console.ForegroundColor = ConsoleColor.DarkGray; break;
                        case "common": Console.ForegroundColor = ConsoleColor.DarkGreen; break;
                        case "uncommon": Console.ForegroundColor = ConsoleColor.DarkBlue; break;
                        case "rare": Console.ForegroundColor = ConsoleColor.DarkMagenta; break;
                        case "legendary": Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                    }
                    Console.WriteLine($"[{count + 1}]. {Inventory[count].ItemName}");
                    Console.ResetColor();
                }
                else
                {
                    switch (Inventory[count].Rarety)
                    {
                        case "poor": Console.ForegroundColor = ConsoleColor.Gray; break;
                        case "normal": Console.ForegroundColor = ConsoleColor.White; break;
                        case "common": Console.ForegroundColor = ConsoleColor.Green; break;
                        case "uncommon": Console.ForegroundColor = ConsoleColor.Blue; break;
                        case "rare": Console.ForegroundColor = ConsoleColor.Magenta; break;
                        case "legendary": Console.ForegroundColor = ConsoleColor.Yellow; break;
                    }
                    Console.WriteLine($"{count + 1}. {Inventory[count].ItemName}");
                    Console.ResetColor();
                }
            }
            Console.WriteLine($"Money: {Cash}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1. Equip Items           2. Unequip Items");
            Console.WriteLine();
            Console.WriteLine("close with any other Key");
            selection = Console.ReadKey().KeyChar;
            if (selection == '1' || selection == '2')
            {
                SelectItem(selection);
            }

        }
        internal void SelectItem(char selection)
        {
            int item = 0;
            Console.Clear();
            Console.WriteLine("Inventorry");
            Console.WriteLine();
            for (int count = 0; count < Inventory.Count; count++)
            {
                Console.WriteLine($"{count + 1}. {Inventory[count].ItemName}");
            }
            Console.WriteLine();
            bool error = false;
            if (selection == '1')
            {
                Console.WriteLine("Select the Item you want to equip.\nNumber:");
                do
                {
                    try
                    {
                        item = int.Parse(Console.ReadLine());
                        if (item > Inventory.Count || item < 0)
                        {
                            throw new Exception("Input out of bounds");
                        }
                        else
                        {
                            EqipItem(item - 1);
                            error = false;
                            Thread.Sleep(1000);
                        }

                    }
                    catch
                    {
                        Console.WriteLine("Wrong input!");
                        error = true;
                    }

                } while (error);

            }
            else if (selection == '2')
            {
                Console.WriteLine("Select the Item you want to unequip.\nNumber:");
                do
                {
                    try
                    {
                        item = int.Parse(Console.ReadLine());
                        if (item > Inventory.Count || item <= 0)
                        {
                            throw new Exception("Input out of bounds");
                        }
                        else
                        {
                            UnEqipItem(item - 1);
                            error = false;
                        }

                    }
                    catch
                    {
                        Console.WriteLine("Wrong input!");
                        error = true;
                        Thread.Sleep(1000);
                    }

                } while (error);

            }

        }
        internal void GetExperience(int xp)
        {
            if (Level < 60)
            {
                Experience += xp;
                if (Experience >= (Level * Level * 2))
                {
                    Experience = Experience - (Level * Level * 2);
                    Level++;
                    StatPoints++;
                    switch (CharacterClass)
                    {
                        case "Fighter":
                            STRIncrease(5);
                            DEXIncrease(2);
                            ENDIncrease(5);
                            INTIncrease(0);
                            SPRIncrease(2);
                            break;
                        case "Archer":
                            STRIncrease(4);
                            DEXIncrease(5);
                            ENDIncrease(2);
                            INTIncrease(1);
                            SPRIncrease(3);
                            break;
                        case "Cleric":
                            STRIncrease(2);
                            DEXIncrease(3);
                            ENDIncrease(4);
                            INTIncrease(2);
                            SPRIncrease(4);
                            break;
                        case "Mage":
                            STRIncrease(1);
                            DEXIncrease(2);
                            ENDIncrease(1);
                            INTIncrease(6);
                            SPRIncrease(5);
                            break;
                    }
                    Console.WriteLine($"You reached Level:{Level}!");
                }

            }

        }
        internal void SetStatpoints()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\n{Name}   Level: {Level} Free Points: {StatPoints}");
            Console.WriteLine($"STR: {STR} + {STRIncreased}     (Increases Damage)");
            Console.WriteLine($"DEX: {DEX} + {DEXIncreased}     (Increases Evation and Aim)");
            Console.WriteLine($"END: {END} + {ENDIncreased}     (Increases Defance, Block Rate and HP)");
            Console.WriteLine($"INT: {INT} + {INTIncreased}     (Increases Magical Damage)");
            Console.WriteLine($"SPR: {SPR} + {SPRIncreased}     (Increases Magical Defance, Crit Rate and MP)");
            Console.ResetColor();
            if (StatPoints > 0)
            {
                Console.WriteLine("Where Do you want to set your Point?");
                Console.WriteLine();
                Console.WriteLine("Back with 0");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "STR": STRIncrease(1); StatPoints--; STRIncreased++; SetStatpoints(); break;
                    case "DEX": DEXIncrease(1); StatPoints--; DEXIncreased++; SetStatpoints(); break;
                    case "END": ENDIncrease(1); StatPoints--; ENDIncreased++; SetStatpoints(); break;
                    case "INT": INTIncrease(1); StatPoints--; INTIncreased++; SetStatpoints(); break;
                    case "SPR": SPRIncrease(1); StatPoints--; SPRIncreased++; SetStatpoints(); break;
                    case "0": break;
                    default: Console.WriteLine("Wrong input please try again!"); SetStatpoints(); break;
                }

            }
            else
            {
                Console.WriteLine("Back with 0");
                char back = Console.ReadKey().KeyChar;
                switch (back)
                {
                    case '0': break;
                    default: Console.WriteLine("Wrong input please try again!"); SetStatpoints(); break;
                }
            }

        }
        internal void STRIncrease(int increase)
        {
            for (int count = 0; count < increase; count++)
            {
                STR++;
                MinDamage = (STR + ItemSTR) + ItemMinDmg;
                float MaxCalcPhy = (STR + ItemSTR) * 1.2F + ItemMaxDmg;
                MaxDamage = (int)MaxCalcPhy;
            }
            return;
        }
        internal void DEXIncrease(int increase)
        {
            for (int count = 0; count < increase; count++)
            {
                DEX++;
                Aim = (DEX + ItemDEX) + ItemAim;
                Evasion = (DEX + ItemDEX) + ItemEvation;
            }
            return;
        }
        internal void ENDIncrease(int increase)
        {
            for (int count = 0; count < increase; count++)
            {
                END++;
                Defanse = (END + ItemEND) * 2 + ItemDefance;
                MaximalHealth = (END + ItemEND) * 10 + ItemMaxHealth;
            }
            return;
        }
        internal void INTIncrease(int increase)
        {
            for (int count = 0; count < increase; count++)
            {
                INT++;
                MinMagicalDamage = (INT + ItemINT) + ItemMinMDmg;
                float MaxCalcMag = (INT + ItemINT) * 1.2F + ItemMaxMDmg;
                MaxMagicalDamage = (int)MaxCalcMag;
            }
            return;
        }
        internal void SPRIncrease(int increase)
        {
            for (int count = 0; count < increase; count++)
            {
                SPR++;
                CritChance = SPRIncreased * 0.2F + ItemCritChance;
                MagicalDefanse = (SPR + ItemSPR) * 2 + ItemMDefance;
                MaxiamlManaPoints = (SPR + ItemSPR) * 10 + ItemMaxManaPoints;
            }
            return;
        }

        internal void LoseExperience()
        {
            if (Experience > 0)
            {
                Experience = Experience - (Level * Level * 2) / 100;
            }

        }
        internal void Healer()
        {
            CurrentHealth = MaximalHealth;
        }
        
    }

}
