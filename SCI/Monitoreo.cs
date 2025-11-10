using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SCI
{
    public class Monitoreo
    {
        public void Inicializar(int[] ids, string[] tipos, string[] ubicaciones, int[] estados)
        {
            Console.WriteLine("Monitoreando sensores...\n");

            Random rand = new Random();
            int alertas = 0;
            int simulacion = 0;

            int anchoID = 5;
            int anchoTipo = 15;
            int anchoUbicacion = 20;
            int anchoTemperatura = 15;
            int anchoEstado = 10;

            int[] activos = new int[ids.Length];

            for (int i = 0; i < estados.Length; i++)
            {
                estados[i] = 0;
            }

            while (alertas == 0)
            {
                simulacion++;

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("###### FIRE GUARD - SCI ######");
                Console.ResetColor();

                if (simulacion > 3)
                {
                    Console.WriteLine("ID".PadRight(anchoID) +
                                  "Tipo".PadRight(anchoTipo) +
                                  "Ubicación".PadRight(anchoUbicacion) +
                                  "Porcentaje".PadRight(anchoTemperatura) +
                                  "Estado".PadRight(anchoEstado));

                    for (int i = 0; i < ids.Length; i++)
                    {
                        int temperatura = rand.Next(0, 100);
                        double humo = Math.Round(rand.NextDouble() * 5, 2);

                        if (tipos[i] == "Temperatura" && temperatura > 57)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(ids[i].ToString().PadRight(anchoID));
                            Console.Write(tipos[i].PadRight(anchoTipo));
                            Console.Write(ubicaciones[i].PadRight(anchoUbicacion));
                            Console.Write($"{temperatura}°C".PadRight(anchoTemperatura));
                            estados[i] = 1;
                            Console.Write(estados[i].ToString().PadRight(anchoEstado));
                            Console.ResetColor();
                            Console.WriteLine();
                            activos[i] = i;
                            alertas++;
                        }
                        else if (tipos[i] == "Humo" && humo > 2.5)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(ids[i].ToString().PadRight(anchoID));
                            Console.Write(tipos[i].PadRight(anchoTipo));
                            Console.Write(ubicaciones[i].PadRight(anchoUbicacion));
                            Console.Write($"{humo}%".PadRight(anchoTemperatura));
                            estados[i] = 1;
                            Console.Write(estados[i].ToString().PadRight(anchoEstado));
                            Console.ResetColor();
                            Console.WriteLine();
                            activos[i] = i;
                            alertas++;
                        }
                        else
                        {
                            Console.Write(ids[i].ToString().PadRight(anchoID));
                            Console.Write(tipos[i].PadRight(anchoTipo));
                            Console.Write(ubicaciones[i].PadRight(anchoUbicacion));
                            if (tipos[i] == "Humo")
                            {
                                Console.Write($"{humo}%".PadRight(anchoTemperatura));
                            }
                            else if (tipos[i] == "Temperatura")
                            {
                                Console.Write($"{temperatura}°C".PadRight(anchoTemperatura));
                            }
                            else
                            {
                                Console.Write("-".PadRight(anchoTemperatura));
                            }

                            activos[i] = -1;
                            Console.Write(estados[i].ToString().PadRight(anchoEstado));
                            Console.WriteLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("ID".PadRight(anchoID) +
                                  "Tipo".PadRight(anchoTipo) +
                                  "Ubicación".PadRight(anchoUbicacion) +
                                  "Porcentaje".PadRight(anchoTemperatura) +
                                  "Estado".PadRight(anchoEstado));

                    for (int i = 0; i < ids.Length; i++)
                    {
                        int temperatura = rand.Next(0, 50);
                        double humo = Math.Round(rand.NextDouble() * 2, 2);

                        Console.Write(ids[i].ToString().PadRight(anchoID));
                        Console.Write(tipos[i].PadRight(anchoTipo));
                        Console.Write(ubicaciones[i].PadRight(anchoUbicacion));
                        if (tipos[i] == "Humo")
                        {
                            Console.Write($"{humo}%".PadRight(anchoTemperatura));
                        }
                        else if (tipos[i] == "Temperatura")
                        {
                            Console.Write($"{temperatura}°C".PadRight(anchoTemperatura));
                        }
                        else
                        {
                            Console.Write("-".PadRight(anchoTemperatura));
                        }
                        activos[i] = -1;
                        Console.Write(estados[i].ToString().PadRight(anchoEstado));
                        Console.WriteLine();
                    }
                }

                if (alertas == 0)
                {
                    Thread.Sleep(2000);
                    Console.WriteLine();
                }
            }

            Console.WriteLine("\nMonitoreo completado.");
            Console.WriteLine($"Total de alertas: {alertas}");
            Console.WriteLine();

            for (int i = 0; i < activos.Length; i++)
            {
                if (activos[i] != -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[ALERTA] Activando alarmas...");
                    Console.ResetColor();
                    Console.WriteLine($"- Sensor ID: {ids[activos[i]]}, Tipo: {tipos[activos[i]]}, Ubicación: {ubicaciones[activos[i]]}");
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Emitiendo alerta a la central...");
            Console.ResetColor();

            bool start = true;

            Thread beap = new Thread(() =>
            {
                while (start)
                {
                    Console.Beep(2000, 300);
                    Thread.Sleep(150);
                }
            });

            beap.Start();

            int apagar = 1;

            while (apagar != 0)
            {
                Console.Write("[0] Apagar alarmas: ");
                apagar = int.Parse(Console.ReadLine());
            }

            start = false;
            beap.Join();
        }
    }
}
