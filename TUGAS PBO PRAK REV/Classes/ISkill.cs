using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUGAS_PBO_PRAK_REV.Classes
{
    public interface ISkill
    {
        void Gunakan(Robot target);
        void Gunakan(BosRobot target);
        int Cooldown { get; }
        int CooldownRemaining { get; set; }
    }
}
