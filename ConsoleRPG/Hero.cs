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
        private static int _maxHealth { get; set; } = 100;
        private static int _curHealth { get; set; } = 100;
        private static int _lvl { get; set; } = 1;
        private static int _damage { get; set; } = 1;
        private static float _actionSpeed { get; set; } = 0.5F;

        internal int MaxHealth()
        {
            return _maxHealth;
        }
        internal int CurrentHealth()
        {
            return _curHealth;
        }
        internal int Level()
        {
            return _lvl;
        }
        internal int Damage()
        {
            return _damage;
        }
        internal float ActionSpeed()
        {
            return _actionSpeed;
        }
        internal void Healer()
        {
            _curHealth = _maxHealth;
        }

    }

}
