using System;

namespace OneAway
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        static bool OneAway(string s1, string s2)
        {
            int[] charset1 = new int[26];
            int[] charset2 = new int[26];
            
            foreach (var c in s1)
                charset1[c - 'a']++;

            foreach (var c in s2)
                charset2[c - 'a']++;


            int charactersOff = 0;
            
            for (int i = 0; i < 26; i++)
            {
                if (charset1[i] != charset2[i])
                    charactersOff++;

                if (charactersOff > 1)
                    return false;
            }

            return true;
        }
    }
}
