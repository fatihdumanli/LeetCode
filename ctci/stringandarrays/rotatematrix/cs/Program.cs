const int n = 3;
var matrix = new int[n][];
matrix[0] = new int[n] { 1,2,3 };
matrix[1] = new int[n] { 4,5,6 };
matrix[2] = new int[n] { 7,8,9 };

RotateMatrix(matrix);

void RotateMatrix(int[][] matrix)
{
    var N = matrix.Length;

    // TODO: We should check all the rows, not only 'matrix[0]'
    if(N != matrix[0].Length)
        throw new InvalidOperationException("Matrix should be a N x N");

    // Should give 3
    var numOfLayers = Math.Ceiling(Convert.ToDouble(N) / 2);

    var tiles = N;

    for(int l = 0; l < numOfLayers; l++)
    {
        var firstRow = l;
        var mostLeft = l;
        var mostRight = N - 1 - l;
        var mostBottom = N - 1 - l;

        var left = new int[tiles];
        var top = new int[tiles];
        var right = new int[tiles];
        var bottom = new int[tiles];

        for(int i = 0; i < tiles; i++)
        {
            left[i] = matrix[i + l][mostLeft];
        }

        for(int i = 0; i < tiles; i++)
        {
            top[i] = matrix[firstRow][i + l];
        }

        for(int i = 0; i < tiles; i++)
        {
            right[i] = matrix[i + l][mostRight];
        }

        for(int i = 0; i < tiles; i++)
        {
            bottom[i] = matrix[mostBottom][i + l];
        }


        // Left -> Top
        for(int i = 0; i < tiles; i++)
        {
            matrix[firstRow][i + l] = left[tiles - 1 - i];
        }

        // Top -> Right
        for(int i = 0; i < tiles; i++)
        {
            matrix[i + l][mostRight] = top[i];
        }


        // Right -> Bottom
        for(int i = 0; i < tiles; i++)
        {
            matrix[mostBottom][i + l] = right[tiles - 1  - i];
        }


        // Bottom -> Left
        for(int i = 0; i < tiles; i++)
        {
            matrix[i + l][mostLeft] = bottom[i];
        }

        tiles -= 2;
    }
}