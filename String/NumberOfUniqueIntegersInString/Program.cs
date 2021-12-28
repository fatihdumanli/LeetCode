using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberOfUniqueIntegersInString
{ 
    class Program
    {
        static void Main(string[] args)
        {
            var result = NumDifferentIntegers("a1b01c001");
            
            
            Console.WriteLine("Hello World!");
        }
        
        
        static int NumDifferentIntegers(string word) {
            HashSet<string> result = new HashSet<string>();    
            var sb = new StringBuilder();
            for(int i = 0; i < word.Length; i++)
            {    
                if(IsDigit(word[i]))
                    sb.Append(word[i]);      
                if((!IsDigit(word[i]) && sb.Length > 0) || (IsDigit(word[i]) && i == word.Length - 1)) {
                    //Todo: The number itself could be zero
                    //And we need to ignore leading zeros.       
                    result.Add(sb.ToString());
                    sb = new StringBuilder();
                }    
            }
            return result.Count;
        }
        static bool IsDigit(char c) => c >= '0' && c <= '9';

    }
}
