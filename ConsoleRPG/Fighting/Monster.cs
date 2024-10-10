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
        public Monster(string name, int setHealth, float setActionspeed, int setDmg, int lvl) : base(name) 
        {
            MaxHealth = setHealth;
            ActionSpeed = setActionspeed;
            MaxDamage = setDmg;
            Levl = lvl;
        }

    }


}
