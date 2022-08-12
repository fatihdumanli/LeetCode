var mat = new int[][] 
{
    new int[3] { 1,2,3},
    new int[3] { 4,5,6},
    new int[3] { 7,8,9}
};

var order = FindDiagonalOrder(mat);


int[] FindDiagonalOrder(int[][] mat)
{
    var rows = mat.Length;
    var cols = mat[0].Length;

    bool IsOutOfBoundaries(int i, int j)
    {
        return i < 0 || i > rows - 1 || j < 0 || j > cols - 1;
    }

    var subs = new List<List<int>>();

    int i = 0;
    int j = 0;

    int c = 0;
    while(c < rows * cols)
    {
        var sub = new List<int>();

        var tempRow = i;
        var tempCol = j;

        while(!IsOutOfBoundaries(i, j))
        {
            sub.Add(mat[i][j]);
            c++;
            i--;
            j++;
        }

        i = tempRow;
        j = tempCol;

        if(tempRow + 1 < rows)
        {
            i++;
        }
        else
        {
            j++;
        }

        subs.Add(sub);
    }

    var result = new List<int>();

    var isReverse = false;
    foreach(var item in subs)
    {
        if(!isReverse)
        {
            for(var x = 0; x < item.Count; x++)
            {
                result.Add(item[x]);
            }
            isReverse = true;
        }
        else
        {
            for(var x = item.Count - 1; x >= 0; x--)
            {
                result.Add(item[x]);
            }
            isReverse = false;
        }
    }

    return result.ToArray();
}