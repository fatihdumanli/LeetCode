namespace cs;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var board = new char[9][]
        {
            new char[] { '5', '3', ' ', ' ', '7', ' ', ' ', ' ', ' ' },
            new char[] { '6', ' ', ' ', '1', '9', '5', ' ', ' ', ' ' },
            new char[] { ' ', '9', '8', ' ', ' ', ' ', ' ', '6', ' ' },
            new char[] { '8', ' ', ' ', ' ', '6', ' ', ' ', ' ', '3' },
            new char[] { '4', ' ', ' ', '8', ' ', '3', ' ', ' ', '1' },
            new char[] { '7', ' ', ' ', ' ', '2', ' ', ' ', ' ', '6' },
            new char[] { ' ', '6', ' ', ' ', ' ', ' ', '2', '8', ' ' },
            new char[] { ' ', ' ', ' ', '4', '1', '9', ' ', ' ', '5' },
            new char[] { ' ', ' ', ' ', ' ', '8', ' ', ' ', '7', '9' },
        };

        var r = IsValidSudoku(board);

        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/valid-sudoku/
    static bool IsValidSudoku(char[][] board)
    {
        var rows = new Dictionary<int, HashSet<int>>();
        var cols = new Dictionary<int, HashSet<int>>();
        var subBoxes = new Dictionary<int, HashSet<int>>();

        for(int i = 0; i < 9; i++)
        {
            rows.Add(i, new HashSet<int>());
            cols.Add(i, new HashSet<int>());
            subBoxes.Add(i, new HashSet<int>());
        }

        for(int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                if (board[i][j] == ' ')
                    continue;

                var row = i;
                var col = j;
                var val = board[row][col];

                if (rows[row].Contains(val))
                    return false;

                rows[row].Add(val);

                if (cols[col].Contains(val))
                    return false;

                cols[col].Add(val);

                var macroRow = row / 3;
                var macroCol = col / 3;
                var subBoxId = (macroRow * 3) + macroCol;

                if (subBoxes[subBoxId].Contains(val))
                    return false;

                subBoxes[subBoxId].Add(val);
            }
        }

        return true;
    }
}
