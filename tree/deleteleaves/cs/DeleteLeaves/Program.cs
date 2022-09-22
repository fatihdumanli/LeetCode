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
        var root = new TreeNode(1);
        root.left = new TreeNode(1);
        root.right = new TreeNode(1);

        var newRoot = RemoveLeafNodes(root, 2);

        var x = 2;

    }

    static TreeNode RemoveLeafNodes(TreeNode root, int target)
    {
        Helper(root, target);

        if (root == null)
            return null;

        if (root.left == null && root.right == null && root.val == target)
            return null;

        return root;
    }

    static bool Helper(TreeNode node, int target)
    {
        if (node == null)
            return false;

        var leftResult = Helper(node.left, target);

        if (leftResult)
            node.left = null;

        var rightResult = Helper(node.right, target);

        if (rightResult)
            node.right = null;

        if (node.left == null && node.right == null && node.val == target)
            return true;

        return false;
    }
}
