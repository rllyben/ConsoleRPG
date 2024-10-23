using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Fighting
{
    internal class Skills
    {

        public Skills(string skillName, int skillLevel, int skillManaCost, int skillMinDamage = 0, int skillMaxDamage = 0, int skillMinMDamage = 0, int skillMaxMDamage = 0, int skillHeal = 0) 
        { 
            SkillName = skillName;
            SkillLevel = skillLevel;
            SkillMinDamage = skillMinDamage;
            SkillMaxDamage = skillMaxDamage;
            SkillMinMDamage = skillMinMDamage;
            SkillMaxMDamage= skillMaxMDamage;
            SkillManaCost = skillManaCost;
            SkillHeal = skillHeal;
        }
        public string SkillName { get; set; }
        public int SkillMinDamage { get; set; }
        public int SkillMaxDamage { get; set; }
        public int SkillLevel { get; set; }
        public int SkillMinMDamage { get; set; }
        public int SkillMaxMDamage { get; set; }
        public int SkillManaCost { get; set; }
        public int SkillHeal {  get; set; }

        // Fighter (Physical Damage / Tank)
        /*
         * 
         */

        // Archer (Physical Damage / Poisons)
        /*
         * 
         */

        // Cleric (Physical Damage / Heals / Buffs / Tank)
        /*
         * 
         */

        // Mage (Magical Damage / Debuffs)
        /*
         * 
         */

        // Rough (Physical Damage / Subtank)
        /*
         * 
         */

        // Crusader (Magic and Phisical Damage / Healing)
        /*
         * 
         */

    }

}
