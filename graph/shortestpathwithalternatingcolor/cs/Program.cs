class Program
{
    class Edge
    {
        public int from;
        public int to;
        public int color;
    }

    const int RED = 0;
    const int BLUE = 1;
    static void Main(string[] args)
    {
        var n = 5;
        var redEdges = new int[][]
        {
            new int[] { 1, 4 },
            new int[] { 0, 3 },
        };

        var blueEdges = new int[][]
        {
            new int[] { 3, 1 },
            new int[] { 3, 4 },
        };

        // var n = 3;
        // var redEdges = new int[][]
        // {
        //     new int[] { 0, 1 },
        //     new int[] { 1, 2 },
        // };
        // 
        // var blueEdges = new int[][]
        // {
        // };
        var result = ShortestAlternatingPaths(n, redEdges, blueEdges);
        foreach(var a in result)
        {
            Console.WriteLine(a);
        }

    }

    static int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges) 
    {
        var adjList = new Dictionary<int, List<Edge>>();

        for(int i = 0; i < n; i++)
        {
            adjList.Add(i, new List<Edge>());
        }
        foreach(var r in redEdges)
        {
            var from = r[0];
            var to = r[1];
            adjList[from].Add(new Edge() { from = from, to = to, color = RED });
        }
        foreach(var b in blueEdges)
        {
            var from = b[0];
            var to = b[1];
            adjList[from].Add(new Edge() { from = from, to = to, color = BLUE });
        }

        var answer = new int[n];
        answer[0] = 0;

        for(int i = 1; i < n; i++)
        {
            answer[i] = BFS(i, adjList);
        }

        return answer;
    } 

    static int BFS(int node, IDictionary<int, List<Edge>> adjList)
    {
        var queue = new Queue<Edge>();
        var firstEdges = adjList[0];
        int min = Int32.MaxValue;

        foreach(var e in firstEdges)
        {
            var ctr = 1;
            queue.Enqueue(e);

            while(queue.Count > 0)
            {
                var dequeued = queue.Dequeue();

                if(dequeued.to == node)
                {
                    min = Math.Min(min, ctr);
                    break;
                }

                ctr++;
                var currentColor = dequeued.color;

                var neighbors = adjList[dequeued.to];

                foreach(var item in neighbors)
                {
                    if(item.color == currentColor)
                        continue;
                    
                    queue.Enqueue(item);
                }
            }

            queue.Clear();
        }
        return min == Int32.MaxValue ? -1 : min;
    }       
}




