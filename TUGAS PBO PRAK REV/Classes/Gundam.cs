using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUGAS_PBO_PRAK_REV.Classes
{
    public class Gundam : Robot
    {
        public Gundam(string nama, int energi, int armor, int serangan)
        {
            this.serangan = serangan;
            this.energi = energi;
            this.nama = nama;
            this.armor = armor;

            skills.Add(new PlasmaCannon());
            skills.Add(new Repair());
        }

        public override string ToString()
        {
            return nama;
        }

        public override void Serang(BosRobot target, int totaldamage)
        {
            Console.WriteLine($"Gundam menyerang {target} sebanyak {totaldamage}");
            target.diserang(this, totaldamage);
            target.mati();
        }

        public override void diserang(BosRobot penyerang, int totalDamage)
        {
            int damageMasuk = totalDamage - armor;
            if (damageMasuk > 0)
            {
                this.armor -= totalDamage;
                Console.WriteLine($"Gundam sedang diserang oleh {penyerang.nama}! Armor menahan damage dari serangan! Armor tersisa {armor}. Energi yang tersisa adalah {this.energi}");
            }
            else
            {
                this.energi -= totalDamage;
                Console.WriteLine($"Gundam sedang diserang oleh {penyerang.nama}! Energi yang tersisa adalah {this.energi}");
            }
        }


        public override void mati()
        {
            if (this.energi <= 0)
            { Console.WriteLine("Gundam sudah mati"); }
            else
            {
                Console.WriteLine($"Gundam memiliki {energi} tersisa");
            }
        }

        public override void cetakInformasi()
        {
            Console.WriteLine($"Nama Gundam = {nama}\nEnergi = {energi}\nArmor = {armor}");
        }
    }
}
