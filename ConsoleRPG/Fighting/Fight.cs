using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Fighting
{

    internal class Fight
    {
        public static void Fighting(Monster mob)
        {
            int minHeroDmg = Program.hero.MinDamage;
            int maxHeroDmg = Program.hero.MaxDamage + 1;
            float heroCritChance = Program.hero.CritChance;
            int heroLevel = Program.hero.Level;
            int mobHP = mob.CurrentHealth;
            float MonsterSpeed = mob.ActionSpeed;

            while (Program.hero.CurrentHealth > 0 && mobHP > 0)
            {
                float MobSpeed = MonsterSpeed;
                float heroSpeed = Program.hero.ActionSpeed;
                Random rnd = new Random();
                if (heroSpeed < MobSpeed && mobHP > 0 && Program.hero.CurrentHealth > 0)
                {
                    while (heroSpeed < MobSpeed && mobHP > 0)
                    {
                        float damageDeal = 0;
                        float damage = rnd.Next(minHeroDmg, maxHeroDmg);
                        if (rnd.Next(1, 100) < heroCritChance * 100)
                            damageDeal = (((2 * heroLevel) * 20 * (damage / mob.Defanse)) / 50) * 2;
                        else
                            damageDeal = ((2 * heroLevel) * 20 * (damage / mob.Defanse)) / 50;

                        if (damageDeal <= 0)
                            damageDeal = 1;

                        mobHP -= (int)damageDeal;
                        if (mobHP < 0)
                            mobHP = 0;

                        Console.WriteLine();
                        Console.WriteLine($"You attack the {mob.Name} and deal {(int)damageDeal} damage!");
                        Console.WriteLine($"The {mob.Name} has {mobHP}HP left");
                        MobSpeed -= heroSpeed;
                    }

                }
                if (MobSpeed <= heroSpeed && mobHP > 0 && Program.hero.CurrentHealth > 0)
                {
                    while (MobSpeed <= heroSpeed && mobHP > 0)
                    {
                        FightHero(mob);
                        heroSpeed -= MobSpeed;
                    }

                }


            }
            if (mobHP <= 0)
            {
                Console.WriteLine($"You killed the {mob.Name}! You have {Program.hero.CurrentHealth}HP left.");
                Program.hero.GetExperience(mob.GiveXP);
                Program.hero.GetCash(mob.GiveXP);
                Thread.Sleep(2000);
            }
            else if (Program.hero.CurrentHealth <= 0)
            {
                Console.WriteLine($"You Died! You lose {Program.hero.Experience - (Program.hero.Level * Program.hero.Level * 2) / 100} XP!");
                Program.hero.LoseExperience();
                Thread.Sleep(2000);
            }
            return;

        }
        internal static void FightHero(Monster mob)
        {
            float heroBlockChance = Program.hero.BlockChance;
            int healthSave = Program.hero.CurrentHealth;
            Random rnd = new Random();
            float MobDamage = rnd.Next(mob.MinDamage, mob.MaxDamage + 1);
            if (rnd.Next(1, 101) < heroBlockChance * 100)
            {
                Console.WriteLine();
                Console.WriteLine($"You get attacked by the {mob.Name} but you {Console.ForegroundColor = ConsoleColor.Cyan} Blocked {Console.ResetColor}!");
            }
            else
            {
                float damageTaken = ((2 * mob.Level) * 20 * (MobDamage / Program.hero.Defanse)) / 50;
                if (damageTaken <= 0)
                    damageTaken = 1;
                Program.hero.CurrentHealth -= (int)damageTaken;
                Console.WriteLine();
                Console.WriteLine($"You get attacked by the {mob.Name} and lost {healthSave - Program.hero.CurrentHealth}HP!");
            }
            if (Program.hero.CurrentHealth < 0)
                Program.hero.CurrentHealth = 0;
            Console.WriteLine($"You have {Program.hero.CurrentHealth}HP left");
            return;
        }
    }

}