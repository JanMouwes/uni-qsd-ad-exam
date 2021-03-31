using System.Collections.Generic;

namespace Ex1Scheduler.Queue
{
    public class MyQueue<T> : IMyQueue<T>
    {
        private readonly IList<T> list = new List<T>();

        public bool IsEmpty()
        {
            return this.list.Count == 0;
        }

        public void Enqueue(T data)
        {
            this.list.Insert(this.list.Count, data);
        }

        public T GetFront()
        {
            if (IsEmpty())
            {
                throw new MyQueueEmptyException();
            }

            return this.list[0];
        }

        public T Dequeue()
        {
            T item = GetFront();
            this.list.RemoveAt(0);
            return item;
        }

        public void Clear()
        {
            this.list.Clear();
        }
    }
}