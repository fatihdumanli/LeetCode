using System;
using System.Collections;
using System.Collections.Generic;

namespace BFS
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] adjList = new int[4][];
            adjList[0] = new int[] { 2, 4 };
            adjList[1] = new int[] { 1, 3 };
            adjList[2] = new int[] { 2, 4 };
            adjList[3] = new int[] { 1, 3 };

            BFS(adjList);
        }

        static void BFS(int[][] adjList)
        {
            var queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();
            
            queue.Enqueue(1);
            visited.Add(1);

            while (queue.Count > 0)
            {
                var popped = queue.Dequeue();
                //visit
                Console.WriteLine(popped);
                
                var neighbors = adjList[popped - 1];
                
                foreach (var neighbor in neighbors)
                {
                    if(visited.Contains(neighbor))
                        continue;
                    
                    queue.Enqueue(neighbor);
                    visited.Add(neighbor);
                }
            }
            
        }
    }
}