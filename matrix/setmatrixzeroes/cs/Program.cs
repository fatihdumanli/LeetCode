// See https://aka.ms/new-console-template for more information

var matrix = new int[][]
{
    new int[] { 1, 1, 1 },
    new int[] { 1, 0, 1 },
    new int[] { 1, 1, 1 }
};

SetZeroes(matrix);

Console.WriteLine("done");

void SetZeroes(int[][] matrix)
{
    List<int[]> zeroPositions = new List<int[]>();

    for(int i = 0; i < matrix.Length; i++)
    {
        for(int j = 0; j < matrix[i].Length; j++)
        {
            if(matrix[i][j] == 0)
                zeroPositions.Add(new int[] { i, j });
        }
    }

    foreach(var z in zeroPositions)
    {
        var row = z[0];
        var col = z[1];

        for(int i = 0; i < matrix[row].Length; i++)
        {
            matrix[row][i] = 0;
        }

        for(int i = 0; i < matrix.Length; i++)
        {
            matrix[i][col] = 0;
        }
    }
}



