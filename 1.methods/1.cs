using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static int[,] FillArray(int[,] arr, int n)
        {
            int num = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = num++;
                }
            }
            return arr;
        }

        public static int[,] ChangeArray(int[,] arr, int n)
        {
            int j = 0;
            for (int i = 0; i < n/ 2; i++)
            {
                int tempArrayElemet = arr[i, j];
                arr[i, j] = arr[n - 1 - i, n - 1- j];
                arr[n - 1 - i, n - 1 - j] = tempArrayElemet;
                j++;
            }

            j = 0;
            for (int i = 0; i < n / 2; i++)
            {
                int tempArrayElemet = arr[i, n - 1 - j];
                arr[i, n - 1 - j] = arr[n - 1 - i, j];
                arr[n - 1 - i, j] = tempArrayElemet;
                j++;
            }
            return arr;
        }

        public static void DisplayArray(int[,] arr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i,j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Input n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[,] arr = new int[n,n];
            FillArray(arr, n);
            DisplayArray(arr, n);
            Console.WriteLine("before change");
            ChangeArray(arr, n);
            Console.WriteLine("after change");
            DisplayArray(arr, n);
        }
    }
}
