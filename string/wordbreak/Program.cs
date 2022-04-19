using System;
using System.Collections.Generic;

namespace wordbreak
{
    class Program
    {
        // https://leetcode.com/problems/word-break/
        static void Main(string[] args)
        {
            //"abcd"
            //["a","abc","b","cd"]
            var words = new string[] {"bc", "cb"};
            var s = "ccbb";
            var result = WordBreak(s, words);
            Console.WriteLine(result);
        }

        static bool WordBreak(string s, IList<string> wordDict)
        {
            // 1. Build hashset with the wordDict
            var hashset = new HashSet<string>();
            for(int i = 0; i < wordDict.Count; i++)
            {
                hashset.Add(wordDict[i]);
            }
            
            return Helper(s, hashset, "");
        }

        static bool Helper(string s, HashSet<string> words, string remove)
        {
            if (s == "") 
                return true;

            if (!s.StartsWith(remove)) 
                return false;

            if (!string.IsNullOrEmpty(remove))
            {
                var index = s.IndexOf(remove);
                s = s.Remove(index, remove.Length);
            }

            foreach(var w in words)
            {
                var res = Helper(s, words, w);

                if (res)
                    return true;
            }

            return false;
        }
    }
}
