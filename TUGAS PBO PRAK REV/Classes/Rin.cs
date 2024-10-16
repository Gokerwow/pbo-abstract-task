using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUGAS_PBO_PRAK_REV.Classes
{
    public class Rin : Robot
    {
        public Rin(string nama, int energi, int armor, int serangan)
        {
            this.serangan = serangan;
            this.energi = energi;
            this.nama = nama;
            this.armor = armor;

            skills.Add(new ElectricShock());
            skills.Add(new SuperShield());
            skills.Add(new Repair());
        }

        public override string ToString()
        {
            return nama;
        }

        public override void Serang(BosRobot target, int totaldamage)
        {
            Console.WriteLine($"Rin menyerang {target} sebanyak {totaldamage}");
            target.diserang(this, totaldamage);
            target.mati();
        }

        public override void diserang(BosRobot penyerang, int totalDamage)
        {
            int damageMasuk = totalDamage - armor;
            if (damageMasuk > 0)
            {
                armor -= totalDamage;
                Console.WriteLine($"Rin sedang diserang oleh {penyerang.nama}! Armor menahan damage dari serangan! Armor tersisa {armor}. Energi yang tersisa adalah {energi}");
            }
            else
            {
                energi -= totalDamage;
                Console.WriteLine($"Rin sedang diserang oleh {penyerang.nama}! Energi yang tersisa adalah {energi}");
            }
        }


        public override void mati()
        {
            if (energi <= 0)
            { Console.WriteLine("Rin sudah mati"); }
            else
            {
                Console.WriteLine($"Rin memiliki {energi} tersisa");
            }
        }

        public override void cetakInformasi()
        {
            Console.WriteLine($"Nama Rin = {nama}\nEnergi = {energi}\nArmor = {armor}");
        }
    }
}
