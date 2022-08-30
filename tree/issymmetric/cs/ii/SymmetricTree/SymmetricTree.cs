namespace SymmetricTreeLib;

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

public class SymmetricTree
{
    public bool IsSymmetric(TreeNode root)
    {
        if(root == null)
            return true;

        return IsSymmetric(root.left, root.right);
    }

    public bool IsSymmetric(TreeNode left, TreeNode right)
    {
        if(left == null && right == null)
            return true;

        if(left == null || right == null)
            return false;

        return left.val == right.val && IsSymmetric(left.left, right.right)
            && IsSymmetric(left.right, right.left);
    }
}
