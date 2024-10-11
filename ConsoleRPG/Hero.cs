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

namespace ConsoleRPG
{
    internal class Hero
    {
        public static Hero hero;
        List<Items> Inventorry { get; set; }
        public int Cash { get; set; } = 0;
        public string Name { get; set; }
        public int CurHealth { get; set; } = 100;
        public int Levl { get; set; } = 1;
        public int MaxHealth { get; set; } = 100;
        public int Experience { get; set; } = 0;
        public int MinDamage { get; set; } = 5;
        public int MaxDamage { get; set; } = 10;
        public float ActionSpeed { get; set; } = 0.5F;
        public int _newItem = 0;
        public int ItemID { get; set; }
        public Hero(string name, int cash = 0, int tempHealth = 100, int lvl = 1, int maxHP = 100, int xp = 0, int minDmg = 1, int maxDmg = 5, float speed = 0.5F)
        {
            Inventorry = new List<Items>();
            Name = name;
            Cash = cash;
            CurHealth = tempHealth;
            Levl = lvl;
            MaxHealth = maxHP;
            Experience = xp;
            MinDamage = minDmg;
            MaxDamage = maxDmg;
        }

        public static void CrateHero()
        {
            hero = new Hero(Console.ReadLine());
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
                Console.WriteLine("Hero not found!");
                Thread.Sleep(500);
                return null;
            }

            string jsonData = File.ReadAllText(filePath);
            Hero hero = new Hero(JsonSerializer.Deserialize<Hero>(jsonData));
            return hero;
        }
        internal void GetItem(Items item)
        {
            Inventorry.Add(item);
            if (item.GetLevel() <= Levl)
            {
                MinDamage = Inventorry[_newItem].GetMinDamage();
                MaxDamage = Inventorry[_newItem].GetMaxDamage();
            }
            ItemID = _newItem;
            _newItem++;
        }
        internal void CheckItems()
        {
            if (Hero.hero.Inventorry.Count > 0 && Hero.hero.Inventorry[_newItem - 1].GetLevel() <= Levl)
            {
                MinDamage = Inventorry[_newItem - 1].GetMinDamage();
                MaxDamage = Inventorry[_newItem - 1].GetMaxDamage();
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

        internal void ShowInventorry(Hero player)
        {
            Console.WriteLine();
            Console.WriteLine("Inventorry");
            Console.WriteLine();
            for (int count = 0; count < player.Inventorry.Count; count++)
            {
                Console.WriteLine($"{count + 1}. {player.Inventorry[count].GetItemName()}");
            }
            Console.WriteLine($"Money: {Cash}");

        }

        internal string GetName()
        {
            return Name;
        }
        internal int MaximalHealth()
        {
            return MaxHealth;
        }
        internal int CurrentHealth(bool fight = false, int mobMinDmg = 0, int mobMaxDmg = 0)
        {
            if (fight)
            {
                int healthSave = CurHealth;
                Random rnd = new Random();
                CurHealth -= rnd.Next(mobMinDmg, mobMaxDmg);
                Console.WriteLine();
                Console.WriteLine($"You get attacked by the Monster and lost {healthSave-CurHealth}HP!");
                Console.WriteLine($"You have {CurHealth}HP left");
                return CurHealth;
            }

            return CurHealth;
        }
        internal int Level()
        {
            return Levl;
        }
        internal int ReadExperience()
        {
            return Experience;
        }
        internal void GetExperience(int xp)
        {
            Experience += xp;
            if (Experience > (Levl * Levl*2))
            {
                Experience = 0;
                Levl++;
                MaxHealth = Levl * 100;
                Console.WriteLine($"You reached Level:{Levl}!");
                Hero.hero.CheckItems();
            }

        }
        internal void LoseExperience()
        {
            Experience = Experience;
        }
        internal int MaxDamageOut()
        {
            return MaxDamage;
        }
        internal int MinDamageOut()
        {
            return MinDamage;
        }
        internal float ActionSpeedOut()
        {
            return ActionSpeed;
        }
        internal void Healer()
        {
            CurHealth = MaxHealth;
        }

    }

}
