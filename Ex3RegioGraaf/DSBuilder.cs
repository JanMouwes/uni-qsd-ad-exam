namespace AD
{
    public class DSBuilder
    {
        public static IGraph CreateGraphEmpty()
        {
            return new Graph();
        }

        public static IGraph CreateGraph14_1()
        {
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

            return graph;
        }
    }
}
