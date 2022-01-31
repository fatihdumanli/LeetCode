using System;

namespace StringBuilder
{
    public class MyStringBuilder
    {
        private const int ARRAY_SIZE = 50;
        private char[] _array = new char[ARRAY_SIZE];
        private int _ptr = 0;
        
        public void Append(string phrase)
        {
            if (_ptr + phrase.Length > _array.Length)
            {
                Resize();
            }
            foreach (var c in phrase)
                _array[_ptr++] = c;
        }

        private void Resize()
        {
            var temp = _array;
            _array = new char[_array.Length * 2];

            for (int i = 0; i < _ptr; i++)
            {
                _array[i] = temp[i];
            }
        }
        
        public override string ToString()
        {
            return new string(_array);
        }
    }
}
