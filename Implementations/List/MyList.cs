using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace List
{
    public class MyList
    {
        private const int INITIAL_CAPACITY = 100;
        private int[] _array;
        private int _ptr = 0;
        
        public MyList()
        {
            _array = new int[INITIAL_CAPACITY];
        }

        public MyList(int capacity)
        {
            _array = new int[capacity];
        }
        
        //Takes O(1) (Amortized insertion runtime) - Each resizing takes O(N)
        public void Add(int value)
        {
            if (_ptr == _array.Length)
                Resize();
            
            _array[_ptr++] = value;
        }

        //Takes O(N)
        public int IndexOf(int value)
        {
            var ptr = -1;
            while (ptr < _ptr)
            {
                if (_array[++ptr] == value)
                    return ptr;
            }
            return -1;
        }
        
        
        //Remove the first occurence.
        //Takes O(N)
        public void Remove(int value)
        {
            var index = IndexOf(value);

            if (index == -1)
                return;

            //Shifting
            for (; index < _ptr - 1; index++)
            {
                _array[index] = _array[index + 1];
            }

            _ptr--;
        }
        
        //Takes O(N)
        public bool Contains(int value)
        {
            var ptr = 0;
            while (ptr < _ptr)
            {
                if (_array[ptr++] == value)
                    return true;
            }

            return false;
        }

        //Takes O(N)
        private void Resize()
        {
            var temp = _array;
            _array = new int[_array.Length * 2];

            for (int i = 0; i < temp.Length; i++)
            {
                _array[i] = temp[i];
            }

            _ptr = temp.Length;
        }
        
    }
}
