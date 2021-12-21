using System;
using System.Collections.Generic;

namespace SetOfStacks
{
    public class StackNode
    {
        public int val;
        public StackNode next;

        public StackNode(int val)
        {
            this.val = val;
        }
    }
    
    public class SetOfStack
    {
        private int _capacityPerStack;
        private int _numOfStacks = 1;
        private int _size = 0;
        private StackNode[] _stackNodes = new StackNode[1];

        public SetOfStack(int capacityPerStack)
        {
            _capacityPerStack = capacityPerStack;
        }

        public bool IsEmpty() => _size == 0;
        private bool IsCapacityFull() => _size >= (_numOfStacks * _capacityPerStack);
        public void Push(int val)
        {
            if (IsCapacityFull())   
                Resize();
            
            var newNode = new StackNode(val);
            var stackHead = _stackNodes[_numOfStacks - 1];
            if (stackHead == null)
            {
                _stackNodes[_numOfStacks - 1] = newNode;
                _size++;
                return;
            }

            var temp = stackHead;
            newNode.next = temp;
            _stackNodes[_numOfStacks - 1] = newNode;
            _size++;
        }

        public int PopFrom(int stackNumber)
        {
            if (stackNumber > _numOfStacks)
                throw new InvalidOperationException($"No such stack!");
            
            var stackHead = _stackNodes[stackNumber - 1];

            if (stackHead == null)
                throw new InvalidOperationException("Stack is empty!");
            
            var val = stackHead.val;
            _stackNodes[stackNumber - 1] = _stackNodes[stackNumber - 1].next;

            if (_stackNodes[stackNumber - 1] == null)
                ShiftFrom(stackNumber);
            
            _size--;
            return val;
        }
        
        private void ShiftFrom(int stackNumber)
        {
            for (int i = stackNumber - 1; i < _numOfStacks - 1; i++)
            {
                _stackNodes[i] = _stackNodes[i + 1];
            }
            _stackNodes[stackNumber] = null;
            _numOfStacks--;
        }

        public int Pop()
        {
            var currentStackHead = _stackNodes[_numOfStacks - 1];

            if (currentStackHead == null)
                throw new InvalidOperationException($"Stack is empty!");
            
            var val = currentStackHead.val;
            _stackNodes[_numOfStacks - 1] = _stackNodes[_numOfStacks - 1].next;

            if (_stackNodes[_numOfStacks - 1] == null)
                ShrinkStack();
            
            _size--;
            return val;
        }

        private void ShrinkStack()
        {
            var temp = _stackNodes;

            _numOfStacks--;
            
            if (_numOfStacks == 0)
                _numOfStacks++;
            
            _stackNodes = new StackNode[_numOfStacks];

            for (int i = 0; i < _numOfStacks; i++)
                _stackNodes[i] = temp[i];
        }

        public int Peek()
        {
            var currentStackHead = _stackNodes[_numOfStacks - 1];
            
            if (currentStackHead == null)
                throw new InvalidOperationException($"Stack is empty!");

            return currentStackHead.val;
        }
        
        private void Resize()
        {
            var temp = _stackNodes;
            _stackNodes = new StackNode[temp.Length * 2];

            for (int i = 0; i < temp.Length; i++)
            {
                _stackNodes[i] = temp[i];
            }

            _numOfStacks++;
        }
        
        
        
        
    }
}