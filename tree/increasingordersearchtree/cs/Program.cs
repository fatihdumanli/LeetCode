class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var root = new TreeNode(5);
        root.left = new TreeNode(3);
        root.left.left = new TreeNode(2);
        root.left.left.left = new TreeNode(1);
        root.left.right = new TreeNode(4);

        root.right = new TreeNode(6);
        root.right.right = new TreeNode(8);
        root.right.right.left = new TreeNode(7);
        root.right.right.right = new TreeNode(9);

        IncreasingBST(root);
    }

    static TreeNode IncreasingBST(TreeNode root)
    {
        var newRoot = new TreeNode();
        var nums = new List<int>();
        Traverse(root, nums);

        var ptr = newRoot;
        foreach(var item in nums)
        {
            ptr.right = new TreeNode(item);
            ptr = ptr.right;
        }

        return newRoot.right;
    }

    static void Traverse(TreeNode root, List<int> nums)
    {
        if(root == null)
            return;

        Traverse(root.left, nums);
        nums.Add(root.val);
        Traverse(root.right, nums);
    }

}
