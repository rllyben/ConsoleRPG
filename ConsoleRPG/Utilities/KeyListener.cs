using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Utilities
{
    public static class KeyListener
    {
        public static bool IsListening { get; set; } = true;

        public static async Task ListenForEscapeKey()
        {
            await Task.Run(() =>
            {
                while (IsListening)
                {
                    if (Console.KeyAvailable)
                    {
                        var key = Console.ReadKey(intercept: true).Key;
                        if (key == ConsoleKey.Escape)
                        {
                            Console.Clear();
                            Program.MainMenue();
                        }

                    }

                }

            });

        }

    }

}
