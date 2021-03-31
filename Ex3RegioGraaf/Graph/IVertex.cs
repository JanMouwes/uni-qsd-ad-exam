namespace AD
{
    public interface IVertex
    {
        //----------------------------------------------------------------------
        // Methods that have to be implemented for exam
        //----------------------------------------------------------------------
        void Reset();  // Resets prev, dist and scratch for a vertex

        //----------------------------------------------------------------------
        // Methods that have to be implemented during exam
        //----------------------------------------------------------------------
        string GetName();
        string GetRegio();
    }
}
