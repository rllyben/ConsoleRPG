using ConsoleRPG.Loactions;
using ConsoleRPG.Items;
using System.Text.Json;
using ConsoleRPG.Fighting;
using ConsoleRPG.Heros;
using System.Threading.Tasks;
using ConsoleRPG.Utilities;

namespace ConsoleRPG
{
    internal class Program
    {
        static char mainAction;
        static char adventureAction;
        static bool GameRun = true;
        public static Hero hero;
        public static char characterClass = '0';
        static bool error = false;

        static void Main(string[] args)
        {
            try
            {
                hero = Utils.LoadHero("player");
                Console.WriteLine($"Hero {hero} loaded successfully.");
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex);
                Console.WriteLine("Es konnte kein Hero geladen werden!");
                Thread.Sleep(1000);
                CharacterCreation();
            }
            KeyListener.ListenForEscapeKey();
            do
            {
                MainMenue();
            } while (GameRun);
            KeyListener.IsListening = false;
        }
        public static void MainMenue()
        {
            do
            {
                mainAction = ' ';
                if (hero.CurrentHealth > hero.MaximalHealth)
                    hero.Healer();

                Console.WriteLine("\nMain Menue:" +
                                  "\n1. stats        2. adventure" +
                                  "\n3. shop         4. inventory" +
                                  "\n0. save and exit");

                mainAction = Console.ReadKey().KeyChar;

                switch (mainAction)
                {
                    case '0': error = false; Utils.SaveHero(hero); GameRun = false; break;
                    case '1': error = false; Stats(); break;
                    case '2': error = false; Adventure(); break;
                    case '3': error = false; Shop(); break;
                    case '4': error = false; hero.ShowInventory(); break;
                    default: Console.WriteLine("Wrong input please try again:"); error = true; break;
                }

            } while (error);

        }
        internal static void CharacterCreation()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("please select the Class you want to play:\n" +
                                  "1. Fighter           2. Archer\n" +
                                  "3. Cleric            4. Mage\n");

                characterClass = Console.ReadKey().KeyChar;

