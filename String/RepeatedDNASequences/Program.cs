using System;
using System.Collections.Generic;
using System.Linq;

namespace RepeatedDNASequences
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = FindRepeatedDnaSequences("AAAAAAAAAAAAA");
            Console.WriteLine("Hello World!");
        }
        
        static IList<string> FindRepeatedDnaSequences(string s) {
        
            HashSet<string> result = new HashSet<string>();
        
            int i = 0; 
            int j = 9;
        
            HashSet<string> hashSet = new HashSet<string>();
        
            while(j < s.Length)
            {
                var current = s.Substring(i, 10);
                if(!hashSet.Contains(current)) {
                    hashSet.Add(current);
                } else {
                    result.Add(current);
                }
            
                i++;
                j++;
            
            }
        
            return result.ToList();
        }
    }
}