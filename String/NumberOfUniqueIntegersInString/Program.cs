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
            var result = NumDifferentIntegers("00i00e");
            
            
            //a0bc
            //a1b01c001
            
            Console.WriteLine("Hello World!");
        }
        
        
        static int NumDifferentIntegers(string word) {
            HashSet<string> result = new HashSet<string>();    
            var sb = new StringBuilder();
            for(int i = 0; i < word.Length; i++)
            {
                if(IsDigit(word[i]))
                    sb.Append(word[i]);
                if ((IsDigit(word[i]) || sb.Length <= 0) && (!IsDigit(word[i]) || i != word.Length - 1)) continue;          
                var str = sb.ToString();       
                int ptr = 0;
                while (ptr < str.Length - 1 && str[ptr] == '0')
                    ptr++;
                result.Add(str.Substring(ptr, str.Length - ptr));
                sb.Clear();
            }
            return result.Count;
        }
        
        static bool IsDigit(char c) => c >= '0' && c <= '9';

    }
}
