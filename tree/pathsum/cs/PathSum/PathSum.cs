
namespace PathSumLib;

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

public class PathSum
{
    public bool HasPathSum(TreeNode root, int targetSum)
    {
        if(root == null)
            return false;

        if(targetSum - root.val == 0 && root.left == null && root.right == null)
            return true;

        targetSum -= root.val;

        var leftResult = HasPathSum(root.left, targetSum);
        var rightResult = HasPathSum(root.right, targetSum);

        return leftResult || rightResult;
    }
}

