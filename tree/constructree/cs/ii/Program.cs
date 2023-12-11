namespace ii;

class TreeNode
{
    public int val { get; set; }

    public TreeNode left { get; set; }

    public TreeNode right { get; set; }

    public TreeNode(int _val)
    {
        this.val = _val;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var root = new TreeNode(600);
        root.left = new TreeNode(550);
        root.left.left = new TreeNode(547);
        root.left.right = new TreeNode(592);
        root.right = new TreeNode(610);
        root.right.left = new TreeNode(606);
        root.right.left.left = new TreeNode(601);
        root.right.left.right = new TreeNode(608);
        root.right.right = new TreeNode(612);
        root.right.right.right = new TreeNode(615);

        //Console.WriteLine("preorder");
        //Preorder(root);

        //Console.WriteLine();

        //Console.WriteLine("inorder");
        //Inorder(root);
        //
        var preorder = new int[] { 600, 550, 547, 592, 610, 606, 601, 608, 612, 615 };
        var inorder = new int[] { 547, 550, 592, 600, 601, 606, 608, 610, 612, 615 };

        var r = BuildTree(preorder, inorder);
    }

    // https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/
    static TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        return BuildSubtree(inorder, preorder, inorder);
    }

    static TreeNode BuildSubtree(int[] nodes, int[] preorder, int[] inorder)
    {
        if(nodes.Length == 0)
            return null;

        if(nodes.Length == 1)
            return new TreeNode(nodes[0]);

        var root = GetRoot(nodes, preorder);

        var (leftNodes, rightNodes) = GetLeftAndRightSubtree(nodes, root);

        var leftSubtree = BuildSubtree(leftNodes, preorder, inorder);
        var rightSubtree = BuildSubtree(rightNodes, preorder, inorder);

        return new TreeNode(root) { left = leftSubtree, right = rightSubtree };
    }

    static int GetRoot(int[] nodes, int[] preorder)
    {
        var hashset = new HashSet<int>();

        foreach(var n in nodes)
            hashset.Add(n);

        for(int i = 0; i < preorder.Length; i++)
        {
            if (hashset.Contains(preorder[i]))
                    return preorder[i];
        }

        throw new InvalidDataException("root is not found");
    }

    // nodes must be sent 'in-order' - so that it will understand the left
    // handside is left subtree while right handside is the right subtree
    static (int[], int[]) GetLeftAndRightSubtree(int[] nodes, int root)
    {
        var left = new List<int>();
        var right = new List<int>();

        var rootIdx = -1;

        for(int i = 0; i < nodes.Length; i++)
        {
            if (nodes[i] == root)
            {
                rootIdx = i;
                break;
            }

            left.Add(nodes[i]);
        }

        if (rootIdx == -1)
         throw new InvalidDataException("root is not found");

        for(int i = rootIdx + 1; i < nodes.Length; i++)
            right.Add(nodes[i]);

        return (left.ToArray(), right.ToArray());
    }


    static void Preorder(TreeNode root)
    {
        if (root == null)
            return;

        Console.Write(root.val + " ");
        Preorder(root.left);
        Preorder(root.right);
    }

    static void Inorder(TreeNode root)
    {
        if (root == null)
            return;

        Inorder(root.left);
        Console.Write(root.val + " ");
        Inorder(root.right);
    }
}
