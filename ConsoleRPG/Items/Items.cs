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
        public string ItemName { get; set; }
        public int Cost { get; set; }
        public int Level { get; set; }
        public string Classe {  get; set; }
        public int MinDamage { get; set; } = 0;
        public int MaxDamage { get; set; } = 0;
        public int MinMDamage { get; set; } = 0;
        public int MaxMDamage { get; set; } = 0;
        public float ActionSpeed { get; set; } = 0;
        public int Defance { get; set; } = 0;
        public int MagicalDefance { get; set; } = 0;
        public int MaxHealth { get; set; } = 0;
        public int MaxManaPoints { get; set; } = 0;
        public int HealPotantial { get; set; } = 0;
        public float CritChance { get; set; } = 0;
        public int Evation {get; set;} = 0;
        public int Aim { get; set; } = 0;
        public string Slot { get; set; } = " ";
        public int STR { get; set; } = 0;
        public int DEX { get; set; } = 0;
        public int END { get; set; } = 0;
        public int INT { get; set; } = 0;
        public int SPR { get; set; } = 0;
        public string Rarety { get; set; } = "poor";

        public string GetClass()
        {
            return Classe;
        }
        public int GetLevel()
        {
            return Level;
        }
        public string GetSlot()
        {
            return Slot; 
        }

    }

}