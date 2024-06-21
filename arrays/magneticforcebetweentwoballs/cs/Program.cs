namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var position = new int[] { 22, 57, 74, 79 };
        var m = 4;

        var r = MaxDistance(position, m);
        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/magnetic-force-between-two-balls
    static int MaxDistance(int[] position, int m)
    {
        Array.Sort(position);

        var max = Int32.MinValue;
        var start = 0;
        var end = position[position.Length - 1];

        while (start <= end)
        {
            var mid = start + (end - start) / 2;

            if (CanArrange(position, mid, m))
            {
                start = mid + 1;
                max = Math.Max(max, mid);
            }
            else
            {
                end = mid - 1;
            }
        }

        return max;
    }


    static bool CanArrange(int[] position, int candidate, int m)
    {
        var c = 1;
        var last = position[0];

        for (int i = 0; i < position.Length; i++)
        {
            if (position[i] - last >= candidate)
            {
                c++;
                last = position[i];
            }

            if (c >= m)
                return true;
        }

        return false;
    }
}


