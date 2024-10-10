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
        protected string ItemName {get; set;}
        protected int MaxHealth { get; set; }
        protected int Level { get; set; }
        protected int MinDamage { get; set; }
        protected int MaxDamage { get; set; }
        protected float ActionSpeed { get; set; }
        protected int Cost { get; set; }

    }

}