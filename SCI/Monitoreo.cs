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

            int anchoID = 5;
            int anchoTipo = 15;
            int anchoUbicacion = 20;
            int anchoTemperatura = 15;
            int anchoEstado = 10;

            int[] activos = new int[ids.Length];

            while (alertas == 0)
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

                Thread.Sleep(1000);
                Console.WriteLine();
            }

            Console.WriteLine("\nMonitoreo completado.");
            Console.WriteLine($"Total de alertas: {alertas}");
            Console.WriteLine();

            for (int i = 0; i < activos.Length; i++)
            {                
                if (activos[i] != -1)
                {
                    Console.WriteLine("[ALERTA] Activando alarmas...");
                    Console.WriteLine($"- Sensor ID: {ids[activos[i]]}, Tipo: {tipos[activos[i]]}, Ubicación: {ubicaciones[activos[i]]}");
                }
            }

            for (int i = 0; i < 10; i++)
            {
                Console.Beep(2000, 300);
                Thread.Sleep(150);
            }
        }
    }
}
