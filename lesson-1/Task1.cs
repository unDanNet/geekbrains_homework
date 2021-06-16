using System;

namespace lesson_1
{
    public static class Task1
    {
        /// <summary>
        /// Determine whether the specified number is a prime number.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <returns>Value indicating whether the number is prime.</returns>
        /// <exception cref="ArgumentException">if specified number is negative.</exception>
        private static bool IsPrimeNumber(long number)
        {
            if (number < 0)
                throw new ArgumentException("Number must be non-negative.");
            
            
            long d = 0;
            long i = 2;

            while (i < number)
            {
                if (number % i == 0)
                    d++;

                i++;
            }

            return d == 0;
        }
        
        public class TestCase
        {
            public long Number { get; set; }
            public bool Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }
        
        public static void Test(TestCase testCase)
        {
            try
            {
                var actual = IsPrimeNumber(testCase.Number);

                if (actual == testCase.Expected)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch(Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }

        }
    }
}