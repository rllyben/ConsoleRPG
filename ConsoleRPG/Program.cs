using ConsoleRPG.Loactions;

namespace ConsoleRPG
{
    internal class Program
    {
        static char mainAction;
        static char adventureAction;
        public static Hero hero;
        public static City roumen = new City("Roumen", 1);
        public static City elderine = new City("Elderine", 20);
        public static City uruga = new City("Uruga", 60);
        public static City adelia = new City("Adelia", 110);
        public static Location tideForest = new Location("Forest of Tides", 3);
        public static Location beach = new Location("Sand Beach", 7);
        public static Location caveEcho = new Location("Cave of Echo", 10);
        public static Location mistForest = new Location("Forest of Mist", 11);
        public static Location sea = new Location("Sea of Greed", 16);
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
        public static Location caveGold = new Location("Golden Cave", 61);
        public static Location elvenWoods = new Location("Ancient Elven Woods", 65);
        public static Location slumberForest = new Location("Forest of Slumber", 71);
        public static Location rock = new Location("Burning Rock", 79);
        public static Location swamp = new Location("Swamp of Dawn", 88);
        public static Location ruins = new Location("Alberstol Ruins", 100);
        public static Location darkLand = new Location("Dark Land", 105);
        public static Location plain = new Location("Kahal Plain", 111);
        public static Location thornCave = new Location("Thron Cave", 115);

        static void Main(string[] args)
        {
            bool GameRun = true;

            Console.WriteLine("please name your caracter to start:");
            hero = new Hero(Console.ReadLine());
            Console.WriteLine($"Your character name is: {hero._name}");

            do
            {
                mainAction = ' ';
                hero.MaximalHealth();
                if (hero.CurrentHealth() > hero.MaximalHealth()) 
                    hero.Healer();

                while (mainAction == ' ')
                {
                    Console.WriteLine("\nMain Menue:" +
                        "\n1. stats        2. adventure" +
                        "\n3. shop         0. exit");

                    mainAction = Console.ReadKey().KeyChar;

                }

                switch (mainAction)
                {
                    case '0': GameRun = false; break;
                    case '1': Stats(); break;
                    case '2': Adventure(); break;
                    case '3': Shop(); break;
                    default: Console.WriteLine("Wrong input please try again:"); mainAction = ' '; break;
                }

            } while (GameRun);
            
        }

        internal static void Stats()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\n{hero._name}   Level: {hero.Level()}");
            Console.ResetColor();
            Console.WriteLine($"\n       Max HP: {hero.MaximalHealth()}\n       dmg: {hero.DamageOut()}\n       action speed: {hero.ActionSpeedOut()}\n");
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
                case '1': roumen.StandatCityAction(); break;
                case '2': elderine.StandatCityAction(); break;
                case '3': uruga.StandatCityAction(); break;
                case '4': adelia.StandatCityAction(); break;
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
            Console.ReadKey();
        }

    }

}
