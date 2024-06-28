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
        var root = new TreeNode(1);
        root.right = new TreeNode(2);
        root.right.right = new TreeNode(3);
        root.right.right.right = new TreeNode(4);

        var r = BalanceBST(root);

        Console.WriteLine("ok");
    }

    // https://leetcode.com/problems/balance-a-binary-search-tree/
    public static TreeNode BalanceBST(TreeNode root) {
        var sortedElements = new List<int>();

        Inorder(root, sortedElements);

        return BuildMerge(sortedElements.ToArray(), 0, sortedElements.Count - 1);
    }

    public static TreeNode BuildMerge(int[] elements, int start, int end)
    {
        if (start > end)
            return null;

        if (start == end)
            return new TreeNode(elements[start]);

        var mid = start + (end - start) / 2;

        var root = new TreeNode(elements[mid]);
        root.left = BuildMerge(elements, start, mid - 1);
        root.right = BuildMerge(elements, mid + 1, end);

        return root;
    }

    public static void Inorder(TreeNode root, List<int> elements)
    {
        if (root == null)
            return;

        Inorder(root.left, elements);
        elements.Add(root.val);
        Inorder(root.right, elements);
    }
}
