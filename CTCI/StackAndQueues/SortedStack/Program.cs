using System;
using System.Collections.Generic;

namespace SortedStack
{
    public class SortedStack
    {
        private Stack<int> _stack = new Stack<int>();
        private Stack<int> _temp = new Stack<int>();
        
        public void Push(int val)
        {
            if (IsEmpty())
            {
                _stack.Push(val);
                return;
            }
            
            var top = _stack.Peek();
            while (val >= top)
            {
                _temp.Push(_stack.Pop());

                if (_stack.Count == 0)
                    break;
                
                top = _stack.Peek();
            }
            _stack.Push(val);
            
            while(_temp.Count > 0)
                _stack.Push(_temp.Pop());
        }

        public int Pop()
        {
            if (_stack.Count == 0)
                throw new InvalidOperationException($"Stack is empty!");

            return _stack.Pop();
        }

        public int Peek()
        {
            return _stack.Peek();
        }

        public bool IsEmpty() => _stack.Count == 0;

    }
    class Program
    {
        static void Main(string[] args)
        {
            var sortedStack = new SortedStack();
            
            sortedStack.Push(4);
            sortedStack.Push(5);
            sortedStack.Push(6);
            sortedStack.Push(3);
            sortedStack.Push(7);
            sortedStack.Push(2);
            sortedStack.Push(9);
            sortedStack.Push(1);

            while (!sortedStack.IsEmpty())
            {
                var min = sortedStack.Pop();
            }


            var stack = new Stack<int>();
            for (int i = 0; i < 5; i++)
            {
                var random = new Random();
                var randInt = random.Next(0, 100);
                stack.Push(randInt);
            }
            
            stack = Sort(stack);
        }

        public static Stack<int> Sort(Stack<int> stack)
        {
            if (stack.Count == 0)
                return stack;
            
            var temp = new Stack<int>();
            var popped = stack.Pop();
            temp.Push(popped);
            
            while (stack.Count > 0)
            {
                popped = stack.Pop();
                var top = temp.Peek();
             
                while (popped >= top)
                {
                    stack.Push(temp.Pop());
                    if (temp.Count == 0)
                        break;
                    top = temp.Peek();
                }

                temp.Push(popped);
            }

            return temp;

        }
    }
}
