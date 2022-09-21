namespace FindKthLargestElement;

public class MaxHeap
{
    private int[] _array;
    private int _ptr = 1;

    public MaxHeap(int capacity)
    {
        this._array = new int[capacity + 1];
    }

    public void Add(int val)
    {
        _array[_ptr] = val;

        var ptr = _ptr;
        var parentIdx = ptr / 2;

        while (parentIdx >= 1 && _array[parentIdx] <= val)
        {
            var parentVal = _array[parentIdx];

            _array[parentIdx] = val;
            _array[ptr] = parentVal;

            ptr = parentIdx;
            parentIdx = ptr / 2;
        }

        _ptr++;
    }

    public int ExtractMax()
    {
        var maxVal = _array[1];

        var leftPtr = 2;
        var rightPtr = 3;

        //put the last leaf to the root
        _array[1] = _array[_ptr - 1];

        var ptr = 1;

        //bubble it down
        while ((leftPtr < _ptr && rightPtr < _ptr) && (_array[leftPtr] > _array[ptr] || _array[rightPtr] > _array[ptr]))
        {
            var tempVal = _array[ptr];

            if (_array[leftPtr] >= _array[rightPtr])
            {
                _array[ptr] = _array[leftPtr];
                _array[leftPtr] = tempVal;
                ptr = leftPtr;
            }
            else
            {
                _array[ptr] = _array[rightPtr];
                _array[rightPtr] = tempVal;
                ptr = rightPtr;
            }

            leftPtr = ptr * 2;
            rightPtr = leftPtr + 1;
        }

        _ptr--;
        return maxVal;
    }
}



public class KthLargestElementFinder
{
    public int FindKthLargest(int[] nums, int k)
    {
        var heap = new MaxHeap(capacity: nums.Length);

        foreach (var item in nums)
        {
            heap.Add(item);
        }

        int val = 0;

        for (int i = 0; i < k; i++)
        {
            val = heap.ExtractMax();
        }

        return val;
    }
}

