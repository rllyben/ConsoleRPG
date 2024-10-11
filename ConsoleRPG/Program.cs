using ConsoleRPG.Loactions;
using System.Text.Json;

namespace ConsoleRPG
{
    internal class Program
    {
        static char mainAction;
        static char adventureAction;
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
            }

            roumen.AddConnection(tideForest);
            roumen.AddConnection(beach);
            roumen.AddConnection(sea);
            roumen.AddTrader(City.james);
            tideForest.AddConnection(roumen);
            tideForest.AddConnection(beach);
            tideForest.AddConnection(caveEcho);
            beach.AddConnection(roumen);
            beach.AddConnection(tideForest);
            beach.AddConnection(caveEcho);
            beach.AddConnection(mistForest);
            caveEcho.AddConnection(tideForest);
            caveEcho.AddConnection(beach);
            caveEcho.AddConnection(sea);
            mistForest.AddConnection(beach);
            mistForest.AddConnection(sea);
            mistForest.AddConnection(elderine);
            sea.AddConnection(roumen);
            sea.AddConnection(caveEcho);
            sea.AddConnection(mistForest);
            sea.AddConnection(elderine);
            sea.AddConnection(burnHill);
            elderine.AddConnection(mistForest);
            elderine.AddConnection(sea);
            elderine.AddConnection(moonTomb);
            elderine.AddConnection(brokePrison);
            elderine.AddTrader(City.karl);
            sandHill.AddConnection(burnHill);
            sandHill.AddConnection(moonTomb);
            sandHill.AddTrader(Location.rohan);
            burnHill.AddConnection(sea);
            burnHill.AddConnection(sandHill);
            moonTomb.AddConnection(elderine);
            moonTomb.AddConnection(sandHill);
            moonTomb.AddConnection(passageI);
            passageI.AddConnection(moonTomb);
            passageI.AddConnection(vineTomb);
            caveWind.AddConnection(moonTomb);
            caveWind.AddConnection(camp);
            vineTomb.AddConnection(passageI);
            vineTomb.AddConnection(camp);
            camp.AddConnection(caveWind);
            camp.AddConnection(vineTomb);
            camp.AddConnection(brokePrison);
            brokePrison.AddConnection(camp);
            brokePrison.AddConnection(elderine);
            brokePrison.AddConnection(execution);
            brokePrison.AddConnection(passageII);
            execution.AddConnection(brokePrison);
            execution.AddConnection(uruga);
            passageII.AddConnection(brokePrison);
            passageII.AddConnection(uruga);
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

            Traders.TraderItemInitilation();

            bool GameRun = true;

            try
            {
                hero = Hero.LoadHero("player");
                hero.CheckItems();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine($"Hero {hero} loaded successfully.");
            Thread.Sleep(1000);

            do
            {
                mainAction = ' ';
                if (hero.CurrentHealth() > hero.MaxHealth)
                    hero.Healer();

                while (mainAction == ' ')
                {
                    Console.WriteLine("\nMain Menue:" +
                        "\n1. stats        2. adventure" +
                        "\n3. shop         4. inventorry" +
                        "\n0. save and exit");

                    mainAction = Console.ReadKey().KeyChar;

                }

                switch (mainAction)
                {
                    case '0': hero.SaveHero(); GameRun = false; break;
                    case '1': Stats(); break;
                    case '2': Adventure(); break;
                    case '3': Shop(); break;
                    case '4': hero.ShowInventorry(hero); break;
                    default: Console.WriteLine("Wrong input please try again:"); mainAction = ' '; break;
                }

            } while (GameRun);
            
        }
        internal static void CharacterCreation()
        {
        Console.Clear();
        Console.WriteLine("please name your caracter to start:");
        hero = new Hero(Console.ReadLine());
        Console.WriteLine($"Your character name is: {hero}");
        }
        internal static void Stats()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\n{hero}   Level: {hero.Level}");
            Console.ResetColor();
            Console.WriteLine($"\n       HP: {hero.MaxHealth} / {hero.CurrentHealth()}\n       dmg: {hero.MinDamage} ~ {hero.MaxDamage}\n       action speed: {hero.ActionSpeed}\n");
        }
        internal static void Adventure()
        {
            adventureAction = ' ';
            Console.Clear();

            while (adventureAction == ' ')
            {

                Console.WriteLine("Adventure");
                Console.WriteLine("\nWhere do you want to go?" +
                                  "\n1. Village of Roumen          2. City of Elderine" +
                                  "\n3. City of Uruga              4. City of Adelia");
                Console.WriteLine("back with 0");

                adventureAction = Console.ReadKey().KeyChar;
            }

            switch (adventureAction)
            {
                case '0': break;
                case '1': roumen.StandatCityAction(roumen); break;
                case '2': elderine.StandatCityAction(elderine); break;
                case '3': uruga.StandatCityAction(uruga); break;
                case '4': adelia.StandatCityAction(adelia); break;
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
