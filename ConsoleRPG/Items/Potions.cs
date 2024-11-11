using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Items
{
    internal class Potions : Item
    {
        public Potions(string itemName, int healPotantial) : base(itemName)
        {
            Name = itemName;
            HealPotantial = healPotantial;
        }

    }

}