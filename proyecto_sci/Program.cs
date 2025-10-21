using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace proyecto_sci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            int sensores = 6;

            do
            {
                Console.WriteLine("\n### SCI - Sistema contra incendios ###");
                Console.WriteLine("----------");
                Console.WriteLine("|        |");
                Console.WriteLine("|        |");
                Console.WriteLine("|        |");
                Console.WriteLine("----------");
                Console.WriteLine("|        |");
                Console.WriteLine("|        |");
                Console.WriteLine("|        |");
                Console.WriteLine("----------");
                Console.WriteLine("|        |");
                Console.WriteLine("|        |");
                Console.WriteLine("|        |");
                Console.WriteLine("----------");
                Console.WriteLine("[1] Monitorear");
                Console.WriteLine("[2] Revisar Sensores");
                Console.WriteLine("[5] Salir");

                Console.Write("Seleccione una opcion: ");
                opcion = int.Parse(Console.ReadLine());
                Menu(opcion, sensores);

            } while (opcion != 5);
        }

        static void Menu(int opcion, int sensores)
        {
            switch (opcion)
            {
                case 1:
                    Monitorear(sensores);
                    break;
                case 2:
                    RevisarSensores();
                    break;
                case 5:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }

        static void Monitorear(int sensores)
        {
            Console.Clear();
            Console.WriteLine("\nMonitoreando...");

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 10; i++)
            {
                Console.Write("=");
                Thread.Sleep(100);
            }
            Console.ResetColor();
            Console.WriteLine();

            Random rand = new Random();

            for (int  i = 1;  i <= sensores;  i++)
            {
                int sensor = rand.Next(0, 150);

                if (sensor > 50)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Sensor {i}: Temperatura: {sensor}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"Sensor {i}: Temperatura: {sensor}");
                }
            }

            Console.WriteLine("\nMonitoreo completado.");
        }

        static void RevisarSensores()
        {
            int sensores = 6;

            Console.Clear();
            Console.WriteLine("Revisando sensores...");
            Console.WriteLine($"Cantidad de sensores: {sensores}");
        }
    }
}