using System;

namespace Ex1Scheduler.Queue
{
    public interface IMyQueue<T>
    {
        bool IsEmpty();
        void Enqueue(T data);
        T GetFront();
        T Dequeue();
        void Clear();
    }

    public class MyQueueEmptyException : Exception
    {
    }
}