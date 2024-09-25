using ConsoleRPG.Loactions;

namespace ConsoleRPG
{
    internal class Program
    {
        public static Hero hero;
        public static City roumen = new City("Roumen");
        public static City elderine = new City("Elderine");
        public static City uruga = new City("Uruga");
        public static City adelia = new City("Adelia");
        static void Main(string[] args)
        {
            bool GameRun = true;

            Console.WriteLine("please name your caracter to start:");
            hero = new Hero(Console.ReadLine());
            Console.WriteLine("Your character name is: " + hero._name);

            do
            {
                char mainAction = ' ';
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

        static void Stats()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n" + hero._name + "   Level:" + hero.Level());
            Console.ResetColor();
            Console.WriteLine("\n       Max HP: " + hero.MaximalHealth() + "\n       dmg: " + hero.DamageOut() + "\n       action speed: " + hero.ActionSpeedOut() + "\n");
        }
        static void Adventure()
        {
            char adventureAction = ' ';
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
                case '1': roumen.StandartLocationAction(); break;
                case '2': elderine.StandartLocationAction(); break;
                case '3': uruga.StandartLocationAction(); break;
                case '4': adelia.StandartLocationAction(); break;
                default : Adventure(); break;
            }

        }

        static void Shop()
        {
            Console.WriteLine("The shop is currently unavailable!");
            Console.ReadKey();
        }

    }

}
