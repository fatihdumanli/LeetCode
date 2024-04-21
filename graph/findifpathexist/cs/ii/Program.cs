using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ii;

class DisjointSetNode
{
    public int val { get; set; }
    public DisjointSetNode parent { get; set; }

    public DisjointSetNode(int i)
    {
        this.val = i;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var n = 10;
        var edges = JsonSerializer.Deserialize<int[][]>(@"[[4,3],[1,4],[4,8],[1,7],[6,4],[4,2],[7,4],[4,0],[0,9],[5,4]]");

        var r = ValidPath(n, edges, source: 5, destination: 9);

        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/find-if-path-exists-in-graph
    static bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        var nodes = new Dictionary<int, DisjointSetNode>();
        for (int i = 0; i < n; i++)
            nodes.Add(i, new DisjointSetNode(i));

        foreach (var e in edges)
        {
            var from = Find(nodes[e[0]]);
            var to = Find(nodes[e[1]]);

            if (from == to)
                continue;

            to.parent = from;
        }

        return Find(nodes[source]) == Find(nodes[destination]);
    }

    static DisjointSetNode Find(DisjointSetNode node)
    {
        if (node.parent == null)
            return node;
        return Find(node.parent);

    }

}
