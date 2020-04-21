using System;

namespace Classactivity
{
    class Program
    {
       
        static void Main(string[] args)
        {
            int[,] Matriz = new int[5, 5];
            Matriz = llenar(5, 5);
            Console.WriteLine("Matriz:");
            Mostrar(Matriz);
            Console.WriteLine("");
            Console.WriteLine("Pulse la tecla Enter para continuar");
            Console.ReadLine();
            Console.WriteLine("El mayor numero de la matriz es " + mayor(Matriz));
            Console.ReadLine();
            Console.WriteLine("El promedio de numeros de la matriz es = " + promedio(Matriz));
            Console.ReadLine();
            Console.WriteLine("La suma de datos por fila es la siguiente: ");
            mostrarVectorAcumulado(acumuladoFilas(Matriz));
            Console.ReadLine();
            
        }

        static int[,] llenar(int f, int c)
        {
            Random r = new Random();
            int[,] M = new int[f, c];
            for (int i = 0; i < f; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    M[i, j] = r.Next(10, 100);
                }
            }
            return M;
        }
        static void Mostrar(int[,] M)
        {
            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                {
                    Console.Write(M[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static int mayor(int[,] M)
        {
            int m = M[0, 0];
            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                {
                    if (M[i, j] > m)
                    {
                        m = M[i, j];
                    }
                }
            }
            return m;
        }

        static double promedio(int[,] M)
        {
            int suma = 0;
            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                {
                    suma += M[i, j];
                }
            }
            return suma / (M.GetLength(0) * M.GetLength(1));

        }

        static int[] acumuladoFilas(int[,] M)
        {
            int suma = 0;
            int[] vec = new int[M.GetLength(0)];

            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                {
                    suma += M[i, j];
                    
                }
                vec[i] = suma;
                suma = 0;
            }
            return vec;
        }

        static void mostrarVectorAcumulado(int[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                Console.Write("Fila " + (i+1) + ": " + vector[i] + "\n");
            }
            
        }
    }
}

