namespace cs;

public class Result
{
    public int val { get; set; }
}

class Program
{
    static void Main(string[] args)
    {

        var s = "010100010101001";
        // s = "01001001";
        var r = NumWays(s);
        Console.WriteLine(r);
    }


    // https://leetcode.com/problems/number-of-ways-to-split-a-string
    static int NumWays(string s) {

        // The only way we're gonna be able to split the string into 3 parts
        // with each part having the same number of '1's in it is that number of
        // 1's in the string is divisible to 3. (total % 3 == 0)
        var total = 0;
        foreach(var c in s)
        {
            if (c == '1')
                total++;
        }

        if (total % 3 != 0)
            return 0;

        int need = total / 3;

        var result = new Result();

        // Now we permute the string with three windows.
        // Each window has 'start' end 'end'
        // We expand window as long as we maintain the number of ones equal to
        // 'need'
        //
        // 0    1   0   0   1   0   0   1
        // s/e
        // 
        // 0    1   0   0   1   0   0   1
        // s    e
        // 
        // 0    1   0   0   1   0   0   1
        // s    e  s/e
        //
        // 0    1   0   0   1   0   0   1
        // s    e   s   e
        //
        // 0    1   0   0   1   0   0   1
        // s    e   s       e
        //
        // 0    1   0   0   1   0   0   1
        // s    e   s       e   s       e
        //
        // 0    1   0   0   1   0   0   1
        // s    e   s           e   s   e
        //
        // 0    1   0   0   1   0   0   1
        // s    e   s               e  s/e
        //
        // 0    1   0   0   1   0   0   1
        // s    e   s                   e X TERMINATE
        //
        // 0    1   0   0   1   0   0   1
        // s        e   s/e                     
        //
        // 0    1   0   0   1   0   0   1
        // s        e   s   e   s       e                 
        //
        // 0    1   0   0   1   0   0   1
        // s        e   s       e   s   e             
        //
        // 0    1   0   0   1   0   0   1
        // s        e   s           e   s/e
        //
        // 0    1   0   0   1   0   0   1
        // s        e   s           e   s/e
        //
        // 0    1   0   0   1   0   0   1  X (NUMBER OF 1's exceed the 'need')
        // s        e   s               e
        //
        // 0    1   0   0   1   0   0   1  
        // s            e  s/e  s       e
        //
        // 0    1   0   0   1   0   0   1  
        // s            e   s   e   s   e
        //
        // 0    1   0   0   1   0   0   1  
        // s            e   s       e  s/e 
        //
        // 0    1   0   0   1   0   0   1  
        // s            e   s           e X (NUMBER OF 1's exceed the 'need')
        //
        // 0    1   0   0   1   0   0   1  
        // s            e   s           e X (NUMBER OF 1's exceed the 'need')
        //
        // 0    1   0   0   1   0   0   1  
        // s            e   s              e X (ARRAY OVERFLOW)
        //
        // 0    1   0   0   1   0   0   1  
        // s                e             X (NUMBER OF 1's exceed the 'need')
        Permute(s, 0, 0, 1, need, result);

        return result.val;
    }

    static void Permute(string s, int start, int end, int total, int need, Result result)
    {
        if (end >= s.Length)
            return;

        if (total == 3)
        {
            result.val++;
            return;
        }

        var ones = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (end < s.Length && s[end] == '1')
                ones++;

            if (ones > need)
                return;
            else if (ones == need)
            {
                Permute(s, start: end + 1, end: end + 1, total + 1, need, result);
            }

            end++;
        }
    }
}
