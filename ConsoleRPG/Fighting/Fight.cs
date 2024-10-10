using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Fighting
{
    internal class Fight
    {
        public static void Fighting(int mobDmg, int monsterHP ,float monsterSpeed)
        {
            int heroDmg = Program.hero.DamageOut();

            while (Program.hero.CurrentHealth()  > 0 && monsterHP > 0)
            {
                float heroSpeed = Program.hero.ActionSpeedOut();
                float MobSpeed = monsterSpeed;

                while (heroSpeed > 0 && MobSpeed > 0 && monsterHP > 0)
                {
                    Random rnd = new Random();
                    if (heroSpeed < MobSpeed)
                    {
                        while (heroSpeed < MobSpeed)
                        {
                            int mobHP = monsterHP;
                            monsterHP = monsterHP - (heroDmg + rnd.Next(heroDmg - 1, heroDmg*2));
                            Console.WriteLine();
                            Console.WriteLine($"You attack the Monster and deal {mobHP-monsterHP} damage!");
                            MobSpeed -= heroSpeed;
                            Thread.Sleep(1000);
                        }

                    }
                    else
                    {
                        while (MobSpeed <= heroSpeed)
                        {
                            Program.hero.CurrentHealth(true, mobDmg);
                            heroSpeed -= MobSpeed;
                        }

                    }

                }

            }
            if (monsterHP <= 0)
                Console.WriteLine("You killed the Monster!");
                Thread.Sleep(2000);
                return;

        }

    }

}
