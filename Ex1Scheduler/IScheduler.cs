namespace AD
{
    public enum Priority
    {
        High = 0,
        Medium = 1,
        Low = 2
    }

    interface IScheduler<T>
    {
        void Enqueue(Priority priority, T Data);
        T Dequeue();
    }
}
