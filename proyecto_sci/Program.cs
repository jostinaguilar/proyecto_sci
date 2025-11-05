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
                    monitoreo.Inicializar(ids, tipos, ubicaciones, estados);
                    break;
                case 2:
                    ActivarSensor(ids, tipos, ubicaciones, estados);
                    break;
                case 3:
                    ApagarSensores();
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }

        static void ActivarSensor(int[] ids, string[] tipos, string[] ubicaciones, int[] estados)
        {
            //Console.Clear();
            //Console.WriteLine("Revisando sensores...");
            //Console.WriteLine($"Cantidad de sensores: {sensores}");
            //Console.Write("Ingrese el número del sensor a activar (1-" + sensores + "): ");
            //int sensorSeleccionado = int.Parse(Console.ReadLine());
            //Console.WriteLine($"Activando sensor {sensorSeleccionado}...");
            //Thread.Sleep(500);
            //Console.WriteLine($"Sensor {sensorSeleccionado} ha sido activado.");
            //Console.WriteLine();
        }

        static void ApagarSensores()
        {
            Console.Clear();
            Console.WriteLine("Apagando todos los sensores...");
            Thread.Sleep(500);
            Console.WriteLine("Todos los sensores han sido apagados.");
            Console.WriteLine();
        }
    }
}