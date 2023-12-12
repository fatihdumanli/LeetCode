namespace ii;

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

class Program
{
    static void Main(string[] args)
    {
        var root = new TreeNode(3);
        root.left = new TreeNode(1);
        root.left.right = new TreeNode(2);

        root.right = new TreeNode(4);


        var r = KthSmallest(root, 3);
        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/kth-smallest-element-in-a-bst
    static int KthSmallest(TreeNode root, int k) 
    {
        var result = Helper(root, k);

        return result.Item1;
    }

    // First return value is result
    // While second is k
    // Treating Int32.MinValue as error code
    // If the result != Int32.MinValue - treating it as a result
    static (int, int) Helper(TreeNode root, int k)
    {
        if (root == null)
            return (Int32.MinValue, k);;

        var left = Helper(root.left, k);

        if (left.Item1 != Int32.MinValue)
            return (left.Item1, 0);

        // Check if we've run out of k's
        var result = left.Item2 - 1;

        if (result == 0)
            return (root.val, 0);

        // Initiate right branching with new k value - as it's inorder traversal
        var right = Helper(root.right, result);

        if (right.Item1 != Int32.MinValue)
            return (right.Item1, 0);

        return (Int32.MinValue, right.Item2);
    }

}
