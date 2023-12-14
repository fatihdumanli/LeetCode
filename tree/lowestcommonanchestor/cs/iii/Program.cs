namespace iii;

public class TreeNode
{
    public int val { get; set; }
    public TreeNode left { get; set; }

    public TreeNode right { get; set; }

    public TreeNode(int val)
    {
        this.val = val;
    }
    
    public TreeNode()
    {
    }
}

class Result
{
    public TreeNode val { get; set; }
}

class Program
{
    static void Main(string[] args)
    {

        var root = new TreeNode(3);
        root.left = new TreeNode(1);
        root.left.right = new TreeNode(2);

        root.right = new TreeNode(4);

        var r = LowestCommonAnchestor(root, root.left.right, root);

        Console.WriteLine(r.val);
    }

    // https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/
    static TreeNode LowestCommonAnchestor(TreeNode root, TreeNode p, TreeNode q)
    {
        var r = new Result();

        Helper(root, p, q, r);

        return r.val;
    }

    static bool Helper(TreeNode root, TreeNode p, TreeNode q, Result result)
    {
        if (root == null)
            return false;

        if (result.val != null)
            return false;

        var left = Helper(root.left, p, q, result);
        var right = Helper(root.right, p, q, result);

        if (left && right)
        {
            result.val = root;
            return true;
        }

        if ((left || right) && (root == p || root == q))
        {
            result.val = root;
            return true;
        }

        if (root == p || root == q)
            return true;


        return left || right;
    }
}

