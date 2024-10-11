using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRPG;
using ConsoleRPG.Fighting;

namespace ConsoleRPG
{
    internal class Hero
    {
        List<Items> Inventorry { get; set; }
        private int Cash { get; set; } = 0;
        private string Name { get; set; }
        protected static int CurHealth { get; set; } = 100;
        protected static int Levl { get; set; } = 1;
        protected static int MaxHealth { get; set; } = 100;
        protected static int Experience { get; set; } = 0;
        protected static int MinDamage { get; set; } = 5;
        protected static int MaxDamage { get; set; } = 10;
        protected static float ActionSpeed { get; set; } = 0.5F;
        protected static int _newItem = 0;
        protected int ItemID { get; set; }
        public Hero(string name)
        {
            Inventorry = new List<Items>();
            Name = name;
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
            if (Program.hero.Inventorry.Count > 0 && Program.hero.Inventorry[_newItem - 1].GetLevel() <= Levl)
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

        internal void ShowInventorry(Hero hero)
        {
            Console.WriteLine();
            Console.WriteLine("Inventorry");
            Console.WriteLine();
            for (int count = 0; count < hero.Inventorry.Count; count++)
            {
                Console.WriteLine($"{count + 1}. {hero.Inventorry[count].GetItemName()}");
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
                Program.hero.CheckItems();
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
