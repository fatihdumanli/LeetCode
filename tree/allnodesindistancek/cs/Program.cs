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
        var root = new TreeNode(3);
        root.left = new TreeNode(5);
        root.left.left = new TreeNode(6);
        root.left.right = new TreeNode(2);
        root.left.right.left = new TreeNode(7);
        root.left.right.right = new TreeNode(4);

        root.right = new TreeNode(1);
        root.right.left = new TreeNode(0);
        root.right.right = new TreeNode(8);

        DistanceK(root, root.left.right.right, 2);
    }

    // https://leetcode.com/problems/all-nodes-distance-k-in-binary-tree
    //
    // Steps
    // 1. Find the target by traversing (inorder/preorder/postorder)
    // 2. Start downstream search for the nodes in distance k - a simple DFS
    // 3. Start an upstream search - explained below
    //
    // Upstream search can be initiated only by the parent.
    // So, if we imagine that the parent has a value indicating that one of it's
    // child is the target, and this value is the distance to the target (it
    // will be '1' in this case
    //
    // So, we have a result of integer 1, indicating that as a root, I'm one
    // distance away to the target.
    //
    // 1. First, I need to check if the value (distance) is equal to the 'k' -
    //    which would mean that I'm one of the results. If so, I should be adding
    //    myself to the result array. And then, exit the function as there's no way
    //    I'll be able to initiate a successful search anymore. Anything that I'll
    //    be initating will be likely to have longer distance than the 'k'.
    //
    // 2. I must be initiating a downstream search to the other child.
    //
    //    Imagine, my right child returns me the result '1' and 'k' being '3',
    //    Then I should be seeking the nodes that have a distance of '2' to me.
    //
    //    Pseuodecode would be like Downstream(root.left, k: k - right - 1); (-1
    //    for also bypassing the root - the left becomes the root)
    //
    // 3. I must pass the value to the my parent by returning left + 1, so that
    //    my parent could do the same.
    public static IList<int> DistanceK(TreeNode root, TreeNode target, int k) 
    {
        var result = new List<int>();

        Traverse(root, target, k, result);

        return result;
    }

    static int Traverse(TreeNode root, TreeNode target, int k, IList<int> result)
    {
        if (root == null)
            return -1;

        var left = Traverse(root.left, target, k, result);

        if (left == k)
        {
            result.Add(root.val);

            return -1;
        }

        if (left > 0)
        {
            Downstream(root.right, k - left - 1, 0, result);

            return left + 1;
        }

        if (root == target)
        {
            Downstream(root, k, 0, result);

            return 1;
        }

        var right = Traverse(root.right, target, k, result);

        if (right == k)
        {
            result.Add(root.val);
            
            return -1;
        }

        if (right > 0)
        {
            Downstream(root.left, k - right - 1, 0, result);

            return right + 1;
        }

        return -1;
    }

    // DFS
    static void Downstream(TreeNode root, int k, int c, IList<int> result)
    {
        if (root == null)
            return;

        if (c == k)
        {
            result.Add(root.val);
            return;
        }

        c++;

        Downstream(root.left, k, c, result);
        Downstream(root.right, k, c, result);
    }
}
