namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var land = new int[][]
        {
            new int[] { 0, 0, 0, 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 1, 1, 0, 0 },
            new int[] { 0, 0, 0, 1, 1, 0, 0 },
            new int[] { 0, 0, 0, 0, 0, 0, 0 },
        };

        FindFarmland(land);
    }

    // https://leetcode.com/problems/find-all-groups-of-farmland
    static int[][] FindFarmland(int[][] land)
    {
        var result = new List<int[]>();

        for (int i = 0; i < land.Length; i++)
        {
            for (int j = 0; j < land[i].Length; j++)
            {
                var val = land[i][j];

                if (val == 1)
                {
                    /*
                     * 0 0 0 0 0 0 0 
                     * 0 0 0 0 0 0 0
                     * 0 0 0 1 1 0 0
                     * 0 0 0 1 1 0 0
                     * 0 0 0 0 0 0 0
                     */

                    var topLeftRow = i;
                    var topLeftCol = j;

                    var bottomRight = GetBottomRightPoint(land, topLeftRow, topLeftCol);

                    // Process all the cells that's been covered by the
                    // diagonal topLeft - bottomRight
                    // So that the code will not pick up those cells as a
                    // topLeft point
                    ProcessLands(land, topLeftRow, topLeftCol, bottomRightRow: bottomRight[0], bottomRightCol: bottomRight[1]);

                    result.Add(new int[] { topLeftRow, topLeftCol, bottomRight[0], bottomRight[1]});
                }
            }
        }

        return result.ToArray();
    }

    static int[] GetBottomRightPoint(int[][] land, int row, int col)
    {
        while (row < land.Length && land[row][col] == 1)
        {
            row++;
        }
        row--;

        while (col < land[row].Length && land[row][col] == 1)
        {
            col++;
        }
        col--;

        return new int[] { row, col };
    }

    static void ProcessLands(int[][] land, int topLeftRow, int topLeftCol, int bottomRightRow, int bottomRightCol)
    {
        for(int i = topLeftRow; i <= bottomRightRow; i++)
        {
            for (int j = topLeftCol; j <= bottomRightCol; j++)
            {
                land[i][j] = 2;
            }
        }
    }
}
