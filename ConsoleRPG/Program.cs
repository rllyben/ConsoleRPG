﻿using ConsoleRPG.Loactions;
using ConsoleRPG.Items;
using System.Text.Json;
using ConsoleRPG.Fighting;

namespace ConsoleRPG
{
    internal class Program
    {
        static char mainAction;
        static char adventureAction;
        static bool GameRun = true;
        public static Hero hero;
        public static City roumen = new City("Roumen", 1);
        public static Location tideForest = new Location("Forest of Tides", 3);
        public static Location beach = new Location("Sand Beach", 7);
        public static Location caveEcho = new Location("Cave of Echo", 10);
        public static Location mistForest = new Location("Forest of Mist", 11);
        public static Location sea = new Location("Sea of Greed", 16);
        public static City elderine = new City("Elderine", 20);
        public static Location sandHill = new Location("Sand Hill", 21);
        public static Location burnHill = new Location("Burning Hill", 25);
        public static Location moonTomb = new Location("Moonlight Tomb", 29);
        public static Location passageI = new Location("Dark Passage I", 37);
        public static Location caveWind = new Location("Cave of Wind", 40);
        public static Location vineTomb = new Location("Vine Tomb", 41);
        public static Location camp = new Location("Coblin Camp", 45);
        public static Location brokePrison = new Location("Collapsed Prison", 49);
        public static Location execution = new Location("Scaffold Execution Ground", 51);
        public static Location passageII = new Location("Dark Passage II", 59);
        /*
        public static City uruga = new City("Uruga", 60);
        public static Location caveGold = new Location("Golden Cave", 61);
        public static Location elvenWoods = new Location("Ancient Elven Woods", 65);
        public static Location slumberForest = new Location("Forest of Slumber", 71);
        public static Location rock = new Location("Burning Rock", 79);
        public static Location swamp = new Location("Swamp of Dawn", 88);
        public static Location ruins = new Location("Alberstol Ruins", 100);
        public static Location darkLand = new Location("Dark Land", 105);
        public static City adelia = new City("Adelia", 110);
        public static Location plain = new Location("Kahal Plain", 111);
        public static Location thornCave = new Location("Thron Cave", 115);
        */
        public static Monster slime = new Monster("Slime", "Normal Monster", 25, 1.9F, 1, 1, 1, 1, 1);
        public static Monster honeying = new Monster("Honeying", "Normal Monster", 40, 1.7F, 3, 4, 10, 3, 6);
        public static Monster imp = new Monster("Imp", "Normal Monster", 55, 1.9F, 4, 6, 12, 7, 8);
        public static Monster gangImp = new Monster("Gang Imp", "Elite Monster", 120, 1.2F, 7, 12, 18, 16, 18);
        public static Monster crab = new Monster("Crab", "Normal Monster", 80, 1.5F, 6, 8, 14, 8, 10);
        public static Monster tortoise = new Monster("Tortoise", "Normal Monster", 80, 1.9F, 8, 10, 20, 20, 16);
        public static Monster hob = new Monster("Hob", "Normal Monster", 100, 1.5F, 10, 12, 18, 12, 16);
        public static Monster wolf = new Monster("Wolf", "Elite Monster", 210, 1.1F, 14, 18, 25, 19, 32);
        public static Monster kingCrab = new Monster("King Crab", "Hero Monster", 400, 1.7F, 14, 30, 38, 25, 70);
        public static Monster skeleton = new Monster("Skeleton", "Normal Monster", 100, 1.9F, 10, 12, 20, 10, 16);
        public static Monster phina = new Monster("Phina", "Normal Monster", 100, 1.5F, 12, 0, 0, 5, 16, 12, 20);
        public static Monster kebing = new Monster("Kebing", "Normal Monster", 120, 1.7F, 14, 16, 23, 14, 20);
        public static Monster copperGolem = new Monster("Copper Golem", "Hero Monster", 600, 2.2F, 20, 58, 82, 74, 143);
        public static Monster greeny = new Monster("Greeny", "Normal Monster", 100, 1.2F, 12, 14, 23, 14, 20);
        public static Monster phino = new Monster("Phino", "Normal Monster", 120, 1.7F, 13, 0, 0, 13, 24, 16, 22);
        public static Monster eber = new Monster("Eber", "Normal Monster", 160, 1.8F, 15, 21, 26, 18, 30);
        public static Monster ratmanHunter = new Monster("Ratman Hunter", "Elite Monster", 220, 1.4F, 20, 32, 38, 30, 62); 
        public static Monster pirate = new Monster("Pirate", "Normal Monster", 220, 1.1F, 16, 20, 26, 16, 32); 
        public static Monster matrose = new Monster("Matrose", "Normal Monster", 240, 1.5F, 18, 26, 33, 38, 38); 
        public static Monster lizardman = new Monster("Lizardman", "Normal Monster", 260, 1.7F, 21, 34, 39, 41, 41); 
        public static Monster mara = new Monster("Mara", "Hero Monster", 400, 1.2F, 20, 81, 103, 84, 193);
        public static Monster desertRunner = new Monster("Desert Runner", "Normal Monster", 190, 0.9F, 22, 40, 48, 33, 45);
        public static Monster marloneMegaton = new Monster("Marlone Megaton", "Normal Monster", 290, 0.5F, 23, 32, 46, 31, 49); 
        public static Monster desertSpider = new Monster("Desert Spider", "Normal Monster", 310, 1.6F, 25, 65, 81, 43, 56);
        public static Monster desertLizardman = new Monster("Desert Lizardman", "Elite Monster", 420, 1.7F, 24, 62, 74, 36, 58);
        public static Monster desertWorm = new Monster("Desert Worm", "Hero Monster", 1230, 2.0F, 28, 246, 386, 104, 364);
        public static Monster marloneFighter = new Monster("Marlone Fighter", "Normal Monster", 300, 1.5F, 26, 75, 94, 41, 57); 
        public static Monster marloneGeneral = new Monster("Marlone General", "Elite Monster", 320, 1.3F, 28, 87, 108, 61, 72); 
        public static Monster marlone = new Monster("Marlone", "Hero Monster", 620, 1.4F, 30, 226, 342, 124, 410); 
        public static Monster spider = new Monster("Spider", "Normal Monster", 440, 1.6F, 31, 126, 206, 62, 82); 
        public static Monster bat = new Monster("Bat", "Normal Monster", 380, 1.5F, 28, 93, 128, 56, 78); 
        public static Monster zombie = new Monster("Zombie", "Normal Monster", 620, 1.8F, 34, 148, 241, 83, 120); 
        public static Monster tombFox = new Monster("Tomb Fox", "Normal Monster", 640, 0.8F, 35, 132, 215, 86, 132); 
        public static Monster piggyBat = new Monster("Piggy Bat", "Elite Monster", 2132, 1.5F, 30, 106, 163, 68, 163); 
        public static Monster ghostSlime = new Monster("Ghost Slime", "Hero Monster", 1240, 1.9F, 38, 571, 931, 168, 628);
        public static Monster babyWereBear = new Monster("Baby Werebear", "Normal Monster", 640, 1.1F, 35, 141, 258, 101, 141); 
        public static Monster fireVivi = new Monster("Fire Vivi", "Normal Monster", 612, 1.4F, 38, 0, 0, 62, 164, 212, 328); 
        public static Monster fighterSecretSociety = new Monster("Fighter of the Secret Society", "Elite Monster", 820, 1.1F, 36, 242, 361, 132, 226); 
        public static Monster leaderSecretSociety = new Monster("Leader of the Secret Society", "Hero Monster", 1382, 1.5F, 42, 512, 1026, 312, 816); 
        public static Monster caveProg = new Monster("Cave Prog", "Normal Monster", 640, 1.1F, 34, 138, 191, 81, 153); 
        public static Monster caveBook = new Monster("Cave Magicbook", "Normal Monster", 653, 1.5F, 37, 0, 0, 73, 181, 227, 368); 
        public static Monster silverGolem = new Monster("Silver Golem", "Hero Monster", 2153, 2.2F, 40, 759, 1485, 56, 78); 
        public static Monster ghost = new Monster("Ghost", "Normal Monster", 831, 1.2F, 38, 0, 0, 121, 212, 263, 411); 
        public static Monster boneImp = new Monster("Bone Imp", "Normal Monster", 883, 1.9F, 40, 323, 464, 163, 231); 
        public static Monster prog = new Monster("Prog", "Normal Monster", 694, 1.1F, 41, 383, 523, 118, 243); 
        public static Monster hobFighter = new Monster("Hob Fighter", "Elite Monster", 1637, 1.5F, 43, 512, 761, 236, 417); 
        public static Monster robo = new Monster("Robo", "Hero Monster", 3162, 1.3F, 46, 1828, 2674, 622, 1818); 
        public static Monster goblin = new Monster("Goblin", "Normal Monster", 993, 1.3F, 43, 421, 532, 181, 262); 
        public static Monster werebear = new Monster("Werebear", "Normal Monster", 1231, 1.1F, 45, 512, 704, 213, 281); 
        public static Monster sandRat = new Monster("Sand Rat", "Normal Monster", 1622, 1.4F, 48, 718, 892, 234, 341); 
        public static Monster goblinMage = new Monster("Goblin Mage", "Elite Monster", 1262, 1.6F, 46, 0, 0, 199, 612, 537, 839); 
        public static Monster goblinGeneral = new Monster("Goblin General", "Elite Monster", 2396, 1.3F, 48, 1312, 1730, 510, 738); 
        public static Monster goblinKing = new Monster("Goblin King", "Hero Monster", 5163, 1.4F, 50, 3870, 5643, 1126, 2389); 
        public static Monster harkan = new Monster("Harkan", "Normal Monster", 1782, 1.5F, 49, 731, 903, 262, 368); 
        public static Monster kingEber = new Monster("King Eber", "Normal Monster", 1938, 1.8F, 51, 812, 1135, 281, 410); 
        public static Monster weakebndOrge = new Monster("Weakend Orge", "Normal Monster", 2612, 1.9F, 52, 1161, 1412, 412, 619); 
        public static Monster orge = new Monster("Orge", "Elite Monster", 6162, 1.9F, 52, 1236, 1643, 482, 1619); 
        public static Monster prisinor = new Monster("Prisonor", "Normal Monster", 2363, 1.1F, 54, 1326, 1741, 364, 628); 
        public static Monster executioner = new Monster("Executioner", "Normal Monster", 2644, 1.5F, 56, 1672, 2138, 418, 712); 
        public static Monster torturer = new Monster("Torturer", "Normal Monster", 2818, 1.6F, 58, 1983, 2619, 476, 829); 
        public static Monster erzKarasianMage = new Monster("Erz Karasian Mage", "Elite Monster", 4262, 1.6F, 60, 0, 0, 481, 1262, 2162, 2873); 
        public static Monster desharkan = new Monster("Desharkan", "Normal Monster", 3120, 1.5F, 59, 2050, 2648, 480, 869); 
        public static Monster karasianFighter = new Monster("Karasian Fighter", "Normal Monster", 3270, 0.9F, 60, 2737, 3379, 512, 930); 
        public static Monster karasianMage = new Monster("Karasian Mage", "Normal Monster", 2870, 1.6F, 60, 0, 0, 312, 1071, 2078, 2810); 
        public static Monster archon = new Monster("Archon", "Normal Monster", 3682, 1.3F, 61, 2985, 3810, 548, 1280); 
        public static Monster pixi = new Monster("Pixi", "Elite Monster", 8174, 1.5F, 65, 5380, 8173, 812, 4012); 

