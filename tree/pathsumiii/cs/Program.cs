class TreeNode
{
    public int val { get; set; }
    public TreeNode left { get; set; }
    public TreeNode right { get; set; }

    public TreeNode(int val)
    {
        this.val = val;
    }
}

class PathSumResult
{
    public int Total { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var root = new TreeNode(1000000000);
        root.left = new TreeNode(1000000000);
        root.left.left = new TreeNode(294967296);
        root.left.left.left = new TreeNode(1000000000);
        root.left.left.left.left = new TreeNode(1000000000);
        root.left.left.left.left.left = new TreeNode(1000000000);

        var r = PathSum(root, 0);
        Console.WriteLine(r);
    }

    public static int PathSum(TreeNode root, int targetSum)
    {
        if (root == null)
            return 0;

        var result = new PathSumResult();

        if (root.val == targetSum)
            result.Total++;

        IterateOverChildren(root.left, root.val, targetSum, result);
        IterateOverChildren(root.right, root.val, targetSum, result);

        return result.Total + PathSum(root.left, targetSum) + PathSum(root.right, targetSum);
    }

    public static void IterateOverChildren(TreeNode root, long sum, long targetSum, PathSumResult result)
    {
        if (root == null)
            return;

        if (sum + root.val == targetSum)
            result.Total++;

        IterateOverChildren(root.left, sum + root.val, targetSum, result);
        IterateOverChildren(root.right, sum + root.val, targetSum, result);
    }
}
