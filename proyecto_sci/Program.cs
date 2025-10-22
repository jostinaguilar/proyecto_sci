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
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("###### FIRE GUARD - SCI ######");
                Console.ResetColor();
                Console.WriteLine("------ Panel de Control ------");
                Console.WriteLine("[1] Monitorear sensores");
                Console.WriteLine("[2] Activar sensor manualmente");
                Console.WriteLine("[3] Apagar todos los sensores");
                Console.WriteLine("[0] Apagar Sistema (Salir)");
                Console.WriteLine("------------------------------");
                Console.Write("» Seleccione una opcion: ");
                opcion = int.Parse(Console.ReadLine());
                Menu(opcion, sensores);

            } while (opcion != 0);
        }

        static void Menu(int opcion, int sensores)
        {
            switch (opcion)
            {
                case 0:
                    Console.WriteLine("Saliendo...");
                    break;
                case 1:
                    Monitorear(sensores);
                    break;
                case 2:
                    ActivarSensor(sensores);
                    break;
                case 3:
                    ApagarSensores();
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }

        static void Monitorear(int sensores)
        {
            Console.Clear();
            Console.WriteLine("Escaneando sensores...");

            BarraProgreso();

            Random rand = new Random();
            int alertas = 0;

            for (int i = 1; i <= sensores; i++)
            {
                int sensor = rand.Next(0, 150);

                if (sensor > 50)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Sensor {i}: Temperatura: {sensor}");
                    Console.ResetColor();
                    alertas++;
                }
                else
                {
                    Console.WriteLine($"Sensor {i}: Temperatura: {sensor}");
                }
            }

            Console.WriteLine("Monitoreo completado.");
            Console.WriteLine($"Total de alertas: {alertas}");
            Console.WriteLine();
        }

        static void ActivarSensor(int sensores)
        {
            Console.Clear();
            Console.WriteLine("Revisando sensores...");
            Console.WriteLine($"Cantidad de sensores: {sensores}");
            Console.Write("Ingrese el número del sensor a activar (1-" + sensores + "): ");
            int sensorSeleccionado = int.Parse(Console.ReadLine());
            Console.WriteLine($"Activando sensor {sensorSeleccionado}...");
            Thread.Sleep(500);
            Console.WriteLine($"Sensor {sensorSeleccionado} ha sido activado.");
            Console.WriteLine();
        }

        static void ApagarSensores()
        {
            Console.Clear();
            Console.WriteLine("Apagando todos los sensores...");
            Thread.Sleep(500);
            Console.WriteLine("Todos los sensores han sido apagados.");
            Console.WriteLine();
        }

        static void BarraProgreso()
        {
            int porcentaje = 0;
            int filaBarra = Console.CursorTop;
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[                    ]");
            for (int i = 1; i <= 20; i++)
            {
                porcentaje += 5;
                Console.SetCursorPosition(i, filaBarra);
                Console.Write("■");
                Console.SetCursorPosition(23, filaBarra);
                Console.Write($"{porcentaje}%");
                Thread.Sleep(200);
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.CursorVisible = true;
        }
    }
}