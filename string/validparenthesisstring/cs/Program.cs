namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var s = args[0];
        var r = CheckValidString(s);
        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/valid-parenthesis-string/
    // -> any left parenthesis '(' must have a corresponding right parenthesis ')'
    // -> any right parenthesis ')' must have a corresponding left parenthesis '('
    // -> left parenthesis '(' must go before the corresponding right parenthesis ')' 
    // -> '*' could be treated as a single right parenthesis ')' or a single left parenthesis '(' or an empty string ""
    // s[i] is '(', ')', or '*'
    public static bool CheckValidString(string s)
    {
        // add only '(' to this stack
        var openingStack = new Stack<int>();
        var asteriksStack = new Stack<int>();

        for (int i = 0; i < s.Length; i++)
        {
            var current = s[i];

            if (current == '*')
            {
                asteriksStack.Push(i);
            }
            else if (current == ')')
            {
                if (openingStack.Count == 0)
                {
                    // check if we have any asteriks
                    if (asteriksStack.Count == 0)
                        return false;

                    // use one asteriks
                    asteriksStack.Pop();
                }
                else
                {
                    // use one '(' to match with this one
                    openingStack.Pop();
                }
            }
            else
            {
                openingStack.Push(i);
            }
        }

        // Check if we have any pending '('
        // So that we can use '*'s as ')' to match the pending ones.
        while (openingStack.Count > 0)
        {
            if (asteriksStack.Count == 0)
                return false;

            var current = openingStack.Pop();
            var lastAsteriks = asteriksStack.Pop();

            // if last '*' appears before the last '(', return false
            if (lastAsteriks < current)
                return false;
        }

        // (*()()()()
        // '*''s power is that being able to make an INVALID string VALID
        // They can't make a VALID string INVALID so we don't need to worry about 
        // that
        // for '*' to act like a '('
        // 1. we need to encounter a ')'
        // 2. we don't have any '(' in the 'openingStack'
        // 
        // for '*' to act like a ')'
        // 1. we've reached the end of the string
        // 2. we still have elements in 'openingStack', say N
        // 3. there's at least N '*' in the 'asteriksStack'
        // 4. Of course, for an asteriks to act like a ')' to match 
        // an existing '('
        // Asteriks must appear AFTER the '(
        // So we also need the positions of the '*'s


        return true;
    }
}
