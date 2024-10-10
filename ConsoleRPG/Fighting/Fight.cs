using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Fighting
{
    internal class Fight
    {
        public void Fighting(int monsterDmg, int monsterHP ,float monsterSpeed)
        {
            int heroDmg = Program.hero.DamageOut();

            while (Program.hero.CurrentHealth()  > 0 && monsterHP > 0)
            {
                float heroSpeed = Program.hero.ActionSpeedOut();
                float MobSpeed = monsterSpeed;

                while (heroSpeed > 0 && MobSpeed > 0)
                {
                    if (heroSpeed > MobSpeed)
                    {
                        while (heroSpeed > MobSpeed)
                        {
                            MobSpeed -= heroSpeed;
                        }

                    }
                    else
                    {
                        while (MobSpeed > heroSpeed)
                        {
                            heroSpeed -= MobSpeed;
                        }

                    }

                }

            }

        }

    }

}
