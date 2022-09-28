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
        var preorder = new int[] { 5, 2, 1, 3, 7, 9 };
        var inorder = new int[] { 1, 2, 3, 5, 7, 9 };

        var root = BuildTree(preorder, inorder);
    }

    static TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        var rootVal = preorder[0];

        var root = new TreeNode(rootVal);
        var inOrderIdx = FindIndex(inorder, rootVal);

        var leftInorder = GetSubArray(inorder, 0, inOrderIdx - 1);
        var rightInorder = GetSubArray(inorder, inOrderIdx + 1, inorder.Length - 1);

        var leftPreorder = GetSubArray(preorder, 1, leftInorder.Length);
        var rightPreorder = GetSubArray(preorder, 1 + leftInorder.Length, preorder.Length - 1);

        if (leftInorder.Length > 0)
        {
            root.left = BuildTree(leftPreorder, leftInorder);
        }

        if (rightInorder.Length > 0)
        {
            root.right = BuildTree(rightPreorder, rightInorder);
        }

        return root;
    }

    static int[] GetSubArray(int[] arr, int startIndex, int endIndex)
    {
        var newLength = endIndex - startIndex + 1;
        var newArr = new int[newLength];

        var idx = 0;

        for (int i = startIndex; i <= endIndex; i++)
        {
            newArr[idx++] = arr[i];
        }
        return newArr;
    }

    static int FindIndex(int[] arr, int elm)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == elm)
            {
                return i;
            }
        }
        return -1;
    }
}
