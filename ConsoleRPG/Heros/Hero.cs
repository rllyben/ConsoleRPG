using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using ConsoleRPG.Fighting;
using System.Runtime.CompilerServices;
using System.Collections;
using ConsoleRPG.Items;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Text.Json.Serialization;
using ConsoleRPG;

namespace ConsoleRPG.Heros
{
    internal class Hero : IStats
    {
        enum Selection
        {
            Euipen = 1,
            Unequipen = 2
        }
        public List<InventoryEntry> Inventory { get; set; } = new List<InventoryEntry>();
        public Dictionary<string, Item> EquiptItems { get; set; }
        public List<BaseSkills> CharacterSkills { get; set; }
        public string CharacterClass { get; set; } = "null";
        public int Cash { get; set; } = 0;
        public string Name { get; set; }
        public int CurrentHealth { get; set; }
        public int STR { get; set; } = 0;
        public int STRIncreased { get; set; } = 0;
        public int DEX { get; set; } = 0;
        public int DEXIncreased { get; set; } = 0;
        public int END { get; set; } = 0;
        public int ENDIncreased { get; set; } = 0;
        public int INT { get; set; } = 0;
        public int INTIncreased { get; set; } = 0;
        public int SPR { get; set; } = 0;
        public int SPRIncreased { get; set; } = 0;
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;
        public float ActionSpeed { get; set; } = 0.5F;
        public int StatPoints { get; set; } = 0;
        public int MinDamage { get; set; } = 0;
        public int MaxDamage { get; set; } = 0;
        public int Aim { get; set; } = 0;
        public int MinMagicalDamage { get; set; } = 0;
        public int MaxMagicalDamage { get; set; } = 0;
        public int MagicalDefense { get; set; } = 0;
        public int Defense { get; set; } = 0;
        public int Evasion { get; set; } = 0;
        public float CritChance { get; set; } = 0;
        public float BlockChance { get; set; } = 0;
        public int MaximalHealth { get; set; } = 0;
        public int MaxiamlManaPoints { get; set; } = 0;
        public int ManaPoints { get; set; } = 0;
        public bool RangedFighter { get; set; } = false;
        public int NewItem { get; set; } = 0;
        public int ItemID { get; set; } = 0;
        public int ItemSTR { get; set; } = 0;
        public int ItemDEX { get; set; } = 0;
        public int ItemEND { get; set; } = 0;
        public int ItemINT { get; set; } = 0;
        public int ItemSPR { get; set; } = 0;
        public int ItemMinDmg { get; set; } = 0;
        public int ItemMaxDmg { get; set; } = 0;
        public int ItemDefance { get; set; } = 0;
        public int ItemMinMDmg { get; set; } = 0;
        public int ItemMaxMDmg { get; set; } = 0;
        public int ItemMDefance { get; set; } = 0;
        public int ItemMaxHealth { get; set; } = 0;
        public float ItemActionSpeed { get; set; } = 0;
        public float ItemCritChance { get; set; } = 0;
        public float ItemBlockChance { get; set; } = 0;
        public int ItemMaxManaPoints { get; set; } = 0;
        public int ItemEvation { get; set; } = 0;
        public int ItemAim { get; set; } = 0;
        public int HPStones { get; set; } = 0;
        public int MPStones { get; set; } = 0;

        // Fighter Skills
        Skills blow = new Skills("Sword Blow", 1, 10, 3, 32, 35, 0, 0, 0, "", 0, 0);
        Skills breakthrough = new Skills("Breakthrough", 1, 15, 10, 27, 32, 0, 0, 0, "lowerG Def %", 5, 2);
        Skills shieldWall = new Skills("Shield wall", 1, 10, 5, 0, 0, 0, 0, 0, "higherS BlockRate %", 5, 5);
        Skills stunningBlow = new Skills("Stunning blow", 1, 15, 10, 34, 37, 0, 0, 0, "stunG Round", 1, 0);
        Skills powerfulBlow = new Skills("Powerful blow", 1, 13, 10, 44, 51, 0, 0, 0, "lowerG DEX %", 10, 3);
        Skills allIn = new Skills("All in", 1, 21, 10, 0, 0, 0, 0, 0, "higherS Dmg %, lowerS Def %", 3, 5);
        Skills splitter = new Skills("Splitter", 1, 26, 15, 165, 201, 0, 0, 0, "", 0, 0);

