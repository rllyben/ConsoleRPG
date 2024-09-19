using ConsoleRPG;

namespace ConsoleRPG
{
    internal class Program
    {
        static Blacksmith james = new Blacksmith() { _name = "James" };
        static Hero hero;
        static void Main(string[] args)
        {
            bool GameRun = true;

            Console.WriteLine("please name your caracter to start:");
            hero = new Hero(Console.ReadLine());
            Console.WriteLine("Your character name is: " + hero._name);

            do
            {
                char mainAction = ' ';
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
                case '1': Roumen(); break;
            }

        }
        static void Roumen()
        {
            char roumenAction = ' ';
            Console.Clear();

            while (roumenAction == ' ')
            {
                Console.WriteLine("\nYou enter Roumen. What do you want to do?\n" +
                                  "1. Search for Quests           2. Go to the Healer\n" +
                                  "3. Enter the Forest of Mist    4. Go to the Sandy Beach\n" +
                                  "5. Go to the Blacksmith");
                Console.WriteLine("back with 0");

                roumenAction = Console.ReadKey().KeyChar;
            }

            switch(roumenAction)
            {
                case '0': break;
                case '1':
                    Console.WriteLine("\nQuests are currently unavailable");
                    Console.ReadKey(); Roumen(); break;
                case '2':
                    hero.Healer(); Console.WriteLine("\nThe Healer heals you to your full HP");
                    Console.ReadKey(); Roumen(); break;
                case '3': break;
                case '4': break;
                case '5': RoumenBlacksmith(); break;
            }

        }
        static void RoumenBlacksmith()
        {
            char roumenBlacksmith = ' ';

            while (roumenBlacksmith == ' ')
            {
                james.StandartAction();
                roumenBlacksmith = Console.ReadKey().KeyChar;
            }

            switch (roumenBlacksmith)
            {
                case '0': break;
                case '1': james.BlacksmithShop(); break;
                case '2': break;
                case '3': break;
                case '4': break;
                case '5': break;
                case '6': break;
            }
        }
        static void Shop()
        {
            Console.WriteLine("The shop is currently unavailable!");
            Console.ReadKey();
        }

    }

}
