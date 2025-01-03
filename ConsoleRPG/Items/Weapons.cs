using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Items
{
    internal class Weapons : Item
    {
        public Weapons(string itemName, string classe, string slot, string rarety, int cost, int level, float critChance, int minDamage, int maxDamage, float actionSpeed, int minMDamage = 0, int maxMDamage = 0) : base(itemName)
        {
            Name = itemName;
            Cost = cost;
            Level = level;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            ActionSpeed = actionSpeed;
            Classe = classe;
            Slot = slot;
            CritChance = critChance;
            MinMagicalDamage = minMDamage;
            MaxMagicalDamage = maxMDamage;
        }

    }

}