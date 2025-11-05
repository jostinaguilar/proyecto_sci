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
                    ActivarSensor(ids, tipos, ubicaciones, estados);
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

            for (int i = 0; i < ids.Length; i++)
            {

                if (ids[i] == id)
                {
                    Console.WriteLine($"Sensor: ID={ids[i]} Tipo={tipos[i]} Ubicación={ubicaciones[i]}");
                }

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