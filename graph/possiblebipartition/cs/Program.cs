// See https://aka.ms/new-console-template for more information
//var n = 4;
//var dislikes = new int[][] { new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 2, 4 } };
//var n = 3;
//var dislikes = new int[][] { new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 2, 3 } };
//var n = 5;
//var dislikes = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 }, new int[] { 4, 5 }, new int[] { 3, 5 } };
var n = 10;
var dislikes = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 }, new int[] { 5, 6 }, new int[] { 6, 7 }, new int[] { 8, 9 }, new int[] { 7, 8 } };


var r = PossibleBipartition(n, dislikes);
Console.Write(r);

static bool PossibleBipartition(int n, int[][] dislikes)
{
    const int GROUP_A = 0;
    const int GROUP_B = 1;

    Dictionary<int, int> nodeGroups = new Dictionary<int, int>();
    var adjList = new Dictionary<int, List<int>>();

    for (int i = 1; i <= n; i++)
    {
        nodeGroups.Add(i, -1);
        adjList.Add(i, new List<int>());
    }

    for (int i = 0; i < dislikes.Length; i++)
    {
        adjList[dislikes[i][0]].Add(dislikes[i][1]);
        adjList[dislikes[i][1]].Add(dislikes[i][0]);
    }

    nodeGroups[1] = GROUP_A;

    var visited = new HashSet<int>();


    for (int i = 1; i <= n; i++)
    {
        var queue = new Queue<int>();
        queue.Enqueue(i);

        if (visited.Contains(i))
            continue;

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            var currentGroup = nodeGroups[node];
            var disliked = adjList[node];
            var nextGroup = currentGroup == GROUP_A ? GROUP_B : GROUP_A;

            // if any of disliked node has a group of 'currentGroup', than we have a problem.
            foreach (var d in disliked)
            {
                if (visited.Contains(d))
                    continue;

                if (nodeGroups[d] != -1 && nodeGroups[d] == currentGroup)
                    return false;

                nodeGroups[d] = nextGroup;
                queue.Enqueue(d);
            }

            visited.Add(node);
        }
    }

    return true;
}