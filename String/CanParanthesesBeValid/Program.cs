using System;

namespace CanParanthesesBeValid
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var s = "((()(()()))()((()()))))()((()(()";
            var locked = "10111100100101001110100010001001";

            var result = CanBeValid(s, locked);

        }
        
        static bool CanBeValid(string s, string locked) {
       
            /* OPTIMIZATIONS */
            if(s.Length % 2 == 1)
                return false;

            //First char must be ( no matter what
            if(s[0] == ')' && locked[0] == '1')
                return false;
            /* OPTIMIZATIONS */
            
            return true;
        }
        
        private static char Swap(char c) => c == ')' ? '(' : ')';
        private static bool IsSymmetric(char s, char e) => (s == '(' && e == ')') || (s == ')' && e == '(');
    }
}
