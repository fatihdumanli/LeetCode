using System;

namespace PalindromeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"[{args[0]}] Is Palindrome?: {IsPalindrome(Convert.ToInt32(args[0]))}");
        }

        static bool IsPalindrome(int x)
        {
            var str = x.ToString();
            var length = str.Length;
        
            int middle = length / 2;
        
            int i = 0;
        
            while(i < middle)
            {
                if(str[i] != str[length - 1 - i])
                {
                    return false;
                }
                i++;            
            }
        
            return true;

        }
    }
}
