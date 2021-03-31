using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Ex3RegioGraaf.Dijkstra;
using Ex3RegioGraaf.PriorityQueue;


namespace AD
{
    public class Graph : IGraph
    {
        public static readonly double INFINITY = System.Double.MaxValue;

        private Dictionary<string, Vertex> vertexMap;


        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Graph()
        {
            this.vertexMap = new Dictionary<string, Vertex>();
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public Vertex GetVertex(string name)
        {
            if (!this.vertexMap.ContainsKey(name)) { this.vertexMap[name] = new Vertex(name); }

            return this.vertexMap[name];
        }

        public void AddEdge(string source, string dest, double cost)
        {
            Vertex sourceVertex = GetVertex(source);
            Vertex destVertex   = GetVertex(dest);

            Edge edge = new Edge(destVertex, cost);

            sourceVertex.Edges.AddLast(edge);
        }

        public void ClearAll()
        {
            foreach ((string _, Vertex vertex) in this.vertexMap) { vertex.Edges.Clear(); }
        }


        //----------------------------------------------------------------------
        // ToString that has to be implemented for exam
        //----------------------------------------------------------------------

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach ((string _, Vertex vertex) in this.vertexMap)
            {
                stringBuilder.Append(vertex);
                stringBuilder.Append("\n");
            }

            return stringBuilder.ToString();
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public void Unweighted(string name)
        {
            Queue<(Vertex, double)> vertexQueue = new Queue<(Vertex, double)>();

            Vertex origin = GetVertex(name);

            vertexQueue.Enqueue((origin, 0));

            while (vertexQueue.Count > 0)
            {
                (Vertex current, double dist) = vertexQueue.Dequeue();

                if (current.Known) continue;

                current.Known = true;
                current.Dist  = dist;

                IEnumerable<Vertex> unknownVerteces = current.Edges.Where(currentEdge => !currentEdge.dest.Known)
                                                             .Select(edge => edge.dest);

                foreach (Vertex currentVertex in unknownVerteces) { vertexQueue.Enqueue((currentVertex, current.Dist + 1.0)); }
            }
        }

        public void Dijkstra(string name)
        {
            PriorityQueue<VertexComparable> priorityQueue = new PriorityQueue<VertexComparable>();

            Vertex vertex = GetVertex(name);
            priorityQueue.Add(new VertexComparable {Vertex = vertex, Dist = 0});

            do
            {
                VertexComparable vertexComparable = priorityQueue.Remove();
                vertex = vertexComparable.Vertex;

                if (vertex.Known) { continue; }

                if (vertexComparable.Prev != null)
                {
                    foreach (string prevVisitedRegion in vertexComparable.Prev.visitedRegions) { vertex.visitedRegions.Add(prevVisitedRegion); }

                    if (vertexComparable.Prev.GetRegio() != vertex.GetRegio()) { vertex.visitedRegions.Add(vertexComparable.Prev.GetRegio()); }
                }

                vertex.Dist = vertexComparable.Dist;

                vertex.Prev = vertexComparable.Prev;

                vertex.Known = true;

                IEnumerable<Edge> vertexRange = vertex.Edges.Where(vertexEdge => !vertexEdge.dest.Known && !vertex.visitedRegions.Contains(vertexEdge.dest.GetRegio()));


                foreach (Edge edge in vertexRange)
                {
                    VertexComparable comparable = new VertexComparable(edge.dest, vertex, vertex.Dist + edge.cost);

                    priorityQueue.Add(comparable);
                }
            } while (priorityQueue.Size() > 0);
        }

        public bool IsConnected()
        {
            bool CanReachNode(Vertex nodeOne, Vertex nodeTwo, IEnumerable<Vertex> visitedNodes)
            {
                if (nodeOne.Edges.Any(edge => edge.dest == nodeTwo)) return true;

                if (nodeOne.Edges.Count == 0) return false;

                ICollection<Vertex> newVisitedNodes = new LinkedList<Vertex>(visitedNodes);
                newVisitedNodes.Add(nodeOne);

                return nodeOne.Edges.Where(edge => !newVisitedNodes.Contains(edge.dest))
                              .Select(edge => CanReachNode(edge.dest, nodeTwo, newVisitedNodes))
                              .FirstOrDefault();
            }

            bool CanReachAllNodes(Vertex vertex) => this.vertexMap.Values.All(otherVertex => CanReachNode(vertex, otherVertex, new List<Vertex>()));

            return this.vertexMap.Values.All(CanReachAllNodes);
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented during exam
        //----------------------------------------------------------------------

        public string AllPaths()
        {
            StringBuilder builder = new StringBuilder();

            foreach ((string key, Vertex vertex) in this.vertexMap)
            {
                string currentKey = key;
                builder.Append(currentKey);

                while (currentKey != "")
                {
                    Vertex current = this.vertexMap[currentKey];

                    if (current.Prev == null) break;

                    builder.Append("<-" + current.Prev.GetName());
                    currentKey = this.vertexMap[currentKey].Prev.GetName();
                }

                builder.Append(";");
            }

            return builder.ToString();
        }

        public void AddUndirectedEdge(string source, string dest, double cost)
        {
            GetVertex(source).Edges.AddLast(new Edge(GetVertex(dest), cost));
            GetVertex(dest).Edges.AddLast(new Edge(GetVertex(source), cost));
        }

        public void AddVertex(string name, string regio)
        {
            this.vertexMap[name] = new Vertex(name, regio);
        }
    }
}