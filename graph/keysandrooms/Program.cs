// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

bool CanVisitAllRooms(IList<IList<int>> rooms)
{
    var adjList = new Dictionary<int, List<int>>();
    var n = rooms.Count;
    for (int i = 0; i < n; i++)
    {
        adjList.Add(i, new List<int>());
    }

    for (int i = 0; i < rooms.Count; i++)
    {
        foreach (var key in rooms[i])
            adjList[i].Add(key);
    }

    var visited = new HashSet<int>();
    var queue = new Queue<int>();

    queue.Enqueue(0);

    while (queue.Count > 0)
    {
        var dequeued = queue.Dequeue();

        var neighbors = adjList[dequeued];


        foreach (var neighbor in neighbors)
            if (!visited.Contains(neighbor))
                queue.Enqueue(neighbor);

        visited.Add(dequeued);
    }

    return visited.Count == n;
}