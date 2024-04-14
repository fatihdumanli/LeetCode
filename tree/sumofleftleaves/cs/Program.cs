using System.Security;

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
        var root = new TreeNode(7);
        root.left = new TreeNode(11);
        root.left.left = new TreeNode(2);
        root.left.right = new TreeNode(8);
        root.left.right.right = new TreeNode(14);
        root.left.right.left = new TreeNode(15);
        root.left.right.left.left = new TreeNode(1);
        root.right = new TreeNode(9);

        var r = SumOfLeftLeaves(root);
        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/sum-of-left-leaves
    static int SumOfLeftLeaves(TreeNode root)
    {
        if (root == null)
            return Int32.MinValue;

        var sum = 0;

        if (root.left != null)
        {
            if (root.left.left == null && root.left.right == null)
                sum += root.left.val;
        }

        var l = SumOfLeftLeaves(root.left);
        var r = SumOfLeftLeaves(root.right);

        if (l != Int32.MinValue)
            sum += l;

        if (r != Int32.MinValue)
            sum += r;

        return sum;
    }
}