        // Archer Skills
        Skills sharpendSenses = new("Sharpend Senses", 1, 25, 10, 0, 0, 0, 0, 0, "higherS DEX", 100, 28);
        Skills snakeBite = new("Snake Bite", 1, 7, 15, 16, 23, 0, 0, 0, "poisonG", 10, 7);
        Skills injection = new("Injection", 1, 12, 15, 21, 29, 0, 0, 0, "illnessG", 10, 13);
        Skills splinterArrow = new("Splinter Arrow", 1, 17, 15, 34, 46, 0, 0, 0, "bleedingG", 10, 32);
        Skills clubbingBlow = new("Clubbing Blow", 1, 24, 10, 24, 31, 0, 0, 0, "stun", 5, 0);
        Skills daggerHit = new("Dagger Hit", 1, 32, 3, 46, 57, 0, 0, 0, "", 0, 0);
        Skills arrowStorm = new("Arrow Storm", 1, 65, 15, 103, 243, 0, 0, 0, "", 0, 0);

        public Hero(string name)
        {
            Inventory = new();
            EquiptItems = new();
            CharacterSkills = new List<BaseSkills>();
            Name = name;

            switch (Program.characterClass)
            {
                case '1': CharacterClass = "Fighter"; break;
                case '2': CharacterClass = "Archer"; break;
                case '3': CharacterClass = "Cleric"; break;
                case '4': CharacterClass = "Mage"; break;
            }
            switch (CharacterClass)
            {
                case "Fighter":
                    STRIncrease(8);
                    DEXIncrease(4);
                    ENDIncrease(12);
                    INTIncrease(1);
                    SPRIncrease(4);
                    break;
                case "Archer":
                    STRIncrease(6);
                    DEXIncrease(10);
                    ENDIncrease(10);
                    INTIncrease(2);
                    SPRIncrease(6);
                    RangedFighter = true;
                    break;
                case "Cleric":
                    STRIncrease(5);
                    DEXIncrease(6);
                    ENDIncrease(12);
                    INTIncrease(4);
                    SPRIncrease(8);
                    break;
                case "Mage":
                    STRIncrease(2);
                    DEXIncrease(4);
                    ENDIncrease(10);
                    INTIncrease(14);
                    SPRIncrease(10);
                    RangedFighter = true;
                    break;
            }
            MinDamage = STR + ItemSTR + ItemMinDmg;
            float MaxCalcPhy = (STR + ItemSTR) * 1.2F + ItemMaxDmg;
            MaxDamage = (int)MaxCalcPhy;
            Aim = DEX + ItemDEX + ItemAim;
            MinMagicalDamage = INT + ItemINT + ItemMinMDmg;
            float MaxCalcMag = (INT + ItemINT) * 1.2F + ItemMaxMDmg;
            MaxMagicalDamage = (int)MaxCalcMag;
            MagicalDefense = SPR + ItemSPR + ItemMDefance;
            Defense = END + ItemEND + ItemDefance;
            Evasion = DEX + ItemDEX + ItemEvation;
            CritChance = SPRIncreased * 0.2F + ItemCritChance;
            MaximalHealth = (END + ItemEND) * 10 + ItemMaxHealth;
            MaxiamlManaPoints = (SPR + ItemSPR) * 10 + ItemMaxManaPoints;
            ManaPoints = MaxiamlManaPoints;
            CurrentHealth = MaximalHealth;
            HPStones = HPStones;
            MPStones = MPStones;

        }
        public override string ToString()
        {
            return Name;
        }
        private void AddSkill(Skills skill)
        {
            CharacterSkills.Add(skill);
        }
        internal void GetItem(Item item, int amount = 1)
        {
            var existingEntry = Inventory.Find(entry => entry.Item.Name == item.Name);
            if (existingEntry != null)
            {
                existingEntry.Quantity += amount;
            }
            else
            {
                Inventory.Add(new InventoryEntry(item, amount));
            }

        }
        internal void GetHPStones(int count)
        {
            HPStones += count;
        }
        internal void GetMPStones(int count)
        {
            HPStones += count;
        }
        internal void UseHPStone()
        {
            HPStones--;
            CurrentHealth += MaximalHealth / 20;
        }
        internal void UseMPStone()
        {
            MPStones--;
            ManaPoints += MaxiamlManaPoints / 20;
        }
        internal int ReadCash()
        {
            return Cash;
        }
        internal void GetCash(int amount)
        {
            Cash += amount;
        }
        internal void PayCash(int amount)
        {
            if (Cash < amount)
            {
                return;
            }
            Cash -= amount;
        }

