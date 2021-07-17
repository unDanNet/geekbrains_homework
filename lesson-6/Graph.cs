using System;
using System.Collections.Generic;
using System.Linq;

namespace lesson_6
{
	public class Node
	{
		public int Number { get; set; }
		public int Value { get; set; }
		public List<Edge> Edges { get; set; } = new List<Edge>();
	}

	public class Edge
	{
		public Node Node { get; set; }
	}
	
	public class Graph
	{
		public List<Node> Nodes { get; } = new List<Node>();

		public Graph(bool[][] adjacencyMatrix, int[] values)
		{
			if (adjacencyMatrix.Length == 0) {
				throw new ArgumentException("Adjacency matrix can not be empty.", nameof(adjacencyMatrix));
			}
			
			if (adjacencyMatrix.Any(inner => inner.Length == 0)) {
				throw new ArgumentException("Adjacency matrix can not have empty rows.", nameof(adjacencyMatrix));
			}
			
			if (adjacencyMatrix.Any(inner => inner.Length != adjacencyMatrix.Length)) {
				throw new ArgumentException("Adjacency matrix must be a square matrix.", nameof(adjacencyMatrix));
			}

			if (values.Length != adjacencyMatrix.Length) {
				throw new ArgumentException("Adjacency matrix and value array must be of the same length.", nameof(values));
			}

			for (var i = 0; i < adjacencyMatrix.Length; i++)
			{
				var node = new Node {Value = values[i], Number = i + 1};
				Nodes.Add(node);
			}
			
			for (var i = 0; i < adjacencyMatrix.Length; i++)
			{
				bool[] row = adjacencyMatrix[i];
				Node curNode = Nodes.Find(n => n.Number == i + 1);
				
				for (var j = 0; j < row.Length; j++)
				{
					if (row[j])
					{
						var edge = new Edge {Node = Nodes.Find(n => n.Number == j + 1)};
						curNode.Edges.Add(edge);
					}
				}
			}
		}


		public Node BFSearch(int value)
		{
			Console.WriteLine(new string('=', Console.BufferWidth));

			var first = Nodes.Find(n => n.Number == 1);

			if (first.Value == value)
			{
				Console.WriteLine($"Первая вершина графа является искомой: [{first.Number}:{first.Value}]. Возвращаем " +
				                  "её и завершаем работу алгоритма.");
				Console.WriteLine(new string('=', Console.BufferWidth));

				return first;
			}
			
			Console.WriteLine($"1) Кладём первую вершину в список посещенных: [{first.Number}:{first.Value}]");
			
			var visited = new List<Node> {first};
			var queue = new Queue<Node>();

			Console.Write("2) Кладём в очередь все вершины смежные с первой: ");
			foreach (var edge in first.Edges) 
			{
				queue.Enqueue(edge.Node);
				Console.Write($"[{edge.Node.Number}:{edge.Node.Value}]");
			}
			Console.WriteLine();


			while (queue.Count != 0)
			{
				var node = queue.Dequeue();
				Console.WriteLine($"3) Посещаем элемент в начале очереди: [{node.Number}:{node.Value}]");

				if (node.Value == value)
				{
					Console.WriteLine($"Текущая вершина графа является искомой: [{node.Number}:{node.Value}]. Возвращаем " +
				                   "её и завершаем работу алгоритма.");
					Console.WriteLine(new string('=', Console.BufferWidth));
					return node;
				}
				
				Console.Write("4) Кладём все непосещенные и отсутствующие в очереди вершины в очередь: ");
				foreach (var edge in node.Edges)
				{
					if (!visited.Contains(edge.Node) && !queue.Contains(edge.Node)) 
					{
						queue.Enqueue(edge.Node);
						Console.Write($"[{edge.Node.Number}:{edge.Node.Value}]");
					}
				}
				Console.WriteLine();
				
				Console.WriteLine("5) Помечаем текущую вершину как посещенную и переходим к следующему узлу в очереди.\n");
				visited.Add(node);
			}

			Console.WriteLine("Искомый элемент не был найден. Возвращаем null.");
			Console.WriteLine(new string('=', Console.BufferWidth));
			return null;
		}


		public Node DFSearch(int value)
		{
			Console.WriteLine(new string('=', Console.BufferWidth));

			var first = Nodes.Find(n => n.Number == 1);

			if (first.Value == value)
			{
				Console.WriteLine($"Первая вершина графа является искомой: [{first.Number}:{first.Value}]. Возвращаем " +
				                  "её и завершаем работу алгоритма.");
				Console.WriteLine(new string('=', Console.BufferWidth));

				return first;
			}
			
			Console.WriteLine($"1) Кладём первую вершину в список посещенных: [{first.Number}:{first.Value}]");
			
			var visited = new List<Node> {first};
			var stack = new Stack<Node>();

			Console.Write("2) Кладём в cтек все вершины смежные с первой: ");
			foreach (var edge in first.Edges) 
			{
				stack.Push(edge.Node);
				Console.Write($"[{edge.Node.Number}:{edge.Node.Value}]");
			}
			Console.WriteLine();


			while (stack.Count != 0)
			{
				var node = stack.Pop();
				Console.WriteLine($"3) Посещаем элемент в начале стека: [{node.Number}:{node.Value}]");

				if (node.Value == value)
				{
					Console.WriteLine($"Текущая вершина графа является искомой: [{node.Number}:{node.Value}]. Возвращаем " +
					                  "её и завершаем работу алгоритма.");
					Console.WriteLine(new string('=', Console.BufferWidth));
					return node;
				}
				
				Console.Write("4) Кладём все непосещенные и отсутствующие в стеке вершины в стек: ");
				foreach (var edge in node.Edges)
				{
					if (!visited.Contains(edge.Node) && !stack.Contains(edge.Node)) 
					{
						stack.Push(edge.Node);
						Console.Write($"[{edge.Node.Number}:{edge.Node.Value}]");
					}
				}
				Console.WriteLine();
				
				Console.WriteLine("5) Помечаем текущую вершину как посещенную и переходим к следующему узлу в стеке.\n");
				visited.Add(node);
			}

			Console.WriteLine("Искомый элемент не был найден. Возвращаем null.");
			Console.WriteLine(new string('=', Console.BufferWidth));
			return null;
		}
	}
}