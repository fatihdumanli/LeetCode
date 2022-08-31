namespace LowestCommonAnchestorLib;

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

public class LowestCommonAnchestor
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null)
            return null;

        if (root == p)
            return p;

        if (root == q)
            return q;

        var leftResult = LowestCommonAncestor(root.left, p, q);
        var rightResult = LowestCommonAncestor(root.right, p, q);

        if (leftResult == null && rightResult == null)
            return null;

        if (root == p || root == q)
            return root;

        if (rightResult == null)
            return leftResult;

        if (leftResult == null)
            return rightResult;

        return root;
    }
}
