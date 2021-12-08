using System;

namespace IsAnagram
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "anagram";
            var t = "naagram";
            Console.WriteLine(IsAnagram(s, t));
        }
        
        static bool IsAnagram(string s, string t) {
       
            int[] frequency = new int[26];
        
            foreach(var c in s)
                frequency[(int)c - 97]++;
    
            foreach(var c in t)
                frequency[(int)c - 97]--;
                  
            for(int i = 0; i < 26; i++)
                if(frequency[i] != 0) return false;
        
            return true;        
        
        }
    }
}
