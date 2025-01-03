using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Items
{
    internal class Shield : Armor
    {
        public Shield(string itemName, string classe, string slot, string rarety, int cost, int maxHealth, int level, int defance, int magicalDefance, int evation, int aim, float blockRate) : base(itemName, classe, slot, rarety, cost, maxHealth, level, defance, magicalDefance, evation, aim)
        {
            Name = itemName;
            Cost = cost;
            Level = level;
            Defense = defance;
            MagicalDefense = magicalDefance;
            MaxHealth = maxHealth;
            Evasion = evation;
            Aim = aim;
            BlockRate = blockRate;
            Classe = classe;
            Slot = slot;
            Rarety = rarety;
        }

        public float BlockRate {get; set;}
    }

}