        static void Main(string[] args)
        {
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
            }

            roumen.AddConnection(tideForest);

            try
            {
                hero = Hero.LoadHero("player");
                hero.CheckItems();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                CharacterCreation();
            }
            Console.WriteLine($"Hero {hero} loaded successfully.");
            Thread.Sleep(1000);

            do
            {
                MainMenue();
            } while (GameRun);
            
        }
        public static void MainMenue()
        {
            mainAction = ' ';
            if (hero.CurrentHealth > hero.MaximalHealth)
                hero.Healer();

            while (mainAction == ' ')
            {
                Console.WriteLine("\nMain Menue:" +
                    "\n1. stats        2. adventure" +
                    "\n3. shop         4. inventory" +
                    "\n0. save and exit");

                mainAction = Console.ReadKey().KeyChar;

            }

            switch (mainAction)
            {
                case '0': hero.SaveHero(); GameRun = false; break;
                case '1': Stats(); break;
                case '2': Adventure(); break;
                case '3': Shop(); break;
                case '4': hero.ShowInventory(); break;
                default: Console.WriteLine("Wrong input please try again:"); mainAction = ' '; break;
            }

        }
        internal static void CharacterCreation()
        {
        Console.Clear();
        Console.WriteLine("please name your character to start:");
        hero = new Hero(Console.ReadLine());
        Console.WriteLine($"Your character name is: {hero}");
        }
        internal static void Stats()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\n{hero}   Level: {hero.Level}");
            Console.ResetColor();
            Console.WriteLine($"\n       HP: {hero.MaximalHealth} / {hero.CurrentHealth}\n       dmg: {hero.MinDamage} ~ {hero.MaxDamage}\n       action speed: {hero.ActionSpeed}\n\n Free Statpoints: {hero.StatPoints}");
            Console.WriteLine();
            Console.WriteLine("Do you want to set Stat Points? [Y/N]");
            char statPoints = Console.ReadKey().KeyChar;
            switch (statPoints)
            {
                case 'Y':
                case 'y': hero.SetStatpoints(); break;
                case 'N':
                case 'n': break;
                default: 
                    Console.WriteLine("Worng input please try again!");
                    Thread.Sleep(1000);
                    Stats(); break; 
            }
            
        }
        internal static void Adventure()
        {
            adventureAction = ' ';
            Console.Clear();

            while (adventureAction == ' ')
            {

                Console.WriteLine("Adventure");
                Console.WriteLine("\nWhere do you want to go?" +
                                  "\n1. Village of Roumen          2. City of Elderine" /*+
                                  "\n3. City of Uruga              4. City of Adelia"*/);
                Console.WriteLine("back with 0");

                adventureAction = Console.ReadKey().KeyChar;
            }

            switch (adventureAction)
            {
                case '0': break;
                case '1': roumen.StandatCityAction(roumen); break;
                case '2': elderine.StandatCityAction(elderine); break;
                // case '3': uruga.StandatCityAction(uruga); break;
                // case '4': adelia.StandatCityAction(adelia); break;
                default : Adventure(); break;
            }

            if (City.backCheck)
            {
                City.backCheck = false; 
                Adventure();
            }

        }

        internal static void Shop()
        {
            Console.WriteLine("The shop is currently unavailable!");
            Thread.Sleep(2000);
        }

    }

}
