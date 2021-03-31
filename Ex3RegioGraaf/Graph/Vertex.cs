using System.Collections.Generic;
using System.Linq;

namespace AD
{
    public class Vertex : IVertex
    {
        public readonly string Name;

        public readonly LinkedList<Edge> Edges;
        
        public readonly HashSet<string> visitedRegions = new HashSet<string>();

        #region Search-specific attributes

        public double  Dist;
        public IVertex Prev;
        public bool    Known = false; //    Scratch

        #endregion

        private string regio;

        public Vertex(string name)
        {
            this.Name = name;

            this.Edges = new LinkedList<Edge>();
        }
        
        public Vertex(string name, string regio) : this(name)
        {
            this.regio = regio;
        }

        public void Reset()
        {
            this.Known = false;
            this.Dist  = int.MaxValue;
            
            this.visitedRegions.Clear();
        }

      


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented during exam
        //----------------------------------------------------------------------

        public string GetName()
        {
            return this.Name;
        }


        public string GetRegio()
        {
            return this.regio;
        }


        //----------------------------------------------------------------------
        // ToString that has to be implemented for exam
        //----------------------------------------------------------------------

//        public override string ToString()
           //        {
           //            throw new System.NotImplementedException();
           //        }
        
        public override string ToString()
        {
            string currentVertexString = this.Known ? $"{this.Name}({this.Dist})" : this.Name;
            string neighbourString     = this.Edges.Any() ? $" [ {string.Join(" ", this.Edges.Select(edge => $"{edge.dest.Name}({edge.cost})"))} ] " : string.Empty;

            return currentVertexString + neighbourString;
        }

    }
}