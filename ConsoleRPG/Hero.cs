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
        public List<Items> Inventorry { get; set; } 
        public int Cash { get; set; } = 0;
        public string Name { get; set; }
        public int CurHealth { get; set; } = 100;
        public int Level { get; set; } = 1;
        public int MaxHealth { get; set; } = 100;
        public int Experience { get; set; } = 0;
        public int MinDamage { get; set; } = 5;
        public int MaxDamage { get; set; } = 10;
        public float ActionSpeed { get; set; } = 0.5F;
        private int NewItem {get; set;} = 0;
        private int ItemID { get; set; }
        public Hero(string name)
        {
            Inventorry = new List<Items>();
            Name = name;
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
        internal void GetItem(Items item)
        {
            Inventorry.Add(item);
            if (item.Level <= Program.hero.Level)
            {
                MinDamage = Inventorry[NewItem].MinDamage;
                MaxDamage = Inventorry[NewItem].MaxDamage;
            }
            ItemID = NewItem;
            NewItem++;
        }
        internal void CheckItems()
        {
            var InvSize = Inventorry.Count;
            if ( InvSize > 0 && Inventorry[InvSize - 1].Level <= Program.hero.Level)
            {
                MinDamage = Inventorry[InvSize - 1].MinDamage;
                MaxDamage = Inventorry[InvSize - 1].MaxDamage;
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
                Console.WriteLine($"{count + 1}. {player.Inventorry[count].ItemName}");
            }
            Console.WriteLine($"Money: {Cash}");

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
        internal void GetExperience(int xp)
        {
            Experience += xp;
            if (Experience > (Level * Level * 2))
            {
                Experience = Experience - (Level * Level * 2);
                Level++;
                MaxHealth = Level * 100;
                Console.WriteLine($"You reached Level:{Level}!");
                Program.hero.CheckItems();
            }

        }
        internal void LoseExperience()
        {
            Experience = Experience;
        }
        internal void Healer()
        {
            CurHealth = MaxHealth;
        }

    }

}
