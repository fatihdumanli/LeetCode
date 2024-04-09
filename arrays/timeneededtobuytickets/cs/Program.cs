namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var tickets = new int[] { 84, 49, 5, 24, 70, 77, 87, 8 };
        var k = 3;

        var r = TimeRequiredToBuy(tickets, k);
        Console.WriteLine(r);
    }

    // Rule set:
    // Ahead - less: Add the other one 
    // Ahead - equal: Add the other one
    // Ahead - more: Add the current one
    // 
    // Behind - less: Add the other one
    // Behind - equal: Add (the current one - 1)
    // Behind - more: Add (the current one - 1)
    // https://leetcode.com/problems/time-needed-to-buy-tickets
    static int TimeRequiredToBuy(int[] tickets, int k)
    {
        var timeNeeded = 0;

        for (int i = 0; i < tickets.Length; i++)
        {
            // Ahead
            if (i <= k)
            {
                // add the one with less tickets
                timeNeeded += Math.Min(tickets[i], tickets[k]);
            }
            // Behind
            else
            {
                // less
                if (tickets[i] < tickets[k])
                    timeNeeded += tickets[i];

                // more
                else
                    timeNeeded += tickets[k] - 1;
            }
        }

        return timeNeeded;
    }
}
