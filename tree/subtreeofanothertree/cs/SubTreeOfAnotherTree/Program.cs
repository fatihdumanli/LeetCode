public class TreeNode
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
        var root = new TreeNode(3);
        root.left = new TreeNode(4);
        root.right = new TreeNode(5);
        root.left.left = new TreeNode(1);
        root.left.right = new TreeNode(2);


        var subRoot = new TreeNode(4);
        subRoot.left = new TreeNode(1);
        subRoot.right = new TreeNode(3);

        var r = IsSubtree(root, subRoot);

        Console.Write(r);

    }

    static bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        if (root == null && subRoot == null)
            return true;

        if (root == null || subRoot == null)
            return false;

        var r = IsSameTree(root, subRoot);

        if (r)
            return true;

        var l = IsSubtree(root.left, subRoot);
        var right = IsSubtree(root.right, subRoot);

        return l || right;
    }

    static bool IsSameTree(TreeNode root1, TreeNode root2)
    {
        if (root1 == null && root2 == null)
            return true;

        if (root1 == null || root2 == null)
            return false;

        var isSame = root1.val == root2.val;

        var left = IsSameTree(root1.left, root2.left);
        var right = IsSameTree(root1.right, root2.right);

        return isSame && left && right;
    }
}

