using System.Globalization;
using System.Text.Json.Serialization;

namespace kthweakestrowsinamatrix;
class Program
{

    static void Main(string[] args)
    {
        var mat = new int[][]
        {
            new[] { 1, 1, 0, 0, 0 },
            new[] { 1, 1, 1, 1, 0 },
            new[] { 1, 0, 0, 0, 0 },
            new[] { 1, 1, 0, 0, 0 },
            new[] { 1, 1, 1, 1, 1 }
        };
        
        var k = 3;
        
        var r = KWeakestRows(mat, k);

        Console.WriteLine(r);
    }

    class SoldierRowComparer : IComparer<int[]>
    {
        //arr[0]: nums of soldiers
        //arr[1]: row
        public int Compare(int[]? x, int[]? y)
        {
            if(x[0] == y[0])
                return x[1] < y[1] ? -1 : 1;

            if(x[0] > y[0])
                return 1;
            
            return -1;
        }
    }
    // https://leetcode.com/problems/the-k-weakest-rows-in-a-matrix
    static int[] KWeakestRows(int[][] mat, int k)
    {
        var pq = new PriorityQueue<int, int[]>(new SoldierRowComparer());
        
        for(int i = 0; i < mat.Length; i++)
        {
            var numOfSoldiers = 0;

            for(int j = 0; j < mat[i].Length; j++)
            {
                if(mat[i][j] == 1)
                    numOfSoldiers++;
            }
            
            pq.Enqueue(i, new int[] { numOfSoldiers, i });
        }
        
        var result = new int[k];
        for(int i = 0; i < k; i++)
        {
            result[i] = pq.Dequeue();
        }
        
        return result;
    }
}

