namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var n = 1;
        var r = GenerateParenthesis(n);

        Console.WriteLine("Hello, World!");
    }

    // https://leetcode.com/problems/generate-parentheses
    public static IList<string> GenerateParenthesis(int n) {
        var result = new List<string>();

        Weave("", n, 0, n * 2, result);

        return result;
    }

    static void Weave(string phrase, int numOfOpensLeft, int numOfPendingOpens, int targetLength, List<string> result) 
    {
        if (phrase.Length == targetLength)
        {
            result.Add(phrase);
            return;
        }

        // We can't close here
        // We've got no choice but open a new parentheses
        if (numOfPendingOpens == 0)
        {
            numOfOpensLeft--;
            numOfPendingOpens++;
            phrase += "(";
            Weave(phrase, numOfOpensLeft, numOfPendingOpens, targetLength, result);
            return;
        }

        // Did we ran out of opens?
        if (numOfOpensLeft == 0)
        {
            // We've got no choice but close the parentheses
            numOfPendingOpens--;
            phrase += ")";
            Weave(phrase, numOfOpensLeft, numOfPendingOpens, targetLength, result);
            return;
        }

        // We have enough opens, and we have pending opens too.
        // We can either open or close
        Weave(phrase + "(", numOfOpensLeft - 1, numOfPendingOpens + 1, targetLength, result);
        Weave(phrase + ")", numOfOpensLeft, numOfPendingOpens - 1, targetLength, result);
    }
}
