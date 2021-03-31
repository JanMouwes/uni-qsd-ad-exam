namespace AD
{

    public interface IGraph
    {
        //----------------------------------------------------------------------
        // Methods that have to be implemented for exam
        //----------------------------------------------------------------------

        // Returns a vertex from the graph by name
        // If there is no such vertex, one is added
        Vertex GetVertex(string name);
        void AddEdge(string source, string dest, double cost);
        void ClearAll();
        
        //----------------------------------------------------------------------
        // Methods that have to be implemented for homework
        //----------------------------------------------------------------------
        void Unweighted(string name);
        void Dijkstra(string name);
        bool IsConnected();

        //----------------------------------------------------------------------
        // Methods that have to be implemented during exam
        //----------------------------------------------------------------------
        string AllPaths();
        void AddVertex(string name, string regio);
        void AddUndirectedEdge(string source, string dest, double cost);

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //!!
        //!! Vul deze klasse met je eigen Graph
        //!!
        //!! LET OP!
        //!! De namespace is "AD".
        //!! Waarschijnlijk zijn je uitwerkingen van het huiswerk nog "Huiswerk6"
        //!!
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

    }
}