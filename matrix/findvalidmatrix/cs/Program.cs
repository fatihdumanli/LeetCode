namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var rowSum = new int[] { 5, 7, 10 };
        var colSum = new int[] { 8, 6, 8 };

        var r = RestoreMatrix(rowSum, colSum);
        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/find-valid-matrix-given-row-and-column-sums/
    static int[][] RestoreMatrix(int[] rowSum, int[] colSum) {
        var result = new int[rowSum.Length][];

        for (int i = 0; i < rowSum.Length; i++)
            result[i] = new int[colSum.Length];
        
        for (int i = 0; i < rowSum.Length; i++)
        {
            for (int j = 0; j < colSum.Length; j++)
            {
                // Cell i, j
                // The sum of the current row is rowSum[i]
                // The sum of the current col is colSum[j]
                var currentRowSum = rowSum[i];
                var currentColSum = colSum[j];

                var min = Math.Min(currentColSum, currentRowSum);

                result[i][j] = min;

                rowSum[i] -= min;
                colSum[j] -= min;
            }
        }

        return result;
    }
}
