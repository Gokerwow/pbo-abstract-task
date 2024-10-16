using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUGAS_PBO_PRAK_REV.Classes
{
    public class ElectricShock : ISkill
    {
        public int Cooldown { get; } = 3; 
        public int CooldownRemaining { get; set; } = 0;

        public void Gunakan(Robot target)
        {

        }

        public void Gunakan(BosRobot target)
        {
            if (CooldownRemaining > 0)
            {
                Console.WriteLine($"Electric Shock sedang cooldown! {CooldownRemaining} giliran tersisa.");
                return;
            }
            else
            {
                target.TurnsStunned = 1; 
                Console.WriteLine($"{target.nama} terkena stun oleh Electric Shock selama 1 turn!");
            }

            CooldownRemaining = Cooldown; 
        }
    }
}
