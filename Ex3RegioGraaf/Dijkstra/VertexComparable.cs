using System;
using AD;

namespace Ex3RegioGraaf.Dijkstra
{
    public struct VertexComparable : IComparable<VertexComparable>
    {
        public Vertex Vertex { get; set; }

        public double Dist { get; set; }
        public Vertex Prev { get; set; }

        public VertexComparable(Vertex vertex,  Vertex prev, double dist)
        {
            this.Prev = prev;
            this.Vertex = vertex;
            this.Dist   = dist;
        }

        public int CompareTo(VertexComparable other) => other.Dist > this.Dist ? -1 : other.Dist < this.Dist ? 1 : 0;
    }
}