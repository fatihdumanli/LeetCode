using System.Text;

namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var s = "lee(t(c)o)de)";
        var r = MinRemoveToMakeValid(s);

        Console.WriteLine(r);
    }

    static string MinRemoveToMakeValid(string s)
    {
        const char CHAR_DELETED = '-';

        // Holds the positions of '('s
        var openingStack = new Stack<int>();
        var arr = s.ToCharArray();

        for (int i = 0; i < s.Length; i++)
        {
            var current = s[i];

            // it's opening
            if (current == '(')
                openingStack.Push(i);

            else if (current == ')')
            {
                // We've encountered a ')' and we don't have enough opening to match this one to.
                // This needs to be removed
                if (openingStack.Count == 0)
                {
                    arr[i] = CHAR_DELETED;
                    continue;
                }

                // We match the current 'closing' with a pending 'opening'
                openingStack.Pop();
            }
        }

        // After the entire loop, if there's still opening, 
        // That means we didn't have enough closing to match them to.
        while (openingStack.Count > 0)
        {
            var pos = openingStack.Pop();
            arr[pos] = CHAR_DELETED;
        }

        var sb = new StringBuilder();

        for (int i = 0; i < arr.Length; i++)
        {
            var current = arr[i];

            if (current == CHAR_DELETED)
                continue;

            sb.Append(current);
        }

        return sb.ToString();
    }
}



