namespace ii;
class Program
{
    static void Main(string[] args)
    {
        char[][] board = new char[][]
        {
            new char[] { 'A', 'B', 'C', 'E' },
            new char[] { 'S', 'F', 'E', 'S' },
            new char[] { 'A', 'D', 'E', 'E' }
        };

        var r = Exist(board, "ABCESEEEFS");

        Console.WriteLine(r);
    }


    public static bool Exist(char[][] board, string word) {


        for(int i = 0; i < board.Length; i++)
        {
            for(int j = 0; j < board[i].Length; j++)
            {
                if(DFS(board, word, 0, i, j))
                    return true;
            }
        }

        return false;
    }

    static bool DFS(char[][] board, string target, int currentLevel, int row, int col)
    {
        if(row < 0 || row >= board.Length)
            return false;

        if(col < 0 || col >= board[row].Length)
            return false;

        if(board[row][col] != target[currentLevel])
            return false;

        if (currentLevel + 1 >= target.Length)
            return true;

        var temp = board[row][col];
        board[row][col] = (char)0;
        var l = DFS(board, target, currentLevel + 1, row, col - 1);
        var r = DFS(board, target, currentLevel + 1, row, col + 1);
        var u = DFS(board, target, currentLevel + 1, row - 1, col);
        var d = DFS(board, target, currentLevel + 1, row + 1, col);
        board[row][col] = temp;

        if (l || r || u || d)
            return true;

        return false;
    }
}
