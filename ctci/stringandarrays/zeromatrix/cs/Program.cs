var matrix = new int[][]
{
    new int[3] { 1,1,1},
    new int[3] { 1,0,1},
    new int[3] { 1,1,1},
};

ZeroMatrix(matrix);

void ZeroMatrix(int[][] matrix)
{
    var zeroCoordinates = new List<int[]>();

    for(int i = 0; i < matrix.Length; i++)
    {
        for(int j = 0; j < matrix[i].Length; j++)
        {
            if(matrix[i][j] == 0)
                zeroCoordinates.Add(new int[2] { i, j });
        }
    }

    for(int i = 0; i < zeroCoordinates.Count; i++)
    {
        var row = zeroCoordinates[i][0];
        var col = zeroCoordinates[i][1];


        var arr = matrix[row];
        for(int c = 0; c < matrix[row].Length; c++)
            matrix[row][c] = 0;


        for(var m = 0; m < matrix.Length; m++)
            matrix[m][col] = 0;
    }

}


