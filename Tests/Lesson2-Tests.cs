using System;
using lesson_2;
using NUnit.Framework;

namespace TestProject1
{
    // Test functions are named satisfying the next rule:
    // Test_"MethodName"[_"MethodName"]__"Short description"
    // where [] - repeat 0 or more times
    
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void Test_DefaultConstructor()
        {
            var list = new LinkedList();
            
            Assert.Zero(list.GetCount());
        }

        [Test]
        public void Test_First_Exception()
        {
            var list = new LinkedList();

            try
            {
                var a = list.First;
            }
            catch (MemberAccessException e)
            {
                Assert.Pass();
            }
            
            Assert.Fail();
        }

        [Test]
        public void Test_Last__Exception()
        {
            var list = new LinkedList();

            try
            {
                var a = list.Last;
            }
            catch (MemberAccessException e)
            {
                Assert.Pass();
            }
            
            Assert.Fail();
        }
        
        [Test]
        public void Test_AddNode_First__AddOneNode()
        {
            var list = new LinkedList();
            
            list.AddNode(1);
            
            Assert.AreEqual(1, list.First);
        }

        [Test]
        public void Test_AddNode_Last__AddTwoNodes()
        {
            var list = new LinkedList();
            
            list.AddNode(1);
            list.AddNode(2);
            
            Assert.AreEqual(2, list.Last);
        }

        [Test]
        public void Test_GetCount()
        {
            var list = new LinkedList(1, 2);
            
            Assert.True(list.GetCount() == 2);
        }
        
        [Test]
        public void Test_AddNode__AddThreeNodes()
        {
            var list = new LinkedList();
            
            list.AddNode(1);
            list.AddNode(2);
            list.AddNode(3);
            
            Assert.True(list.GetCount() == 3 && list.First == 1 && list.Last == 3);
        }

        [Test]
        public void Test_SecondaryConstructor_ToString()
        {
            var list = new LinkedList(1, 2, 3, 4, 5);
            
            Assert.AreEqual("1 2 3 4 5", list.ToString());
        }

        [Test]
        public void Test_IndexOperatorGet__GetMiddle()
        {
            var list = new LinkedList(1, 2, 3, 4, 5);
            
            Assert.AreEqual(4, list[3]);
        }
        
        [Test]
        public void Test_IndexOperatorGet__GetFirst()
        {
            var list = new LinkedList(1, 2, 3, 4, 5);
            
            Assert.AreEqual(1, list[0]);
        }
        
        [Test]
        public void Test_IndexOperatorGet__GetLast()
        {
            var list = new LinkedList(1, 2, 3, 4, 5);
            
            Assert.AreEqual(5, list[4]);
        }

        [Test]
        public void Test_IndexOperatorSet()
        {
            var list = new LinkedList(1, 2, 3, 4, 5);

            list[2] = 100;
            
            Assert.AreEqual(100, list[2]);
        }

        [Test]
        public void Test_IndexOperatorGet__Exception()
        {
            var list = new LinkedList(1, 2, 3);

            try
            {
                var a = list[10];
            }
            catch (IndexOutOfRangeException e)
            {
                Assert.Pass();
            }
            
            Assert.Fail();
        }

        [Test]
        public void Test_IndexOperatorSet__Exception()
        {
            var list = new LinkedList(1, 2, 3);

            try
            {
                list[10] = 100;
            }
            catch (IndexOutOfRangeException e)
            {
                Assert.Pass();
            }
            
            Assert.Fail();
        }


        [Test]
        public void Test_FindNode__FindFirst()
        {
            var list = new LinkedList(1, 2, 3, 4, 5);

            var node = list.FindNode(1);
            Assert.True(node.Value == 1 && node.PrevNode == null);
        }
        
        [Test]
        public void Test_FindNode__FindLast()
        {
            var list = new LinkedList(1, 2, 3, 4, 5);

            var node = list.FindNode(5);
            Assert.True(node.Value == 5 && node.NextNode == null);
        }
        
        [Test]
        public void Test_FindNode__FindMiddle()
        {
            var list = new LinkedList(1, 2, 3, 4, 5);

            var node = list.FindNode(3);
            Assert.True(node.Value == 3 && node.PrevNode != null && node.NextNode != null);
        }

        [Test]
        public void Test_FindNode__FindNone()
        {
            var list = new LinkedList(1, 2, 3);

            var node = list.FindNode(100);
            Assert.Null(node);
        }

