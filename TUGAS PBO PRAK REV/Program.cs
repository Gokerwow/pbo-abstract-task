using System;
using TUGAS_PBO_PRAK_REV.Classes;

namespace Main
{
    public class Game
    {
        public static void Main(string[] args)
        {
            BosRobot bos = new BosRobot("Boss", 100, 150);
            Gundam gundam = new Gundam("Gundam", 100, 50, 25);
            Rin rin = new Rin("Rin", 170, 20, 50);

            List<Robot> robots = new List<Robot> { gundam, rin };

            int turn = 1;
            Random random = new Random(); 
            while (bos.energi > 0 && robots.TrueForAll(robot => robot != null && robot.energi > 0))
            {
                Console.WriteLine($"\n=== Turn {turn} ===");

                foreach (var robot in robots)
                {
                    if (robot != null && robot.energi > 0) 
                    {
                        robot.KurangiCooldown();

                        Console.WriteLine($"\n{robot.nama}, pilih skill yang ingin digunakan:");
                        for (int i = 0; i < robot.skills.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {robot.skills[i].GetType().Name} (Cooldown: {robot.skills[i].CooldownRemaining})");
                        }
                        Console.WriteLine($"{robot.skills.Count + 1}. Serangan Biasa");

                        Console.Write("Masukkan nomor skill yang ingin digunakan: ");
                        if (int.TryParse(Console.ReadLine(), out int pilihan) && pilihan >= 1 && pilihan <= robot.skills.Count + 1)
                        {
                            if (pilihan == robot.skills.Count + 1) 
                            {
                                robot.Serang(bos, robot.serangan); 
                            }
                            else
                            {
                                ISkill skillDipilih = robot.skills[pilihan - 1];
                                if (skillDipilih.CooldownRemaining == 0)
                                {
                                    if (skillDipilih is PlasmaCannon)
                                    {
                                        skillDipilih.Gunakan(bos); 
                                    }
                                    else if (skillDipilih is ElectricShock)
                                    {
                                        skillDipilih.Gunakan(bos); 
                                    }
                                    else
                                    {
                                        skillDipilih.Gunakan(robot); 
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Skill sedang cooldown!");
                                }
                            }

                            if (bos.energi <= 0)
                            {
                                Console.WriteLine("Game Selesai! Bos Robot telah mati!");
                                return; 
                            }
                        }
                        else
                        {
                            Console.WriteLine("Pilihan tidak valid!");
                        }
                    }
                }

                if (bos.energi > 0)
                {
                    if (bos.TurnsStunned > 0)
                    {
                        Console.WriteLine($"{bos.nama} ter-stun dan tidak dapat menyerang! {bos.TurnsStunned} giliran tersisa.");
                        bos.KurangiStun(); 
                    }
                    else
                    {
                        List<Robot> aliveRobots = robots.FindAll(robot => robot != null && robot.energi > 0);
                        if (aliveRobots.Count > 0)
                        {
                            int randomIndex = random.Next(aliveRobots.Count);
                            Robot targetRobot = aliveRobots[randomIndex];

                            bos.Serang(targetRobot, bos.serangan);
                        }
                    }
                }

                if (bos.energi <= 0)
                {
                    Console.WriteLine("Game Selesai! Bos Robot telah mati!");
                    break;
                }
                turn++;
            }
        }
    }
}