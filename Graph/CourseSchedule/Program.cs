using System;
using System.Collections.Generic;

namespace CourseSchedule
{
    class Program
    {
        static void Main(string[] args)
        {

            var numOfCourses = 2;
            
            
            /*
            int[][] preReq = new int[4][];
            preReq[0] = new int[] {1, 4};
            preReq[1] = new int[] {2, 4};
            preReq[2] = new int[] {3, 1};
            preReq[3] = new int[] {3, 2};
            */
            
            int[][] preReq = new int[2][];
            preReq[0] = new int[] {1, 0};
            preReq[1] = new int[] {0, 1};
            


            var result = CanFinish(numOfCourses, preReq);
        }
        
        static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var adjList = new Dictionary<int, List<int>>();

            for (int i = 0; i < prerequisites.Length; i++)
            {
                if(!adjList.ContainsKey(prerequisites[i][0]))
                    adjList.Add(prerequisites[i][0], new List<int>());
                
                adjList[prerequisites[i][0]].Add(prerequisites[i][1]);
            }

            int[] verticesColors = new int[numCourses];
            
            foreach (var item in adjList)
            {
                if (!DFS(item.Key, adjList, verticesColors))
                    return false;
            }
            
            return true;
        }


        //0: not visited
        //1: visiting
        //2: visited

        static bool DFS(int currentVertex, Dictionary<int, List<int>> adjList, int[] coloring)
        {
            if (coloring[currentVertex] == 1)
                return false;
            
            var neighbors = adjList.ContainsKey(currentVertex) ? adjList[currentVertex] : new List<int>();

            coloring[currentVertex] = 1;

            foreach (var neighbor in neighbors)
            {
                if(coloring[neighbor] == 2)
                    continue;
                
                DFS(neighbor, adjList, coloring);
            }

            coloring[currentVertex] = 2;

            return true;
        }

    }
}