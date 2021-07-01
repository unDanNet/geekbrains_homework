using System;
using System.Collections.Generic;
using lesson_4;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class TreeTests
    {
        [Test]
        public void Test_AddItem__AddOneItem()
        {
            var tree = new Tree();

            tree.AddItem(1);
            
            Assert.AreEqual(1, tree.Root.Value);
        }

        [Test]
        public void Test_AddItem__AddManyItems()
        {
            var tree = new Tree();

            tree.AddItem(2);
            tree.AddItem(1);
            tree.AddItem(3);
            
            Assert.IsTrue(tree.Root.LeftChild.Value == 1 && tree.Root.RightChild.Value == 3);
        }

        [Test]
        public void Test_SecondaryConstructor()
        {
            var values = new List<int>{1, 2, 3};
            var tree = new Tree(values);
            
            Assert.IsTrue(tree.Root.LeftChild is null && tree.Root.RightChild.Value == 2);
        }

        [Test]
        public void Test_SecondaryConstructor__Exception()
        {
            List<int> values = null;

            try
            {
                var tree = new Tree(values);
            }
            catch (ArgumentNullException e)
            {
                Assert.Pass();
            }
            
            Assert.Fail();
        }

        [Test]
        public void Test_Count__Empty()
        {
            var tree = new Tree();
            
            Assert.AreEqual(0, tree.Count);
        }

        [Test]
        public void Test_Count__OneItem()
        {
            var tree = new Tree(new[] {1});
            
            Assert.AreEqual(1, tree.Count);
        }

        [Test]
        public void Test_Count__ManyItems()
        {
            var tree = new Tree(new[] {1, 2, 3, 4, 5});
            
            Assert.AreEqual(5, tree.Count);
        }

        [Test]
        public void Test_GetNodeByValue__Empty()
        {
            var tree = new Tree();
            
            Assert.Null(tree.GetNodeByValue(1));
        }

        [Test]
        public void Test_GetNodeByValue__FindRoot()
        {
            var tree = new Tree(new[]{2, 1, 3});

            var searchResult = tree.GetNodeByValue(2);
            Assert.True(searchResult == tree.Root);
        }

        [Test]
        public void Test_GetNodeByValue__FindAny()
        {
            var tree = new Tree(new[]{3, 2, 4, 1, 6, 5});

            var searchResult = tree.GetNodeByValue(5);
            
            Assert.True(searchResult.Parent.Value == 6 && searchResult.Value == 5);
        }

        [Test]
        public void Test_GetNodeByValue__FindNothing()
        {
            var tree = new Tree(new[]{3, 2, 4, 1, 6, 5});

            var searchResult = tree.GetNodeByValue(100);
            
            Assert.Null(searchResult);
        }
        
        [Test]
        public void Test_RemoveItem__Empty()
        {
            var tree = new Tree();
            
            Assert.False(tree.RemoveItem(1));
        }

        [Test]
        public void Test_RemoveItem__RemoveRootFromTreeWithOneItem()
        {
            var tree = new Tree(new[]{1});

            var success = tree.RemoveItem(1);
            
            Assert.True(tree.Root is null && tree.Count == 0 && success);
        }

        [Test]
        public void Test_RemoveItem__RemoveRootFromTreeWithManyItems()
        {
            var tree = new Tree(new[]{3, 2, 4, 1, 6, 5});

            var success = tree.RemoveItem(3);
            
            Assert.True(
                success && 
                tree.Root.Value == 2 && 
                tree.Root.LeftChild.Value == 1 &&
                tree.Root.RightChild.Value == 4 &&
                tree.Count == 5
            );
        }

        [Test]
        public void Test_RemoveItem__RemoveLeaf()
        {
            var tree = new Tree(new[]{3, 2, 4, 1, 6, 5});

            var success = tree.RemoveItem(1);
            
            Assert.True(
                success &&
                tree.Root.LeftChild.LeftChild is null &&
                tree.Count == 5
            );
        }

        [Test]
        public void Test_RemoveItem__RemoveAny()
        {
            var tree = new Tree(new[]{3, 2, 4, 1, 6, 5});

            var success = tree.RemoveItem(4);
            
            Assert.True(
                success &&
                tree.Root.RightChild.Value == 5 &&
                tree.Count == 5
            );
        }

        [Test]
        public void Test_RemoveItem__RemoveNone()
        {
            var tree = new Tree(new[]{3, 2, 4, 1, 6, 5});

            var success = tree.RemoveItem(100);
            
            Assert.True(
                !success &&
                tree.Count == 6
            );
        }

        [Test]
        public void Test_Contains__Empty()
        {
            var tree = new Tree();

            var contains = tree.Contains(10);
            
            Assert.False(contains);
        }

        [Test]
        public void Test_Contains__Found()
        {
            var tree = new Tree(new[]{3, 2, 4, 1, 6, 5});

            var contains = tree.Contains(5);
            
            Assert.True(contains);
        }

        [Test]
        public void Test_Contains__NotFound()
        {
            var tree = new Tree(new[]{3, 2, 4, 1, 6, 5});

            var contains = tree.Contains(100);
            
            Assert.False(contains);
        }
    }
}