using System.Text.Json;

namespace cs;


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

class Program
{
    static void Main(string[] args)
    {
        var root = new TreeNode(9);
        root.left = new TreeNode(2);
        root.left.left = new TreeNode(2);
        root.left.right = new TreeNode(4);
        root.left.right.left = new TreeNode(4);
        root.left.right.right = new TreeNode(4);

        root.right = new TreeNode(15);
        root.right.left = new TreeNode(11);
        root.right.right = new TreeNode(15);
        root.right.right.left = new TreeNode(15);

        var r = FindMode(root);
        Console.WriteLine(JsonSerializer.Serialize(r));
    }

    public class State
    {
        public int lastValue = Int32.MinValue;
        public int freq = 1;
        public int maxFreq = 0;
        public List<int> result = new List<int>();
    }

    // https://leetcode.com/problems/find-mode-in-binary-search-tree/
    // In this problem we need to leverage the properties of a binary search
    // tree
    // 1. All nodes on the LEFT subtree of a node have a value LESS than the
    // current node
    // 2. All nodes on the RIGHT subtree of each node has a value GREATER than
    // the current node
    // 
    // As has been known, if we apply inorder traversal to a BST
    // we can process the nodes in an ascending order.
    //
    // All we need to do is to keep track of the previous value and the length
    // of the sequence.
    //
    // As soon as the value we process changes, we check if the previous
    // sequence is longer than the maximum sequence.
    //
    // If it's longer, we tweak the result array accordingly.
    // If it's equal, we add the current value to the existing result array.
    static int[] FindMode(TreeNode root)
    {
        var state = new State();
        Search(root, state);

        HandleNumberTransition(state);

        return state.result.ToArray();
    }

    static void HandleNumberTransition(State state)
    {
        if (state.freq == state.maxFreq)
        {
            state.result.Add(state.lastValue);
        }
        else if (state.freq > state.maxFreq)
        {
            state.result.Clear();
            state.result.Add(state.lastValue);
            state.maxFreq = state.freq;
        }
    }

    static void Search(TreeNode root, State state)
    {
        if (root == null)
            return;

        Search(root.left, state);

        if (root.val == state.lastValue)
        {
            state.freq++;
        }
        else if (state.lastValue == Int32.MinValue)
        {
            state.lastValue = root.val;
        }
        else
        {
            // the number has changed
            HandleNumberTransition(state);

            state.lastValue = root.val;
            state.freq = 1;
        }

        Search(root.right, state);
    }
}
