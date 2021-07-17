using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace lesson_8
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var array = new int[30];
            var rand = new Random(DateTime.Now.Millisecond);
            
            for (var i = 0; i < array.Length; i++)
                array[i] = rand.Next(-1000, 1000);
            
            foreach (var item in array)
            {
                Console.Write($"{item.ToString()},");
            }
            
            Console.WriteLine();

            var sorted = array.BucketSort(false);
            
            foreach (var item in sorted)
            {
                Console.Write($"{item.ToString()},");
            }
            
        }
    }
}