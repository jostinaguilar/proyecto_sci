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
        public void Inicializar(int sensores)
        {
            Console.Clear();
            Console.WriteLine("Escaneando sensores...");

            Lib lib = new Lib();
            lib.BarraProgreso();

            Random rand = new Random();
            int alertas = 0;

            for (int i = 1; i <= sensores; i++)
            {
                int sensor = rand.Next(0, 150);

                if (sensor > 57)
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
    }
}
