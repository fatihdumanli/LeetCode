using System.Text.Json;

namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var r = GetRow(Convert.ToInt32(args[0]));

        Console.WriteLine(JsonSerializer.Serialize(r));
    }

    static IList<int> GetRow(int rowIndex)
    {
        var prev = new int[] { 1 };

        if (rowIndex == 0)
            return prev;

        for (int i = 1; i <= rowIndex; i++)
        {
            var N = i + 1;
            var arr = new int[N];

            arr[0] = 1;

            var prevPtr = 0;

            for (var j = 1; j < N - 1; j++)
            {
                arr[j] = prev[prevPtr] + prev[prevPtr + 1];
                prevPtr++;
            }

            arr[N - 1] = 1;
            prev = arr;
        }

        return prev;
    }
}
