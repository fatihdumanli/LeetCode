// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var matrix = new int[][]
{
    new int[] { 1, 2, 3, 4 },
    new int[] { 5, 6, 7, 8 },
    new int[] { 9, 10, 11, 12 },
    new int[] { 13, 14, 15, 16 },
};


Rotate(matrix);


// https://leetcode.com/problems/rotate-image
void Rotate(int[][] matrix)
{
    var N = matrix.Length;
    var numOfLayers = Math.Ceiling((decimal)matrix.Length / 2);

    for(int layer = 0; layer < numOfLayers; layer++)
    {
        var topBackup = new List<int>();

        // Backup the top
        for(int i = 0; i < N - (2 * layer); i++)
        {
            topBackup.Add(matrix[layer][layer + i]);
        }

        // Left -> Top
        var topLeft = matrix[layer][layer];

        for(int i = 0; i < N - (2 * layer); i++)
        {
            matrix[layer][layer + i] = matrix[N - 1 - layer - i][layer];
        }
        matrix[layer][N - 1 - layer] = topLeft;


        // Bottom -> Left
        for(int i = 0; i < N - (2 * layer); i++)
        {
            matrix[layer + i][layer] = matrix[N - 1 - layer][layer + i];
        }

        // Right -> Bottom
        for(int i = 0; i < N - (2 * layer); i++)
        {
            matrix[N - 1 - layer][layer + i] = matrix[N - 1 - layer - i][N - 1 - layer];
        }


        // Top -> Right
        for(int i = 0; i < N - (2 * layer); i++)
        {
            matrix[layer + i][N - 1 - layer] = topBackup[i];
        }
    }

}



