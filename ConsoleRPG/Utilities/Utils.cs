using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ConsoleRPG.Heros;

namespace ConsoleRPG.Utilities
{
    internal class Utils
    {
        public static void SaveHero(Hero hero)
        {
            string filePath = $"player_hero.json";
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string jsonData = JsonSerializer.Serialize(hero, options);
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine($"Hero saved to {filePath}");
        }
        public static Hero LoadHero(string name)
        {
            string filePath = $"{name}_hero.json";

            if (!File.Exists(filePath))
            {
                throw new Exception("Hero not found!");
            }
            string jsonData = File.ReadAllText(filePath);

            Hero hero = JsonSerializer.Deserialize<Hero>(jsonData);

            foreach (var kvp in hero.EquiptItems)
            {
                // Find the item in the hero's inventory by item name
                var inventoryEntry = hero.Inventory.FirstOrDefault(entry => entry.Item.Name == kvp.Value.Name);
                if (inventoryEntry != null)
                {
                    hero.UnEquipItem(inventoryEntry.Item);
                    hero.EquipItem(inventoryEntry.Item);
                }

            }
            return hero;
        }

    }

}
