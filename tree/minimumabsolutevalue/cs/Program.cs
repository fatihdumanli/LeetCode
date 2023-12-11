namespace cs;


class TreeNode
{
    public int val { get; set; }
    
    public TreeNode left { get; set; }

    public TreeNode right { get; set; }

    public TreeNode(int _val)
    {
        val = _val;
    }
}

class Result
{
    public int prevVal { get; set; }
    public int min { get; set; }
}

class Program
{
    static void Main(string[] args)
    {

        var root = new TreeNode(600);
        root.left = new TreeNode(550);
        root.left.left = new TreeNode(547);
        root.left.right = new TreeNode(592);

        root.right = new TreeNode(610);
        root.right.left = new TreeNode(606);
        root.right.left.left = new TreeNode(601);
        root.right.left.right = new TreeNode(608);
        root.right.right = new TreeNode(612);
        root.right.right.right = new TreeNode(615);

        var r = GetMinimumDifference(root);
        
        Console.Write(r);
    }

    // https://leetcode.com/problems/minimum-absolute-difference-in-bst
    // Inorder traversal will process all the nodes in order - from smallest to
    // the greatest.
    //
    // When we have all the nodes in sorted order, all we need to do is
    // interfere when the node is being processed.
    //
    // Save the current node to heap (memory).
    // When the next node is being processed, access the last procssed node.
    // Calculate global min -> min = Math.Min(prev, Math.Abs(prev - root.val))
    static int GetMinimumDifference(TreeNode root)
    {
        var result = new Result();
        result.min = Int32.MaxValue;
        result.prevVal = Int32.MaxValue;

        Helper(root, result);

        return result.min;
    }

    static void Helper(TreeNode root, Result result)
    {
        if (root == null)
            return;

        Helper(root.left, result);
        result.min = Math.Min(result.min, Math.Abs(result.prevVal - root.val));
        result.prevVal = root.val;
        Helper(root.right, result);
    }
}
