namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var edges = new int[][] { [1,2], [2,3], [4,2] };

        var r = FindCenter(edges);

        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/find-center-of-star-graph
    static int FindCenter(int[][] edges)
    {
        var freq = new int[edges.Length + 2];

        var max = Int32.MinValue;
        var maxNode = -1;

        for (int i = 0; i < edges.Length; i++)
        {
            var from = edges[i][0];
            var to = edges[i][1];

            freq[from]++;
            freq[to]++;

            if (freq[from] > max)
            {
                max = freq[from];
                maxNode = from;
            }

            if (freq[to] > max)
            {
                max = freq[to];
                maxNode = to;
            }
        }

        return maxNode;
    }
}
