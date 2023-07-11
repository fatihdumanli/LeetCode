// See https://aka.ms/new-console-template for more information
// 
// 
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
        //var root = new TreeNode(3);
        //root.left = new TreeNode(9);

        //root.right = new TreeNode(20);
        //root.right.left = new TreeNode(15);
        //root.right.right = new TreeNode(7);
        //
        var root = new TreeNode(1);
        root.right = new TreeNode(2);
        root.right.right = new TreeNode(3);
        root.right.right.right = new TreeNode(4);
        root.right.right.right.right = new TreeNode(5);

        var r = MinDepth(root);
        Console.Write(r);
    }


    // https://leetcode.com/problems/minimum-depth-of-binary-tree
    static int MinDepth(TreeNode root)
    {
        var r = Helper(root, 1);
        return r;
    }
    
    static int Helper(TreeNode root, int depth)
    {
        if(root == null)
            return Int32.MaxValue;

        if(root.left == null && root.right == null)
            return depth;

        var left = Helper(root.left, depth + 1);
        var right = Helper(root.right, depth + 1);

        return Math.Min(left, right);
    }
}
    
