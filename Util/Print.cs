using System;
using static System.Console;

namespace CoreEscuela
{
    public static class Printer{

        public static void DrawLine(int tam = 10)
        {
            WriteLine("".PadLeft(tam,'='));
        }
        public static void PresioneEnter()
        {
            WriteLine("Presione enter para continuar");
        }
         public static void writeTitle(string titulo)
        {
            var tamaño = titulo.Length + 4;
            DrawLine(tamaño);
            WriteLine($"| {titulo} |");
            DrawLine(tamaño);
        }
        public static void Beep(int hz = 2000, int tiempo= 30, int cantidad =1  )
        {
            while(cantidad-- >0)
            {
                Console.Beep(hz,tiempo);
            }

        }

    }
}