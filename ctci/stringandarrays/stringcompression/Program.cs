using System;
using System.Text;

namespace StringCompression
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "aabcccccaaa";
            var result = Compress(str);
            Console.WriteLine(result);
        }

        private static string Compress(string s)
        {
            if (s.Length < 3)
                return s;
            
            StringBuilder sb = new StringBuilder();
            char current = s[0];
            int soFar = 1;
            
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i + 1] == current)
                {
                    soFar++;
                    continue;
                }

                sb.Append(current);
                sb.Append(soFar);
                current = s[i + 1];
                soFar = 1;
            }
            
            sb.Append(current);
            sb.Append(soFar);
            
            return sb.Length > s.Length ? s : sb.ToString();
        }
    }
}
