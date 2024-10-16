using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TUGAS_PBO_PRAK_REV.Classes
{
    public class SuperShield : ISkill
    {
        public int Cooldown { get; } = 4;
        public int CooldownRemaining { get; set; } = 0;

        public void Gunakan(Robot target)
        {
            if (CooldownRemaining > 0)
            {
                Console.WriteLine($"Super Shield sedang cooldown! {CooldownRemaining} giliran tersisa.");
                return;
            }

            target.ShieldStrength = 2; 
            CooldownRemaining = Cooldown;
            Console.WriteLine($"{target.nama} menggunakan Super Shield! Shield aktif dengan {target.ShieldStrength} serangan tersisa.");
        }

        public void Gunakan(BosRobot target)
        {
        }
    }

}
