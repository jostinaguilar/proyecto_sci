using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SCI
{
    public class Lib
    {
        public void BarraProgreso()
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
