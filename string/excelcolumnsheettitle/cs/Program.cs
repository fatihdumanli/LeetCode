
using System.Text;

namespace cs;

class Program
{
    static void Main(string[] args)
    {

        var columnNumber = Convert.ToInt32(args[0]);
        var r = ConvertToTitle(columnNumber);

        Console.WriteLine(r);

        //ConsoleKeyInfo keyInfo;
        //do
        //{
        //    keyInfo = Console.ReadKey(true);

        //    if (keyInfo.Key == ConsoleKey.UpArrow)
        //    {
        //        action();
        //    }

        //} while (keyInfo.Key != ConsoleKey.Q);
    }

    // https://leetcode.com/problems/excel-sheet-column-title
    static string ConvertToTitle(int columnNumber)
    {
        var alphabet = new char[]
        {
            'Z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
            'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R',
            'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };

        var sb = new StringBuilder();

        while (columnNumber > 0)
        {
            var remainder = columnNumber % 26;
            sb.Append(alphabet[remainder]);

            columnNumber /= 26;

            if (remainder == 0)
                columnNumber--;
        }

        var arr = sb.ToString().ToCharArray();
        Array.Reverse(arr);

        return new string(arr);
    }

    static string ConvertToTitle2(int columnNumber)
    {
        var i = 1;
        var column = new char[32];
        column[31] = 'A';

        var incrementAction = () =>
        {
            // the most right letter is 'Z'
            if (i % 26 == 0)
            {
                // we need to 'increment the left letter'
                var ptr = 30;

                // Possibilities
                // 1. Z: There couldn't be any left letter -> AZ
                // 2. CZ: The left letter could be less than 'Z' - so we can increment it right away 
                //    and set the letter on the right to 'A'. -> DA
                // 3. ZZ: The left letter could be 'Z' - which requires us to add another 'A' to left of it. -> AAA
                // 4. AZZ: The left letter could be 'Z' and at the same time there could have been a letter 
                //    less than 'Z'. Which requires us to increment the most left letter which is 'A' -> BAA
                while (column[ptr] == 'Z')
                {
                    ptr--;
                }

                // add a new 'A' to the left
                if (column[ptr] == '\0')
                {
                    column[ptr] = 'A';
                }
                else
                {
                    column[ptr]++;
                }

                ptr++;

                // make all right-hand side letters 'A'
                while (ptr <= 31)
                {
                    column[ptr++] = 'A';
                }
            }
            else
            {
                column[31]++;
            }

            i++;
        };

        for (int x = 0; x < columnNumber - 1; x++)
        {
            incrementAction();
        }

        var sb = new StringBuilder();

        foreach (var c in column)
        {
            if (c == '\0')
                continue;

            sb.Append(c);
        }

        return sb.ToString();
    }
}
