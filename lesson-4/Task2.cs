using System;
using System.Collections.Generic;
using System.Linq;

namespace lesson_4
{
    /// <summary>
    /// Data structure representing the binary tree node.
    /// </summary>
    public class TreeNode
    {
        /// <summary>
        /// The value of the node.
        /// </summary>
        public int Value { get; set; }
        
        /// <summary>
        /// The left child of this node.
        /// </summary>
        public TreeNode LeftChild { get; set; }
        
        /// <summary>
        /// The right child of this node.
        /// </summary>
        public TreeNode RightChild { get; set; }

        /// <summary>
        /// The parent node of this node.
        /// </summary>
        public TreeNode Parent { get; set; }
        
        public override bool Equals(object obj)
        {
            var node = obj as TreeNode;

            if (node is null)
                return false;

            return node.Value == Value;
        }
        
        
        public static bool operator==(TreeNode lVal, TreeNode rVal)
        {
            if (lVal is null && rVal is null)
                return true;

            if (lVal is null)
                return false;

            return lVal.Equals(rVal);
        }

        public static bool operator !=(TreeNode lVal, TreeNode rVal)
        {
            return !(lVal == rVal);
        }
    }

    /// <summary>
    /// Data structure containing data about the node in the tree.
    /// </summary>
    public class NodeInfo
    {
        /// <summary>
        /// The level of the tree where the node stored.
        /// </summary>
        public int Depth { get; set; }
        
        /// <summary>
        /// The order number of the node on its level (for printing).
        /// </summary>
        public int OrderOnLevel { get; set; }
        
        /// <summary>
        /// The amount of digits in the node's value (for printing).
        /// </summary>
        public int ValueLength { get; set; }
        
        /// <summary>
        /// The coordinate of the node in the string line (for printing).
        /// </summary>
        public int StrLineCoordinate { get; set; }
        
        /// <summary>
        /// The node of the tree itself.
        /// </summary>
        public TreeNode Node { get; set; }
    }

    /// <summary>
    /// An interface representing a simple binary tree.
    /// </summary>
    public interface ITree
    {
        /// <summary>
        /// Get the root node of the tree.
        /// </summary>
        TreeNode Root { get; }
        
        /// <summary>
        /// Get amount of elements in the tree.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Add new node with specified value to the tree.
        /// </summary>
        /// <param name="value">The value of the node to add.</param>
        TreeNode AddItem(int value);
        
        /// <summary>
        /// Remove the node from the tree by its value.
        /// </summary>
        /// <param name="value">The value of the node to remove.</param>
        bool RemoveItem(int value);
        
        /// <summary>
        /// Get the node from the tree by its value.
        /// </summary>
        /// <param name="value">The value of the node to get.</param>
        /// <returns>The node.</returns>
        TreeNode GetNodeByValue(int value);
        
        /// <summary>
        /// Print the tree to the console.
        /// </summary>
        void PrintTree();


        /// <summary>
        /// Get the value indicating whether the specified value is in the tree.
        /// </summary>
        /// <param name="value">The value to check.</param>
        bool Contains(int value);
    }

    public static class TreeHelper
    {
        public static NodeInfo[] GetTreeInLine(ITree tree)
        {
            var buffer = new Queue<NodeInfo>();
            var returnArray = new List<NodeInfo>();
            var root = new NodeInfo
            {
                Node = tree.Root,
                ValueLength = Utils.GetNumberLength(tree.Root.Value),
                OrderOnLevel = 1
            };
            
            buffer.Enqueue(root);

            while (buffer.Count != 0)
            {
                var element = buffer.Dequeue();
                returnArray.Add(element);

                var depth = element.Depth + 1;

                
                if (element.Node.LeftChild != null)
                {
                    var left = new NodeInfo
                    {
                        Node = element.Node.LeftChild,
                        Depth = depth,
                        ValueLength = Utils.GetNumberLength(element.Node.Value),
                        OrderOnLevel = element.OrderOnLevel * 2 - 1
                    };
                    buffer.Enqueue(left);
                }

                if (element.Node.RightChild != null)
                {
                    var right = new NodeInfo
                    {
                        Node = element.Node.RightChild,
                        ValueLength = Utils.GetNumberLength(element.Node.Value),
                        Depth = depth,
                        OrderOnLevel = element.OrderOnLevel * 2
                    };
                    buffer.Enqueue(right);
                }
            }

            return returnArray.ToArray();
        }
    }

    
    /// <summary>
    /// The data structure representing binary tree.
    /// </summary>
    public class Tree : ITree
    {
        private TreeNode root;
        private int count;

