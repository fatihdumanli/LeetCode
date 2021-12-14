using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumWindowSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "a", t = "a";
            var result = MinWindow(s, t);
            Console.WriteLine("Hello World!");
        }
        
        static  string MinWindow(string s, string t) {        
            
            Dictionary<char, int> need = new Dictionary<char, int>();
            Dictionary<char, int> have = new Dictionary<char, int>();
            int needTotal = 0;
            int haveTotal = 0;
            
            foreach(var c in t)
            {
                needTotal++;
                if(need.ContainsKey(c))
                    need[c]++;
                else
                {
                    need.Add(c, 1);
                    have.Add(c, 0);
                }
            }
            
            int left = 0;
            int right = 0;
            int minWindowLength = Int32.MaxValue;
            int minWindowStart = Int32.MinValue;
            int minWindowEnd = Int32.MinValue;
            
            if (have.ContainsKey(s[right]))
            {
                have[s[right]]++;
                haveTotal++;
            }

            bool isValid = IsValid(have, need, needTotal, haveTotal);
            
            while(true)
            {
                if(!isValid)
                {        
                    if(right == s.Length - 1)
                        break;
                 
                    if(have.ContainsKey(s[++right]))
                    {
                        haveTotal++;
                        have[s[right]]++;
                    }

                    isValid = IsValid(have, need, needTotal, haveTotal);
                }
            
                else {
                
                    if(right - left + 1 < minWindowLength) {
                        minWindowLength = right - left + 1;
                        minWindowStart = left;
                        minWindowEnd = right;
                    }
                
                    // try to shrink
                    if (have.ContainsKey(s[left]))
                    {
                        have[s[left++]]--;
                        haveTotal--;
                    }

                    else
                        left++;

                    isValid = IsValid(have, need, needTotal, haveTotal);
                }
            }
        
            return minWindowLength == Int32.MaxValue ? "" : s.Substring(minWindowStart, minWindowEnd - minWindowStart + 1);
        
    }
        
        static bool IsValid(Dictionary<char, int> have, Dictionary<char, int> need, int needTotal, int haveTotal)
        {
            if (haveTotal < needTotal)
                return false;
            
            foreach (var item in need)
            {
                if (have[item.Key] < item.Value)
                    return false;
            }
            return true;
        }


    }
}
