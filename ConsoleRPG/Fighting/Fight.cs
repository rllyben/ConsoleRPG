using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Fighting
{

    internal class Fight
    {
        static bool error = false;
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
                        Console.WriteLine("What Skill do you want to use?");
                        for (int count = 0; count < Program.hero.CharacterSkills.Count; count++)
                        {
                            if (Program.hero.CharacterSkills[count].CooldownDuration > 0)
                                Program.hero.CharacterSkills[count].CooldownDuration--;
                            if (Program.hero.CharacterSkills[count].CooldownDuration == 0)
                            {
                                Program.hero.CharacterSkills[count].SkillEffectEnd();
                                Program.hero.CharacterSkills[count].CooldownDuration--;
                            }
                            if (Program.hero.CharacterSkills[count].CooldownDuration > 0)
                                Program.hero.CharacterSkills[count].CooldownDuration--;

                            Console.WriteLine($"{count + 1}. Skill: {Program.hero.CharacterSkills[count].SkillName}   " +
                                              $"CD: {Program.hero.CharacterSkills[count].CooldownDuration} / {Program.hero.CharacterSkills[count].Cooldown}");
                        }
                        Console.WriteLine("Auto Attack 0.");
                        do
                        {
                            if (error)
                            {
                                Console.WriteLine("What Skill do you want to use?");
                                for (int count = 0; count < Program.hero.CharacterSkills.Count; count++)
                                {
                                    if (Program.hero.CharacterSkills[count].CooldownDuration > 0)
                                        Program.hero.CharacterSkills[count].CooldownDuration--;

                                    Console.WriteLine($"{count + 1}. Skill: {Program.hero.CharacterSkills[count].SkillName}   " +
                                                      $"CD: {Program.hero.CharacterSkills[count].CooldownDuration} / {Program.hero.CharacterSkills[count].Cooldown}");
                                }
                                Console.WriteLine("Auto Attack 0.");
                                Console.WriteLine("Q. Use HP Stone          E. Use MP Stone");
                            }
                            error = false;
                            char skill = Console.ReadKey().KeyChar;
                            Console.Clear();
                            int skillNumber = skill - 49;
                            skill = char.ToLower(skill);
                            if (skillNumber > 0 && skillNumber < Program.hero.CharacterSkills.Count && Program.hero.CharacterSkills[skillNumber].CooldownDuration > 0)
                            {
                                error = true;
                            }
                            if (skill == '0' && rnd.Next(1, 101) < heroCritChance * 100 && !error)
                            {
                                damageDeal = (((2 * heroLevel) * (damage / mob.Defense))) * 2;
                                error = false;
                            }
                            else if (skill == '0' && !error)
                            {
                                damageDeal = ((2 * heroLevel) * (damage / mob.Defense));
                                error = false;
                            }
                            else if (skillNumber < Program.hero.CharacterSkills.Count && skillNumber > 0 && rnd.Next(1, 101) < heroCritChance * 100 && !error)
                            {
                                if (Program.hero.CharacterSkills[skillNumber].SkillMaxDamage == 0)
                                {
                                    Program.hero.CurrentHealth += Program.hero.CharacterSkills[skillNumber].SkillHeal;
                                    if (Program.hero.CurrentHealth > Program.hero.MaximalHealth)
                                        Program.hero.CurrentHealth = Program.hero.MaximalHealth;
                                    Program.hero.CharacterSkills[skillNumber].SkillEffectUse();
                                    break;
                                }
                                float skillDamage = rnd.Next(Program.hero.CharacterSkills[skillNumber].SkillMinDamage, Program.hero.CharacterSkills[skillNumber].SkillMaxDamage + 1);
                                damageDeal = (((2 * heroLevel) * (skillDamage) * (damage / mob.Defense))) * 2;
                                Program.hero.CharacterSkills[skillNumber].SkillEffectUse();
                                error = false;
                            }
                            else if (skillNumber < Program.hero.CharacterSkills.Count && skillNumber > 0 && !error)
                            {
                                if (Program.hero.CharacterSkills[skillNumber].SkillMaxDamage == 0)
                                {
                                    Program.hero.CurrentHealth += Program.hero.CharacterSkills[skillNumber].SkillHeal;
                                    if (Program.hero.CurrentHealth > Program.hero.MaximalHealth)
                                        Program.hero.CurrentHealth = Program.hero.MaximalHealth;
                                    Program.hero.CharacterSkills[skillNumber].SkillEffectUse();
                                    break;
                                }
                                float skillDamage = rnd.Next(Program.hero.CharacterSkills[skillNumber].SkillMinDamage, Program.hero.CharacterSkills[skillNumber].SkillMaxDamage + 1);
                                damageDeal = (((2 * heroLevel) * (skillDamage) * (damage / mob.Defense)));
                                Program.hero.CharacterSkills[skillNumber].SkillEffectUse();
                                error = false;
                            }
                            else if (skill == 'q' && Program.hero.HPStones > 0)
                            {
                                Program.hero.UseHPStone();
                                error = false;
                            }
                            else if (skill == 'e' && Program.hero.MPStones > 0)
                            {
                                Program.hero.UseMPStone();
                                error = false;
                            }
                            else
                                error = true;

                            if (damageDeal <= 1)
                                damageDeal = 1;
                        } while (error);


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
                float damageTaken = ((2 * mob.Level) * (MobDamage / Program.hero.Defense));
                if (damageTaken <= 1)
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