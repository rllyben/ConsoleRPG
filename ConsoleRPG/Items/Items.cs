using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Items
{
    internal class Item
    {
        public static Item crabClaw = new Item("Crab's Pincers");
        public static Item blueCrabMeat = new Item("Blue Crab Meat");
        public Item(string itemName) 
        {
            ItemName = itemName;
        }
        public string ItemName {get; set;}
        public int Cost { get; set; }
        public int Level { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public float ActionSpeed { get; set; }
        public int Defance { get; set; }
        public int MagicalDefance { get; set; }
        public int MaxHealth { get; set; }
        public int HealPotantial {get; set;}
        public int Evation {get; set;}
        public int Aim {get; set;}

    }

}