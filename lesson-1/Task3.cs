using System;

namespace lesson_1
{
    public class Task3
    {
        /// <summary>
        /// Recursively calculate the number with specified order number of fibonacci sequence.
        /// </summary>
        /// <param name="number">The order number of the required number.</param>
        /// <returns>The fibonacci number.</returns>
        /// <exception cref="ArgumentException">if order number is negative</exception>
        private static long FibonacciRecursive(int number)
        {
            if (number < 0)
                throw new ArgumentException("Order number must be non-negative.");
            
            if (number < 2)
                return number;

            return FibonacciRecursive(number - 2) + FibonacciRecursive(number - 1);
        }

        /// <summary>
        /// Calculate the number with specified order number of fibonacci sequence using loop.
        /// </summary>
        /// <param name="number">The order number of the required number.</param>
        /// <returns>The fibonacci number.</returns>
        /// <exception cref="ArgumentException">if order number is negative</exception>
        private static long Fibonacci(int number)
        {
            if (number < 0)
                throw new ArgumentException("Order number must be non-negative.");
            
            if (number < 2)
                return number;

            long f_0 = 0;
            long f_1 = 1;
            long f_n = 1;

            for (var i = 2; i <= number; i++)
            {
                f_n = f_0 + f_1;
                f_0 = f_1;
                f_1 = f_n;
            }

            return f_n;
        }
        
        
        public class TestCase
        {
            public int OrderNumber { get; set; }
            public long Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }
        
        public static void TestRecursive(TestCase testCase)
        {
            try
            {
                var actual = FibonacciRecursive(testCase.OrderNumber);

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
        
        
        public static void TestLoop(TestCase testCase)
        {
            try
            {
                var actual = Fibonacci(testCase.OrderNumber);

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