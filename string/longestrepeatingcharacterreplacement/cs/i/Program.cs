using System;
using System.Collections.Generic;

namespace LongestRepeatingCharacterReplacement
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "ABBB";
            //"AABABBBBBB"
            //1

            var result = CharacterReplacement(str, 2);
            Console.WriteLine("Hello World!");
        }
        
        static int CharacterReplacement(string s, int k) {
                
            Dictionary<char, int> frequency = new Dictionary<char, int>();

            char[] englishCharacters = new char[] {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'R', 'S', 'T', 
                'Q','W','U', 'X','V', 'Y', 'Z'
            };
        
            foreach(var c in englishCharacters)
                frequency.Add(c, 0);
            
            int left = 0;
            int right = 0;
            int max = 0;    
        
            // 26 + O(N * 26) = O(26*N) = O(N) 
            int maxFrequency = 0;

            while(right < s.Length)
            {        
                frequency[s[right]]++;
            
            
                foreach(var item in frequency)
                    maxFrequency = Math.Max(maxFrequency, item.Value);
            
                var substringLength = right - left + 1;
            
                //valid substring
                if(substringLength - maxFrequency <= k)
                {
                    max = Math.Max(max, substringLength);
                    right++;
                }
            
                else 
                {
                    frequency[s[left]]--;
                    frequency[s[right]]--;
                    left++;
                }    
            
            }
        
            return max;
        }
    }
}
