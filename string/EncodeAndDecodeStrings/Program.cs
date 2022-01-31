using System;
using System.Collections.Generic;
using System.Text;

namespace EncodeAndDecodeStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            char c = '小';
            var t = (int)c;
            
            var words = new string[]
            {
                "foo", "bar", "3te", "#4", "54#", ";test:"
            };

            Console.WriteLine("Words: ");
            Console.Write("[");
            foreach (var word in words)
            {
                Console.Write("\"");
                Console.Write(word);
                Console.Write("\"");
                Console.Write(",");
            }
            Console.Write("]");
            Console.WriteLine();
            var encoded = Encode(words);
            Console.WriteLine($"Encoded: {encoded}");
            var decoded = Decode(encoded);
            Console.WriteLine("Decoded: ");
            
            Console.Write("[");
            foreach (var word in decoded)
            {
                Console.Write("\"");
                Console.Write(word);
                Console.Write("\"");
                Console.Write(",");
            }
            Console.Write("]");
        }

        static string Encode(string[] words)
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (var w in words)
            {
                var len = w.Length;

                sb.Append($"{len}#{w}");

            }
            return sb.ToString();
        }

        static string[] Decode(string encoded)
        {
            List<string> words = new List<string>();

            int ptr = 0;

            while (ptr < encoded.Length - 1)
            {
                var num = "";
                var pos = ptr;
                while (encoded[pos] != '#')
                {
                    num += encoded[pos++];
                }
                
                
                var length = Convert.ToInt32(num);
            
                var word = encoded.Substring(pos + 1, length);
                words.Add(word);

                ptr = ptr + length + 2;
            }
            
            return words.ToArray();
        }
    }
}
