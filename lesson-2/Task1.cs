using System;

namespace lesson_2
{
    /// <summary>
    /// An interface for data structures representing linked list.
    /// </summary>
    public interface ILinkedList
    {
        /// <summary>
        /// Get the amount of nodes in the list.
        /// </summary>
        /// <returns>The amount of nodes in the list.</returns>
        int GetCount();

        /// <summary>
        /// Add a new node to the end of the list.
        /// </summary>
        /// <param name="value">The value the node stores.</param>
        void AddNode(int value);

        /// <summary>
        /// Add a new node after the specified node.
        /// </summary>
        /// <param name="node">The node to add a new node after.</param>
        /// <param name="value">The value the node stores.</param>
        void AddNodeAfter(Node node, int value);

        /// <summary>
        /// Remove the node by its index.
        /// </summary>
        /// <param name="index">The index of the node to remove.</param>
        void RemoveNode(int index);

        /// <summary>
        /// Remove the specified node from the list.
        /// </summary>
        /// <param name="node">The node to remove.</param>
        void RemoveNode(Node node);

        /// <summary>
        /// Find the node by the value the node stores.
        /// </summary>
        /// <param name="searchVal">The value of the node to find.</param>
        /// <returns>The node if node with specified value is in the list, null - otherwise.</returns>
        Node FindNode(int searchVal);
        
        /// <summary>
        /// Get the value of the first node of the list.
        /// </summary>
        int First { get; }
        
        /// <summary>
        /// Get the value of the last node of the list.
        /// </summary>
        int Last { get; }
    }
    
    /// <summary>
    /// The node of the list that store the next node, the previous node and an integer value.
    /// </summary>
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }


    public sealed class LinkedList : ILinkedList
    {
        private Node firstNode;
        private Node lastNode;
        private int count;


        public int First {
            get {
                if (firstNode is null)
                    throw new MemberAccessException("Can not access the value of the first node of the empty list.");

                return firstNode.Value;
            }
        }

        public int Last {
            get {
                if (lastNode is null)
                    throw new MemberAccessException("Can not access the value of the first node of the empty list.");

                return lastNode.Value;
            }
        }

        /// <summary>
        /// Create a new instance of list that is empty list.
        /// </summary>
        public LinkedList()
        {
            count = 0;
            firstNode = null;
            lastNode = null;
        }

        /// <summary>
        /// Create a new instance of list filled with specified values.
        /// </summary>
        /// <param name="values">The initial values of the list.</param>
        public LinkedList(params int[] values)
        {
            foreach (var value in values)
                AddNode(value);
        }

        public int GetCount()
        {
            return count;
        }

        public void AddNode(int value)
        {
            if (lastNode is null)
            {
                firstNode = new Node {Value = value, NextNode = null, PrevNode = null};
                lastNode = firstNode;
                count = 1;
                return;
            }
            
            var node = new Node {Value = value, NextNode = null, PrevNode = lastNode};
            lastNode.NextNode = node;
            lastNode = node;

            count++;
        }

        public void AddNodeAfter(Node node, int value)
        {
            if (node is null)
                throw new ArgumentNullException(nameof(node));

            var searchResult = FindNode(node);
            
            if (searchResult is null)
                throw new ArgumentException("The specified node is not in the list.", nameof(node));
            
            
            if (searchResult == lastNode)
            {
                var newNode = new Node {Value = value, NextNode = null, PrevNode = lastNode};
                lastNode.NextNode = newNode;

                lastNode = newNode;
            }
            
            var nextNode = new Node {Value = value, NextNode = searchResult.NextNode, PrevNode = searchResult};
            searchResult.NextNode.PrevNode = nextNode;
            searchResult.NextNode = nextNode;
        }

        public void RemoveNode(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException(nameof(index));
            
            if (count == 1)
            {
                firstNode = null;
                lastNode = null;
                count = 0;
                
                return;
            }
            
            Node removable;

            // optimize the performance: if index less than half of the count then search from the start of the list,
            // otherwise - search from the end of the list.
            if (index <= count / 2)
            {
                removable = firstNode;
                for (var i = 0; i < index; i++)
                {
                    if (index == i)
                        break;
                    
                    removable = removable.NextNode;
                }
            }
            else
            {
                removable = lastNode;
                for (var i = count - 1; i > count / 2; i--)
                {
                    if (index == i)
                        break;

                    removable = removable.PrevNode;
                }
            }
            
            Remove(removable);
        }

        private void Remove(Node removable)
        {
            if (removable == firstNode)
            {
                firstNode = removable.NextNode;
                firstNode.PrevNode = null;
            }
            else if (removable == lastNode)
            {
                lastNode = removable.PrevNode;
                lastNode.NextNode = null;
            }
            else
            {
                removable.NextNode.PrevNode = removable.PrevNode;
                removable.PrevNode.NextNode = removable.NextNode;
            }
        }
        
        public void RemoveNode(Node node)
        {
            if (node is null)
                throw new ArgumentNullException(nameof(node));

            var searchResult = FindNode(node);
            
            if (searchResult == null)
                return;
            
            Remove(searchResult);
        }

        private Node FindNode(Node node)
        {
            if (node is null)
                throw new ArgumentNullException(nameof(node));
            
            if (node == firstNode)
                return firstNode;

            if (node == lastNode)
                return lastNode;
            
            
            Node current = firstNode;
            while (current.NextNode != null)
            {
                if (current == node)
                    break;

                current = current.NextNode;
            }

            return current == lastNode ? null : current;
        }

        public Node FindNode(int searchVal)
        {
            if (searchVal == firstNode.Value)
                return firstNode;

            if (searchVal == lastNode.Value)
                return lastNode;
            
            
            Node current = firstNode;
            while (current.NextNode != null)
            {
                if (current.Value == searchVal)
                    break;

                current = current.NextNode;
            }

            return current == lastNode ? null : current;
        }
        
        
        
        public int this[int index]
        {
            get {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException("Index must be non-negative and less than amount of elements in the list.");

                if (index == 0)
                    return firstNode.Value;

                if (index == count - 1)
                    return lastNode.Value;
                
                Node current = firstNode;
                for (var i = 0; i < count; i++)
                {
                    if (i == index)
                        break;

                    current = current.NextNode;
                }
                
                return current.Value;
            }

            set {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException("Index must be non-negative and less than amount of elements in the list.");

                if (index == 0)
                    firstNode.Value = value;

                if (index == count - 1)
                    lastNode.Value = value;
                
                Node current = firstNode;
                for (var i = 0; i < count; i++)
                {
                    if (i == index)
                        break;

                    current = current.NextNode;
                }

                current.Value = value;
            }
        }

        public override string ToString()
        {
            Node current = firstNode;
            var result = "";

            while (current != null)
            {
                result += $"{current.Value.ToString()} ";
                current = current.NextNode;
            }

            result = result.TrimEnd();
            return result;
        }
    }
}