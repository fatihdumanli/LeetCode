namespace cs;

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

class Program
{
    static void Main(string[] args)
    {
        var root = new TreeNode(4);
        root.left = new TreeNode(1);
        root.left.left = new TreeNode(0);
        root.left.right = new TreeNode(2);
        root.left.right.right = new TreeNode(3);

        root.right = new TreeNode(6);
        root.right.left = new TreeNode(5);
        root.right.right = new TreeNode(7);
        root.right.right.right = new TreeNode(8);

        var r = BstToGst(root);
    }

    // https://leetcode.com/problems/binary-search-tree-to-greater-sum-tree/
    static TreeNode BstToGst(TreeNode root)
    {
        Helper(0, root);

        return root;
    }

    static int Helper(int sum, TreeNode root)
    {
        if (root == null)
            return 0;

        var r = Helper(sum, root.right);

        var prevRootVal = root.val;

        root.val = r == 0 ? sum + r + prevRootVal : r + prevRootVal;

        var l = Helper(root.val, root.left);

        return l == 0 ? root.val : l;
    }
}
