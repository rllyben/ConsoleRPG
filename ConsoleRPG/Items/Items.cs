using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Items
{
    internal class Item : IStats
    {
        public static Item crabClaw = new Item("Crab's Pincers");
        public static Item blueCrabMeat = new Item("Blue Crab Meat");
        public Item(string name) 
        {
            Name = name;
        }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Level { get; set; }
        public string Classe {  get; set; }
        public int MinDamage { get; set; } = 0;
        public int MaxDamage { get; set; } = 0;
        public int MinMagicalDamage { get; set; } = 0;
        public int MaxMagicalDamage { get; set; } = 0;
        public float ActionSpeed { get; set; } = 0;
        public int Defense { get; set; } = 0;
        public int MagicalDefense { get; set; } = 0;
        public int MaxHealth { get; set; } = 0;
        public int MaxManaPoints { get; set; } = 0;
        public int HealPotantial { get; set; } = 0;
        public float CritChance { get; set; } = 0;
        public int Evasion {get; set;} = 0;
        public int Aim { get; set; } = 0;
        public string Slot { get; set; } = " ";
        public int STR { get; set; } = 0;
        public int DEX { get; set; } = 0;
        public int END { get; set; } = 0;
        public int INT { get; set; } = 0;
        public int SPR { get; set; } = 0;
        public string Rarety { get; set; } = "poor";

        public override string ToString()
        {
            return Name;
        }
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