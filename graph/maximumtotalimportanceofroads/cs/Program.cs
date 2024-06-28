namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var n = 5;
        var roads = new int[][]
        {
            [0,1],
            [1,2],
            [2,3],
            [0,2],
            [1,3],
            [2,4]
        };

        var r = MaximumImportance(n, roads);
        Console.WriteLine(r);
    }

    static long MaximumImportance(int n, int[][] roads)
    {
        var edgeCounts = new int[n][];
        for (int i = 0; i < n; i++)
        {
            edgeCounts[i] = new int[2] { i, 0 };
        }

        for(int i = 0; i < roads.Length; i++)
        {
            var from = roads[i][0];
            var to = roads[i][1];

            edgeCounts[from][1]++;
            edgeCounts[to][1]++;
        }

        edgeCounts = edgeCounts.OrderByDescending(o => o[1]).ToArray();

        var scores = new int[n];
        var score = n;

        for (int i = 0; i < edgeCounts.Length; i++)
        {
            var idx = edgeCounts[i][0];
            
            scores[idx] = score--;
        }

        long importance = 0;

        foreach(var r in roads)
        {
            var from = r[0];
            var to = r[1];

            importance += (scores[from] + scores[to]);
        }

        return importance;
    }
}
