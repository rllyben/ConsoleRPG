using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    internal interface IStats
    {
        public int STR { get; set; }
        public int DEX { get; set; }
        public int END { get; set; }
        public int INT { get; set; } 
        public int SPR { get; set; }
        public int Level { get; set; }
        public float ActionSpeed { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public int Aim { get; set; }
        public int MinMagicalDamage { get; set; }
        public int MaxMagicalDamage { get; set; }
        public int MagicalDefense { get; set; }
        public int Defense { get; set; }
        public int Evasion { get; set; }
        public string Name { get; set; }
    }

}
