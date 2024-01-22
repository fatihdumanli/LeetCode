namespace cs;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var nums = new int[] { -1, -2, 3, 4 };
        var k = 3;

        var r = MaxSubsequence(nums, k);
        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/find-subsequence-of-length-k-with-the-largest-sum/
    static int[] MaxSubsequence(int[] nums, int k) 
    {
        PriorityQueue<int, int> heap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => x.CompareTo(y)));

        var result = new int[k];

        for (int i = 0; i < nums.Length; i++)
        {
            heap.Enqueue(i, 0 - nums[i]);
        }

        var heapIndex = new PriorityQueue<int, int>();
        while (heap.Count > 0 && k > 0)
        {
            var val = heap.Dequeue();
            heapIndex.Enqueue(nums[val], val);
            k--;
        }

        var ctr = 0;
        while (heapIndex.Count > 0)
        {
            var val = heapIndex.Dequeue();
            result[ctr++] = val;
        }
        return result;
    }
}
