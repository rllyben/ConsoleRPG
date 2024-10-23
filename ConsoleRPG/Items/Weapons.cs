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
        public Weapons(string itemName, int cost, int level, int minDamage, int maxDamage, float actionSpeed) : base(itemName)
        {
            ItemName = itemName;
            Cost = cost;
            Level = level;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            ActionSpeed = actionSpeed;
        }

    }

}