using System;
using System.Collections.Generic;
using lesson_4;

namespace lesson_5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var tree = new Tree(new[] {10, 23, 8, 4, 11, 123, 0});
            
            tree.DFSearch(11);
            tree.DFSearch(100);
            tree.DFSearch(10);
            
            tree.BFSearch(11);
            tree.BFSearch(100);
            tree.BFSearch(10);
        }
    }

    public static class TreeAlgorithms
    {
        /// <summary>
        /// Find the node with specified value in the tree using the breadth-first search algorithm.
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="value">The value to search.</param>
        /// <returns>The node with the specified value.</returns>
        public static TreeNode BFSearch(this Tree tree, int value)
        {
            Console.WriteLine(new string('=', Console.BufferWidth));

            TreeNode searchResult = null;
            var nodes = new Queue<TreeNode>();
            nodes.Enqueue(tree.Root);
            
            Console.WriteLine($"1) Кладём корень дерева в очередь: [{tree.Root.Value.ToString()}]");
            
            
            while (nodes.Count > 0)
            {
                Console.WriteLine("2) Проверяем пуста ли очередь.");
                
                var current = nodes.Dequeue();
                
                Console.WriteLine($"3) Очередь не пуста - вынимаем элемент из очереди: [{current.Value.ToString()}]");
                Console.Write($"4) Проверяем является ли вынутый элемент искомым: [{current.Value.ToString()}] = [{value.ToString()}]?");
                
                if (current.Value == value)
                {
                    Console.WriteLine(" - Элемент является искомым.");
                    Console.WriteLine("6) Возвращаем элемент и завершаем работу алгоритма.");
                    
                    searchResult = current;
                    break;
                }
                
                Console.WriteLine(" - Элемент не является искомым.");
                Console.WriteLine("5) Кладём все дочерние узлы элемента в стек: " +
                                  $"{(current.LeftChild != null ? $"[{current.LeftChild.Value.ToString()}] " : "- ")}" +
                                  $"{(current.RightChild != null ? $"[{current.RightChild.Value.ToString()}]" : "-")}"
                );
                
                if (current.LeftChild != null)
                    nodes.Enqueue(current.LeftChild);
                
                if (current.RightChild != null)
                    nodes.Enqueue(current.RightChild);
                
                Console.WriteLine();
            }
            
            Console.WriteLine($"7) {(searchResult is null ? "Стек пуст, искомый элемент не найден" : "Искомый элемент найден")}, завершаем работу алгоритма.");
            Console.WriteLine(new string('=', Console.BufferWidth));
            
            return searchResult;
        }


        /// <summary>
        /// Find the node with specified value in the tree using the depth-first search algorithm.
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="value">The value to search.</param>
        /// <returns>The node with the specified value.</returns>
        public static TreeNode DFSearch(this Tree tree, int value)
        {
            Console.WriteLine(new string('=', Console.BufferWidth));

            TreeNode searchResult = null;
            var nodes = new Stack<TreeNode>();
            nodes.Push(tree.Root);
            
            Console.WriteLine($"1) Кладём корень дерева в стек: [{tree.Root.Value.ToString()}]");

            while (nodes.Count > 0)
            {
                Console.WriteLine("2) Проверяем пуст ли стек.");
                
                var current = nodes.Pop();
                
                Console.WriteLine($"3) Стек не пуст - вынимаем элемент из стека: [{current.Value.ToString()}]");
                Console.Write($"4) Проверяем является ли вынутый элемент искомым: [{current.Value.ToString()}] = [{value.ToString()}]?");

                if (current.Value == value)
                {
                    Console.WriteLine(" - Элемент является искомым.");
                    Console.WriteLine("6) Возвращаем элемент и завершаем работу алгоритма.");

                    searchResult = current;
                    break;
                }
                
                Console.WriteLine(" - Элемент не является искомым.");
                Console.WriteLine("5) Кладём все дочерние узлы элемента в очередь: " +
                                  $"{(current.LeftChild != null ? $"[{current.LeftChild.Value.ToString()}] " : "- ")}" +
                                  $"{(current.RightChild != null ? $"[{current.RightChild.Value.ToString()}]" : "-")}"
                );
                
                if (current.LeftChild != null)
                    nodes.Push(current.LeftChild);
                
                if (current.RightChild != null)
                    nodes.Push(current.RightChild);
                
                Console.WriteLine();
            }

            Console.WriteLine($"7) {(searchResult is null ? "Очередь пуста, искомый элемент не найден" : "Искомый элемент найден")}, завершаем работу алгоритма.");
            Console.WriteLine(new string('=', Console.BufferWidth));
            
            return searchResult;
        }
    }
}