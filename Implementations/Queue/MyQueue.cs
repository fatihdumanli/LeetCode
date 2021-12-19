using System;

namespace Queue
{
    internal class QueueNode
    {
        internal int val;
        internal QueueNode next;

        public QueueNode(int val)
        {
            this.val = val;
        }
    }

    public class MyQueue
    {
        private QueueNode first;
        private QueueNode last;

        public MyQueue()
        {
        }

        public int Peek()
        {
            if (first == null)
                throw new InvalidOperationException($"Queue is empty!");
            
            return first.val;
        }
        public int Dequeue()
        {
            if (first == null)
                throw new InvalidOperationException($"Queue is empty!");
            
            var val = first.val;
            first = first.next;
            return val;
        }

        
        public bool IsEmpty() => first == last;
        
        public void Enqueue(int item)
        {
            var newNode = new QueueNode(item);

            if (last == null)
                last = newNode;
            else
            {
                last.next = newNode;
                last = newNode;
            }
            first ??= last;
        }
    }
}