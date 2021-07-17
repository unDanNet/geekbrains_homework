namespace lesson_6
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			var adj = new [] {
				new[] {false, true, true, false, false, false, false}, // 1
				new[] {true, false, false, false, true, false, true}, // 2
				new[] {true, false, false, true, false, false, false}, // 3
				new[] {false, false, true, false, false, true, true}, // 4
				new[] {false, true, false, false, false, true, true}, // 5
				new[] {false, false, false, true, true, false, false}, // 6
				new[] {false, true, false, true, true, false, false} // 7
				//		1		2	   3	  4     5      6      7
			};

			var values = new[] {25, 50, 0, -25, 75, 100, -50};
			
			var graph = new Graph(adj, values);

			graph.BFSearch(-50);
			graph.BFSearch(100);
			graph.BFSearch(25);
			
			graph.DFSearch(-50);
			graph.DFSearch(100);
			graph.DFSearch(25);
		}
	}
}