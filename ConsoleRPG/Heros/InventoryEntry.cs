using ConsoleRPG.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Heros
{
    internal class InventoryEntry
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }

        public InventoryEntry(Item item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }

    }

}
