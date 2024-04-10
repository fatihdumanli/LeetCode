namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var deck = new int[] { 1, 8, 3, 12, 4, 9, 5, 11, 6, 17, 7 };
        var r = DeckRevealedIncreasing(deck);
        Console.WriteLine("Hello, World!");
    }

    // https://leetcode.com/problems/reveal-cards-in-increasing-order
    static int[] DeckRevealedIncreasing(int[] deck)
    {
        Array.Sort(deck);

        var sortedPtr = 0;
        var result = new int[deck.Length];

        // Take or bury?
        var isTake = true;

        while (sortedPtr < deck.Length)
        {
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != 0)
                    continue;

                // here we've got an unprocessed index
                if (isTake)
                {
                    result[i] = deck[sortedPtr++];
                    isTake = false;
                    continue;
                }
                else
                {
                    isTake = true;
                }
            }
        }
        return result;
    }
}
