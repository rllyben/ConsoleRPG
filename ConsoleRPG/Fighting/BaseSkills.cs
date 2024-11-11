using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRPG.Heros;

namespace ConsoleRPG.Fighting
{
    internal class BaseSkills
    {
        public BaseSkills(string skillName)
        {
            SkillName = skillName;
        }
            
        public string SkillName { get; set; }
        public int SkillLevel { get; set; }
        public int SkillMinDamage { get; set; }
        public int SkillMaxDamage { get; set; }
        public int SkillMinMDamage { get; set; }
        public int SkillMaxMDamage { get; set; }
        public int SkillManaCost { get; set; }
        public int SkillHeal { get; set; }
        public int Cooldown { get; set; }
        public int SkillEffectDuration { get; set; }
        public float SkillEffectStrength { get; set; }
        public string SkillEffect { get; set; }
        public int SkillEffectRound { get; set; } = -1;
        public int CooldownDuration { get; set; } = 0;

        public static void UpdateSkills(List<BaseSkills> skills)
        {
            foreach (BaseSkills skill in skills)
            {
                skill.SkillMinDamage *= skill.SkillLevel;
                skill.SkillMaxDamage *= skill.SkillLevel;
                skill.SkillManaCost *= skill.SkillLevel;
                skill.SkillHeal *= skill.SkillLevel;
                skill.SkillEffectStrength *= skill.SkillLevel;
                skill.SkillMinMDamage *= skill.SkillLevel;
                skill.SkillMaxMDamage *= skill.SkillLevel;
                if (skill.SkillName == "Stunning blow")
                    skill.SkillEffectDuration *= skill.SkillLevel;
            }

        }

        public void SkillEffectUse(Hero hero, Monster enemy)
        {
            int heroMinDamageSave = 0;
            int heroMaxDamageSave = 0;
            int heroDefanceSave = 0;
            switch (SkillEffect)
            {
                case "lowerG Def %":
                    enemy.Defense -= (int)(enemy.Defense * (SkillEffectStrength / 100));
                    SkillEffectRound = SkillEffectDuration;
                    break;

                case "higherS BlockRate %": 
                    Program.hero.BlockChance += SkillEffectStrength;
                    SkillEffectRound = SkillEffectDuration;
                    break;

                case "stunG Round":
                    enemy.IsStunned = true;
                    SkillEffectRound = SkillEffectDuration;
                    break;
                case "lowerG DEX %":
                    enemy.DEX -= (int)(enemy.DEX * (SkillEffectStrength / 100));
                    SkillEffectRound = SkillEffectDuration;
                    break;
                case "higherS Dmg %, lowerS Def %":
                    Program.hero.MinDamage += (int)(heroMinDamageSave * (SkillEffectStrength / 100));
                    Program.hero.MaxDamage += (int)(heroMaxDamageSave * (SkillEffectStrength / 100));
                    Program.hero.Defense -= (int)(heroDefanceSave * ((SkillEffectStrength / 2.5F) / 100));
                    SkillEffectRound = SkillEffectDuration;
                    break;
            }

        }
        public void SkillEffectEnd(Hero hero, Monster enemy)
        {
            switch (SkillEffect)
            {
                case "lowerG Def %":
                    enemy.Defense += (int)(enemy.Defense * (SkillEffectStrength / 100));
                    break;

                case "higherS BlockRate %": 
                    Program.hero.BlockChance -= SkillEffectStrength; 
                    break;

                case "stunG Round": 
                    enemy.IsStunned = false;
                    break;

                case "lowerG DEX %":
                    enemy.DEX += (int)(enemy.DEX * (SkillEffectStrength / 100));
                    break;

                case "higherS Dmg %, lowerS Def %":
                    Program.hero.MinDamage -= (int)(hero.MinDamage * (SkillEffectStrength / 100));
                    Program.hero.MaxDamage -= (int)(hero.MaxDamage * (SkillEffectStrength / 100));
                    Program.hero.Defense += (int)(hero.Defense * ((SkillEffectStrength / 2.5F) / 100));
                    break;
            }

        }
    }

}
