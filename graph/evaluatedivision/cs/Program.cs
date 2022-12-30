var equations = new List<IList<string>>()
{
    new List<string>() { "a", "b"},
    new List<string>() { "c", "b"},
    new List<string>() { "d", "b"},
    new List<string>() { "w", "x"},
    new List<string>() { "y", "x"},
    new List<string>() { "z", "x"},
    new List<string>() { "w", "d"},
};

var values = new double[] { 2, 3, 4, 5, 6, 7, 8 };
var queries = new List<IList<string>>()
{
    new List<string>(){"a","z"},
};

var r = CalcEquation(equations, values, queries);
Console.WriteLine(r);

double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
{
    var answer = new double[queries.Count];
    var hashmap = new Dictionary<string, Node>();

    for (int i = 0; i < equations.Count; i++)
    {
        var eq = equations[i];

        var first = eq[0];
        var second = eq[1];

        Node node1 = GetNode(first, hashmap);
        Node node2 = GetNode(second, hashmap);

        node1.Relations.Add(new Edge(EdgeType.Out, node2, values[i]));
        node2.Relations.Add(new Edge(EdgeType.In, node1, values[i]));

        Union(node1, node2, hashmap);
    }

    var visited = new HashSet<string>();
    foreach (var kv in hashmap)
    {
        var key = kv.Key;
        DFS(kv.Value, hashmap, visited);
    }

    for (int i = 0; i < queries.Count; i++)
    {
        var q = queries[i];

        if (!hashmap.ContainsKey(q[0]) || !hashmap.ContainsKey(q[1]))
        {
            answer[i] = -1;
            continue;
        }

        var node1 = GetNode(q[0], hashmap);
        var node2 = GetNode(q[1], hashmap);

        var p1 = Find(node1);
        var p2 = Find(node2);

        if (p1 != p2)
        {
            answer[i] = -1;
            continue;
        }

        answer[i] = node1.ActualValue / node2.ActualValue;
    }
    return answer;
}

void DFS(Node node, Dictionary<string, Node> hashmap, HashSet<string> visited)
{
    foreach (var edge in node.Relations)
    {
        if (visited.Contains(edge.Id.ToString()))
            continue;

        if (edge.Type == EdgeType.In)
        {
            if (node.ActualValue == -1.00)
                node.ActualValue = 1.00;

            edge.To.ActualValue = node.ActualValue * edge.Value;
        }

        if (edge.Type == EdgeType.Out)
        {
            if (node.ActualValue == -1.00)
                node.ActualValue = edge.Value;

            edge.To.ActualValue = node.ActualValue / edge.Value;
        }

        visited.Add(edge.Id.ToString());
        DFS(edge.To, hashmap, visited);
    }

    visited.Add(node.Symbol);
}

Node GetNode(string key, IDictionary<string, Node> hashmap)
{
    if (!hashmap.ContainsKey(key))
    {
        var node = new Node(key);
        hashmap.Add(key, node);
    }

    return hashmap[key];
}


void Union(Node node1, Node node2, Dictionary<string, Node> hashmap)
{
    var p1 = Find(node1);
    var p2 = Find(node2);

    if (p1 == p2)
        return;

    p2.Parent = p1;

    hashmap[p1.Symbol] = p1;
    hashmap[p2.Symbol] = p2;
}


Node Find(Node node)
{
    if (node.Parent == null)
        return node;

    return Find(node.Parent);
}


public enum EdgeType
{
    In, Out
}

public class Edge
{
    public EdgeType Type { get; set; }
    public Node To { get; set; }
    public double Value { get; set; }
    public Guid Id { get; set; }

    public Edge(EdgeType type, Node to, double value)
    {
        this.Type = type;
        this.To = to;
        this.Value = value;
        Id = Guid.NewGuid();
    }
}

public class Node
{
    public string Symbol { get; set; }
    public Node Parent { get; set; }
    public IList<Edge> Relations { get; set; }
    public double ActualValue { get; set; } = -1.00;

    public Node(string symbol)
    {
        this.Relations = new List<Edge>();
        this.Symbol = symbol;
    }
}