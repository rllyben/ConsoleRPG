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
        public Monster(string name, int currentHealth, float actionSpeed, int level, int minDamage, int maxDamage, int defanse, int giveXP) : base(name) 
        {
            CurrentHealth = currentHealth;
            ActionSpeed = actionSpeed;
            Level = level;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            Defanse = defanse;
            GiveXP = giveXP;
        }

        public int GiveXP {get; set;}

    }


}
