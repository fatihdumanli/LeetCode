namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var points = new int[][] 
        {
            new int[] { 10, 16 },
            new int[] { 2, 8 },
            new int[] { 11, 12 },
            new int[] { 1, 6 },
            new int[] { 7, 12 },
        };

        //var points = new int[][] 
        //{
        //    new int[] { 1, 2 },
        //    new int[] { 2, 3 },
        //    new int[] { 3, 4 },
        //    new int[] { 4, 5 },
        //};

        var r = FindMinArrowShots(points);

        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/minimum-number-of-arrows-to-burst-balloons
    public static int FindMinArrowShots(int[][] points) {
        // First, sort the balloons by their 'end' position
        //
        // Why not 'start'?
        // Ok, why would I need the information regarding the next balloon's
        // start being greater than the current one?
        //
        // |----|
        //         |-----|
        //
        // How is that info useful? It's simply not.
        //
        //
        // If we sort them by their 'end' position, we can make sure that the
        // next balloon's 'end' position is always greater than the current one.
        //
        // Meaning, if we shoot at the end of the current one, there's a
        // possibility of us shooting both of them.
        //
        // 1      5 
        // |------|
        //     3      7
        //     |------|
        //
        //  We know that the next one's 'end' is greater than the current one. 
        //  If the next one's start is less than the previous one's end, we
        //  don't need to spend another arrow.
        //
        Array.Sort(points, (x, y) => x[1].CompareTo(y[1]));

        var arrowPos = points[0][1];        
        var numOfArrows = 1;

        for (int i = 1; i < points.Length; i++)
        {
            var start = points[i][0];

            // The balloon starts before the arrow, and ends after the arrow
            // No need to spend another arrow
            if (start <= arrowPos)
                continue;


            // If we hit here, despite that the current balloon ends after the
            // previous one, it's start is greater than previous 'end'. 
            // Meaning, there's a gap. We need to spend another arrow.
            //
            // Set the position of the arrow at the end of the current balloon
            arrowPos = points[i][1];
            numOfArrows++;
        }

        return numOfArrows;
    }
}

