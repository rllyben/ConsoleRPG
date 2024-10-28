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
         * Skill 1
         * Skillevect: Erhöht eigene Blockrate um [skilllevel]; für 5 Runden; cooldown 5 Runden
         * 
         * Skill 2
         * Skillevect: Erhöt eigenen Dmg um [skilllevel], senkt eigene Def um [skilllevel]; für 3 Runden; cooldown 10 Runden
         * 
         * Skill 3
         * Skillevect: Zusatz Schaden, Stunt Gegner für [skilllevel] Runden; cooldown 10 Runden
         * 
         * Skill 4
         * Skillevect: Zusatz Schaden, senkt gegnerische DEX um [skilllevel]; für 10 Runden; cooldown 10 Runden
         * 
         * Skill 5
         * Skillevect: Zusatz Schaden, senkt gegnerische Def um [skilllevel]; für 5 Runden; cooldown 10 Runden
         * 
         * Skill 6
         * Skillevect: extremer Zusatz Schaden; cooldown 15 Runden
         * 
         * Skill 7
         * Skillevect: Zusatzschaden; cooldown 5 Runden
         * 
         * Skill 8
         * Skillevect: 
         * 
         * Skill 9
         * Skillevect: 
         */

        // Archer (Physical Damage / Poisons)
        /*
         * Skill 1
         * Skillevect: Erhöht eigene DEX um [skilllevel]; für 100 Runden; cooldown 10 Runden;
         * 
         * Skill 2
         * Skillevect: Zusatz Schaden, Vergiftet Gegner für 10 Runden; giftschaden [skilllevel]; cooldown 15 Runden
         * 
         * Skill 3
         * Skillevect: Zusatz Schaden, Infiziert Gegner für 10 Runden; krankheitsschaden [skilllevel]; cooldown 15 Runden
         * 
         * Skill 4
         * Skillevect: Zusatz Schaden, Verwundet Gegner für 10 Runden; blutungsschaden [skilllevel]; cooldown 15 Runden
         * 
         * Skill 5
         * Skillevect: Zusatz Schaden, Stunnt gegner für 5 Runden; cooldown 10 Runden
         * 
         * Skill 6
         * Skillevect: Zusatzschaden; cooldown 3 Runden
         * 
         * Skill 7
         * Skillevect: extremer Zusatzschaden; cooldown 15 Runden
         * 
         * Skill 8
         * Skillevect: 
         * 
         * Skill 9
         * Skillevect:
         */

        // Cleric (Heals / Buffs / Tank)
        /*
         * Skill 1
         * Skillevect: Heal um [skilllevel]
         * 
         * Skill 2
         * Skillevect: Erhöht eigene Def um [skilllevel]; für 15 Runden; cooldown 20 Runden
         * 
         * Skill 3
         * Skillevect: Erhöht eigene MaxHP um [skilllevel]; für 30 Runden; cooldown 15 Runden
         * 
         * Skill 4
         * Skillevect: Erhöht eigenen Dmg um [skilllevel]; für 5 Runden; cooldown 20 Runden
         * 
         * Skill 5
         * Skillevect: Zusatzschaden, senkt gegnerische Def um [skilllevel](stackbar(5)) für 5 Runden; cooldown 3 Runden
         * 
         * Skill 6
         * Skillevect: Zusatzschaden, verkrüpelt Gegner (senkt ActionSpeed um [skilllevel]) für 10 Runden; cooldown 15 Runden
         * 
         * Skill 7
         * Skillevect: Erhöht Blockrate um [skilllevel]; für 30 Runden; cooldown 15 Runden
         * 
         * Skill 8
         * Skillevect: Verhindert Schaden um [skilllevel]HP; für 15 Runden; cooldown 30 Runden
         * 
         * Skill 9
         * Skillevect: Wiederbelebt; cooldown 30 Runden
         */

        // Mage (Magical Damage / Debuffs)
        /*
         * Skill 1
         * Skillevect: extremer Zusatzschaden, verbrennt Gegner für 3 Runden; verbrennungsschaden [skilllevel]; cooldown 20 Runden
         * 
         * Skill 2
         * Skillevect: extremer Zusatzschaden, vereist Gegner für 5 Runden; verlangsamung um [skilllevel]; cooldown 20 Runden
         * 
         * Skill 3
         * Skillevect: extremer Zusatzschaden, stunnt Gegner für 1 Runde; cooldown 20 Runden
         * 
         * Skill 4
         * Skillevect: Zusatzschaden, verflucht Gegner für 5 Runden; Fluch senkt Dmg/MDmg um [skilllevel]; cooldown 10 Runden
         * 
         * Skill 5
         * Skillevect: Zusatzschaden, Heilt um [skilllevel]; cooldwon 5 Runden
         * 
         * Skill 6
         * Skillevect: Zusatzschaden; cooldown 1 Runde
         * 
         * Skill 7
         * Skillevect: Zusatzschaden, Friert Gegner ein (nur wenn Vereist(stun)) für 5 Runden; Eisschanden [skillevel]; cooldown 5 Runden
         * 
         * Skill 8
         * Skillevect: Mana Regeneration um [skilllevel] für 5 Runden; cooldown 10 Runden
         * 
         * Skill 9
         * Skillevect:
         */

        // Rough (Physical Damage / Subtank)
        /*
         * Skill 1
         * Skillevect:
         * 
         * Skill 2
         * Skillevect: 
         * 
         * Skill 3
         * Skillevect:
         * 
         * Skill 4
         * Skillevect:
         * 
         * Skill 5
         * Skillevect:
         * 
         * Skill 6
         * Skillevect:
         * 
         * Skill 7
         * Skillevect:
         * 
         * Skill 8
         * Skillevect: 
         * 
         * Skill 9
         * Skillevect:
         */

        // Crusader (Magic and Phisical Damage / Healing)
        /*
         * Skill 1
         * Skillevect:
         * 
         * Skill 2
         * Skillevect: 
         * 
         * Skill 3
         * Skillevect:
         * 
         * Skill 4
         * Skillevect:
         * 
         * Skill 5
         * Skillevect:
         * 
         * Skill 6
         * Skillevect:
         * 
         * Skill 7
         * Skillevect:
         * 
         * Skill 8
         * Skillevect: 
         * 
         * Skill 9
         * Skillevect:
         */

    }

}
