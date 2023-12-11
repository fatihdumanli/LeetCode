namespace ii;

public class TreeNode
{
    public int val { get; set; }
    public TreeNode left { get; set; }

    public TreeNode right { get; set; }

    public TreeNode(int val)
    {
        this.val = val;
    }
    
    public TreeNode()
    {
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

        var r = LevelOrder(root);

        Console.WriteLine("Hello, World!");
    }

    public static IList<IList<int>> LevelOrder(TreeNode root) {

        var result = new List<IList<int>>();
        var dict = new Dictionary<int, List<int>>();
        
        Traverse(root, 0, dict);

        for(int i = 0; i < 2001; i++)
        {
            if(!dict.ContainsKey(i))
            {
                return result;
            }

            result.Add(dict[i]);
        }

        return result;
    }

    static void Traverse(TreeNode root, int level, Dictionary<int, List<int>> dict)
    {
        if (root == null)
            return;

        Traverse(root.left, level + 1, dict);

        if (dict.ContainsKey(level))
        {
            dict[level].Add(root.val);
        }
        else
        {
            dict.Add(level, new List<int>() { root.val });
        }

        Traverse(root.right, level + 1, dict);
    }
}
