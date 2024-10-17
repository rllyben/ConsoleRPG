using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Fighting
{
    internal class Fight
    {
        public static void Fighting(string monsterName, int monsterHP, float monsterSpeed, int minMonsterDmg, int maxMonsterDmg, int monsterDef, int monsterXp)
        {
            int minHeroDmg = Program.hero.MinDamage;
            int maxHeroDmg = Program.hero.MaxDamage + 1;

            while (Program.hero.CurrentHealth > 0 && monsterHP > 0)
            {
                float heroSpeed = Program.hero.ActionSpeed;
                float MobSpeed = monsterSpeed;
                Random rnd = new Random();
                if (heroSpeed < MobSpeed)
                {
                    while (heroSpeed < MobSpeed)
                    {
                        int mobHP = monsterHP;
                        monsterHP = monsterHP - (rnd.Next(minHeroDmg, maxHeroDmg) / monsterDef);
                        Console.WriteLine();
                        Console.WriteLine($"You attack the {monsterName} and deal {mobHP - monsterHP} damage!");
                        Console.WriteLine($"The Monster has {monsterHP}HP left");
                        MobSpeed -= heroSpeed;
                    }

                }
                if (MobSpeed <= heroSpeed)
                {
                    while (MobSpeed <= heroSpeed)
                    {
                        Program.hero.FightHero(monsterName, minMonsterDmg, maxMonsterDmg);
                        heroSpeed -= MobSpeed;
                    }

                }


            }
            if (monsterHP <= 0)
            {
                Console.WriteLine($"You killed the Monster! You have {Program.hero.CurrentHealth}HP left.");
                Program.hero.GetExperience(monsterXp);
                Program.hero.GetCash(monsterXp);
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
