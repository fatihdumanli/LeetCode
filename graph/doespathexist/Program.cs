using System;
using System.Collections.Generic;

namespace DoesPathExist
{
    class Program
    {
        static void Main(string[] args)
        {
            var nodes = new string[] {"P", "A", "D", "S", "R", "C", "Q"};
            var adjList = new Dictionary<string, List<string>>();
          
            foreach (var node in nodes)
            {
                adjList.Add(node, new List<string>());
            }
            
            
            adjList["P"].Add("A");
            adjList["P"].Add("D");
            adjList["A"].Add("P");
            adjList["A"].Add("D");
            
            adjList["D"].Add("P");
            adjList["D"].Add("A");
            
            adjList["S"].Add("R");

            adjList["R"].Add("S");
            adjList["R"].Add("C");
            adjList["R"].Add("Q");
            
            adjList["C"].Add("R");

            adjList["Q"].Add("R");

            Console.WriteLine(FindIfPathExist(nodes, adjList, "P", "Q"));

        }


        static bool FindIfPathExist(IList<string> nodes, IDictionary<string, List<string>> adjList, string from, string to)
        {
            Dictionary<string, bool> visited = new Dictionary<string, bool>();

            foreach (var node in nodes)
            {
                visited.Add(node, false);
            }

            var queue = new Queue<string>();
            queue.Enqueue(from);
            visited[from] = true;

            while (queue.Count > 0)
            {
                var popped = queue.Dequeue();
                Console.WriteLine(popped);
                var neighbors = adjList[popped];

                foreach (var neighbor in neighbors)
                {
                    if(visited[neighbor])
                        continue;
                    
                    queue.Enqueue(neighbor);
                    visited[neighbor] = true;
                }
                
            }


            return visited[to];
        }

       
    }
}