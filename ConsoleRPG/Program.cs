using ConsoleRPG;
using ConsoleRPG.Cities;

namespace ConsoleRPG
{
    internal class Program
    {
        public static Hero hero;
        public static Roumen roumen = new Roumen();
        public static Elderine elderine = new Elderine();
        public static Uruga uruga = new Uruga();
        public static Adelia adelia = new Adelia();
        static void Main(string[] args)
        {
            bool GameRun = true;

            Console.WriteLine("please name your caracter to start:");
            hero = new Hero(Console.ReadLine());
            Console.WriteLine("Your character name is: " + hero._name);

            do
            {
                char mainAction = ' ';
                hero.MaxHealth();
                if (hero.CurrentHealth() > hero.MaxHealth())
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
            Console.WriteLine("\n       Max HP: " + hero.MaxHealth() + "\n       dmg: " + hero.Damage() + "\n       action speed: " + hero.ActionSpeed() + "\n");
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
                case '1': roumen.RoumenAction(); break;
                case '2': elderine.ElderineAction(); break;
                case '3': uruga.UrugaAction(); break;
                case '4': adelia.AdeliaAction(); break;
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
