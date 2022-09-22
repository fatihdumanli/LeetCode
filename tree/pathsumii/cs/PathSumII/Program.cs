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
        var root = new TreeNode(5);
        root.left = new TreeNode(4);
        root.left.left = new TreeNode(11);
        root.left.left.left = new TreeNode(7);
        root.left.left.right = new TreeNode(2);

        root.right = new TreeNode(8);
        root.right.left = new TreeNode(13);
        root.right.right = new TreeNode(4);
        root.right.right.left = new TreeNode(5);
        root.right.right.right = new TreeNode(1);

        var res = PathSum(root, 22);
    }

    static IList<IList<int>> PathSum(TreeNode root, int targetSum)
    {
        var result = new List<IList<int>>();

        if (root == null)
            return result;

        Helper(root, new List<int>(), targetSum, result);

        return result;
    }


    static void Helper(TreeNode node, List<int> path, int remaining, IList<IList<int>> result)
    {
        if (node == null)
            return;

        if (node.left == null && node.right == null && remaining - node.val == 0)
        {
            var np = new List<int>(path);
            np.Add(node.val);
            result.Add(np);
        }

        var newPath = new List<int>(path);
        newPath.Add(node.val);

        Helper(node.left, newPath, remaining - node.val, result);
        Helper(node.right, newPath, remaining - node.val, result);
    }
}