        public Tree()
        {

        }

        /// <summary>
        /// Initialize a new instance of tree filled with specified values.
        /// </summary>
        /// <param name="values">The values to initialize the tree with.</param>
        public Tree(IEnumerable<int> values)
        {
            if (values is null)
                throw new ArgumentNullException(nameof(values));
            
            foreach (var val in values)
            {
                AddItem(val);
            }
        }
        
        public TreeNode Root => root;

        public int Count => count;

        private TreeNode RecursivelyAddItem(TreeNode curNode, int value)
        {
            if (value <= curNode.Value)
            {
                if (curNode.LeftChild is null)
                {
                    var child = new TreeNode {
                        Parent = curNode,
                        LeftChild = null,
                        RightChild = null,
                        Value = value
                    };

                    curNode.LeftChild = child;

                    count++;
                    return child;
                }
                
                return RecursivelyAddItem(curNode.LeftChild, value);
            }
            else
            {
                if (curNode.RightChild is null)
                {
                    var child = new TreeNode {
                        Parent = curNode,
                        LeftChild = null,
                        RightChild = null,
                        Value = value
                    };

                    curNode.RightChild = child;

                    count++;
                    return child;
                }
                
                return RecursivelyAddItem(curNode.RightChild, value);
            }
        }
        
        public TreeNode AddItem(int value)
        {
            if (root is null)
            {
                root = new TreeNode
                {
                    Parent = null,
                    LeftChild = null,
                    RightChild = null,
                    Value = value
                };

                count = 1;
                return root;
            }
            
            return RecursivelyAddItem(root, value);
        }

        private TreeNode GetMaxLeafOfLeftSubtree(TreeNode curNode)
        {
            if (curNode.LeftChild is null)
                return null;

            curNode = curNode.LeftChild;

            while (curNode.RightChild != null)
                curNode = curNode.RightChild;

            return curNode;
        }

        private TreeNode GetMinLeafOfRightSubtree(TreeNode curNode)
        {
            if (curNode.RightChild is null)
                return null;

            curNode = curNode.RightChild;

            while (curNode.LeftChild != null)
                curNode = curNode.LeftChild;

            return curNode;
        }

