using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    internal class Hero
    {
        internal string _name;
        public Hero(string name)
        {
            _name = name;
        }
        protected static int MaxHealth { get; set; } = 100;
        protected static int CurHealth { get; set; } = 100;
        protected static int Levl { get; set; } = 1;
        protected static int Damage { get; set; } = 1;
        protected static float ActionSpeed { get; set; } = 0.5F;

        internal int MaximalHealth()
        {
            return MaxHealth;
        }
        internal int CurrentHealth()
        {
            return CurHealth;
        }
        internal int Level()
        {
            return Levl;
        }
        internal int DamageOut()
        {
            return Damage;
        }
        internal float ActionSpeedOut()
        {
            return ActionSpeed;
        }
        internal void Healer()
        {
            CurHealth = MaxHealth;
        }

    }

}
