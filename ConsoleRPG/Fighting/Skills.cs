using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Fighting
{
    internal class Skills : BaseSkills
    {

        public Skills(string skillName, int skillLevel, int skillManaCost, int cooldown, int skillMinDamage, int skillMaxDamage, int skillMinMDamage, int skillMaxMDamage, int skillHeal, string skillEffect, int skillEffectDuration, int skillEffectStrength) : base (skillName)
        {
            SkillName = skillName;
            SkillLevel = skillLevel;
            SkillMinDamage = skillMinDamage;
            SkillMaxDamage = skillMaxDamage;
            SkillMinMDamage = skillMinMDamage;
            SkillMaxMDamage= skillMaxMDamage;
            SkillManaCost = skillManaCost;
            SkillHeal = skillHeal;
            Cooldown = cooldown;
            SkillEffectDuration = skillEffectDuration;
            SkillEffectStrength = skillEffectStrength;
            SkillEffect = skillEffect;
        }

            // Cleric (Heals / Buffs / Tank)
            /*
             * Skill 1 Name: Heilende Berürung
             * Skillevect: Heal um [skilllevel]; cooldown 7 Runden
             * 
             * Skill 2 Name: Standfestigkeit
             * Skillevect: Erhöht eigene und die aller Teammitglieder Def um [skilllevel]; für 15 Runden; cooldown 20 Runden
             * 
             * Skill 3 Name: Segen der Vitalität
             * Skillevect: Erhöht MaxHP des Ziels um [skilllevel]; für 50 Runden; cooldown 15 Runden
             * 
             * Skill 4 Name: Segen des Krieges
             * Skillevect: Erhöht Dmg des Ziels um [skilllevel]; für 5 Runden; cooldown 20 Runden
             * 
             * Skill 5 Name: Hammer of Negotiation
             * Skillevect: Zusatzschaden, senkt gegnerische Def um [skilllevel](stackbar(5)) für 5 Runden; cooldown 3 Runden
             * 
             * Skill 6 Name: Brutale Zertrümmerung
             * Skillevect: Zusatzschaden, verkrüpelt Gegner (senkt ActionSpeed um [skilllevel]) für 10 Runden; cooldown 15 Runden
             * 
             * Skill 7 Name: Schutz Siegel 
             * Skillevect: Erhöht eigene Blockrate um [skilllevel]; für 50 Runden; cooldown 15 Runden
             * 
             * Skill 8 Name: Heiliger Schutz Segen
             * Skillevect: Verhindert Schaden auf das Ziel um [skilllevel]HP; für 7 Runden; cooldown 30 Runden
             * 
             * Skill 9 Name: Arise
             * Skillevect: Wiederbelebt Ziel; cooldown 30 Runden
             * 
             * Skill 10 Name: Holy Nova
             * Skillevect: Heilt alle Gruppen Mitglieder um [skilllevel], reduziet Aim von allen Gruppen Mitgliedern um [skilllevel]; cooldown 15 Runden    
             */

            // Mage (Magical Damage / Debuffs)
            /*
             * Skill 1 Name: Meteor
             * Skillevect: extremer Zusatzschaden, verbrennt Gegner für 5 Runden; verbrennungsschaden [skilllevel]; cooldown 25 Runden
             * 
             * Skill 2 Name: Ewiges Eis
             * Skillevect: extremer Zusatzschaden, vereist Gegner für 7 Runden; verlangsamung um [skilllevel]; cooldown 20 Runden
             * 
             * Skill 3 Name: Kugelblitz
             * Skillevect: extremer Zusatzschaden, stunnt Gegner für 2 Runden; cooldown 20 Runden
             * 
             * Skill 4 Name: Fluch der Jahre
             * Skillevect: Zusatzschaden, verflucht Gegner für 5 Runden; Fluch senkt Dmg/MDmg um [skilllevel]; cooldown 7 Runden
             * 
             * Skill 5 Name: Lebens Transver
             * Skillevect: Zusatzschaden, Heilt Anwender um [skilllevel]; cooldwon 5 Runden
             * 
             * Skill 6 Name: Feuerball
             * Skillevect: Zusatzschaden, verbrennt Gegner für 2 Runden; verbrennungsschaden [skilllevel] cooldown 1 Runde
             * 
             * Skill 7 Name: Blizzard
             * Skillevect: Zusatzschaden, Friert Gegner ein (nur wenn Vereist(stun)) für 7 Runden; Eisschanden [skillevel]; cooldown 10 Runden
             * 
             * Skill 8 Name: Mentale Konzentration
             * Skillevect: Mana Regeneration für Anwender um [skilllevel] für 5 Runden; cooldown 10 Runden
             * 
             * Skill 9 Name:
             * Skillevect:



             Beschwört über mehrere Runden ein Portal in die Hölle, aus der Dämonen erscheinen
             */

            // Rough (Physical Damage)
            /*
             * Skill 1 Name:
             * Skillevect:
             * 
             * Skill 2 Name:
             * Skillevect: 
             * 
             * Skill 3 Name:
             * Skillevect:
             * 
             * Skill 4 Name:
             * Skillevect:
             * 
             * Skill 5 Name:
             * Skillevect:
             * 
             * Skill 6 Name:
             * Skillevect:
             * 
             * Skill 7 Name:
             * Skillevect:
             * 
             * Skill 8 Name:
             * Skillevect: 
             * 
             * Skill 9 Name:
             * Skillevect:
             */

            // Crusader (Magic and Phisical Damage / Healing / Buffing)
            /*
             * Skill 1 Name:
             * Skillevect:
             * 
             * Skill 2 Name:
             * Skillevect: 
             * 
             * Skill 3 Name:
             * Skillevect:
             * 
             * Skill 4 Name:
             * Skillevect:
             * 
             * Skill 5 Name:
             * Skillevect:
             * 
             * Skill 6 Name:
             * Skillevect:
             * 
             * Skill 7 Name:
             * Skillevect:
             * 
             * Skill 8 Name:
             * Skillevect: 
             * 
             * Skill 9 Name:
             * Skillevect:
             */

        }

}