        internal void PrintHeroInformation()
        {
            Console.WriteLine($"{Name}: Level: {Level}  XP: {Experience}/{Level * Level * 2}  " +
                              $"HP: {CurrentHealth} / {MaximalHealth} MP: {ManaPoints} / {MaxiamlManaPoints}\n" +
                              $"Money: {Cash}");
        }
        internal void EquipItem(Item item)
        {
            try
            {
                var inventoryEntry = Inventory.FirstOrDefault(e => e.Item.Name == item.Name);
                if (inventoryEntry == null || inventoryEntry.Quantity < 1)
                    throw new Exception("Does not have that item");
                if (EquiptItems.ContainsKey(item.Slot) && EquiptItems[item.Slot] != null)
                    UnEquipItem(item);
                if (item.Level <= Level)
                {
                    if (!EquiptItems.ContainsKey(item.Slot))
                        EquiptItems.Add(item.Slot, item);
                    else
                        EquiptItems[item.Slot] = item;

                    inventoryEntry.Quantity--;
                    ItemSTR += item.STR;
                    ItemDEX += item.DEX;
                    ItemEND += item.END;
                    ItemINT += item.INT;
                    ItemSPR += item.SPR;
                    ItemMinDmg += item.MinDamage;
                    ItemMaxDmg += item.MaxDamage;
                    ItemEvation += item.Evasion;
                    ItemAim += item.Aim;
                    ItemDefance += item.Defense;
                    ItemMaxHealth += item.MaxHealth;

                    if (item is Shield shield)
                        ItemBlockChance += shield.BlockRate;

                    ItemMinMDmg += item.MinMagicalDamage;
                    ItemMaxMDmg += item.MaxMagicalDamage;
                    ItemCritChance += item.CritChance;
                    ItemMDefance += item.MagicalDefense;
                    ItemMaxManaPoints += item.MaxManaPoints;

                    if (item is Weapons weapon)
                        ActionSpeed = weapon.ActionSpeed;

                    RefreshStats();
                }
                else
                {
                    Console.WriteLine("Your Level is not high enugh to equip hat item!");
                }

            }
            catch
            {
                Console.WriteLine("You don't have enough of that item to equip it!");
            }

        }
        internal void UnEquipItem(Item item)
        {
            try
            {
                var inventoryEntry = Inventory.FirstOrDefault(e => e.Item.Name == item.Name);
                if (inventoryEntry == null)
                    throw new Exception("Item is not in inventory");

                inventoryEntry.Quantity++;
                ItemSTR -= item.STR;
                ItemDEX -= item.DEX;
                ItemEND -= item.END;
                ItemINT -= item.INT;
                ItemSPR -= item.SPR;
                ItemMinDmg -= item.MinDamage;
                ItemMaxDmg -= item.MaxDamage;
                ItemEvation -= item.Evasion;
                ItemAim -= item.Aim;
                ItemDefance -= item.Defense;
                ItemMaxHealth -= item.MaxHealth;

                if (item is Shield shield)
                    ItemBlockChance -= shield.BlockRate;

                ItemMinMDmg -= item.MinMagicalDamage;
                ItemMaxMDmg -= item.MaxMagicalDamage;
                ItemCritChance -= item.CritChance;
                ItemMDefance -= item.MagicalDefense;
                ItemMaxManaPoints -= item.MaxManaPoints;

                if (item is Weapons weapon)
                    ActionSpeed = ActionSpeed - weapon.ActionSpeed + 0.5F; // Reset action speed adjustment

                RefreshStats();

                EquiptItems[item.Slot] = null;
            }
            catch
            {
                Console.WriteLine("This item is not equipped.");
            }

        }
        internal void RefreshStats()
        {
            MinDamage = STR + ItemSTR + ItemMinDmg;
            float MaxCalcPhy = (STR + ItemSTR) * 1.2F + ItemMaxDmg;
            MaxDamage = (int)MaxCalcPhy;
            Aim = DEX + ItemDEX + ItemAim;
            MinMagicalDamage = INT + ItemINT + ItemMinMDmg;
            float MaxCalcMag = (INT + ItemINT) * 1.2F + ItemMaxMDmg;
            MaxMagicalDamage = (int)MaxCalcMag;
            MagicalDefense = SPR + ItemSPR + ItemMDefance;
            Defense = (END + ItemEND) * 2 + ItemDefance;
            Evasion = DEX + ItemDEX + ItemEvation;
            CritChance = SPRIncreased * 0.2F + ItemCritChance;
            MaximalHealth = (END + ItemEND) * 10 + ItemMaxHealth;
            MaxiamlManaPoints = (SPR + ItemSPR) * 10 + ItemMaxManaPoints;
        }
        internal void ShowInventory()
        {
            char selection = ' ';
            Console.WriteLine();
            Console.WriteLine("Inventorry");
            Console.WriteLine();
            int count = 1;
            foreach (var entry in Inventory)
            {
                Item currentItem = entry.Item;
                int itemCount = entry.Quantity;

                bool isEquipped = EquiptItems.ContainsKey(currentItem.Slot) && currentItem == EquiptItems[currentItem.Slot];

                if (isEquipped)
                {
                    switch (currentItem.Rarety)
                    {
                        case "normal": Console.ForegroundColor = ConsoleColor.DarkGray; break;
                        case "common": Console.ForegroundColor = ConsoleColor.DarkGreen; break;
                        case "uncommon": Console.ForegroundColor = ConsoleColor.DarkBlue; break;
                        case "rare": Console.ForegroundColor = ConsoleColor.DarkMagenta; break;
                        case "legendary": Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                    }
                    Console.WriteLine($"[{count}]. {currentItem.Name} ({itemCount})");
                    Console.ResetColor();
                }
                else
                {
                    switch (currentItem.Rarety)
                    {
                        case "poor": Console.ForegroundColor = ConsoleColor.Gray; break;
                        case "normal": Console.ForegroundColor = ConsoleColor.White; break;
                        case "common": Console.ForegroundColor = ConsoleColor.Green; break;
                        case "uncommon": Console.ForegroundColor = ConsoleColor.Blue; break;
                        case "rare": Console.ForegroundColor = ConsoleColor.Magenta; break;
                        case "legendary": Console.ForegroundColor = ConsoleColor.Yellow; break;
                    }
                    Console.WriteLine($"{count}. {currentItem.Name} ({itemCount})");
                    Console.ResetColor();
                }
                count++;
            }

            Console.WriteLine($"Money: {Cash}\n\n\n" +
                             "1. Equip Items           2. Unequip Items\n\n" +
                             "close with any other Key");
            selection = Console.ReadKey().KeyChar;
            if (selection == '1' || selection == '2')
            {
                SelectItem(selection);
            }

        }
        internal void SelectItem(Selection selection)
        {
            int item = 0;
            var action = ConsoleKey.NoName;

            switch (selection)
            {
                case Selection.Euipen:
                    List<Item> itemList = Inventory.Select(entry => entry.Item).ToList();
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Select the Item you want to equip or press [ESC] to go back");
                        Console.WriteLine("Inventorry\n");

                        for (int count = 0; count < itemList.Count; count++)
                        {
                            switch (itemList[count].Rarety)
                            {
                                case "normal": Console.ForegroundColor = ConsoleColor.Gray; break;
                                case "common": Console.ForegroundColor = ConsoleColor.Green; break;
                                case "uncommon": Console.ForegroundColor = ConsoleColor.Blue; break;
                                case "rare": Console.ForegroundColor = ConsoleColor.Magenta; break;
                                case "legendary": Console.ForegroundColor = ConsoleColor.Yellow; break;
                            }
                            if (count == item)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine($"{count + 1}. {itemList[count].Name}");
                            }
                            else
                                Console.WriteLine($"{count + 1}. {itemList[count].Name}");
                            Console.ResetColor();
                        }
                        Console.WriteLine();

                        action = Console.ReadKey().Key;

                        switch (action)
                        {
                            case ConsoleKey.W:
                            case ConsoleKey.UpArrow:
                                item++;
                                if (item > itemList.Count)
                                    item = itemList.Count;
                                break;
                            case ConsoleKey.S:
                            case ConsoleKey.DownArrow:
                                item--;
                                if (item < 0)
                                    item = 0;
                                break;
                        }

                    } while (action != ConsoleKey.Enter && action != ConsoleKey.Escape);
                    EquipItem(itemList[item]);
                    break;
                case Selection.Unequipen:
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Select the Item you want to unequip or press [ESC] to go back");
                        Console.WriteLine("Equipt items");
                        int count = 0;
                        foreach (var enty in EquiptItems)
                        {
                            if (item == count)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine($"{enty.Key}: {enty.Value}");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else
                                Console.WriteLine($"{enty.Key}: {enty.Value}");
                            count++;
                        }
                        Console.WriteLine();

