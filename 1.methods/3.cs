using System;

namespace ConsoleApp1
{
    class Program
    {
        public static bool CompareArrays(int[] a, int[] b)
        {
            if (a == null || b == null) { return false; }
            if (a.Length == 0 && b.Length == 0) { return true; }
            if (a.Length != b.Length) { return false; }
            Array.Sort(a);
            Array.Sort(b);
            for (int i = 0; i < a.Length; i++)
            {
                int square = a[i] * a[i];
                if (square != b[i]) return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            int[] a = { 121, 144, 19, 161, 19, 144, 19, 11 };
            int[] b = { 121, 14641, 20736, 361, 25921, 361, 20736, 361 };
            Console.WriteLine(CompareArrays(a, b));
        }
    }
}
