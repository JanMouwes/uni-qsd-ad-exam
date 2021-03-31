using System;

namespace Ex1Scheduler.LinkedList
{
    public interface IMyLinkedList<T>
    {
        // Add an item to the start of the list
        void AddFirst(T data);

        // Returns the first item of the list
        T GetFirst();

        // Remove the first item of the list
        void RemoveFirst();

        // Obtain the size of the list
        int Size();

        // Clear the list
        void Clear();

        // Insert an item on a specific index (insert, not overwrite!)
        void Insert(int index, T data);
    }

    public class MyLinkedListEmptyException : Exception
    {
    }

    public class MyLinkedListIndexOutOfRangeException : Exception
    {
    }
}
