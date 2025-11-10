using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SCI;

namespace proyecto_sci
{
    internal class Program
    {
        static Monitoreo monitoreo = new Monitoreo();
        static int apagado = 1;
        static void Main(string[] args)
        {
            int opcion;
            Sensores sensores = new Sensores();

            int[] idsSensores = sensores.IdsSensores();
            string[] tiposSensores = sensores.TiposSensores();
            string[] ubicacionesSensores = sensores.UbicacionesSensores();
            int[] estadosSensores = sensores.EstadosSensores();

            monitoreo.Inicializar(idsSensores, tiposSensores, ubicacionesSensores, estadosSensores);

            do
            {
                Console.WriteLine("------ Panel de Control ------");
                Console.WriteLine("[1] Monitorear sensores");
                Console.WriteLine("[2] Activar sensor manualmente");
                Console.WriteLine("[3] Apagar todos los sensores");
                Console.WriteLine("[4] Encender todos los sensores");
                Console.WriteLine("[0] Apagar Sistema (Salir)");
                Console.WriteLine("------------------------------");
                Console.Write("» Seleccione una opcion: ");
                opcion = int.Parse(Console.ReadLine());
                Menu(opcion, idsSensores, tiposSensores, ubicacionesSensores, estadosSensores);

            } while (opcion != 0);
        }

        static void Menu(int opcion, int[] ids, string[] tipos, string[] ubicaciones, int[] estados)
        {
            switch (opcion)
            {
                case 0:
                    Console.WriteLine("Saliendo...");
                    break;
                case 1:
                    if (apagado == 0)
                    {
                        Console.WriteLine("Sensores apagados, no puede monitorear. Enciendalos primero");
                    }
                    else
                    {
                        monitoreo.Inicializar(ids, tipos, ubicaciones, estados);
                    }
                    break;
                case 2:
                    if (apagado == 0)
                    {
                        Console.WriteLine("Sensores apagados. Enciendalos primero");
                    }
                    else
                    {
                        ActivarSensor(ids, tipos, ubicaciones, estados);
                    }
                    break;
                case 3:
                    ApagarSensores();
                    break;
                case 4:
                    EncenderSensores();
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }

        static void ActivarSensor(int[] ids, string[] tipos, string[] ubicaciones, int[] estados)
        {
            Console.Clear();
            Console.Write("Ingrese el ID del sensor a activar: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine($"Buscando sensor: ID {id}");

            int pos = -1;

            for (int i = 0; i < ids.Length; i++)
            {

                if (ids[i] == id && tipos[i] == "Manual")
                {
                    pos = i;
                }


            }

            if (pos != -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡Alarma Activada!");
                Console.WriteLine("Emitiendo alerta a la central...");
                Console.ResetColor();
                Console.WriteLine($"Sensor: ID={ids[pos]} Tipo={tipos[pos]} Ubicación={ubicaciones[pos]}");

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
            else
            {
                Console.WriteLine("Sensor no encontrado o no es un sensor manual.");
            }
        }

        static void ApagarSensores()
        {
            Console.Clear();
            Console.WriteLine("Apagando todos los sensores...");
            Thread.Sleep(500);
            Console.WriteLine("Todos los sensores han sido apagados.");
            apagado = 0;
            Console.WriteLine();
        }

        static void EncenderSensores()
        {
            Console.Clear();
            Console.WriteLine("Encendiendo todos los sensores...");
            Thread.Sleep(500);
            Console.WriteLine("Todos los sensores han sido encendidos.");
            apagado = 1;
            Console.WriteLine();
        }
    }
}