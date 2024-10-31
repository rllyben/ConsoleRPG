using ConsoleRPG.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleRPG.Fighting
{
    internal class Monster : Hero
    {
        public Monster(string name, string monsterType, float actionSpeed, int level, int str, int dex, int end, int spr, int giveXP, int inte = 0) : base(name)
        {

            Name = name;
            MinDamage = str;
            float MaxCalcPhy = str * 1.2F;
            MaxDamage = (int)MaxCalcPhy;
            Aim = dex;
            MinMagicalDamage = inte;
            float MaxCalcMag = inte * 1.2F;
            MaxMagicalDamage = (int)MaxCalcMag;
            MagicalDefense = spr;
            Defense = end;
            Evasion = dex;
            CritChance = spr * 0.2F;
            MaximalHealth = end * 10;
            MaxiamlManaPoints = spr * 10;
            ManaPoints = MaxiamlManaPoints;
            CurrentHealth = MaximalHealth;
            ActionSpeed = actionSpeed;
            GiveXP = giveXP;
            MonsterType = monsterType;
        }

        public int GiveXP { get; set; }
        public string MonsterType { get; set; }

    }

}
