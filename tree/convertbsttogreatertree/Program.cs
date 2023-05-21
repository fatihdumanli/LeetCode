namespace convertbsttogreatertree;

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

        var r = ConvertBST(root);
        Console.Read();
    }

    // https://leetcode.com/problems/convert-bst-to-greater-tree/
    static TreeNode ConvertBST(TreeNode root)
    {
        if (root == null)
            return null;

        BFS(0, root);

        return root;
    }

    static int BFS(int initialValue, TreeNode root)
    {
        if (root == null)
            return 0;

        var rightSum = BFS(initialValue, root.right);

        var cumulative = root.val + rightSum;

        root.val += initialValue;
        root.val += rightSum;

        var leftSum = BFS(initialValue + cumulative, root.left);
        cumulative += leftSum;

        return cumulative;
    }
}
