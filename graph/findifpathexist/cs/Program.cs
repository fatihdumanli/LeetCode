// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var edges = new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 2, 0 } };

Console.WriteLine(ValidPath(3, edges, 0, 2));


int Find(int[] arr, int i)
{
    if (arr[i] == -1)
        return i;

    return Find(arr, arr[i]);
}

bool ValidPath(int n, int[][] edges, int source, int destination)
{
    var arr = new int[4];
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = -1;
    }

    for (int i = 0; i < edges.Length; i++)
    {
        var p1 = Find(arr, edges[i][0]);
        var p2 = Find(arr, edges[i][1]);

        if (p1 != p2)
            arr[p2] = p1;
    }

    return Find(arr, source) == Find(arr, destination);
}