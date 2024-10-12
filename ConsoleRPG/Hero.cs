﻿using System;
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

namespace ConsoleRPG
{
    internal class Hero
    {
        public List<Item> Inventory { get; set; } 
        public int Cash { get; set; } = 0;
        public string Name { get; set; }
        public int CurrentHealth {get; set;}
        public int STR  {get; set;} = 6;
        public int STRIncreased {get; set;} = 0;
        public int DEX {get; set;} = 3;
        public int DEXIncreased {get; set;} = 0;
        public int END {get; set;} = 5;
        public int ENDIncreased {get; set;} = 0;
        public int INT {get; set;} = 1;
        public int INTIncreased {get; set;} = 0;
        public int SPR {get; set;} = 1;
        public int SPRIncreased {get; set;} = 0;
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;
        public float ActionSpeed { get; set; } = 0.5F;
        public int StatPoints {get; set;} = 1;
        public int MinDamage {get; set;}
        public int MaxDamage {get; set;}
        public int Aim {get; set;}
        public int MinMagicalDamage {get; set;}
        public int MaxMagicalDamage {get; set;}
        public int MagicalDefanse {get; set;}
        public int Defanse {get; set;}
        public int Evasion {get; set;}
        public float CritChance {get; set;}
        public float BlockChance {get; set;} = 0;
        public int MaximalHealth {get; set;}
        public int MaxiamlManaPoints {get; set;}
        public int ManaPoints {get; set;}
        private static int NewItem {get; set;} = 0;
        private int ItemID { get; set; }
        public Hero(string name)
        {
            Inventory = new List<Item>();
            Name = name;
            MinDamage = STR;
            MaxDamage = MinDamage;
            Aim = DEX;
            MinMagicalDamage = INT;
            MaxMagicalDamage = MinMagicalDamage;
            MagicalDefanse = SPR;
            Defanse = END;
            Evasion = DEX;
            CritChance = SPR * 0.2F;
            MaximalHealth = END * 10;
            MaxiamlManaPoints = SPR * 10;
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
            if(false)Console.WriteLine(jsonData);
            return JsonSerializer.Deserialize<Hero>(jsonData);
        }
        internal void GetItem(Item item)
        {
            Inventory.Add(item);
            if (item.Level <= Program.hero.Level)
            {
                MinDamage += Inventory[NewItem].MinDamage;
                MaxDamage += Inventory[NewItem].MaxDamage;
            }
            ItemID = NewItem;
            NewItem++;
        }
        internal void CheckItems()
        {
            var InvSize = Inventory.Count;
            if ( InvSize > 0 && Inventory[InvSize - 1].Level <= Program.hero.Level)
            {
                MinDamage += Inventory[InvSize - 1].MinDamage;
                MaxDamage += Inventory[InvSize - 1].MaxDamage;
            }

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
            Console.WriteLine();
            Console.WriteLine("Inventorry");
            Console.WriteLine();
            for (int count = 0; count < Inventory.Count; count++)
            {
                Console.WriteLine($"{count + 1}. {Inventory[count].ItemName}");
            }
            Console.WriteLine($"Money: {Cash}");
            Console.WriteLine();
            Console.WriteLine("close with any Key");
            Console.ReadKey(); 
        }
        internal void FightHero(string mobName, int mobMinDmg = 0, int mobMaxDmg = 0)
        {
            int healthSave = CurrentHealth;
            Random rnd = new Random();
            int DamageTaken = rnd.Next(mobMinDmg, mobMaxDmg) / Defanse;
            if(DamageTaken <= 0)
                DamageTaken = 1;
            CurrentHealth = CurrentHealth - DamageTaken;  
            Console.WriteLine();
            Console.WriteLine($"You get attacked by the {mobName} and lost {healthSave - CurrentHealth}HP!");
            Console.WriteLine($"You have {CurrentHealth}HP left");
            return;
        }
        internal void GetExperience(int xp)
        {
            if (Level < 60)
            {
                Experience += xp;
                if (Experience > (Level * Level * 2))
                {
                    Experience = Experience - (Level * Level * 2);
                    Level++;
                    StatPoints++;
                    STRIncrease(4);
                    DEXIncrease(2);
                    ENDIncrease(4);
                    INTIncrease(0);
                    SPRIncrease(1);
                    Console.WriteLine($"You reached Level:{Level}!");
                    Program.hero.CheckItems();
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
            for(int count = 0; count < increase; count++)
            {
                STR++;
                MinDamage = SPR;
                MaxDamage = SPR;
                CheckItems();
            }
            return;
        }
        internal void DEXIncrease(int increase)
        {
            for(int count = 0; count < increase; count++)
            {
                DEX++;
                Aim = DEX;
                Evasion = DEX;
                CheckItems();
            }
            return;
        }
        internal void ENDIncrease(int increase)
        {
            for(int count = 0; count < increase; count++)
            {
                END++;
                Defanse = END;
                MaximalHealth = 27 + END * 5;
                CheckItems();
            }
            return;
        }
        internal void INTIncrease(int increase)
        {
            for(int count = 0; count < increase; count++)
            {
                INT++;
                MaxMagicalDamage = INT;
                MinMagicalDamage = INT;
                CheckItems();
            }
            return;
        }
        internal void SPRIncrease(int increase)
        {
            for(int count = 0; count < increase; count++)
            {
                SPR++;
                MagicalDefanse = SPR;
                MaxiamlManaPoints = 5 + SPR * 5;
                CheckItems();
            }
            return;
        }

        internal void LoseExperience()
        {
            Experience = Experience - (Level * Level * 2) / 100;
        }
        internal void Healer()
        {
            CurrentHealth = MaximalHealth;
        }

    }

}
