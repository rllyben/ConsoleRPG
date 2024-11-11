using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Items
{
    internal class Armor : Item
    {
        public Armor(string itemName, string classe, string slot, string rarety, int cost, int maxHealth, int level, int defance, int magicalDefance, int evation, int aim) : base(itemName)
        {
            Name = itemName;
            Cost = cost;
            Level = level;
            Defense = defance;
            MagicalDefense = magicalDefance;
            MaxHealth = maxHealth;
            Evasion = evation;
            Aim = aim;
            Classe = classe;
            Slot = slot;
        }

    }

}