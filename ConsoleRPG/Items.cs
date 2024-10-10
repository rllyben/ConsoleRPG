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
        public Items(string name, int price, int maxHP = 0, int level = 0, int dmg = 0, float speed = 0) 
        {
            ItemName = name;
            Cost = price;
            MaxHealth = maxHP;
            Level = level;
            Damage = dmg;
            ActionSpeed = speed;
        }
        protected string ItemName {get; set;}
        protected int MaxHealth { get; set; }
        protected int Level { get; set; }
        protected int Damage { get; set; }
        protected float ActionSpeed { get; set; }
        protected int Cost { get; set; }

    }

}