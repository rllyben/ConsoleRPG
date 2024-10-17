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
        public Monster(string name, string monsterType, int currentHealth, float actionSpeed, int level, int minDamage, int maxDamage, int defanse, int giveXP, int minMagicalDamage = 0, int maxMagicalDamage = 0) : base(name)
        {
            CurrentHealth = currentHealth;
            ActionSpeed = actionSpeed;
            Level = level;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            MinMagicalDamage = minMagicalDamage;
            MaxMagicalDamage = maxMagicalDamage;
            Defanse = defanse;
            GiveXP = giveXP;
            MonsterType = monsterType;
        }

        public int GiveXP { get; set; }
        public string MonsterType { get; set; }

    }


}