                if (characterClass > '0' && characterClass < '5')
                {
                    Console.WriteLine("please name your character to start:");
                    hero = new(Console.ReadLine());
                    Console.WriteLine($"Your character name is: {hero}");
                    error = false;
                }
                else
                {
                    Console.WriteLine("Wrong input, please try again!");
                    Thread.Sleep(1000);
                    error = true;
                }

            }while (error);

        }

        internal static void Stats()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\n{hero}   Level: {hero.Level}");
            Console.ResetColor();
            Console.WriteLine($"\n       HP: {hero.CurrentHealth} / {hero.MaximalHealth}        MP: {hero.ManaPoints} / {hero.MaxiamlManaPoints}" +
                              $"\n       Damage: {hero.MinDamage} ~ {hero.MaxDamage}" +
                              $"\n       Magical Damage: {hero.MinMagicalDamage} ~ {hero.MaxMagicalDamage}" +
                              $"\n       Evation: {hero.Evasion}" +
                              $"\n       Aim: {hero.Aim}" +
                              $"\n       Defance: {hero.Defense}" +
                              $"\n       Magical Defance: {hero.MagicalDefense}" +
                              $"\n       Action Speed: {hero.ActionSpeed}\n" +
                              $"\nFree Statpoints: {hero.StatPoints}");
            Console.WriteLine();
            Console.WriteLine("Do you want to set Stat Points? [y/N]");
            char statPoints = Console.ReadKey().KeyChar;

            switch (statPoints)
            {
                case 'Y':
                case 'y': hero.SetStatpoints(); break;
                default: break;
            }

        }

        internal static void Adventure()
        {
            City roumen = new("Roumen", 1);
            Location tideForest = new("Forest of Tides", 3);
            Location beach = new("Sand Beach", 7);
            Location caveEcho = new("Cave of Echo", 10);
            Location mistForest = new("Forest of Mist", 11);
            Location sea = new("Sea of Greed", 16);
            City elderine = new("Elderine", 20);
            Location sandHill = new("Sand Hill", 21);
            Location burnHill = new("Burning Hill", 25);
            Location moonTomb = new("Moonlight Tomb", 29);
            Location passageI = new("Dark Passage I", 37);
            Location caveWind = new("Cave of Wind", 40);
            Location vineTomb = new("Vine Tomb", 41);
            Location camp = new("Coblin Camp", 45);
            Location brokePrison = new("Collapsed Prison", 49);
            Location execution = new("Scaffold Execution Ground", 51);
            Location passageII = new("Dark Passage II", 59);
            /*
             City uruga = new("Uruga", 60);
             Location caveGold = new("Golden Cave", 61);
             Location elvenWoods = new("Ancient Elven Woods", 65);
             Location slumberForest = new("Forest of Slumber", 71);
             Location rock = new("Burning Rock", 79);
             Location swamp = new("Swamp of Dawn", 88);
             Location ruins = new("Alberstol Ruins", 100);
             Location darkLand = new("Dark Land", 105);
             City adelia = new("Adelia", 110);
             Location plain = new("Kahal Plain", 111);
             Location thornCave = new("Thron Cave", 115);
            */
            Monster slime = new("Slime", "Normal Monster", 1.9F, 1, 1, 1, 1, 1, 1);
            Monster honeying = new("Honeying", "Normal Monster", 1.7F, 3, 4, 3, 8, 7, 6);
            Monster imp = new("Imp", "Normal Monster", 1.9F, 4, 5, 5, 12, 9, 8);
            Monster gangImp = new("Gang Imp", "Elite Monster", 1.2F, 7, 12, 8, 25, 22, 18);
            Monster crab = new("Crab", "Normal Monster", 1.5F, 6, 8, 6, 13, 11, 10);
            Monster tortoise = new("Tortoise", "Normal Monster", 1.9F, 8, 12, 7, 30, 25, 16);
            Monster hob = new("Hob", "Normal Monster", 1.5F, 10, 18, 12, 25, 26, 16);
            Monster wolf = new("Wolf", "Elite Monster", 1.1F, 14, 22, 16, 38, 30, 32);
            Monster kingCrab = new("King Crab", "Hero Monster", 1.7F, 14, 30, 20, 60, 60, 70);
            Monster skeleton = new("Skeleton", "Normal Monster", 1.9F, 10, 20, 10, 15, 18, 16);
            Monster phina = new("Phina", "Normal Monster", 1.5F, 12, 0, 15, 16, 22, 12, 22);
            Monster kebing = new("Kebing", "Normal Monster", 1.7F, 14, 45, 23, 33, 30, 20);
            Monster copperGolem = new("Copper Golem", "Hero Monster", 2.2F, 20, 105, 33, 84, 65, 143);
            Monster greeny = new("Greeny", "Normal Monster", 1.2F, 12, 23, 20, 25, 33, 20);
            Monster phino = new("Phino", "Normal Monster", 1.7F, 13, 0, 21, 28, 36, 24, 28);
            Monster eber = new("Eber", "Normal Monster", 1.8F, 15, 30, 26, 33, 26, 30);
            Monster ratmanHunter = new("Ratman Hunter", "Elite Monster", 1.4F, 20, 53, 44, 56, 45, 62);
            Monster pirate = new("Pirate", "Normal Monster", 1.1F, 16, 33, 29, 28, 23, 32);
            Monster matrose = new("Matrose", "Normal Monster", 1.5F, 18, 46, 33, 40, 36, 38);
            Monster lizardman = new("Lizardman", "Normal Monster", 1.7F, 21, 51, 39, 41, 40, 41);
            Monster mara = new("Mara", "Hero Monster", 1.2F, 20, 123, 63, 84, 78, 193);
            Monster desertRunner = new("Desert Runner", "Normal Monster", 0.9F, 22, 56, 38, 48, 46, 45);
            Monster marloneMegaton = new("Marlone Megaton", "Normal Monster", 0.5F, 23, 44, 38, 47, 36, 49);
            Monster desertSpider = new("Desert Spider", "Normal Monster", 1.6F, 25, 103, 46, 57, 41, 56);
            Monster desertLizardman = new("Desert Lizardman", "Elite Monster", 1.7F, 24, 88, 48, 61, 60, 58);
            Monster desertWorm = new("Desert Worm", "Hero Monster", 2.0F, 28, 546, 78, 254, 163, 364);
            Monster marloneFighter = new("Marlone Fighter", "Normal Monster", 1.5F, 26, 95, 55, 73, 58, 57);
            Monster marloneGeneral = new("Marlone General", "Elite Monster", 1.3F, 28, 104, 58, 103, 61, 72);
            Monster marlone = new("Marlone", "Hero Monster", 1.4F, 30, 397, 93, 224, 89, 410);
            Monster spider = new("Spider", "Normal Monster", 1.6F, 31, 166, 84, 112, 78, 82);
            Monster bat = new("Bat", "Normal Monster", 1.5F, 28, 102, 108, 108, 69, 78);
            Monster zombie = new("Zombie", "Normal Monster", 1.8F, 34, 256, 57, 144, 96, 120);
            Monster tombFox = new("Tomb Fox", "Normal Monster", 0.8F, 35, 156, 154, 139, 109, 132);
            Monster piggyBat = new("Piggy Bat", "Elite Monster", 1.5F, 30, 106, 105, 208, 98, 163);
            Monster ghostSlime = new("Ghost Slime", "Hero Monster", 1.9F, 38, 971, 175, 304, 256, 628);
            Monster babyWereBear = new("Baby Werebear", "Normal Monster", 1.1F, 35, 206, 103, 174, 131, 141);
            Monster fireVivi = new("Fire Vivi", "Normal Monster", 1.4F, 38, 0, 112, 124, 265, 164, 212);
            Monster fighterSecretSociety = new("Fighter of the Secret Society", "Elite Monster", 1.1F, 36, 475, 178, 332, 167, 226);
            Monster leaderSecretSociety = new("Leader of the Secret Society", "Hero Monster", 1.5F, 42, 1012, 243, 612, 254, 816);
            Monster caveProg = new("Cave Prog", "Normal Monster", 1.1F, 34, 238, 101, 161, 184, 153);
            Monster caveBook = new("Cave Magicbook", "Normal Monster", 1.5F, 37, 0, 131, 173, 209, 181, 268);
            Monster silverGolem = new("Silver Golem", "Hero Monster", 2.2F, 40, 0, 100, 1045, 1412, 1375, 2687);
            Monster ghost = new("Ghost", "Normal Monster", 1.2F, 38, 0, 164, 161, 185, 212, 311);
            Monster boneImp = new("Bone Imp", "Normal Monster", 1.9F, 40, 423, 164, 263, 163, 231);
            Monster prog = new("Prog", "Normal Monster", 1.1F, 41, 583, 173, 178, 183, 243);
            Monster hobFighter = new("Hob Fighter", "Elite Monster", 1.5F, 43, 712, 261, 436, 236, 417);
            Monster robo = new("Robo", "Hero Monster", 1.3F, 46, 4828, 374, 2022, 622, 2818);
            Monster goblin = new("Goblin", "Normal Monster", 1.3F, 43, 621, 232, 281, 203, 262);
            Monster werebear = new("Werebear", "Normal Monster", 1.1F, 45, 712, 204, 353, 213, 281);
            Monster sandRat = new("Sand Rat", "Normal Monster", 1.4F, 48, 918, 292, 334, 264, 341);
            Monster goblinMage = new("Goblin Mage", "Elite Monster", 1.6F, 46, 0, 264, 399, 612, 737, 839);
            Monster goblinGeneral = new("Goblin General", "Elite Monster", 1.3F, 48, 1712, 230, 510, 338, 753);
            Monster goblinKing = new("Goblin King", "Hero Monster", 1.4F, 50, 7870, 543, 3426, 1389, 4396);
            Monster harkan = new("Harkan", "Normal Monster", 1.5F, 49, 931, 303, 462, 376, 568);
            Monster kingEber = new("King Eber", "Normal Monster", 1.8F, 51, 1012, 335, 681, 476, 610);
            Monster weakebndOrge = new("Weakend Orge", "Normal Monster", 1.9F, 52, 1461, 312, 812, 684, 819);
            Monster orge = new("Orge", "Elite Monster", 1.9F, 52, 2036, 443, 2082, 1019, 1594);
            Monster prisinor = new("Prisonor", "Normal Monster", 1.1F, 54, 1326, 741, 1264, 805, 728);
            Monster executioner = new("Executioner", "Normal Monster", 1.5F, 56, 2172, 838, 1418, 1023, 812);
            Monster torturer = new("Torturer", "Normal Monster", 1.6F, 58, 2683, 919, 1676, 1129, 1073);
            Monster erzKarasianMage = new("Erz Karasian Mage", "Elite Monster", 1.6F, 60, 0, 1423, 1881, 2962, 3162, 2873);
            Monster desharkan = new("Desharkan", "Normal Monster", 1.5F, 59, 2650, 1048, 1880, 1469, 1375);
            Monster karasianFighter = new("Karasian Fighter", "Normal Monster", 0.9F, 60, 3737, 1379, 2012, 1523, 1930);
            Monster karasianMage = new("Karasian Mage", "Normal Monster", 1.6F, 60, 0, 1310, 1312, 2071, 2078, 2010);
            Monster archon = new("Archon", "Normal Monster", 1.3F, 61, 3985, 1810, 2548, 1880, 2264);
            Monster pixi = new("Pixi", "Elite Monster", 1.5F, 65, 8380, 2573, 13512, 8012, 10642);
            if (false)
            {
                roumen.IDcheck();
                tideForest.IDcheck();
                beach.IDcheck();
                caveEcho.IDcheck();
                mistForest.IDcheck();
                sea.IDcheck();
                elderine.IDcheck();
                sandHill.IDcheck();
                burnHill.IDcheck();
                moonTomb.IDcheck();
                passageI.IDcheck();
                caveWind.IDcheck();
                vineTomb.IDcheck();
                camp.IDcheck();
                brokePrison.IDcheck();
                execution.IDcheck();
                passageII.IDcheck();
                /*
                uruga.IDcheck();
                caveGold.IDcheck();
                elvenWoods.IDcheck();
                slumberForest.IDcheck();
                rock.IDcheck();
                swamp.IDcheck();
                ruins.IDcheck();
                darkLand.IDcheck();
                adelia.IDcheck();
                plain.IDcheck();
                thornCave.IDcheck();
                */


                Console.ReadKey();
            }

            Traders taroVeares = new("Taro", "Smith");
            Traders chelia = new("Chelia", "Healer");
            Traders karl = new("Karl", "Smith");
            Traders avon = new("Avon", "Healer");
            Traders hans = new("Hans", "Smith");
            Traders miria = new("Miria", "Healer");
            Traders alexia = new("Alexia", "Smith");
            Traders xela = new("Xela", "Healer");
            Traders rohan = new("Rohan", "Smith");
            Traders marcudos = new("Marcudos", "Smith");


            if (hero.CharacterClass == "Fighter")
            {

                Weapons shortSword = new("Short Sword", "Fighter", "Weapon", "normal", 12, 1, 1.1F, 4, 7, 1.1F);
                Weapons longSword = new("Long Sword", "Fighter", "Weapon", "normal", 75, 8, 1.1F, 12, 20, 1.1F);
                Weapons broadSword = new("Broad Sword", "Fighter", "Weapon", "normal", 240, 15, 1.1F, 19, 33, 1.1F);
                Armor leatherBoots = new("Leatehr Boots", "Fighter", "Boots", "normal", 13, 0, 1, 2, 0, 1, 0);
                Armor leatherHelmet = new("Leatehr Helmet", "Fighter", "Helmet", "normal", 20, 0, 1, 4, 1, 2, 1);
                Armor leatherPants = new("Leatehr Pants", "Fighter", "Pants", "normal", 35, 0, 1, 6, 2, 4, 0);
                Armor leatherShirt = new("Leatehr Shirt", "Fighter", "Chest", "normal", 61, 50, 1, 9, 4, 7, 0);
                Armor chainBoots = new("Chain Boots", "Fighter", "Boots", "normal", 80, 0, 8, 9, 4, 8, 0);
                Armor chainHelmet = new("Chain Helmet", "Fighter", "Helmet", "normal", 120, 0, 8, 11, 5, 10, 4);
                Armor chainPants = new("Chain Pants", "Fighter", "Pants", "normal", 200, 0, 8, 14, 7, 12, 0);
                Armor chainShirt = new("Chain Shirt", "Fighter", "Chest", "normal", 200, 0, 8, 18, 11, 15, 0);
                Armor bronceHelmet = new("Bronce Helmet", "Fighter", "Helmet", "normal", 240, 0, 15, 22, 10, 20, 8);
                Armor bronceChestplate = new("Bronce Chestplate", "Fighter", "Chest", "normal", 450, 0, 15, 36, 22, 30, 0);
                Armor broncePants = new("Bronce Pants", "Fighter", "Pants", "", 400, 0, 15, 28, 14, 24, 0);
                Armor bronceBoots = new("Bronce Boots", "Fighter", "Boots", "", 220, 0, 15, 18, 8, 16, 0);
                Shield wooddenShield = new("Wodden Shield", "Fighter", "Shield", "normal", 10, 0, 1, 5, 0, 0, 0, 1);
                Shield buckler = new("Buckler", "Fighter", "Shield", "normal", 55, 0, 8, 14, 3, 0, 0, 2);
                Shield bronceShield = new("Bronce Shield", "Fighter", "Shield", "", 240, 0, 15, 28, 6, 0, 0, 4);
                Weapons roumenSword = new("Roumen Sword", "Fighter", "Weapon", "normal", 6000, 20, 1.1F, 26, 44, 1.1F);
                Weapons bridgeSword = new("Bridge Sword", "Fighter", "Weapon", "normal", 18000, 30, 1.1F, 45, 78, 1.1F);
                Weapons cutlasSword = new("Cutlas", "Fighter", "Weapon", "normal", 38000, 40, 1.1F, 65, 112, 1.1F);
                Weapons edgedSword = new("Edged Sword", "Fighter", "Weapon", "normal", 69000, 50, 1.1F, 85, 146, 1.1F);
                Weapons steelSword = new("Steel Sword", "Fighter", "Weapon", "normal", 6000, 20, 1.4F, 61, 87, 1.3F);
                Weapons crusaderSword = new("Crusader", "Fighter", "Weapon", "normal", 18000, 30, 1.4F, 108, 154, 1.3F);
                Weapons twohandedSword = new("Zweihander", "Fighter", "Weapon", "normal", 38000, 40, 1.4F, 155, 221, 1.3F);
                Weapons busterSword = new("Buster Sword", "Fighter", "Weapon", "normal", 69000, 50, 1.4F, 202, 287, 1.3F);
                Weapons steelAxe = new("Steel Axe", "Fighter", "Weapon", "normal", 6000, 20, 1.7F, 96, 134, 1.5F);
                Weapons hideAxe = new("Hide Axe", "Fighter", "Weapon", "normal", 18000, 30, 1.7F, 170, 235, 1.5F);
                Weapons twoHandedAxe = new("Two Handed Axe", "Fighter", "Weapon", "normal", 38000, 40, 1.7F, 243, 337, 1.5F);
                Weapons poleAxe = new("Pole Axe", "Fighter", "Weapon", "normal", 69000, 50, 1.7F, 316, 438, 1.5F);
                Weapons splitterSword = new("Splitter", "Fighter", "Weapon", "normal", 290000, 60, 1.1F, 105, 181, 1.1F);
                Weapons avantSword = new("Avent Garde Sword", "Fighter", "Weapon", "normal", 440000, 70, 1.1F, 131, 226, 1.1F);
                Weapons sperpentSword = new("Serpent Sword", "Fighter", "Weapon", "normal", 640000, 80, 1.1F, 164, 282, 1.1F);
                Weapons claymoreSword = new("Claymore", "Fighter", "Weapon", "normal", 290000, 60, 1.4F, 250, 356, 1.3F);
                Weapons flambergeSword = new("Flamberge", "Fighter", "Weapon", "normal", 440000, 70, 1.4F, 312, 444, 1.3F);
                Weapons giantSword = new("Giand Sword", "Fighter", "Weapon", "normal", 640000, 80, 1.4F, 389, 555, 1.3F);
                Weapons halbendAxe = new("Halberd", "Fighter", "Weapon", "normal", 290000, 60, 1.7F, 392, 543, 1.5F);
                Weapons vikingAxe = new("Viking Axe", "Fighter", "Weapon", "normal", 440000, 70, 1.7F, 490, 678, 1.5F);
                Weapons giantAxe = new("Giand Axe", "Fighter", "Weapon", "normal", 640000, 80, 1.7F, 613, 850, 1.5F);
                Weapons vulcanSword = new("Vulcan Sword", "Fighter", "Weapon", "normal", 890000, 90, 1.1F, 275, 423, 1.1F);
                Weapons hellasSword = new("Hellas Sword", "Fighter", "Weapon", "normal", 2230000, 100, 1.1F, 412, 634, 1.1F);
                Weapons gedSword = new("Ged Sword", "Fighter", "Weapon", "normal", 3080000, 108, 1.1F, 618, 951, 1.1F);
                Weapons titanicSword = new("Titanic Sword", "Fighter", "Weapon", "normal", 890000, 90, 1.4F, 541, 832, 1.3F);
                Weapons valorSword = new("Valor Sword", "Fighter", "Weapon", "normal", 2230000, 100, 1.4F, 811, 1248, 1.3F);
                Weapons gorgonSword = new("Gorgon Sword", "Fighter", "Weapon", "normal", 3080000, 108, 1.4F, 1216, 1872, 1.3F);
                Weapons titanicAxe = new("Titanic Axe", "Fighter", "Weapon", "normal", 890000, 90, 1.7F, 829, 1275, 1.5F);
                Weapons valorAxe = new("Valor Axe", "Fighter", "Weapon", "normal", 2230000, 100, 1.7F, 1243, 1912, 1.5F);
                Weapons gorgonAxe = new("Gorgon Axe", "Fighter", "Weapon", "normal", 3080000, 108, 1.7F, 1864, 2868, 1.5F);

                taroVeares.AddWeapon(shortSword);
                taroVeares.AddWeapon(longSword);
                taroVeares.AddWeapon(broadSword);
                taroVeares.AddArmor(leatherBoots);
                taroVeares.AddArmor(leatherPants);
                taroVeares.AddArmor(leatherShirt);
                taroVeares.AddArmor(leatherHelmet);
                taroVeares.AddArmor(wooddenShield);
                taroVeares.AddArmor(chainBoots);
                taroVeares.AddArmor(chainPants);
                taroVeares.AddArmor(chainShirt);
                taroVeares.AddArmor(chainHelmet);
                taroVeares.AddArmor(buckler);
                taroVeares.AddArmor(bronceBoots);
                taroVeares.AddArmor(broncePants);
                taroVeares.AddArmor(bronceChestplate);
                taroVeares.AddArmor(bronceHelmet);
                taroVeares.AddArmor(bronceShield);
                karl.AddWeapon(roumenSword);
                karl.AddWeapon(bridgeSword);
                karl.AddWeapon(cutlasSword);
                karl.AddWeapon(edgedSword);
                karl.AddWeapon(steelSword);
                karl.AddWeapon(crusaderSword);
                karl.AddWeapon(twohandedSword);
                karl.AddWeapon(busterSword);
                karl.AddWeapon(steelAxe);
                karl.AddWeapon(hideAxe);
                karl.AddWeapon(twoHandedAxe);
                karl.AddWeapon(poleAxe);
                rohan.AddWeapon(roumenSword);
                rohan.AddWeapon(bridgeSword);
                rohan.AddWeapon(cutlasSword);
                rohan.AddWeapon(edgedSword);
                rohan.AddWeapon(steelSword);
                rohan.AddWeapon(crusaderSword);
                rohan.AddWeapon(twohandedSword);
                rohan.AddWeapon(busterSword);
                rohan.AddWeapon(steelAxe);
                rohan.AddWeapon(hideAxe);
                rohan.AddWeapon(twoHandedAxe);
                rohan.AddWeapon(poleAxe);
                hans.AddWeapon(splitterSword);
                hans.AddWeapon(avantSword);
                hans.AddWeapon(sperpentSword);
                hans.AddWeapon(claymoreSword);
                hans.AddWeapon(flambergeSword);
                hans.AddWeapon(giantSword);
                hans.AddWeapon(halbendAxe);
                hans.AddWeapon(vikingAxe);
                hans.AddWeapon(giantAxe);
                marcudos.AddWeapon(vulcanSword);
                marcudos.AddWeapon(hellasSword);
                marcudos.AddWeapon(gedSword);
                marcudos.AddWeapon(titanicSword);
                marcudos.AddWeapon(valorSword);
                marcudos.AddWeapon(gorgonSword);
                marcudos.AddWeapon(titanicAxe);
                marcudos.AddWeapon(valorAxe);
                marcudos.AddWeapon(gorgonAxe);
                alexia.AddWeapon(splitterSword);
                alexia.AddWeapon(avantSword);
                alexia.AddWeapon(sperpentSword);
                alexia.AddWeapon(claymoreSword);
                alexia.AddWeapon(flambergeSword);
                alexia.AddWeapon(giantSword);
                alexia.AddWeapon(halbendAxe);
                alexia.AddWeapon(vikingAxe);
                alexia.AddWeapon(giantAxe);
            }
            if (hero.CharacterClass == "Archer")
            {

            }
            if (hero.CharacterClass == "Cleric")
            {

            }
            if (hero.CharacterClass == "Mage")
            {

            }
            if (hero.CharacterClass == "Rouge")
            {

            }
            if (hero.CharacterClass == "Crusader")
            {

            }
            if (false)
            {
                Console.WriteLine("james:" + taroVeares.TraderItems.Count);
                Console.WriteLine("karl:" + karl.TraderItems.Count);
                Console.WriteLine("rohan:" + rohan.TraderItems.Count);
                Console.WriteLine("hans:" + hans.TraderItems.Count);
                Console.WriteLine("marcudos:" + marcudos.TraderItems.Count);
                Console.WriteLine("alexia:" + alexia.TraderItems.Count);
                Console.ReadLine();
            }

            roumen.AddConnection(tideForest);
            roumen.AddConnection(beach);
            roumen.AddConnection(sea);
            roumen.AddTrader(taroVeares);
            roumen.AddTrader(chelia);
            tideForest.AddConnection(roumen);
            tideForest.AddConnection(beach);
            tideForest.AddConnection(caveEcho);
            tideForest.AddMonster(slime);
            tideForest.AddMonster(honeying);
            tideForest.AddMonster(imp);
            tideForest.AddMonster(gangImp);
            beach.AddConnection(roumen);
            beach.AddConnection(tideForest);
            beach.AddConnection(caveEcho);
            beach.AddConnection(mistForest);
            beach.AddMonster(crab);
            beach.AddMonster(tortoise);
            beach.AddMonster(hob);
            beach.AddMonster(wolf);
            beach.AddMonster(kingCrab);
            caveEcho.AddConnection(tideForest);
            caveEcho.AddConnection(beach);
            caveEcho.AddConnection(sea);
            caveEcho.AddMonster(skeleton);
            caveEcho.AddMonster(phina);
            caveEcho.AddMonster(kebing);
            caveEcho.AddMonster(copperGolem);
            mistForest.AddConnection(beach);
            mistForest.AddConnection(sea);
            mistForest.AddConnection(elderine);
            mistForest.AddMonster(greeny);
            mistForest.AddMonster(phino);
            mistForest.AddMonster(eber);
            mistForest.AddMonster(ratmanHunter);
            sea.AddConnection(roumen);
            sea.AddConnection(caveEcho);
            sea.AddConnection(mistForest);
            sea.AddConnection(elderine);
            sea.AddConnection(burnHill);
            sea.AddMonster(pirate);
            sea.AddMonster(matrose);
            sea.AddMonster(lizardman);
            sea.AddMonster(mara);
            elderine.AddConnection(mistForest);
            elderine.AddConnection(sea);
            elderine.AddConnection(moonTomb);
            elderine.AddConnection(brokePrison);
            elderine.AddTrader(karl);
            elderine.AddTrader(miria);
            sandHill.AddConnection(burnHill);
            sandHill.AddConnection(moonTomb);
            sandHill.AddTrader(rohan);
            sandHill.AddMonster(desertRunner);
            sandHill.AddMonster(marloneMegaton);
            sandHill.AddMonster(desertSpider);
            sandHill.AddMonster(desertLizardman);
            sandHill.AddMonster(desertWorm);
            burnHill.AddConnection(sea);
            burnHill.AddConnection(sandHill);
            burnHill.AddMonster(marloneMegaton);
            burnHill.AddMonster(marloneFighter);
            burnHill.AddMonster(marloneGeneral);
            burnHill.AddMonster(marlone);
            moonTomb.AddConnection(elderine);
            moonTomb.AddConnection(sandHill);
            moonTomb.AddConnection(passageI);
            moonTomb.AddMonster(bat);
            moonTomb.AddMonster(spider);
            moonTomb.AddMonster(zombie);
            moonTomb.AddMonster(tombFox);
            moonTomb.AddMonster(piggyBat);
            moonTomb.AddMonster(ghostSlime);
            passageI.AddConnection(moonTomb);
            passageI.AddConnection(vineTomb);
            passageI.AddMonster(babyWereBear);
            passageI.AddMonster(fireVivi);
            passageI.AddMonster(fighterSecretSociety);
            passageI.AddMonster(leaderSecretSociety);
            caveWind.AddConnection(moonTomb);
            caveWind.AddConnection(camp);
            caveWind.AddMonster(caveProg);
            caveWind.AddMonster(caveBook);
            caveWind.AddMonster(silverGolem);
            vineTomb.AddConnection(passageI);
            vineTomb.AddConnection(camp);
            vineTomb.AddMonster(ghost);
            vineTomb.AddMonster(prog);
            vineTomb.AddMonster(boneImp);
            vineTomb.AddMonster(hobFighter);
            vineTomb.AddMonster(robo);
            camp.AddConnection(caveWind);
            camp.AddConnection(vineTomb);
            camp.AddConnection(brokePrison);
            camp.AddMonster(prog);
            camp.AddMonster(goblin);
            camp.AddMonster(werebear);
            camp.AddMonster(sandRat);
            camp.AddMonster(goblinMage);
            camp.AddMonster(goblinGeneral);
            camp.AddMonster(goblinKing);
            brokePrison.AddConnection(camp);
            brokePrison.AddConnection(elderine);
            brokePrison.AddConnection(execution);
            brokePrison.AddConnection(passageII);
            brokePrison.AddMonster(harkan);
            brokePrison.AddMonster(kingEber);
            brokePrison.AddMonster(weakebndOrge);
            brokePrison.AddMonster(orge);
            execution.AddConnection(brokePrison);
            // execution.AddConnection(uruga);
            execution.AddMonster(prisinor);
            execution.AddMonster(executioner);
            execution.AddMonster(torturer);
            execution.AddMonster(erzKarasianMage);
            passageII.AddConnection(brokePrison);
            // passageII.AddConnection(uruga);
            passageII.AddMonster(desharkan);
            passageII.AddMonster(karasianFighter);
            passageII.AddMonster(karasianMage);
            passageII.AddMonster(archon);
            passageII.AddMonster(pixi);
            /*
            uruga.AddConnection(execution);
            uruga.AddConnection(passageII);
            uruga.AddConnection(caveGold);
            uruga.AddConnection(elvenWoods);
            uruga.AddConnection(slumberForest);
            uruga.AddTrader(hans);
            uruga.AddTrader(miria);
            elvenWoods.AddConnection(uruga);
            elvenWoods.AddConnection(slumberForest);
            slumberForest.AddConnection(uruga);
            slumberForest.AddConnection(elvenWoods);
            slumberForest.AddConnection(rock);
            rock.AddConnection(slumberForest);
            rock.AddConnection(swamp);
            swamp.AddConnection(rock);
            swamp.AddConnection(ruins);
            ruins.AddConnection(swamp);
            ruins.AddConnection(darkLand);
            ruins.AddTrader(marcudos);
            darkLand.AddConnection(ruins);
            darkLand.AddConnection(adelia);
            adelia.AddConnection(darkLand);
            adelia.AddConnection(plain);
            adelia.AddTrader(alexia);
            adelia.AddTrader(xela);
            plain.AddConnection(adelia);
            plain.AddConnection(thornCave);
            thornCave.AddConnection(plain);
            */
            do
            {
                Console.Clear();


                Console.WriteLine("Adventure");
                Console.WriteLine("\nWhere do you want to go?" +
                                  "\n1. Village of Roumen          2. City of Elderine" /*+
                                  "\n3. City of Uruga              4. City of Adelia"*/);
                Console.WriteLine("back with 0");

                adventureAction = Console.ReadKey().KeyChar;

                switch (adventureAction)
                {
                    case '0': error = false; break;
                    case '1': error = false; roumen.StandatCityAction(); break;
                    case '2': error = false; elderine.StandatCityAction(); break;
                    // case '3': error = false; uruga.StandatCityAction(); error = false; break;
                    // case '4': error = false; adelia.StandatCityAction(); error = false; break;
                    case '#':
                        error = false;
                        Random rnd = new Random();
                        while (true)
                        {

                            Monster mob = new Monster("Pixi", "Elite Monster", 1.5F, 65, 8380, 2573, 13512, 8012, 10642);
                            float Damage = rnd.Next(hero.MinDamage, hero.MaxDamage);
                            float DamageDeal = (((2 * hero.Level) * 20 * (Damage / mob.Defense)) / 50) * 2;
                            float MobDamage = rnd.Next(mob.MinDamage, mob.MaxDamage + 1);
                            Console.WriteLine((int)DamageDeal);
                            DamageDeal = ((2 * hero.Level) * 20 * (Damage / mob.Defense)) / 50;
                            Console.WriteLine((int)DamageDeal);

                            Console.WriteLine(Damage + "Damage count");

                            float damageTaken = ((2 * mob.Level) * 20 * (MobDamage / Program.hero.Defense)) / 50;
                            Console.WriteLine(damageTaken);

                            Thread.Sleep(1000);
                        }
                        break;
                    default: error = true; break;
                }

            } while (error);

        }

        internal static void Shop()
        {
            Console.WriteLine("The shop is currently unavailable!");
            Thread.Sleep(2000);
        }

    }

}
