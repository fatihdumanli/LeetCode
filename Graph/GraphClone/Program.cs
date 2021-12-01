using System;
using System.Collections.Generic;
using Common;

namespace GraphClone
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

            var node1 = new GraphNode(1);
            var node2 = new GraphNode(2);
            var node3 = new GraphNode(3);
            var node4 = new GraphNode(4);
            
            node1.neighbors.Add(node2);
            node1.neighbors.Add(node4);
            
            node2.neighbors.Add(node1);
            node2.neighbors.Add(node3);
            
            node3.neighbors.Add(node2);
            node3.neighbors.Add(node4);
            
            node4.neighbors.Add(node1);
            node4.neighbors.Add(node3);

            var result = CloneGraph(node1);
            
            Console.WriteLine("Hello World!");
        }

        static GraphNode CloneGraph(GraphNode node)
        {
            if (node == null) return null;
            var hashmap = new Dictionary<int, GraphNode>();
            return CloneGraph(node, hashmap);
        }

        //Recursive helper function
        static GraphNode CloneGraph(GraphNode node, IDictionary<int, GraphNode> hashmap)
        {
            if (hashmap.ContainsKey(node.val))
                return hashmap[node.val];

            var copy = new GraphNode(node.val);
            hashmap.Add(node.val, copy);

            foreach (var neighbor in node.neighbors)
            {
                copy.neighbors.Add(CloneGraph(neighbor, hashmap));
            }
            
            return copy;
        }

      
    }
}