                        action = Console.ReadKey().Key;

                        switch (action)
                        {
                            case ConsoleKey.S:
                            case ConsoleKey.DownArrow:
                                item++;
                                if (item > EquiptItems.Count)
                                    item = EquiptItems.Count;
                                break;
                            case ConsoleKey.W:
                            case ConsoleKey.UpArrow:
                                item--;
                                if (item < 0)
                                    item = 0;
                                break;
                        }

                    } while (action != ConsoleKey.Enter && action != ConsoleKey.Escape);
                    int select = 0;
                    foreach (var enty in EquiptItems)
                    {
                        if(select == item)
                            UnEquipItem(enty.Value);
                        select++;
                    }
                    break;
            }

        }
        internal void GetExperience(int xp)
        {
            if (Level < 60)
            {
                Experience += xp;
                if (Experience >= Level * Level * 2)
                {
                    Experience = Experience - Level * Level * 2;
                    Level++;
                    StatPoints++;
                    // Update Character Stats
                    ApplyStatIncreases();
                    // Update Skills
                    BaseSkills.UpdateSkills(CharacterSkills);

                    switch (CharacterClass)
                    {
                        case "Fighter":
                            switch (Level)
                            {
                                case 3: AddSkill(blow); break;
                                case 5: AddSkill(breakthrough); break;
                                case 8: AddSkill(shieldWall); blow.SkillLevel++; break;
                                case 12: AddSkill(stunningBlow); break;
                                case 16: AddSkill(powerfulBlow); blow.SkillLevel++; breakthrough.SkillLevel++; break;
                                case 20: AddSkill(allIn); shieldWall.SkillLevel++; break;
                                case 25: AddSkill(splitter); breakthrough.SkillLevel++; stunningBlow.SkillLevel++; blow.SkillLevel++; break;
                                case 28: powerfulBlow.SkillLevel++; break;
                                case 29: shieldWall.SkillLevel++; break;
                                case 30: allIn.SkillLevel++; break;
                                case 32: blow.SkillLevel++; splitter.SkillLevel++; break;
                                case 34: breakthrough.SkillLevel++; break;
                                case 35: stunningBlow.SkillLevel++; powerfulBlow.SkillLevel++; break;
                                case 37: shieldWall.SkillLevel++; splitter.SkillLevel++; break;
                                case 39: blow.SkillLevel++; breakthrough.SkillLevel++; break;
                                case 40: allIn.SkillLevel++; break;
                                case 41: powerfulBlow.SkillLevel++; break;
                                case 43: stunningBlow.SkillLevel++; splitter.SkillLevel++; break;
                                case 45: shieldWall.SkillLevel++; breakthrough.SkillLevel++; blow.SkillLevel++; break;
                                case 46: powerfulBlow.SkillLevel++; break;
                                case 49: stunningBlow.SkillLevel++; break;
                                case 50: allIn.SkillLevel++; break;
                                case 53: shieldWall.SkillLevel++; break;
                                case 54: splitter.SkillLevel++; blow.SkillLevel++; break;
                                case 56: powerfulBlow.SkillLevel++; breakthrough.SkillLevel++; break;
                                case 57: stunningBlow.SkillLevel++; break;
                                case 59: shieldWall.SkillLevel++; blow.SkillLevel++; break;
                                case 60: allIn.SkillLevel++; splitter.SkillLevel++; break;
                            }
                            break;
                        case "Archer":
                            switch (Level)
                            {
                                case 3: AddSkill(daggerHit); break;
                                case 7: AddSkill(snakeBite); break;
                                case 11: AddSkill(injection); daggerHit.SkillLevel++; break;
                                case 16: AddSkill(clubbingBlow); snakeBite.SkillLevel++; break;
                                case 20: AddSkill(sharpendSenses); AddSkill(arrowStorm); break;
                                case 21: daggerHit.SkillLevel++; break;
                                case 22: AddSkill(splinterArrow); injection.SkillLevel++; break;
                                case 24: snakeBite.SkillLevel++; clubbingBlow.SkillLevel++; break;
                                case 27: arrowStorm.SkillLevel++; break;
                                case 30: sharpendSenses.SkillLevel++; daggerHit.SkillLevel++; break;
                                case 32: snakeBite.SkillLevel++; injection.SkillLevel++; splinterArrow.SkillLevel++; break;
                                case 34: clubbingBlow.SkillLevel++; break;
                                case 35: arrowStorm.SkillLevel++; break;
                                case 38: daggerHit.SkillLevel++; splinterArrow.SkillLevel++; break;
                                case 39: injection.SkillLevel++; break;
                                case 40: sharpendSenses.SkillLevel++; snakeBite.SkillLevel++; break;
                            }
                            break;
                        case "Cleric":
                            switch (Level)
                            {

                            }
                            break;
                        case "Mage":
                            switch (Level)
                            {

                            }
                            break;
                    }

                    Console.WriteLine($"You reached Level:{Level}!");
                }

            }

        }

        private void ApplyStatIncreases()
        {
            switch (CharacterClass)
            {
                case "Fighter":
                    STRIncrease(5);
                    DEXIncrease(2);
                    ENDIncrease(5);
                    SPRIncrease(2);
                    break;
                case "Archer":
                    STRIncrease(4);
                    DEXIncrease(5);
                    ENDIncrease(2);
                    INTIncrease(1);
                    SPRIncrease(3);
                    break;
                case "Cleric":
                    STRIncrease(2);
                    DEXIncrease(3);
                    ENDIncrease(4);
                    INTIncrease(2);
                    SPRIncrease(4);
                    break;
                case "Mage":
                    STRIncrease(1);
                    DEXIncrease(2);
                    ENDIncrease(1);
                    INTIncrease(6);
                    SPRIncrease(5);
                    break;
            }

        }
        internal void SetStatpoints()
        {
            bool loop = false;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"\n{Name}   Level: {Level} Free Points: {StatPoints}");
                Console.WriteLine($"STR: {STR} + {STRIncreased}     (Increases Damage)");
                Console.WriteLine($"DEX: {DEX} + {DEXIncreased}     (Increases Evation and Aim)");
                Console.WriteLine($"END: {END} + {ENDIncreased}     (Increases Defance, Block Rate and HP)");
                Console.WriteLine($"INT: {INT} + {INTIncreased}     (Increases Magical Damage)");
                Console.WriteLine($"SPR: {SPR} + {SPRIncreased}     (Increases Magical Defance, Crit Rate and MP)");
                Console.ResetColor();
                if (StatPoints > 0)
                {
                    Console.WriteLine("Where Do you want to set your Point?");
                    Console.WriteLine();
                    Console.WriteLine("Back with 0");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "STR": STRIncrease(1); StatPoints--; STRIncreased++; loop = true; break;
                        case "DEX": DEXIncrease(1); StatPoints--; DEXIncreased++; loop = true; break;
                        case "END": ENDIncrease(1); StatPoints--; ENDIncreased++; loop = true; break;
                        case "INT": INTIncrease(1); StatPoints--; INTIncreased++; loop = true; break;
                        case "SPR": SPRIncrease(1); StatPoints--; SPRIncreased++; loop = true; break;
                        case "0": loop = false; break;
                        default: Console.WriteLine("Wrong input please try again!"); loop = true; break;
                    }

                }
                else
                {
                    Console.WriteLine("Back with 0");
                    char back = Console.ReadKey().KeyChar;
                    switch (back)
                    {
                        case '0': loop = false; break;
                        default: Console.WriteLine("Wrong input please try again!"); loop = true; break;
                    }

                }

            } while (loop);

        }
        internal void STRIncrease(int increase)
        {
            for (int count = 0; count < increase; count++)
            {
                STR++;
                MinDamage = STR + ItemSTR + ItemMinDmg;
                float MaxCalcPhy = (STR + ItemSTR) * 1.2F + ItemMaxDmg;
                MaxDamage = (int)MaxCalcPhy;
            }
            return;
        }
        internal void DEXIncrease(int increase)
        {
            for (int count = 0; count < increase; count++)
            {
                DEX++;
                Aim = DEX + ItemDEX + ItemAim;
                Evasion = DEX + ItemDEX + ItemEvation;
            }
            return;
        }
        internal void ENDIncrease(int increase)
        {
            for (int count = 0; count < increase; count++)
            {
                END++;
                Defense = (END + ItemEND) * 2 + ItemDefance;
                MaximalHealth = (END + ItemEND) * 10 + ItemMaxHealth;
            }
            return;
        }
        internal void INTIncrease(int increase)
        {
            for (int count = 0; count < increase; count++)
            {
                INT++;
                MinMagicalDamage = INT + ItemINT + ItemMinMDmg;
                float MaxCalcMag = (INT + ItemINT) * 1.2F + ItemMaxMDmg;
                MaxMagicalDamage = (int)MaxCalcMag;
            }
            return;
        }
        internal void SPRIncrease(int increase)
        {
            for (int count = 0; count < increase; count++)
            {
                SPR++;
                CritChance = SPRIncreased * 0.2F + ItemCritChance;
                MagicalDefense = (SPR + ItemSPR) * 2 + ItemMDefance;
                MaxiamlManaPoints = (SPR + ItemSPR) * 10 + ItemMaxManaPoints;
            }
            return;
        }

        internal void LoseExperience()
        {
            if (Experience > 0)
            {
                Experience = Experience - Level * Level * 2 / 100;
            }

        }
        internal void Healer()
        {
            CurrentHealth = MaximalHealth;
            ManaPoints = MaxiamlManaPoints;
        }

    }

}