        public bool RemoveItem(int value)
        {
            if (root is null)
                return false;

            var removable = GetNodeByValue(value);
            
            if (removable is null)
                return false;

            /* Case 1: removable is the only item in the tree */
            if (count == 1)
            {
                root = null;
            }
            /* Case 2: removable is the leaf */
            else if (removable.RightChild is null && removable.LeftChild is null)
            {
                if (removable.Parent.LeftChild == removable)
                    removable.Parent.LeftChild = null;
                else
                    removable.Parent.RightChild = null;
            }
            /* The next cases is for the case when removable is not only item in the tree and not the leaf */
            else
            {
                // if removable node does not have right subtree then removable is replaced with the most right
                // node of the left subtree.
                // if removable node does not have left subtree then removable is replaced with the most left
                // node of the right subtree.
                // if removable have both subtrees then does not matter what to choose.
                var replaceNode = GetMaxLeafOfLeftSubtree(removable) ?? GetMinLeafOfRightSubtree(removable);

                if (removable == root)
                    root = replaceNode;
                
                /* Case 3: replace node is the leaf, but not the child of removable */
                if (replaceNode.LeftChild is null && replaceNode.RightChild is null && replaceNode.Parent != removable)
                {
                    if (replaceNode.Parent.LeftChild == replaceNode)
                        replaceNode.Parent.LeftChild = null;
                    else
                        replaceNode.Parent.RightChild = null;

                    replaceNode.Parent = removable.Parent;
                    replaceNode.LeftChild = removable.LeftChild;
                    replaceNode.RightChild = removable.RightChild;

                    if (removable.LeftChild != null) 
                        removable.LeftChild.Parent = replaceNode;

                    if (removable.RightChild != null)
                        removable.RightChild.Parent = replaceNode;

                    if (removable.Parent != null)
                    {
                        if (removable.Parent.LeftChild == removable)
                            removable.Parent.LeftChild = replaceNode;
                        else
                            removable.Parent.RightChild = replaceNode;
                    }
                    
                }
                /* Case 4: replace node is the child of the removable but not the leaf */
                else if (replaceNode.Parent == removable && !(replaceNode.LeftChild is null && replaceNode.RightChild is null))
                {
                    replaceNode.Parent = removable.Parent;
                    
                    if (removable.Parent != null)
                    {
                        if (removable.Parent.LeftChild == removable)
                            removable.Parent.LeftChild = replaceNode;
                        else
                            removable.Parent.RightChild = replaceNode;
                    }

                    if (replaceNode.RightChild is null)
                    {
                        replaceNode.RightChild = removable.RightChild;
                        
                        if (replaceNode.RightChild != null)
                            replaceNode.RightChild.Parent = replaceNode;
                    }
                    else
                    {
                        replaceNode.LeftChild = removable.LeftChild;

                        if (replaceNode.LeftChild != null)
                            replaceNode.LeftChild.Parent = replaceNode;
                    }
                }
                /* Case 5: replace node is a leaf and the child of the removable */
                else if (replaceNode.Parent == removable && replaceNode.LeftChild is null && replaceNode.RightChild is null)
                {
                    replaceNode.Parent = removable.Parent;
                    
                    if (removable.Parent != null)
                    {
                        if (removable.Parent.LeftChild == removable)
                            removable.Parent.LeftChild = replaceNode;
                        else
                            removable.Parent.RightChild = replaceNode;
                    }

                    if (replaceNode == removable.LeftChild)
                    {
                        replaceNode.RightChild = removable.RightChild;

                        if (replaceNode.RightChild != null)
                            replaceNode.RightChild.Parent = replaceNode;
                    }
                    else
                    {
                        replaceNode.LeftChild = removable.LeftChild;
                        
                        if (replaceNode.LeftChild != null)
                            replaceNode.LeftChild.Parent = replaceNode;
                    }
                }
                /* Case 6: replace node is not the child of removable and not the leaf */
                else
                {
                    if (removable.Parent != null)
                    {
                        if (removable.Parent.LeftChild == removable)
                            removable.Parent.LeftChild = replaceNode;
                        else
                            removable.Parent.RightChild = replaceNode;
                    }

                    if (replaceNode.Parent.RightChild == replaceNode)
                    {
                        replaceNode.Parent.RightChild = replaceNode.LeftChild;

                        if (replaceNode.LeftChild != null)
                            replaceNode.LeftChild.Parent = replaceNode.Parent;
                    }
                    else
                    {
                        replaceNode.Parent.LeftChild = replaceNode.RightChild;

                        if (replaceNode.RightChild != null)
                            replaceNode.RightChild.Parent = replaceNode.Parent;
                    }

                    replaceNode.Parent = removable.Parent;
                    replaceNode.LeftChild = removable.LeftChild;
                    replaceNode.RightChild = removable.RightChild;

                    if (replaceNode.LeftChild != null)
                        replaceNode.LeftChild.Parent = replaceNode;

                    if (replaceNode.RightChild != null)
                        replaceNode.RightChild.Parent = replaceNode;
                }
            }

            removable.LeftChild = null;
            removable.RightChild = null;
            removable.Parent = null;

            count--;
            return true;
        }


        private TreeNode RecursivelyGetNodeByValue(TreeNode curNode, int value)
        {
            if (value == curNode.Value)
            {
                return curNode;
            }
            else if (value < curNode.Value)
            {
                if (curNode.LeftChild is null)
                    return null;

                return RecursivelyGetNodeByValue(curNode.LeftChild, value);
            }
            else
            {
                if (curNode.RightChild is null)
                    return null;

                return RecursivelyGetNodeByValue(curNode.RightChild, value);
            }
        }

        public TreeNode GetNodeByValue(int value)
        {
            return root is null ? null : RecursivelyGetNodeByValue(root, value);
        }


        public bool Contains(int value)
        {
            return GetNodeByValue(value) != null;
        }

