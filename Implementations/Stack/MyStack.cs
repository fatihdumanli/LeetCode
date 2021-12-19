using System;

namespace Stack
{
    internal class StackNode
    {
        internal StackNode next;
        internal int val;

        public StackNode(int val)
        {
            this.val = val;
        }
    }
    
    public class MyStack
    {
        private StackNode _top;
        
        public void Push(int element) 
        {
            var newTop = new StackNode(element);
            newTop.next = _top;
            _top = newTop;
        }

        public int Pop()
        {
            if (_top == null)
                throw new InvalidOperationException("Stack is empty!");

            var val = _top.val;
            _top = _top.next;
            return val;
        }

        public bool IsEmpty() => _top == null;

        public int Peek()
        {
            if (_top == null)
                throw new InvalidOperationException("Stack is empty");
            return _top.val;
        }
        //Push()
        //Pop()
        //IsEmpty()
        //Peek()
    }
}