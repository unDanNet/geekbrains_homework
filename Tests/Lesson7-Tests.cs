using System;
using lesson_7;
using NUnit.Framework;

namespace TestProject1
{
    public class Lesson7_Tests
    {
        [TestFixture]
        public class DynamicProgrammingTest
        {
            [Test]
            public void Test_FindAmountOfWaysRecursive__Exception()
            {
                try
                {
                    Program.FindAmountOfWaysRecursive(0, 2);
                }
                catch (ArgumentException e)
                {
                    Assert.Pass();
                }

                Assert.Fail();
            }

            [Test]
            public void Test_FindAmountOfWaysRecursive__Case1()
            {
                var result = Program.FindAmountOfWaysRecursive(1, 3);

                Assert.AreEqual(result, 1);
            }

            [Test]
            public void Test_FindAmountOfWaysRecursive__Case2()
            {
                var result = Program.FindAmountOfWaysRecursive(2, 2);

                Assert.AreEqual(result, 2);
            }
            
            
            [Test]
            public void Test_FindAmountOfWaysRecursive__CaseAny()
            {
                var result = Program.FindAmountOfWaysRecursive(3, 4);

                Assert.AreEqual(result, 10);
            }
            
            
            
            [Test]
            public void Test_FindAmountOfWays__Exception()
            {
                try
                {
                    Program.FindAmountOfWays(0, 2);
                }
                catch (ArgumentException e)
                {
                    Assert.Pass();
                }

                Assert.Fail();
            }

            [Test]
            public void Test_FindAmountOfWays__Case1()
            {
                var result = Program.FindAmountOfWays(1, 3);

                Assert.AreEqual(result, 1);
            }

            [Test]
            public void Test_FindAmountOfWays__Case2()
            {
                var result = Program.FindAmountOfWays(2, 2);

                Assert.AreEqual(result, 2);
            }
            
            
            [Test]
            public void Test_FindAmountOfWays__CaseAny()
            {
                var result = Program.FindAmountOfWays(3, 4);

                Assert.AreEqual(result, 10);
            }
        }
    }
}