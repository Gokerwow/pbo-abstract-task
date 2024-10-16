using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUGAS_PBO_PRAK_REV.Classes
{
    public class Repair : ISkill
    {
        public int Cooldown { get; } = 3; 
        public int CooldownRemaining { get; set; } = 0;

        public Repair()
        {
            CooldownRemaining = 0;
        }

        public void Gunakan(Robot target)
        {
            if (CooldownRemaining == 0)
            {
                target.energi += 20; 
                Console.WriteLine($"{target.nama} menggunakan Repair dan memulihkan 20 energi.");
                CooldownRemaining = 3;
            }
            else
            {
                Console.WriteLine("Skill sedang cooldown!");
            }
        }

        public void Gunakan(BosRobot target)
        {
        }
    }
}
