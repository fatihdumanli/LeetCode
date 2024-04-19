namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var grid = new char[][]
        {
            new char[] { '1', '1', '1', '0', '0', '1', '1' },
            new char[] { '1', '1', '0', '0', '0', '1', '1' },
            new char[] { '0', '0', '0', '1', '0', '0', '0' },
            new char[] { '1', '1', '0', '0', '1', '1', '1' },
            new char[] { '0', '0', '0', '0', '0', '1', '1' },
        };

        var r = NumIslands(grid);
        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/number-of-islands
    static int NumIslands(char[][] grid)
    {
        var result = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                var val = grid[i][j];

                if (val == '0')
                    continue;

                if (val == 'X')
                    continue;

                DFS(grid, i, j);
                result++;
            }
        }

        return result;
    }

    static void DFS(char[][] grid, int i, int j)
    {
        if (i < 0 || i >= grid.Length || j < 0 || j >= grid[i].Length)
            return;

        if (grid[i][j] == '0')
            return;

        if (grid[i][j] == 'X')
            return;

        grid[i][j] = 'X';

        // left
        DFS(grid, i, j - 1);
        // right
        DFS(grid, i, j + 1);
        // top
        DFS(grid, i - 1, j);
        // bottom
        DFS(grid, i + 1, j);
    }
}
