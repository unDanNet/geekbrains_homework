using System;

namespace lesson_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /* ---- Task 1 test ---- */
            TestTask1();
            
            /* ---- Task 3 test ---- */
            TestTask3();
        }

        private static void TestTask1()
        {
            var testCase1 = new Task1.TestCase {
                Number = 1,
                Expected = true,
                ExpectedException = null
            };

            var testCase2 = new Task1.TestCase {
                Number = 9,
                Expected = false,
                ExpectedException = null
            };
            
            var testCase3 = new Task1.TestCase {
                Number = 19,
                Expected = true,
                ExpectedException = null
            };
            
            var testCase4 = new Task1.TestCase {
                Number = 9835,
                Expected = false,
                ExpectedException = null,
            };

            var testCase5 = new Task1.TestCase {
                Number = -10,
                Expected = true,
                ExpectedException = new ArgumentException()
            };

            Console.Out.WriteLine("ТЕСТ ЗАДАНИЯ 1:");
            
            Console.Out.WriteLine($"На вход подаем {testCase1.Number.ToString()}, ожидаем {testCase1.Expected.ToString()}:");
            Task1.Test(testCase1);
            Console.Out.WriteLine("");
            
            Console.Out.WriteLine($"На вход подаем {testCase2.Number.ToString()}, ожидаем {testCase2.Expected.ToString()}:");
            Task1.Test(testCase2);
            Console.Out.WriteLine("");
            
            Console.Out.WriteLine($"На вход подаем {testCase3.Number.ToString()}, ожидаем {testCase3.Expected.ToString()}:");
            Task1.Test(testCase3);
            Console.Out.WriteLine("");
            
            Console.Out.WriteLine($"На вход подаем {testCase4.Number.ToString()}, ожидаем {testCase4.Expected.ToString()}:");
            Task1.Test(testCase4);
            Console.Out.WriteLine("");
            
            Console.Out.WriteLine($"На вход подаем {testCase5.Number.ToString()}, ожидаем {testCase5.ExpectedException.GetType()}:");
            Task1.Test(testCase5);
            Console.Out.WriteLine("");
        }

        private static void TestTask3()
        {
            var testCase1 = new Task3.TestCase {
                OrderNumber = 0,
                Expected = 0,
                ExpectedException = null
            };

            var testCase2 = new Task3.TestCase {
                OrderNumber = 1,
                Expected = 1,
                ExpectedException = null
            };
            
            var testCase3 = new Task3.TestCase {
                OrderNumber = 3,
                Expected = 2,
                ExpectedException = null
            };
            
            var testCase4 = new Task3.TestCase {
                OrderNumber = 10,
                Expected = 55,
                ExpectedException = null,
            };

            var testCase5 = new Task3.TestCase {
                OrderNumber = -10,
                Expected = -55,
                ExpectedException = new ArgumentException()
            };

            Console.Out.WriteLine("--------------------------");
            Console.Out.WriteLine("ТЕСТ ЗАДАНИЯ 3 (РЕКУРСИЯ):");
            
            Console.Out.WriteLine($"На вход подаем {testCase1.OrderNumber.ToString()}, ожидаем {testCase1.Expected.ToString()}:");
            Task3.TestRecursive(testCase1);
            Console.Out.WriteLine("");
            
            Console.Out.WriteLine($"На вход подаем {testCase2.OrderNumber.ToString()}, ожидаем {testCase2.Expected.ToString()}:");
            Task3.TestRecursive(testCase2);
            Console.Out.WriteLine("");
            
            Console.Out.WriteLine($"На вход подаем {testCase3.OrderNumber.ToString()}, ожидаем {testCase3.Expected.ToString()}:");
            Task3.TestRecursive(testCase3);
            Console.Out.WriteLine("");
            
            Console.Out.WriteLine($"На вход подаем {testCase4.OrderNumber.ToString()}, ожидаем {testCase4.Expected.ToString()}:");
            Task3.TestRecursive(testCase4);
            Console.Out.WriteLine("");
            
            Console.Out.WriteLine($"На вход подаем {testCase5.OrderNumber.ToString()}, ожидаем {testCase5.ExpectedException.GetType()}:");
            Task3.TestRecursive(testCase5);
            Console.Out.WriteLine("");

            Console.Out.WriteLine("--------------------------");
            Console.Out.WriteLine("ТЕСТ ЗАДАНИЯ 3 (ЦИКЛ):");
            
            Console.Out.WriteLine($"На вход подаем {testCase1.OrderNumber.ToString()}, ожидаем {testCase1.Expected.ToString()}:");
            Task3.TestLoop(testCase1);
            Console.Out.WriteLine("");
            
            Console.Out.WriteLine($"На вход подаем {testCase2.OrderNumber.ToString()}, ожидаем {testCase2.Expected.ToString()}:");
            Task3.TestLoop(testCase2);
            Console.Out.WriteLine("");
            
            Console.Out.WriteLine($"На вход подаем {testCase3.OrderNumber.ToString()}, ожидаем {testCase3.Expected.ToString()}:");
            Task3.TestLoop(testCase3);
            Console.Out.WriteLine("");
            
            Console.Out.WriteLine($"На вход подаем {testCase4.OrderNumber.ToString()}, ожидаем {testCase4.Expected.ToString()}:");
            Task3.TestLoop(testCase4);
            Console.Out.WriteLine("");
            
            Console.Out.WriteLine($"На вход подаем {testCase5.OrderNumber.ToString()}, ожидаем {testCase5.ExpectedException.GetType()}:");
            Task3.TestLoop(testCase5);
            Console.Out.WriteLine("");
        }
    }
}