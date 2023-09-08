namespace pascalstriangle;
class Program
{
    static void Main(string[] args)
    {
        var rows = 5;
        var r = Generate(rows);
    }

    // https://leetcode.com/problems/pascals-triangle
    static IList<IList<int>> Generate(int numRows)
    {
        var result = new List<IList<int>>();
        result.Add(new List<int> { 1 });

        for(int row = 3; row <= numRows; row++)
        {
            var arr = new int[row];

            // Set edges to '1'
            arr[0] = 1;
            arr[row - 1] = 1;
            
            
            // First element of the previous row
            var ptr = 0;

            for(int i = 1; i < row - 1; i++)
            {
                // Create a pointer on the previous array
                arr[i] = result[row - 2][ptr] + result[row - 2][ptr + 1];
                ptr++;
            }
            
            result.Add(arr.ToList());
        }
        
        return result;
    }
}
