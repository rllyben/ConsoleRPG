using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Fighting
{
    internal class Fight
    {
        public static void Fighting(int mobMinDmg, int mobMaxDmg, int monsterHP ,float monsterSpeed)
        {
            int minHeroDmg = Program.hero.MinDamage;
            int maxHeroDmg = Program.hero.MaxDamage + 1;

            while (Program.hero.CurrentHealth > 0 && monsterHP > 0)
            {
                float heroSpeed = Program.hero.ActionSpeed;
                float MobSpeed = monsterSpeed;

                while (heroSpeed > 0 && MobSpeed > 0 && monsterHP > 0)
                {
                    Random rnd = new Random();
                    if (heroSpeed < MobSpeed)
                    {
                        while (heroSpeed < MobSpeed)
                        {
                            int mobHP = monsterHP;
                            monsterHP = monsterHP - (rnd.Next(minHeroDmg, maxHeroDmg));
                            Console.WriteLine();
                            Console.WriteLine($"You attack the Monster and deal {mobHP-monsterHP} damage!");
                            Console.WriteLine($"The Monster has {monsterHP}HP left");
                            MobSpeed -= heroSpeed;
                        }

                    }
                    else
                    {
                        while (MobSpeed <= heroSpeed)
                        {
                            Program.hero.FightHero(mobMinDmg, mobMaxDmg);
                            heroSpeed -= MobSpeed;
                        }

                    }

                }

            }
            if (monsterHP <= 0)
            {
                Console.WriteLine($"You killed the Monster! You have {Program.hero.CurrentHealth}HP left.");
                Program.hero.GetCash(mobMinDmg * 2);
                Program.hero.GetExperience(mobMinDmg);
                Thread.Sleep(1000);
            }
            else if (Program.hero.CurrentHealth <= 0)
            {
                Console.WriteLine($"You Died! You lose {Program.hero.MinDamage * 2} Money");
                Program.hero.LoseExperience();
                Thread.Sleep(2000);
            }
                return; 

        }

    }

}
