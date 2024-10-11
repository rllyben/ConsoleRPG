using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    internal class Items
    {
        public Items(string name, int price, int maxHP = 0, int level = 0, int minDmg = 0, int maxDmg = 0, float speed = 0) 
        {
            ItemName = name;
            Cost = price;
            MaxHealth = maxHP;
            Level = level;
            MinDamage = minDmg;
            MaxDamage = maxDmg;
            ActionSpeed = speed;
        }
        public string ItemName {get; set;}
        public int MaxHealth { get; set; }
        public int Level { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public float ActionSpeed { get; set; }
        public int Cost { get; set; }

        internal string GetItemName()
        {
            return ItemName;
        }
        internal int GetMaxHealth()
        {
            return MaxHealth;
        }        
        internal int GetLevel()
        {
            return Level;
        }        
        internal int GetMinDamage()
        {
            return MinDamage;
        }        
        internal int GetMaxDamage()
        {
            return MaxDamage;
        }        
        internal float GetActionSpeed()
        {
            return ActionSpeed;
        }
        internal int GetCost()
        {
            return Cost;
        }

    }

}