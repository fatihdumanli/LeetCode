using System;

namespace ValidPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "racecar";
            
            // racecar
            Console.WriteLine(IsPalindrome(s));
        }
        
        static bool IsPalindrome(string s) {
        
            int left = 0;
            int right = s.Length - 1;
        
            //raceacar
        
            while(left < right) {
                if(!IsAlphanumeric(s[left])) { left++; continue; }
                if(!IsAlphanumeric(s[right])) { right--; continue; }
            
                if(Char.ToLower(s[left]) != Char.ToLower(s[right]))
                    return false;
            
                left++;
                right--;
            }
        
            return true;
        
        }
    
        static bool IsAlphanumeric(char c) {
            var ascii = (int)c;
            return (ascii >= 48 && ascii <= 57) || (ascii >= 65 && ascii <= 90) || (ascii >= 97 && ascii <= 122);
        }
    }
}
