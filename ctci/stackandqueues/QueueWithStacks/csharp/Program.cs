using System;
using System.Collections.Generic;

namespace QueueWithStacks
{
    public class MyQueue {

    
        private Stack<int> stack;
        private Stack<int> temp;
    
        public MyQueue() {
            stack = new Stack<int>();
            temp = new Stack<int>();
        }
    
        public void Push(int x) {
            stack.Push(x);        
        }
    
        /*
            count: 2
            
            | |   | |
            |2|   | |
        */
        public int Pop() {
        
            for(int i = 0; i < stack.Count - 1; i++)
            {
                var popped = stack.Pop();
                temp.Push(popped);
            }
        
            var last = stack.Pop();
        
            while(temp.Count > 0)
            {
                stack.Push(temp.Pop());
            }
        
            return last;
        }
    

        public int Peek() {
        
            for(int i = 0; i < stack.Count; i++)
            {
                temp.Push(stack.Pop());
            }
        
            var val = temp.Peek();
        
            while(temp.Count > 0)
            {
                stack.Push(temp.Pop());
            }
            return val;       
        }
    
        public bool Empty() => stack.Count == 0;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var myQueue = new MyQueue();
            myQueue.Push(1);
            myQueue.Push(2);

            var res = myQueue.Peek();
            Console.WriteLine("Hello World!");
        }
    }
}
