using System;
using System.Linq;

namespace URLify
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "aa bb cc    ";
            var test = s.ToCharArray();
            var result = URLify(s, 8);
            result = URLify2(s, 8);
            Console.WriteLine(result);
        }

        static string URLify2(string s, int actualLength)
        {

            int numberOfSpaces = 0;
            for (int i = 0; i < actualLength; i++)
            {
                if (s[i] == ' ')
                    numberOfSpaces++;
            }

            var phrase = s.ToCharArray();
            int spacesSoFar = 0;
            for (int i = actualLength - 1; i >= 0; i--)
            {
                var expr = (numberOfSpaces * 2) - (spacesSoFar * 2);
                if (phrase[i] != ' ')
                {
                    phrase[i + expr] = phrase[i];
                }

                else
                {
                    spacesSoFar++;
                    phrase[i + expr] = '0';
                    phrase[i + expr - 1] = '2';
                    phrase[i + expr - 2] = '%';
                }
            }
            return new string(phrase);
        }
        static string URLify(string s, int actualLength)
        {
            char[] phrase = new char[actualLength * 3];
            int wordLength = 0;
            int i = 0;
            int j = 0;

            while (wordLength < actualLength)
            {
                if (s[i] != ' ')
                {
                    phrase[j++] = s[i++];
                    wordLength++;
                    continue;
                }

                i++;
                wordLength++;

                phrase[j++] = '%';
                phrase[j++] = '2';
                phrase[j++] = '0';
            }

            phrase[j] = '\0';

            return new string(phrase);
        }
    }
}
