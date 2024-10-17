using ConsoleRPG.Loactions;
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

        static void Main(string[] args)
        {

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

            Console.WriteLine("\nMain Menue:" +
                "\n1. stats        2. adventure" +
                "\n3. shop         4. inventory" +
                "\n0. save and exit");

            mainAction = Console.ReadKey().KeyChar;

            switch (mainAction)
            {
                case '0': hero.SaveHero(); GameRun = false; break;
                case '1': Stats(); break;
                case '2': Adventure(); break;
                case '3': Shop(); break;
                case '4': hero.ShowInventory(); break;
                default: Console.WriteLine("Wrong input please try again:"); MainMenue(); break;
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

            City roumen = new City("Roumen", 1);
            Location tideForest = new Location("Forest of Tides", 3);
            Location beach = new Location("Sand Beach", 7);
            Location caveEcho = new Location("Cave of Echo", 10);
            Location mistForest = new Location("Forest of Mist", 11);
            Location sea = new Location("Sea of Greed", 16);
            City elderine = new City("Elderine", 20);
            Location sandHill = new Location("Sand Hill", 21);
            Location burnHill = new Location("Burning Hill", 25);
            Location moonTomb = new Location("Moonlight Tomb", 29);
            Location passageI = new Location("Dark Passage I", 37);
            Location caveWind = new Location("Cave of Wind", 40);
            Location vineTomb = new Location("Vine Tomb", 41);
            Location camp = new Location("Coblin Camp", 45);
            Location brokePrison = new Location("Collapsed Prison", 49);
            Location execution = new Location("Scaffold Execution Ground", 51);
            Location passageII = new Location("Dark Passage II", 59);
            /*
             City uruga = new City("Uruga", 60);
             Location caveGold = new Location("Golden Cave", 61);
             Location elvenWoods = new Location("Ancient Elven Woods", 65);
             Location slumberForest = new Location("Forest of Slumber", 71);
             Location rock = new Location("Burning Rock", 79);
             Location swamp = new Location("Swamp of Dawn", 88);
             Location ruins = new Location("Alberstol Ruins", 100);
             Location darkLand = new Location("Dark Land", 105);
             City adelia = new City("Adelia", 110);
             Location plain = new Location("Kahal Plain", 111);
             Location thornCave = new Location("Thron Cave", 115);
            */
            Monster slime = new Monster("Slime", "Normal Monster", 25, 1.9F, 1, 1, 1, 1, 1);
            Monster honeying = new Monster("Honeying", "Normal Monster", 40, 1.7F, 3, 4, 10, 3, 6);
            Monster imp = new Monster("Imp", "Normal Monster", 55, 1.9F, 4, 6, 12, 7, 8);
            Monster gangImp = new Monster("Gang Imp", "Elite Monster", 120, 1.2F, 7, 12, 18, 16, 18);
            Monster crab = new Monster("Crab", "Normal Monster", 80, 1.5F, 6, 8, 14, 8, 10);
            Monster tortoise = new Monster("Tortoise", "Normal Monster", 80, 1.9F, 8, 10, 20, 20, 16);
            Monster hob = new Monster("Hob", "Normal Monster", 100, 1.5F, 10, 12, 18, 12, 16);
            Monster wolf = new Monster("Wolf", "Elite Monster", 210, 1.1F, 14, 18, 25, 19, 32);
            Monster kingCrab = new Monster("King Crab", "Hero Monster", 400, 1.7F, 14, 30, 38, 25, 70);
            Monster skeleton = new Monster("Skeleton", "Normal Monster", 100, 1.9F, 10, 12, 20, 10, 16);
            Monster phina = new Monster("Phina", "Normal Monster", 100, 1.5F, 12, 0, 0, 5, 16, 12, 20);
            Monster kebing = new Monster("Kebing", "Normal Monster", 120, 1.7F, 14, 16, 23, 14, 20);
            Monster copperGolem = new Monster("Copper Golem", "Hero Monster", 600, 2.2F, 20, 58, 82, 74, 143);
            Monster greeny = new Monster("Greeny", "Normal Monster", 100, 1.2F, 12, 14, 23, 14, 20);
            Monster phino = new Monster("Phino", "Normal Monster", 120, 1.7F, 13, 0, 0, 13, 24, 16, 22);
            Monster eber = new Monster("Eber", "Normal Monster", 160, 1.8F, 15, 21, 26, 18, 30);
            Monster ratmanHunter = new Monster("Ratman Hunter", "Elite Monster", 220, 1.4F, 20, 32, 38, 30, 62);
            Monster pirate = new Monster("Pirate", "Normal Monster", 220, 1.1F, 16, 20, 26, 16, 32);
            Monster matrose = new Monster("Matrose", "Normal Monster", 240, 1.5F, 18, 26, 33, 38, 38);
            Monster lizardman = new Monster("Lizardman", "Normal Monster", 260, 1.7F, 21, 34, 39, 41, 41);
            Monster mara = new Monster("Mara", "Hero Monster", 400, 1.2F, 20, 81, 103, 84, 193);
            Monster desertRunner = new Monster("Desert Runner", "Normal Monster", 190, 0.9F, 22, 40, 48, 33, 45);
            Monster marloneMegaton = new Monster("Marlone Megaton", "Normal Monster", 290, 0.5F, 23, 32, 46, 31, 49);
            Monster desertSpider = new Monster("Desert Spider", "Normal Monster", 310, 1.6F, 25, 65, 81, 43, 56);
            Monster desertLizardman = new Monster("Desert Lizardman", "Elite Monster", 420, 1.7F, 24, 62, 74, 36, 58);
            Monster desertWorm = new Monster("Desert Worm", "Hero Monster", 1230, 2.0F, 28, 246, 386, 104, 364);
            Monster marloneFighter = new Monster("Marlone Fighter", "Normal Monster", 300, 1.5F, 26, 75, 94, 41, 57);
            Monster marloneGeneral = new Monster("Marlone General", "Elite Monster", 320, 1.3F, 28, 87, 108, 61, 72);
            Monster marlone = new Monster("Marlone", "Hero Monster", 620, 1.4F, 30, 226, 342, 124, 410);
            Monster spider = new Monster("Spider", "Normal Monster", 440, 1.6F, 31, 126, 206, 62, 82);
            Monster bat = new Monster("Bat", "Normal Monster", 380, 1.5F, 28, 93, 128, 56, 78);
            Monster zombie = new Monster("Zombie", "Normal Monster", 620, 1.8F, 34, 148, 241, 83, 120);
            Monster tombFox = new Monster("Tomb Fox", "Normal Monster", 640, 0.8F, 35, 132, 215, 86, 132);
            Monster piggyBat = new Monster("Piggy Bat", "Elite Monster", 2132, 1.5F, 30, 106, 163, 68, 163);
            Monster ghostSlime = new Monster("Ghost Slime", "Hero Monster", 1240, 1.9F, 38, 571, 931, 168, 628);
            Monster babyWereBear = new Monster("Baby Werebear", "Normal Monster", 640, 1.1F, 35, 141, 258, 101, 141);
            Monster fireVivi = new Monster("Fire Vivi", "Normal Monster", 612, 1.4F, 38, 0, 0, 62, 164, 212, 328);
            Monster fighterSecretSociety = new Monster("Fighter of the Secret Society", "Elite Monster", 820, 1.1F, 36, 242, 361, 132, 226);
            Monster leaderSecretSociety = new Monster("Leader of the Secret Society", "Hero Monster", 1382, 1.5F, 42, 512, 1026, 312, 816);
            Monster caveProg = new Monster("Cave Prog", "Normal Monster", 640, 1.1F, 34, 138, 191, 81, 153);
            Monster caveBook = new Monster("Cave Magicbook", "Normal Monster", 653, 1.5F, 37, 0, 0, 73, 181, 227, 368);
            Monster silverGolem = new Monster("Silver Golem", "Hero Monster", 2153, 2.2F, 40, 759, 1485, 56, 78);
            Monster ghost = new Monster("Ghost", "Normal Monster", 831, 1.2F, 38, 0, 0, 121, 212, 263, 411);
            Monster boneImp = new Monster("Bone Imp", "Normal Monster", 883, 1.9F, 40, 323, 464, 163, 231);
            Monster prog = new Monster("Prog", "Normal Monster", 694, 1.1F, 41, 383, 523, 118, 243);
            Monster hobFighter = new Monster("Hob Fighter", "Elite Monster", 1637, 1.5F, 43, 512, 761, 236, 417);
            Monster robo = new Monster("Robo", "Hero Monster", 3162, 1.3F, 46, 1828, 2674, 622, 1818);
            Monster goblin = new Monster("Goblin", "Normal Monster", 993, 1.3F, 43, 421, 532, 181, 262);
            Monster werebear = new Monster("Werebear", "Normal Monster", 1231, 1.1F, 45, 512, 704, 213, 281);
            Monster sandRat = new Monster("Sand Rat", "Normal Monster", 1622, 1.4F, 48, 718, 892, 234, 341);
            Monster goblinMage = new Monster("Goblin Mage", "Elite Monster", 1262, 1.6F, 46, 0, 0, 199, 612, 537, 839);
            Monster goblinGeneral = new Monster("Goblin General", "Elite Monster", 2396, 1.3F, 48, 1312, 1730, 510, 738);
            Monster goblinKing = new Monster("Goblin King", "Hero Monster", 5163, 1.4F, 50, 3870, 5643, 1126, 2389);
            Monster harkan = new Monster("Harkan", "Normal Monster", 1782, 1.5F, 49, 731, 903, 262, 368);
            Monster kingEber = new Monster("King Eber", "Normal Monster", 1938, 1.8F, 51, 812, 1135, 281, 410);
            Monster weakebndOrge = new Monster("Weakend Orge", "Normal Monster", 2612, 1.9F, 52, 1161, 1412, 412, 619);
            Monster orge = new Monster("Orge", "Elite Monster", 6162, 1.9F, 52, 1236, 1643, 482, 1619);
            Monster prisinor = new Monster("Prisonor", "Normal Monster", 2363, 1.1F, 54, 1326, 1741, 364, 628);
            Monster executioner = new Monster("Executioner", "Normal Monster", 2644, 1.5F, 56, 1672, 2138, 418, 712);
            Monster torturer = new Monster("Torturer", "Normal Monster", 2818, 1.6F, 58, 1983, 2619, 476, 829);
            Monster erzKarasianMage = new Monster("Erz Karasian Mage", "Elite Monster", 4262, 1.6F, 60, 0, 0, 481, 1262, 2162, 2873);
            Monster desharkan = new Monster("Desharkan", "Normal Monster", 3120, 1.5F, 59, 2050, 2648, 480, 869);
            Monster karasianFighter = new Monster("Karasian Fighter", "Normal Monster", 3270, 0.9F, 60, 2737, 3379, 512, 930);
            Monster karasianMage = new Monster("Karasian Mage", "Normal Monster", 2870, 1.6F, 60, 0, 0, 312, 1071, 2078, 2810);
            Monster archon = new Monster("Archon", "Normal Monster", 3682, 1.3F, 61, 2985, 3810, 548, 1280);
            Monster pixi = new Monster("Pixi", "Elite Monster", 8174, 1.5F, 65, 5380, 8173, 812, 4012);
            if (true)
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

            roumen.AddConnection(tideForest);
            roumen.AddConnection(beach);
            roumen.AddConnection(sea);
            roumen.AddTrader(City.james);
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
            elderine.AddTrader(City.karl);
            sandHill.AddConnection(burnHill);
            sandHill.AddConnection(moonTomb);
            sandHill.AddTrader(Location.rohan);
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
            uruga.AddTrader(City.hans);
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
            ruins.AddTrader(Location.marcudos);
            darkLand.AddConnection(ruins);
            darkLand.AddConnection(adelia);
            adelia.AddConnection(darkLand);
            adelia.AddConnection(plain);
            adelia.AddTrader(City.alexia);
            plain.AddConnection(adelia);
            plain.AddConnection(thornCave);
            thornCave.AddConnection(plain);
            */

            Traders.TraderItemInitilation();

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
                case '1': roumen.StandatCityAction(); break;
                case '2': elderine.StandatCityAction(); break;
                // case '3': uruga.StandatCityAction(); break;
                // case '4': adelia.StandatCityAction(); break;
                default: Adventure(); break;
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
