namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var grid = new int[4][]
        {
            new int[] { 9, 9, 8 , 1 },
            new int[] { 5, 6, 2 , 6 },
            new int[] { 8, 2, 6 , 4 },
            new int[] { 6, 2, 2 , 2 },
        };

        var r = LargestLocal(grid);

        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/largest-local-values-in-a-matrix
    static int[][] LargestLocal(int[][] grid) {

        var generated = new int[grid.Length - 2][];
        
        for (int i = 0; i < generated.Length; i++)
        {
            generated[i] = new int[grid.Length - 2];
        }

        for (int i = 1; i <= grid.Length - 2; i++)
        {
            for (int j = 1; j <= grid.Length - 2; j++)
            {
                var values = new int[9];

                values[0] = grid[i - 1][j - 1];
                values[1] = grid[i - 1][j];
                values[2] = grid[i - 1][j + 1];
                values[3] = grid[i][j + 1];
                values[4] = grid[i + 1][j + 1];
                values[5] = grid[i + 1][j];
                values[6] = grid[i + 1][j - 1];
                values[7] = grid[i][j - 1];
                values[8] = grid[i][j];

                var max = Int32.MinValue;

                foreach(var v in values)
                    max = Math.Max(max, v);

                generated[i - 1][j - 1] = max;
            }
        }

        return generated;
    }
}

