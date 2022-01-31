using System;

namespace OneAway
{
    class Program
    {
        static void Main(string[] args)
        {

            var result = OneAway("pale", "ple");
            Console.WriteLine(result);

            result = OneAway("pales", "pale");
            Console.WriteLine(result);

            result = OneAway("pale", "bale");
            Console.WriteLine(result);
            
            result = OneAway("pale", "bake");
            Console.WriteLine(result);
        }


        static bool OneAway(string s1, string s2)
        {
            if (Math.Abs(s1.Length - s2.Length) > 1)
                return false;

            if (s1.Length == s2.Length)
            {
                //Character by character comparison
                bool mismatch = false;
                for (int i = 0; i < s1.Length; i++)
                {
                    if (s1[i] == s2[i]) continue;
                    if (mismatch)
                        return false;
                    mismatch = true;
                }   
            }
            
            else
            {
                //ASCII check
                var charset = new int[26];
                foreach (var c in s1)
                    charset[c - 'a']++;

                var charset2 = new int[26];
                var mismatch = false;
                foreach (var c in s2)
                {
                    charset2[c - 'a']++;

                    if (charset2[c - 'a'] == charset[c - 'a']) continue;
                    
                    if (mismatch)
                        return false;
                    mismatch = true;
                }
            }
            
            return true;
        }
    }
}
