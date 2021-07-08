using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba
{
    class Program
    {
        static bool[,] piedras;
        static bool ganador = false;
        static int fila;
        static int numPiedras;
        static int totalPiedras;
        static void Main(string[] args)
        {
            bool turno = false;
            int ancho, alto;
            Console.WriteLine("Introduce el alto del tablero de juego");
            while (!int.TryParse(Console.ReadLine(), out alto))
            {
                Console.WriteLine("Introduce el alto del tablero de juego");
            }
            Console.WriteLine("Introduce el ancho del tablero de juego");
            while (!int.TryParse(Console.ReadLine(), out ancho))
            {
                Console.WriteLine("Introduce el ancho del tablero de juego");
            }
            piedras = new bool[alto, ancho];
            totalPiedras = alto * ancho;
            do
            {
                if (!turno)
                {
                    Console.WriteLine("Turno del jugador 1");
                    turno = true;
                }
                else
                {
                    Console.WriteLine("Turno del jugador 2");
                    turno = false;
                }
                pintarPiedras();
                do {
                    Console.WriteLine("Introduce numero de fila:");
                    fila = Convert.ToInt32(Console.ReadLine());
                } while (fila > 0 && fila < piedras.GetLength(0) && ComprobarFila(fila));
                Console.WriteLine("Introduce numero de piedras:");
                numPiedras = Convert.ToInt32(Console.ReadLine());
                quitarPiedras();
            } while (!ganador);
            if (turno)
                Console.WriteLine("Jugador 1 ha perdido, felicidades jugador 2!!");
            else
                Console.WriteLine("Jugador 2 ha perdido, felicidades jugador 1!!");
            Console.ReadLine();
        }

        public static void pintarPiedras()
        {
            for (int i = 0; i < piedras.GetLength(0); ++i)
            {
                for (int j = 0; j < piedras.GetLength(1); ++j)
                {
                    if (piedras[i, j] == false)
                        Console.Write("o ");
                    else
                        Console.Write("  ");
                }
                Console.WriteLine();
            }
        }
        public static void quitarPiedras()
        {
            int j = 0;
            Console.WriteLine("Numero de piedras a quitar: "+numPiedras);
            for (int i = 0; j < numPiedras && i < piedras.GetLength(1); ++i)
            {
                if(piedras[fila - 1, i] == false)
                {
                    piedras[fila - 1, i] = true;
                    ++j;
                    --totalPiedras;
                    if (totalPiedras == 0)
                        ganador = true;
                }
            }
        }

        public static bool ComprobarFila(int numFila)
        {
            return piedras[numFila - 1, piedras.GetLength(1) - 1];
        }
    }
}
