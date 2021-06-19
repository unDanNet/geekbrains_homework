using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace lesson_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
        
        public class BenchmarkClass
        {
            public PointClass fclass_point1 = new PointClass{X = 12.0242142f, Y = 67.0054021f};
            public PointClass fclass_point2 = new PointClass{X = 198.6382949f, Y = 234.3424214f};
            
            public PointStructFloat fstruct_point1 = new PointStructFloat{X = 12.0242142f, Y = 67.0054021f};
            public PointStructFloat fstruct_point2 = new PointStructFloat{X = 198.6382949f, Y = 234.3424214f};
            
            public PointStructDouble dstruct_point1 = new PointStructDouble{X = 12.0242142, Y = 67.0054021};
            public PointStructDouble dstruct_point2 = new PointStructDouble{X = 198.6382949, Y = 234.3424214};
            
            public float PointDistanceClassFloat(PointClass p1, PointClass p2)
            {
                float x = p1.X - p2.X;
                float y = p1.Y - p2.Y;
                return (float)Math.Sqrt(x * x + y * y);
            }

            public float PointDistanceStructFloat(PointStructFloat p1, PointStructFloat p2)
            {
                float x = p1.X - p2.X;
                float y = p1.Y - p2.Y;
                return (float)Math.Sqrt(x * x + y * y);
            }

            public double PointDistanceStructDouble(PointStructDouble p1, PointStructDouble p2)
            {
                double x = p1.X - p2.X;
                double y = p1.Y - p2.Y;
                return Math.Sqrt(x * x + y * y);
            }
            
            public float PointDistanceShortStructFloat(PointStructFloat p1, PointStructFloat p2)
            {
                float x = p1.X - p2.X;
                float y = p1.Y - p2.Y;
                return x * x + y * y;
            }

            [Benchmark]
            public void Test_PointDistanceClassFloat()
            {
                PointDistanceClassFloat(fclass_point1, fclass_point2);
            }

            [Benchmark]
            public void Test_PointDistanceStructFloat()
            {
                PointDistanceStructFloat(fstruct_point1, fstruct_point2);
            }

            [Benchmark]
            public void Test_PointDistanceStructDouble()
            {
                PointDistanceStructDouble(dstruct_point1, dstruct_point2);
            }

            [Benchmark]
            public void Test_PointDistanceShortStructFloat()
            {
                PointDistanceShortStructFloat(fstruct_point1, fstruct_point2);
            }
        }
    }

    public class PointClass
    {
        public float X { get; set; }
        public float Y { get; set; }
    }

    public struct PointStructFloat
    {
        public float X { get; set; }
        public float Y { get; set; }
    }

    public struct PointStructDouble
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    
}