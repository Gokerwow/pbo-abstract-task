using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUGAS_PBO_PRAK_REV.Classes
{
    public class BosRobot : Robot
    {
        public int pertahanan;
        public int TurnsStunned { get; set; } = 0;

        public BosRobot(string nama, int energi, int pertahanan)
        {
            this.pertahanan = pertahanan;
            this.energi = energi;
            this.nama = nama;
        }

        public void KurangiStun()
        {
            if (TurnsStunned > 0)
            {
                TurnsStunned--;
            }
        }

        public override string ToString()
        {
            return nama;
        }

        public void diserang(Robot penyerang, int TotalDamage)
        {
            if (pertahanan > 0)
            {
                this.pertahanan -= TotalDamage;
                Console.WriteLine($"Bos Robot sedang diserang oleh {penyerang}! Armor menhan damage dari serangan! Armor terisisa {pertahanan} Energi yang tersisa adalah {this.energi}");
            }
            else
            {
                this.energi -= TotalDamage;
                Console.WriteLine($"Bos Robot sedang diserang oleh {penyerang}! Energi yang tersisa adalah {this.energi}");
            }
        }

        public override void mati()
        {
            if (this.energi <= 0)
            { Console.WriteLine("Bos sudah mati"); }
            else
            {
                Console.WriteLine($"Bos Robot memiliki {energi}");
            }
        }

        public override void Serang(Robot target, int totalDamage)
        {
            Console.WriteLine($"{nama} menyerang {target.nama} sebanyak {totalDamage}.");
            target.diserang(this, totalDamage);
            target.mati();
        }

        public override void cetakInformasi()
        {
            Console.WriteLine($"Nama Bos = {nama}\nEnergi Bos = {energi}\nSisa Pertahanan = {pertahanan}");
        }
    }
}
