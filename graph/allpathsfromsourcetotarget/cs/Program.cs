var paths = new int[4][];
paths[0] = new int[] { 1, 2 };
paths[1] = new int[] { 3 };
paths[2] = new int[] { 3 };
paths[3] = new int[] { };

AllPathsSourceTarget(paths);


IList<IList<int>> AllPathsSourceTarget(int[][] graph)
{
    var result = new List<IList<int>>();
    var target = graph.Length - 1;

    DFS(0, graph, new List<int>() { 0 }, result);

    return result;
}


void DFS(int node, int[][] adjList, List<int> path, List<IList<int>> result)
{
    if (node == adjList.Length - 1)
    {
        result.Add(new List<int>(path));
        return;
    }

    var children = adjList[node];
    foreach (var c in children)
    {
        path.Add(c);
        DFS(c, adjList, path, result);
        path.RemoveAt(path.Count - 1);
    }
}

//TreeNode DFS(int node, int[][] adjList, int target, HashSet<int> visited)
//{
//    if (node == target)
//        return new TreeNode(node) { IsValidNode = true };
//
//    var children = adjList[node];
//    var root = new TreeNode(node);
//
//    foreach (var c in children)
//    {
//        if (visited.Contains(c))
//            continue;
//
//        var r = DFS(c, adjList, target, visited);
//        if (r.IsValidNode)
//        {
//            root.Children.Add(r);
//            root.IsValidNode = true;
//        }
//    }
//
//    visited.Add(node);
//    return root;
//}
//
class TreeNode
{
    public int Val { get; set; }
    public bool IsValidNode { get; set; }
    public List<TreeNode> Children { get; set; }

    public TreeNode(int val)
    {
        this.Val = val;
        this.Children = new List<TreeNode>();
    }
}