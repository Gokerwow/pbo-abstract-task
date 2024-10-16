using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUGAS_PBO_PRAK_REV.Classes
{
    public abstract class Robot
    {
        public string nama;
        public int energi, armor, serangan;
        public int ShieldStrength { get; set; } = 0;
        public List<ISkill> skills = new List<ISkill>();

        public virtual void Serang(BosRobot target, int TotalDamage)
        {
        }
        public virtual void Serang(Robot target, int TotalDamage)
        {
        }

        public virtual void gunakanKemampuan(string kemampuan)
        {
        }

        public virtual void diserang(BosRobot penyerang, int totalDamage)
        {
            if (ShieldStrength > 0)
            {
                ShieldStrength--;
                Console.WriteLine($"{nama} diserang! Shield menyerap damage. Sisa Shield: {ShieldStrength}");
                return; 
            }

            if (armor > 0)
            {
                this.armor -= totalDamage;
                if (this.armor < 0)
                {
                    int excessDamage = Math.Abs(this.armor);
                    this.armor = 0;
                    this.energi -= excessDamage;
                }
                Console.WriteLine($"Bos Robot sedang diserang oleh {penyerang}! Armor tersisa {armor}. Energi yang tersisa adalah {this.energi}");
            }
            else
            {
                this.energi -= totalDamage;
                Console.WriteLine($"Bos Robot sedang diserang oleh {penyerang}! Energi yang tersisa adalah {this.energi}");
            }
        }

        public void KurangiCooldown()
        {
            foreach (var skill in skills)
            {
                if (skill.CooldownRemaining > 0)
                    skill.CooldownRemaining--;
            }
        }

        public abstract void mati();
        public abstract void cetakInformasi();
    }
}