        [Test]
        public void Test_RemoveNode__RemoveFirstNode()
        {
            var list = new LinkedList(1, 2, 3, 4, 5);

            var removable = list.FindNode(1);
            list.RemoveNode(removable);
            
            Assert.AreEqual("2 3 4 5", list.ToString());
        }
        
        [Test]
        public void Test_RemoveNode__RemoveLastNode()
        {
            var list = new LinkedList(1, 2, 3, 4, 5);

            var removable = list.FindNode(5);
            list.RemoveNode(removable);
            
            Assert.AreEqual("1 2 3 4", list.ToString());
        }
        
        [Test]
        public void Test_RemoveNode__RemoveMiddleNode()
        {
            var list = new LinkedList(1, 2, 3, 4, 5);

            var removable = list.FindNode(3);
            list.RemoveNode(removable);
            
            Assert.AreEqual("1 2 4 5", list.ToString());
        }
        
        [Test]
        public void Test_RemoveNode__RemoveNodeException()
        {
            var list = new LinkedList(1, 2, 3);

            try
            {
                list.RemoveNode(null);
            }
            catch (ArgumentNullException e)
            {
                Assert.Pass();
            }
            
            Assert.Fail();
        }
        
        [Test]
        public void Test_RemoveNode__RemoveFirstIndex()
        {
            var list = new LinkedList(1, 2, 3, 4, 5);
            
            list.RemoveNode(0);
            
            Assert.AreEqual("2 3 4 5", list.ToString());
        }
        
        [Test]
        public void Test_RemoveNode__RemoveLastIndex()
        {
            var list = new LinkedList(1, 2, 3, 4, 5);
            
            list.RemoveNode(4);
            
            Assert.AreEqual("1 2 3 4", list.ToString());
        }
        
        [Test]
        public void Test_RemoveNode__RemoveMiddleIndex()
        {
            var list = new LinkedList(1, 2, 3, 4, 5);
            
            list.RemoveNode(2);
            
            Assert.AreEqual("1 2 4 5", list.ToString());
        }

        [Test]
        public void Test_RemoveNode__RemoveIndexException()
        {
            var list = new LinkedList(1, 2, 3);

            try
            {
                list.RemoveNode(10);
            }
            catch (IndexOutOfRangeException e)
            {
                Assert.Pass();
            }
            
            Assert.Fail();
        }

        [Test]
        public void Test_AddNodeAfter__AddAfterLast()
        {
            var list = new LinkedList(1, 2, 3);

            var node = list.FindNode(3);
            list.AddNodeAfter(node, 100);
            
            Assert.AreEqual(100, list.Last);
        }
        
        [Test]
        public void Test_AddNodeAfter__AddAfterMiddle()
        {
            var list = new LinkedList(1, 2, 3);

            var node = list.FindNode(2);
            list.AddNodeAfter(node, 100);
            
            Assert.AreEqual("1 2 100 3", list.ToString());
        }

        [Test]
        public void Test_AddNodeAfter__ArgumentNullException()
        {
            var list = new LinkedList(1, 2, 3);

            try
            {
                list.AddNodeAfter(null, 1000);
            }
            catch (ArgumentNullException e)
            {
                Assert.Pass();
            }
            
            Assert.Fail();
        }
        
        [Test]
        public void Test_AddNodeAfter__ArgumentException()
        {
            var list = new LinkedList(1, 2, 3);

            try
            {
                list.AddNodeAfter(new Node{Value = 1000}, 1000);
            }
            catch (ArgumentException e)
            {
                Assert.Pass();
            }
            
            Assert.Fail();
        }
    }


    [TestFixture]
    public class BinarySearchTests
    {
        [Test]
        public void Test_ArrayWithEvenLength()
        {
            long[] array = {1L, 2L, 3L, 4L, 5L, 6L};

            var result = Task2.BinarySearch(array, 3L);
            
            Assert.AreEqual(2, result);
        }


        [Test]
        public void Test_ArrayWithUnevenLength()
        {
            long[] array = {1L, 2L, 3L, 4L, 5L};

            var result = Task2.BinarySearch(array, 4L);
            
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Test_UnsortedArray()
        {
            long[] array = {2L, 1L, 5L, 3L, 4L};

            var result = Task2.BinarySearch(array, 4L);
            
            Assert.AreNotEqual(4, result);
        }

        [Test]
        public void Test_NotFound()
        {
            long[] array = {1L, 2L, 3L};

            var result = Task2.BinarySearch(array, 10L);
            
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void Test_EmptyArray()
        {
            long[] array = { };

            var result = Task2.BinarySearch(array, 10L);
            
            Assert.AreEqual(-1, result);
        }
    }
}