        public void PrintTree()
        {
            NodeInfo[] nodesInfos = TreeHelper.GetTreeInLine(this);

            var maxDepth = nodesInfos.Max(ni => ni.Depth);
            
            // set buffer width depending on tree's height
            int bufferWidth = (int)Math.Pow(2, 3 + maxDepth);
            
            if (bufferWidth > 155)
                Console.SetBufferSize(bufferWidth, Console.BufferHeight);
            
            // calculate string coordinate for the root
            var _root = nodesInfos[0];
            _root.StrLineCoordinate = bufferWidth / 2 - _root.ValueLength / 2;
            
            // calculate string coordinateы for other items on other levels
            for (var depth = 1; depth <= maxDepth; depth++)
            {
                var curDepth = depth;
                var spacesAmount = (int) Math.Pow(2, depth) + 1;
                var itemsOnLevel = nodesInfos.Where(ni => ni.Depth == curDepth).ToList();
            
                for (var i = 0; i < itemsOnLevel.Count; i++)
                {
                    var item = itemsOnLevel[i];
            
                    item.StrLineCoordinate = (bufferWidth * item.OrderOnLevel / spacesAmount)
                                             - item.ValueLength / 2 + (i > 0 ? itemsOnLevel[i-1].ValueLength : 0);
            
                }
            }
            
            // draw tree in the list of strings
            var output = new List<string>();
            for (var depth = 0; depth <= maxDepth; depth++)
            {
                var curDepth = depth;
                var treeLine = new string(' ', bufferWidth);
                var branchLine = new string(' ', bufferWidth);
            
                var itemsOnLevel = nodesInfos.Where(ni => ni.Depth == curDepth).ToList();
                var itemsOnNextLevel = nodesInfos.Where(ni => ni.Depth == curDepth + 1).ToList();
            
                foreach (var item in itemsOnLevel)
                {
                    treeLine = treeLine.Replace(
                        item.StrLineCoordinate,
                        $"({item.Node.Value.ToString()})"
                    );
                }
            
                if (itemsOnNextLevel.Count > 0)
                {
                    foreach (var item in itemsOnNextLevel)
                    {
                        if (item.Node.Parent.LeftChild == item.Node)
                        {
                            var parentNodeInfo = nodesInfos.FirstOrDefault(ni => ni.Node == item.Node.Parent);
                            
                            if (parentNodeInfo != null)
                            {
                                branchLine = branchLine.Replace(
                                    item.StrLineCoordinate + 1 + item.ValueLength / 2,
                                    parentNodeInfo.StrLineCoordinate,
                                    '='
                                );
                                branchLine = branchLine.Replace(
                                    item.StrLineCoordinate + 1,
                                    item.StrLineCoordinate + 2,
                                    '/'
                                );
                                branchLine = branchLine.Replace(
                                    parentNodeInfo.StrLineCoordinate,
                                    parentNodeInfo.StrLineCoordinate + 1,
                                    '/'
                                );
                            }
                        }
            
                        if (item.Node.Parent.RightChild == item.Node)
                        {
                            var parentNodeInfo = nodesInfos.FirstOrDefault(ni => ni.Node == item.Node.Parent);
                            
                            if (parentNodeInfo != null)
                            {
                                branchLine = branchLine.Replace(
                                    parentNodeInfo.StrLineCoordinate + 2 + parentNodeInfo.ValueLength,
                                    item.StrLineCoordinate + item.ValueLength / 2 + 1,
                                    '='
                                );
                                branchLine = branchLine.Replace(
                                    item.StrLineCoordinate + 1 + item.ValueLength / 2,
                                    item.StrLineCoordinate + 2 + item.ValueLength / 2,
                                    '\\'
                                );
                                branchLine = branchLine.Replace(
                                    parentNodeInfo.StrLineCoordinate + 1 + parentNodeInfo.ValueLength,
                                    parentNodeInfo.StrLineCoordinate + 2 + parentNodeInfo.ValueLength,
                                    '\\'
                                );
                            }
                        }
                    }
                }
                
                output.Add(treeLine);
                output.Add(branchLine);
            }
            
            foreach (var str in output)
                Console.WriteLine(str);
            
        }
    }
}