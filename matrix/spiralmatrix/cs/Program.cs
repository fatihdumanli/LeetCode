var matrix = new int[3][]
{
    new int[] { 1, 2, 3 },
    new int[] { 4, 5, 6 },
    new int[] { 7, 8, 9 }
};

var r = SpiralOrder(matrix);

Console.WriteLine(r);

// https://leetcode.com/problems/spiral-matrix/
// Constantly iterate in spiral pattern until 
// The number of processed cells reaches m * n
IList<int> SpiralOrder(int[][] matrix)
{
    var result = new List<int>();

    int totalProcessed = 0;
    int row = 0;
    int col = 0;
    char direction = 'R';

    while(totalProcessed < matrix.Length * matrix[0].Length)
    {
        result.Add(matrix[row][col]);

        matrix[row][col] = 101;
        totalProcessed++;
        
        var (newDirecttion, nextCell) = GetNextCell(matrix, row, col, direction);

        row = nextCell[0];
        col = nextCell[1];

        direction = newDirecttion;
    }

    return result;
}

// Get next cell based on the current cell.
// Switch directions if 
// 1. It hits the borders
// 2. It hits an already processed cell
(char, int[]) GetNextCell(int[][] matrix, int row, int col, char direction)
{
    switch(direction)
    {
        case 'R':
            if (col + 1 >= matrix[row].Length || matrix[row][col + 1] == 101)
                return ('D', new int[] { row + 1, col });
            return ('R', new int[] { row, col + 1 });
        case 'D':
            if (row + 1 >= matrix.Length || matrix[row + 1][col] == 101)
                return ('L', new int[] { row, col - 1 });
            return ('D', new int[] { row + 1, col });
        case 'L':
            if (col - 1 < 0 || matrix[row][col - 1] == 101)
                return ('U', new int[] { row - 1, col });
            return ('L', new int[] { row, col - 1});
        case 'U':
            if (row - 1 < 0 || matrix[row - 1][col] == 101)
                return ('R', new int[] { row, col + 1 });
            return ('U', new int[] { row - 1, col });

        default:
            throw new Exception();
    }
}


