using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace lesson_4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            
            // var tree = new Tree();
            //
            // var amount = 12;
            // var rand = new Random();
            //
            // for (var i = 1; i < amount; i++)
            //     tree.AddItem(rand.Next(1, 1000));
            //
            // tree.PrintTree();
            // Console.ReadLine();
        }

        public class BenchmarkClass
        {
            public const int Size = 20000;
            
            public string[] TestArray { get; private set; }
            public HashSet<string> TestHashSet { get; private set; }

            public BenchmarkClass()
            {
                TestArray = new string[Size];
                TestHashSet = new HashSet<string>();
                
                var strLenRandomizer = new Random(DateTime.Now.Millisecond);
                var strCharRandomizer = new Random(DateTime.Now.Millisecond);
                
                for (var i = 0; i < Size; i++)
                {
                    var randStrLen = strLenRandomizer.Next(1, 100);
                    var str = "";

                    
                    for (var j = 0; j < randStrLen; j++)
                        str += (char)(strCharRandomizer.Next(0, char.MaxValue));

                    
                    TestArray[i] = str;
                    TestHashSet.Add(str);
                }
            }

            [Benchmark]
            public void Test_ArrayContainsString()
            {
                TestArray.Contains("test");
            }

            [Benchmark]
            public void Test_HashSetContainsString()
            {
                TestHashSet.Contains("test");
            }
        }
    }
}