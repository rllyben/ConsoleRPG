using ConsoleRPG.Heros;
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
        private static bool error = false;
        public static void Fighting(Monster mob)
        {
            int minHeroDmg = Program.hero.MinDamage;
            int maxHeroDmg = Program.hero.MaxDamage + 1;
            float heroCritChance = Program.hero.CritChance;
            int heroLevel = Program.hero.Level;
            int mobHP = mob.CurrentHealth;
            float monsterSpeed = mob.ActionSpeed;
            float heroSpeed = Program.hero.ActionSpeed;

            while (Program.hero.CurrentHealth > 0 && mobHP > 0)
            {
                
                if (heroSpeed <= monsterSpeed)
                {
                    heroSpeed = Program.hero.ActionSpeed;
                    HeroTurn(mob, ref mobHP);
                    if (!mob.IsStunned)
                        monsterSpeed -= heroSpeed;
                }
                else
                {
                    monsterSpeed = mob.ActionSpeed;
                    MobTurn(mob);
                    heroSpeed -= monsterSpeed;
                }

            }
            EndFight(mob, mobHP);
        }
        private static void HeroTurn(Monster mob, ref int mobHP)
        {

            float damageDealt = 0;
            bool skillUsed = false;
            Random rnd = new();

            while (!skillUsed)
            {
                Console.Clear();
                Console.WriteLine("What Skill do you want to use?");
                DisplaySkills();
                char skillInput = Console.ReadKey().KeyChar;

                int skillIndex = skillInput - 49;
                skillInput = char.ToLower(skillInput);

                if (IsValidSkill(skillInput, skillIndex, out var selectedSkill))
                {
                    if (selectedSkill == null)
                    {
                        damageDealt = CalculateDamage(rnd, Program.hero.Level, Program.hero.MinDamage, Program.hero.MaxDamage, mob.Defense, Program.hero.CritChance, true);
                        skillUsed = true;
                    }
                    else
                    {
                        damageDealt = UseSkill(selectedSkill, mob, rnd);
                        selectedSkill.SkillEffectUse(Program.hero, mob);
                        skillUsed = true;
                    }
                    ApplyDamageToMob(ref mobHP, mob.Name, damageDealt);
                }
                else if (skillInput == 'q')
                {
                    Program.hero.UseHPStone();
                    skillUsed = true;
                }
                else if (skillInput == 'e')
                {
                    Program.hero.UseMPStone();
                    skillUsed = true;
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please choose a skill or action.");
                }
                if (skillUsed)
                    EndTurn(Program.hero, mob);

            }
        }
        private static bool IsValidSkill(char skillInput, int skillIndex, out BaseSkills selectedSkill)
        {
            selectedSkill = null;

            if (skillInput == '0') // Autoattack
            {
                return true;
            }
            else if (skillIndex >= 0 && skillIndex < Program.hero.CharacterSkills.Count)
            {
                selectedSkill = Program.hero.CharacterSkills[skillIndex];
                return selectedSkill.CooldownDuration <= 0;
            }
            return false;
        }
        private static float CalculateDamage(Random rnd, int level, int minDmg, int maxDmg, int defense, float critChance, bool isAutoAttack)
        {
            float baseDamage = rnd.Next(minDmg, maxDmg);
            float critMultiplier = rnd.NextDouble() < critChance ? 2.0f : 1.0f;
            float calculatedDamage = critMultiplier * 2 * level * (baseDamage / defense);
            if (calculatedDamage < 1)
                calculatedDamage = 1;
            return calculatedDamage;
        }
        private static float UseSkill(BaseSkills skill, Monster mob, Random rnd)
        {
            float damageDealt = 0;
            if (skill.SkillMaxDamage > 0)
            {
                float skillDamage = rnd.Next(skill.SkillMinDamage, skill.SkillMaxDamage + 1);
                damageDealt = CalculateDamage(rnd, Program.hero.Level, Program.hero.MinDamage + (int)skillDamage, Program.hero.MaxDamage + (int)skillDamage, mob.Defense, Program.hero.CritChance, false);
            }
            else if (skill.SkillHeal > 0) // Healing skill
            {
                Program.hero.CurrentHealth = Math.Min(Program.hero.CurrentHealth + skill.SkillHeal, Program.hero.MaximalHealth);
                Console.WriteLine($"{Program.hero.Name} heals for {skill.SkillHeal} health points!");
            }

            skill.CooldownDuration = skill.Cooldown;
            return damageDealt;
        }
        private static void DisplaySkills()
        {
            for (int count = 0; count < Program.hero.CharacterSkills.Count; count++)
            {
                BaseSkills skill = Program.hero.CharacterSkills[count];
                Console.WriteLine($"{count + 1}. {skill.SkillName} - Cooldown: {skill.CooldownDuration}/{skill.Cooldown}");
            }
            Console.WriteLine("Auto Attack: 0");
            Console.WriteLine("Use HP Stone: Q");
            Console.WriteLine("Use MP Stone: E");
        }
        private static void ApplyDamageToMob(ref int mobHP, string mobName, float damageDealt)
        {
            mobHP -= (int)damageDealt;
            if (mobHP < 0) mobHP = 0;

            Console.WriteLine($"You attack the {mobName} and deal {(int)damageDealt} damage!");
            Console.WriteLine($"The {mobName} has {mobHP} HP left.");
            Thread.Sleep(500);
        }
        private static void MobTurn(Monster mob)
        {
            float heroBlcokChance = Program.hero.BlockChance;
            Random rnd = new();

            if (rnd.NextDouble() < heroBlcokChance)
            {
                Console.WriteLine($"The {mob.Name} attacks, but you block the attack!");
            }
            else
            {
                float mobDamage = rnd.Next(mob.MinDamage, mob.MaxDamage + 1);
                float damageTaken = Math.Max(1, (2 * mob.Level) * (mobDamage / Program.hero.Defense));
                Program.hero.CurrentHealth -= (int)damageTaken;
                Console.WriteLine($"The {mob.Name} attacks and deals {damageTaken} damage!");
            }
            Console.WriteLine($"You have {Program.hero.CurrentHealth} HP left.");
            Thread.Sleep(500);
        }
        private static void EndTurn(Hero hero, Monster mob)
        {
            foreach (var skill in hero.CharacterSkills)
            {
                if (skill.SkillEffectRound > 0)
                {
                    skill.SkillEffectRound--;
                    if (skill.SkillEffectRound == 0)
                    {
                        skill.SkillEffectEnd(hero, mob);
                    }
                }
                // Decrement cooldown for each skill
                if (skill.CooldownDuration > 0)
                {
                    skill.CooldownDuration--;
                }

            }

        }
        private static void EndFight(Monster mob, int mobHP)
        {
            if (mobHP <= 0)
            {
                Console.WriteLine($"You defeated the {mob.Name}!");
                Thread.Sleep(500);
                Program.hero.GetExperience(mob.GiveXP);
                Program.hero.GetCash(mob.GiveXP);
            }
            else if (Program.hero.CurrentHealth <= 0)
            {
                Console.WriteLine("You have been defeated!");
                Thread.Sleep(500);
                Program.hero.LoseExperience();
            }

        }

    }

}