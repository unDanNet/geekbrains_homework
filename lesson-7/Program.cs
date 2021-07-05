using System;

namespace lesson_7
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var successfulInput = false;
            
            uint m = 0;
            uint n = 0;
            
            while(!successfulInput)
            {
                Console.Clear();
                Console.WriteLine("Введите размер поля M x N (M > 0, N > 0): ");
                
                Console.Write("M:");
                var strM = Console.ReadLine();
                
                Console.Write("N:");
                var strN = Console.ReadLine();

                if (string.IsNullOrEmpty(strM) || string.IsNullOrEmpty(strN))
                    continue;

                successfulInput = uint.TryParse(strM, out m) && uint.TryParse(strN, out n);
            }
            
            Console.WriteLine();

            try
            {
                var result = FindAmountOfWaysRecursive(m, n);
                Console.Write($"Количество путей: {result.ToString()}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.ReadLine();
        }

        /// <summary>
        /// Calculate amount of ways in the rectangle using recursive function.
        /// </summary>
        /// <param name="m">Width of the rectangle.</param>
        /// <param name="n">Height of the rectangle.</param>
        /// <exception cref="ArgumentException">if any argument equals zero.</exception>
        public static int FindAmountOfWaysRecursive(uint m, uint n)
        {
            if (m == 0 || n == 0)
                throw new ArgumentException("Size of the rectangle must be positive.");

            if (m == 1 || n == 1)
                return 1;

            if (m == 2 && n == 2)
                return 2;

            return FindAmountOfWaysRecursive(m - 1, n) + FindAmountOfWaysRecursive(m, n - 1);
        }

        /// <summary>
        /// Calculate amount of ways in the rectangle using combinatorics equation.
        /// </summary>
        /// <param name="m">Width of the rectangle.</param>
        /// <param name="n">Height of the rectangle.</param>
        /// <exception cref="ArgumentException">if any argument equals zero.</exception>
        public static ulong FindAmountOfWays(uint m, uint n)
        {
            if (m == 0 || n == 0)
                throw new ArgumentException("Size of the rectangle must be positive.");

            if (m == 1 || n == 1)
                return 1;

            if (m == 2 && n == 2)
                return 2;

            return Factorial(m-1 + n-1) / (Factorial(m-1) * Factorial(n-1));
        }
        
        private static ulong Factorial(uint n)
        {
            ulong factorial = 1;
            
            for (uint i = 1; i <= n; i++)
                factorial *= i;

            return factorial;
        }
    }
}