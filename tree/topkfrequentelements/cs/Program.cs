class HeapNode
{
    public int freq { get; set; }
    public int val { get; set; }

    public HeapNode(int val, int freq)
    {
        this.val = val;
        this.freq = freq;
    }
}
class MaxHeap
{
    private List<HeapNode> maxHeap;

    private int size = 0;

    public MaxHeap()
    {
        maxHeap = new List<HeapNode>();
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    public void AddNum(int val, int freq)
    {
        maxHeap.Add(new HeapNode(val, freq));
        size++;

        var idx = size - 1;
        var parentIdx = idx / 2;

        while (idx > 0 && maxHeap[idx].freq > maxHeap[parentIdx].freq)
        {
            var parentVal = maxHeap[parentIdx];
            maxHeap[parentIdx] = maxHeap[idx];
            maxHeap[idx] = parentVal;

            idx = parentIdx;
            parentIdx = idx / 2;
        }
    }

    public HeapNode ExtractMax()
    {
        if (size == 0)
        {
            throw new InvalidOperationException("the heap is empty");
        }

        var max = maxHeap[0];

        if (size == 1)
        {
            maxHeap[0] = null;
            size = 0;
            return max;
        }

        maxHeap[0] = maxHeap[size - 1];
        maxHeap[size - 1] = null;
        size--;

        var idx = 0;

        var leftVal = Int32.MinValue;
        var rightVal = Int32.MinValue;

        var leftIdx = 1;
        var rightIdx = 2;

        if (leftIdx < size)
            leftVal = maxHeap[leftIdx].freq;

        if (rightIdx < size)
            rightVal = maxHeap[rightIdx].freq;

        while (leftVal > maxHeap[idx].freq || rightVal > maxHeap[idx].freq)
        {
            int indexToSwap = -1;

            if (leftVal > rightVal)
                indexToSwap = leftIdx;
            else
                indexToSwap = rightIdx;

            var temp = maxHeap[idx];

            maxHeap[idx] = maxHeap[indexToSwap];
            maxHeap[indexToSwap] = temp;

            idx = indexToSwap;

            leftIdx = 2 * idx;
            rightIdx = (2 * idx) + 1;

            leftVal = Int32.MinValue;
            rightVal = Int32.MinValue;

            if (leftIdx < size)
                leftVal = maxHeap[leftIdx].freq;

            if (rightIdx < size)
                rightVal = maxHeap[rightIdx].freq;
        }

        return max;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var nums = new int[] { 1, 2, 2 };
        var r = TopKFrequent(nums, 1);
        Console.WriteLine(r);
    }

    public static int[] TopKFrequent(int[] nums, int k)
    {
        var hashmap = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (hashmap.ContainsKey(num))
            {
                hashmap[num]++;
            }
            else
            {
                hashmap.Add(num, 1);
            }
        }

        var maxHeap = new MaxHeap();

        foreach (var item in hashmap)
        {
            maxHeap.AddNum(item.Key, item.Value);
        }

        var result = new int[k];

        for (int i = 0; i < k; i++)
        {
            result[i] = maxHeap.ExtractMax().val;
        }

        return result;
    }
}
