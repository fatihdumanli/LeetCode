
//var isConnected = new int[][] {new int[]{ 1,1,0}, new int[] {1,1,0}, new int[] {0, 0, 1} }; 
var isConnected = new int[][] {new int[]{ 1,0,0}, new int[] {0,1,0}, new int[] {0, 0, 1} }; 
var r = FindCircleNum(isConnected);
Console.Write(r);


int FindCircleNum(int[][] isConnected)
{
    int N = isConnected.Length;
    HashSet<int> visited = new HashSet<int>();
    
    var numOfProvinces = 0;
    
    for(int i = 0; i < N; i++)
    {
        if(visited.Contains(i))
            continue;
        
        DFS(i, isConnected, visited);
        
        numOfProvinces++;
    }
    
    return numOfProvinces;
}

void DFS(int node, int[][] isConnected, HashSet<int> visited)
{
    visited.Add(node);
    
    var adj = isConnected[node];
    for(int i = 0; i < adj.Length; i++)
    {
        var isNeigbor = adj[i] == 1;
        
        if(!isNeigbor)
            continue;

        if(i == node)
            continue;
        
        if(visited.Contains(i))
            continue;
        
        DFS(i, isConnected, visited);
    }
}

