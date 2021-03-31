using System.Text;

namespace Ex1Scheduler.LinkedList
{
    public class MyLinkedList<T> : IMyLinkedList<T>
    {
        public  MyNode<T> header;
        public  MyNode<T> tail;
        private int       size;

        public MyLinkedList()
        {
            this.header = null;
            this.tail   = null;
            this.size   = 0;
        }

        public bool IsEmpty()
        {
            return this.header == null;
        }

        //    O(1)
        public void AddFirst(T data)
        {
            MyNode<T> node = new MyNode<T> {data = data, next = this.header};

            this.header = node;

            if (this.header.next == null) { this.tail = this.header; }

            size++;
        }

        //    O(1)
        public T GetFirst()
        {
            if (this.header == null) { throw new MyLinkedListEmptyException(); }

            return this.header.data;
        }


        //    O(1)
        public void RemoveFirst()
        {
            if (this.header == null) { throw new MyLinkedListEmptyException(); }

            this.header = this.header.next;
            this.size--;
        }

        //    O(1)
        public void AddLast(T data)
        {
            if (this.size == 0)
            {
                AddFirst(data);

                return;
            }

            this.tail.next = new MyNode<T>() {data = data};
            this.tail      = this.tail.next;

            this.size++;
        }

        //    O(1)
        public T GetLast()
        {
            if (this.tail == null) { throw new MyLinkedListEmptyException(); }

            return this.tail.data;
        }

        //    O(1)
        public void RemoveLast()
        {
            if (this.tail == null) { throw new MyLinkedListEmptyException(); }

            this.tail = GetNode(this.size - 2);
            this.size--;
        }

        public T Get(int index)
        {
            return GetNode(index).data;
        }

        public MyNode<T> GetNode(int index)
        {
            MyNode<T> current = this.header;

            for (int i = 0; i < index; i++) { current = current.next ?? throw new MyLinkedListIndexOutOfRangeException(); }

            return current;
        }

        //    O(1)
        public int Size()
        {
            return this.size;
        }

        //    O(1)
        public void Clear()
        {
            this.header = null;
            this.size   = 0;
        }

        //    O(N)
        public void Insert(int index, T data)
        {
            if (index > this.size || index < 0) { throw new MyLinkedListIndexOutOfRangeException(); }

            MyNode<T> prevNode = this.header;

            if (index == 0)
            {
                AddFirst(data);

                return;
            }

            //    Move to the 'previous' node, so index - 1
            int currentIndex = 0;

            while (currentIndex < index - 1)
            {
                prevNode = prevNode.next;

                currentIndex++;
            }

            //    Determine 'next' node, either the previous node's next node or the header.
            MyNode<T> nextNode = prevNode.next;
            MyNode<T> newNode  = new MyNode<T> {data = data, next = nextNode};

            //    Increment size
            this.size++;

            //    Place node back onto the linked list
            if (nextNode == this.header)
            {
                this.header = newNode;

                return;
            }

            prevNode.next = newNode;

            if (newNode.next == null) { this.tail = newNode; }
        }

        public override string ToString()
        {
            if (this.header == null) { return "NIL"; }

            StringBuilder builder     = new StringBuilder("[");
            MyNode<T>     currentNode = this.header;

            builder.Append(currentNode.data);

            while (currentNode.next != null)
            {
                currentNode = currentNode.next;
                builder.Append(",");
                builder.Append(currentNode.data);
            }

            builder.Append("]");

            return builder.ToString();
        }
    }
}