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
        public Items(string itemName, int cost, int maxHealth = 0, int level = 0, int minDamage = 0, int maxDamage = 0, float actionSpeed = 0) 
        {
            ItemName = itemName;
            Cost = cost;
            MaxHealth = maxHealth;
            Level = level;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            ActionSpeed = actionSpeed;
        }
        public string ItemName {get; set;}
        public int Cost { get; set; }
        public int MaxHealth { get; set; }
        public int Level { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public float ActionSpeed { get; set; }

    }

}