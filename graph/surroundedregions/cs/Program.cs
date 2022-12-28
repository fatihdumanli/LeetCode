//var board = new char[][] {
//    new char[] { 'X', 'X', 'X', 'X' },
//    new char[] { 'X', 'O', 'O', 'X' },
//    new char[] { 'X', 'X', 'O', 'X' },
//    new char[] { 'X', 'O', 'X', 'X' }
//};
var board = new char[][] {
    new char[]{'X', 'O', 'X', 'O', 'X', 'O'},
    new char[]{'O', 'X', 'O', 'X', 'O', 'X'},
    new char[]{'X', 'O', 'X', 'O', 'X', 'O'},
    new char[]{'O', 'X', 'O', 'X', 'O', 'X'},
};

Solve(board);

//https://leetcode.com/problems/surrounded-regions/
void Solve(char[][] board)
{
    //left
    for (int i = 0; i < board.Length; i++)
        if (board[i][0] == 'O')
            DFS(board, i, 0);

    //right
    for (int i = 0; i < board.Length; i++)
        if (board[i][board[i].Length - 1] == 'O')
            DFS(board, i, board[i].Length - 1);

    //top
    for (int i = 0; i < board[0].Length; i++)
        if (board[0][i] == 'O')
            DFS(board, 0, i);

    //bottom
    for (int i = 0; i < board[0].Length; i++)
        if (board[board.Length - 1][i] == 'O')
            DFS(board, board.Length - 1, i);

    for (int i = 0; i < board.Length; i++)
    {
        for (int j = 0; j < board[i].Length; j++)
        {
            if (board[i][j] == 'V')
            {
                board[i][j] = 'O';
                continue;
            }

            if (board[i][j] == 'O')
            {
                board[i][j] = 'X';
                continue;
            }
        }
    }
}

void DFS(char[][] board, int i, int j)
{
    if (i < 0 || i >= board.Length || j < 0 || j >= board[i].Length)
        return;

    if (board[i][j] != 'O')
        return;

    board[i][j] = 'V';

    DFS(board, i, j - 1);
    DFS(board, i, j + 1);
    DFS(board, i - 1, j);
    DFS(board, i + 1, j);
}
