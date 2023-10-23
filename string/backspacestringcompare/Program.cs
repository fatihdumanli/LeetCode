using System.Configuration.Assemblies;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace backspacestringcompare;
class Program
{
    static void Main(string[] args)
    {
        var s = "isfcow#";
        var t = "isfco#w#";

        var r = BackspaceCompare(s, t);
        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/backspace-string-compare
    // This solution does not use any memory
    // Based on rewriting removed characters with X
    // Then two pointers used for comparison.
    // O(N) time complexity - O(1) space complexity
    static bool BackspaceCompare(string s, string t)
    {
        var ss = new StringBuilder(s);
        var tt = new StringBuilder(t);
        
        ClearString(ss);
        ClearString(tt);
        
        var sPtr = 0;
        var tPtr = 0;
        var sCtr = 0;
        var tCtr = 0;
        
        while(sPtr < ss.Length || tPtr < tt.Length)
        {
            if(sPtr < ss.Length && ss[sPtr] == 'X')
            {
                sPtr++;
                continue;
            }
            
            if(tPtr < tt.Length && tt[tPtr] == 'X')
            {
                tPtr++;
                continue;
            }
            
            if(sPtr < ss.Length && tPtr < tt.Length && ss[sPtr] != tt[tPtr])
                return false;
            
            if(sPtr < ss.Length)
                sCtr++;
            
            if(tPtr < t.Length)
                tCtr++;
            
            sPtr++;
            tPtr++;
        }
        
        return sCtr == tCtr;
    }

    // var s = "a##c";
    // var t = "#a#c";
    // "isfcow#"
    // "isfco#w#"
    private static void ClearString(StringBuilder s)
    {
        var sPtr = 0;
        var tPtr = 0;
        var lastLetterIndex = 0;
        
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] != '#')
                lastLetterIndex = i;

            var ptr = i;
            var total = 0;
            
            while(ptr < s.Length && s[ptr] == '#')
            {
                s[ptr] = 'X';
                total++;
                ptr++;
            }
            
            if(total > 0)
                Mark(s, lastLetterIndex, total, markWith: 'X');
        }

    }
    
    
    private static void Mark(StringBuilder sb, int end, int count, char markWith)
    {
        var ptr = end;
        
        while(ptr >= 0 && count > 0)
        {
            if(sb[ptr] == markWith)
            {
                ptr--;
                continue;
            }
            
            sb[ptr--] = markWith;
            count--;
        }
    }



    // With O(N) memory usage
    static bool BackspaceCompareWithStack(string s, string t)
    {
        Stack<char> stack = new Stack<char>();
        Stack<char> stack2 = new Stack<char>();
        
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] == '#' && stack.Count > 0)
                stack.Pop();
            else if(s[i] != '#')
                stack.Push(s[i]);
            
        }
        
        for(int i = 0; i < t.Length; i++) 
        {
            if(t[i] == '#' && stack2.Count > 0)
                stack2.Pop();
            else if(t[i] != '#')
                stack2.Push(t[i]);
        }
        
        StringBuilder sb1 = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
        
        while(stack.Count > 0)
            sb1.Append(stack.Pop());

        while(stack2.Count > 0)
            sb2.Append(stack2.Pop());
        
        return sb1.ToString() == sb2.ToString();
    }
}
