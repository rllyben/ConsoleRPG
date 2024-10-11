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
            int minHeroDmg = Hero.hero.MinDamageOut();
            int maxHeroDmg = Hero.hero.MaxDamageOut() + 1;

            while (Hero.hero.CurrentHealth()  > 0 && monsterHP > 0)
            {
                float heroSpeed = Hero.hero.ActionSpeedOut();
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
                            Hero.hero.CurrentHealth(true, mobMinDmg, mobMaxDmg);
                            heroSpeed -= MobSpeed;
                        }

                    }

                }

            }
            if (monsterHP <= 0)
            {
                Console.WriteLine($"You killed the Monster! You have {Hero.hero.CurrentHealth()}HP left.");
                Hero.hero.GetCash(mobMinDmg * 2);
                Hero.hero.GetExperience(mobMinDmg);
                Thread.Sleep(1000);
            }
            else if (Hero.hero.CurrentHealth() <= 0)
            {
                Console.WriteLine($"You Died! You lose {Hero.hero.MinDamageOut() * 2} Money");
                Hero.hero.PayCash(Hero.hero.MinDamageOut() * 2);
                Thread.Sleep(2000);
            }
                return; 

        }

    }

}
