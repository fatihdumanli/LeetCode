//var nums = new int[] { 0, 0, -1 };
//var nums = new int[] { 100, 200, 4, 3, 1, 2 };
//var nums = new int[] { -1, 0 };
//var nums = new int[] { 1, 2, 3, 0 };
var nums = new int[] { 1 };
var r = LongestConsecutive(nums);
Console.WriteLine(r);

//https://leetcode.com/problems/longest-consecutive-sequence/
int LongestConsecutive(int[] nums)
{
    var max = 0;
    var hashmap = new Dictionary<int, Node>();

    Node FindParent(Node node)
    {
        if (node.Parent == null)
            return node;

        return FindParent(node.Parent);
    }

    for (int i = 0; i < nums.Length; i++)
    {
        var num = nums[i];
        if (hashmap.ContainsKey(num))
            continue;

        var node = new Node();

        if (hashmap.ContainsKey(num - 1))
        {
            var prev = FindParent(hashmap[num - 1]);
            prev.Parent = node;
            node.Size += prev.Size;
        }

        if (hashmap.ContainsKey(num + 1))
        {
            var next = FindParent(hashmap[num + 1]);
            next.Parent = node;
            node.Size += next.Size;
        }

        hashmap[num] = node;
        max = Math.Max(max, node.Size);
    }

    return max;
}

class Node
{
    public int Size { get; set; }
    public Node Parent { get; set; }

    public Node()
    {
        this.Size = 1;
    }
}