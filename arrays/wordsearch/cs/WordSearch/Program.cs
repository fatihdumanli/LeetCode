class Program
{
    static void Main(string[] args)
    {
        var board = new char[][]
        {
            new char[] { 'A'},
        };

        var res = Exist(board, "A");
        Console.Write(res);
    }

    static bool Exist(char[][] board, string word)
    {
        var numOfElemets = board.Length * board[0].Length;
        var visited = new int[numOfElemets];

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                if (!word.StartsWith(board[i][j]))
                    continue;

                if (DFS(board, i, j, word, 0))
                    return true;
            }
        }

        return false;
    }

    static bool DFS(char[][] board, int i, int j, string word, int idx)
    {
        if (i < 0 || i >= board.Length)
            return false;

        if (j < 0 || j >= board[i].Length)
            return false;

        if (board[i][j] != word[idx])
            return false;

        if (idx >= word.Length - 1)
            return true;

        var temp = board[i][j];
        board[i][j] = (char)0;

        var left = DFS(board, i, j - 1, word, idx + 1);
        var top = DFS(board, i - 1, j, word, idx + 1);
        var right = DFS(board, i, j + 1, word, idx + 1);
        var bottom = DFS(board, i + 1, j, word, idx + 1);
        board[i][j] = temp;


        return left || top || right || bottom;
    }
}
