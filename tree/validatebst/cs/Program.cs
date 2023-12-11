namespace cs;

class TreeNode
{
    public int val { get; set; }
    
    public TreeNode left { get; set; }

    public TreeNode right { get; set; }

    public TreeNode(int val) => this.val = val;
}

class Program
{
    static void Main(string[] args)
    {
        var root = new TreeNode(5);
        root.left = new TreeNode(4);
        root.right = new TreeNode(6);
        root.right.left = new TreeNode(3);
        root.right.right = new TreeNode(7);

        var r = IsValidBST(root);

        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/validate-binary-search-tree
    static bool IsValidBST(TreeNode root)
    {
        return IsValid(root, min: Int32.MinValue, max: Int32.MaxValue);
    }

    // Force boundaries for every single node
    // Strict conditions cannot be loosened and vice versa
    static bool IsValid(TreeNode root, int min, int max)
    {
        if (root == null)
            return true;

        var left = IsValid(root.left, min, max: Math.Min(max, root.val - 1));

        var right = IsValid(root.right, min: Math.Max(min, root.val + 1), max: max);

        if (root.val > max || root.val < min)
            return false;

        if (root.left != null && root.left.val >= root.val)
            return false;

        if (root.right != null && root.right.val <= root.val)
            return false;

        return left && right;
    }
}
