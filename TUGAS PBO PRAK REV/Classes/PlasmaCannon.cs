using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUGAS_PBO_PRAK_REV.Classes
{
    public class PlasmaCannon : ISkill
    {
        public int Cooldown { get; } = 2;
        public int CooldownRemaining { get; set; } = 0;

        public void Gunakan(Robot target)
        {
        }

        public void Gunakan(BosRobot target)
        {
            if (CooldownRemaining > 0)
            {
                Console.WriteLine($"Plasma Cannon sedang cooldown! {CooldownRemaining} giliran tersisa.");
                return;
            }

            int damage = 50;
            target.energi -= damage;
            CooldownRemaining = Cooldown;
            Console.WriteLine($"{target.nama} terkena Serangan Plasma! Energi tersisa {target.energi}");
        }
    }
}

