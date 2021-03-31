using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Ex1Scheduler.LinkedList;
using Ex1Scheduler.Queue;

namespace AD
{
    public class Scheduler<T> : IScheduler<T>
    {
        private readonly MyLinkedList<T>[] priorityQueues;

        // Insert data members here

        public Scheduler()
        {
            this.priorityQueues = new MyLinkedList<T>[3];

            for (int i = 0; i < 3; i++) { this.priorityQueues[i] = new MyLinkedList<T>(); }
        }

        private static T Dequeue(MyLinkedList<T> linkedList)
        {
            T item = linkedList.GetFirst();
            linkedList.RemoveFirst();

            return item;
        }

        private static void Enqueue(MyLinkedList<T> linkedList, T item)
        {
            linkedList.AddLast(item);
        }

        private static int GetPriorityIndex(Priority priority)
        {
            int index;

            switch (priority)
            {
                case Priority.High:
                    index = 2;

                    break;
                case Priority.Medium:
                    index = 1;

                    break;
                case Priority.Low:
                default:
                    index = 0;

                    break;
            }

            return index;
        }

        private MyLinkedList<T> GetPriorityQueue(Priority priority) => this.priorityQueues[GetPriorityIndex(priority)];

        public void Enqueue(Priority priority, T Data) => this.priorityQueues[GetPriorityIndex(priority)].AddLast(Data);

        public T Dequeue()
        {
            bool wasFound        = false;
            T    dequeuedElement = default;

            for (int i = this.priorityQueues.Length - 1; i >= 0; i--)
            {
                if (this.priorityQueues[i].IsEmpty()) { continue; }

                if (wasFound && i < this.priorityQueues.Length - 1)
                {
                    Enqueue(this.priorityQueues[i + 1], Dequeue(this.priorityQueues[i]));

                    continue;
                }

                dequeuedElement = Dequeue(this.priorityQueues[i]);
                wasFound        = true;
            }

            return dequeuedElement;
        }

        override public string ToString()
        {
            string ToQueueString(string label, MyLinkedList<T> queue)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(label + ":[");


                if (!queue.IsEmpty())
                {
                    MyNode<T> current = queue.header;

                    

                    T[] nodes = new T[queue.Size()];

                    for (int index = 0; index < queue.Size(); index++)
                    {
                        nodes[index] = current.data;

                        current = current.next;
                    }

                    stringBuilder.Append(string.Join(",", nodes));
                }

                stringBuilder.Append("]");

                return stringBuilder.ToString();
            }

            return $"{{{ToQueueString("High", GetPriorityQueue(Priority.High))},{ToQueueString("Medium", GetPriorityQueue(Priority.Medium))},{ToQueueString("Low", GetPriorityQueue(Priority.Low))}}}";
        }
    }
}