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
         * Skill 1 Name: Schildwall
         * Skillevect: Erhöht eigene Blockrate um [skilllevel]; für 5 Runden; cooldown 5 Runden
         * 
         * Skill 2 Name: All in
         * Skillevect: Erhöt eigenen Dmg um [skilllevel], senkt eigene Def um [skilllevel]; für 3 Runden; cooldown 10 Runden
         * 
         * Skill 3 Name: Betäubungs Hieb
         * Skillevect: Zusatz Schaden, Stunt Gegner für [skilllevel] Runden; cooldown 10 Runden
         * 
         * Skill 4 Name: Wuchtiger Hieb
         * Skillevect: Zusatz Schaden, senkt gegnerische DEX um [skilllevel] für 10 Runden; cooldown 10 Runden
         * 
         * Skill 5 Name: Durchbruch
         * Skillevect: Zusatz Schaden, senkt gegnerische Def um [skilllevel]; für 5 Runden; cooldown 10 Runden
         * 
         * Skill 6 Name: Schädel Spalter 
         * Skillevect: extremer Zusatz Schaden; cooldown 15 Runden
         * 
         * Skill 7 Name: Hieb
         * Skillevect: Zusatzschaden; cooldown 3 Runden
         * 
         * Skill 8 Name:
         * Skillevect: 
         * 
         * Skill 9 Name:
         * Skillevect: 
         */

        // Archer (Physical Damage / Poisons)
        /*
         * Skill 1 Name: Geschärfte Sinne
         * Skillevect: Erhöht eigene DEX um [skilllevel]; für 100 Runden; cooldown 10 Runden;
         * 
         * Skill 2 Name: schlangen Biss
         * Skillevect: Zusatz Schaden, Vergiftet Gegner für 10 Runden; giftschaden [skilllevel]; cooldown 15 Runden
         * 
         * Skill 3 Name: Impfung
         * Skillevect: Zusatz Schaden, Infiziert Gegner für 10 Runden; krankheitsschaden [skilllevel]; cooldown 15 Runden
         * 
         * Skill 4 Name: Splitter Pfeil
         * Skillevect: Zusatz Schaden, Verwundet Gegner für 10 Runden; blutungsschaden [skilllevel]; cooldown 15 Runden
         * 
         * Skill 5 Name: Knüppel Schlag
         * Skillevect: Zusatz Schaden, Stunnt gegner für 5 Runden; cooldown 10 Runden
         * 
         * Skill 6 Name: Dolch stoß
         * Skillevect: Zusatzschaden; cooldown 3 Runden
         * 
         * Skill 7 Name: Pfeil Regen
         * Skillevect: extremer Zusatzschaden; cooldown 15 Runden
         * 
         * Skill 8 Name:
         * Skillevect: 
         * 
         * Skill 9 Name:
         * Skillevect:
         */

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
