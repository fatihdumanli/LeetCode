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
class MaxPathResult
{
    public int max { get; set; }
}
class Program
{
    static void Main(string[] args)
    {
        var root = new TreeNode(-10);
        root.left = new TreeNode(9);
        root.right = new TreeNode(20) { left = new TreeNode(15), right = new TreeNode(7) };
        var result = MaxPathSum(root);

    }

    public static int MaxPathSum(TreeNode root)
    {
        var result = new MaxPathResult();
        result.max = root.val;

        Helper(root, result);
        return result.max;
    }

    public static int Helper(TreeNode root, MaxPathResult result)
    {
        if (root == null)
            return 0;

        var left = Helper(root.left, result);
        var right = Helper(root.right, result);

        result.max = Math.Max(result.max, left + root.val);
        result.max = Math.Max(result.max, right + root.val);
        result.max = Math.Max(result.max, left + right + root.val);
        result.max = Math.Max(result.max, root.val);


        var maxLocalPath = Math.Max(Math.Max(root.val + left, root.val + right), root.val);
        return maxLocalPath;
    }
}









