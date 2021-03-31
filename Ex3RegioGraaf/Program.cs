namespace AD
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Figuur 14.1 uit boek.
            Graph graph = new Graph();
            graph.GetVertex("V0");
            graph.GetVertex("V1");
            graph.GetVertex("V2");
            graph.GetVertex("V3");
            graph.GetVertex("V4");
            graph.GetVertex("V5");
            graph.GetVertex("V6");
            graph.AddEdge("V0", "V1", 2);
            graph.AddEdge("V0", "V3", 1);
            graph.AddEdge("V1", "V3", 3);
            graph.AddEdge("V1", "V4", 10);
            graph.AddEdge("V3", "V2", 2);
            graph.AddEdge("V3", "V5", 8);
            graph.AddEdge("V3", "V6", 4);
            graph.AddEdge("V3", "V4", 2);
            graph.AddEdge("V2", "V0", 4);
            graph.AddEdge("V2", "V5", 5);
            graph.AddEdge("V4", "V6", 6);
            graph.AddEdge("V6", "V5", 1);
            System.Console.WriteLine(graph);
            graph.Unweighted("V0");
            System.Console.WriteLine(graph);
            graph.Dijkstra("V0");
            System.Console.WriteLine(graph);

            // RegioGraaf tests
            graph = new Graph();
            graph.AddVertex("A", "Q");
            graph.AddVertex("B", "R");
            graph.AddVertex("C", "R");
            graph.AddVertex("D", "R");
            graph.AddVertex("E", "R");
            graph.AddVertex("F", "S");
            graph.AddVertex("G", "R");

            graph.AddUndirectedEdge("A", "B", 2);
            graph.AddUndirectedEdge("A", "C", 3);
            graph.AddUndirectedEdge("A", "G", 4);

            graph.AddUndirectedEdge("B", "C", 8);
            graph.AddUndirectedEdge("B", "D", 10);
            graph.AddUndirectedEdge("B", "F", 3);

            graph.AddUndirectedEdge("C", "E", 5);

            graph.AddUndirectedEdge("D", "E", 2);
            graph.AddUndirectedEdge("D", "F", 4);

            graph.Dijkstra("A");
            System.Console.WriteLine(graph.ToString());
            System.Console.WriteLine(graph.AllPaths());

        }
    }
}
