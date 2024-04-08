namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var students = new int[] { 1, 1, 0, 0, 0, 1 };
        var sandwiches = new int[] { 0, 0, 1, 0, 0, 1 };

        var r = CountStudents(students, sandwiches);

        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/number-of-students-unable-to-eat-lunch
    public static int CountStudents(int[] students, int[] sandwiches)
    {
        var zeros = 0;
        var ones = 0;

        for (int i = 0; i < students.Length; i++)
        {
            var s = students[i];

            if (s == 0)
                zeros++;
            if (s == 1)
                ones++;
        }

        for (int i = 0; i < sandwiches.Length; i++)
        {
            var sandwich = sandwiches[i];

            if (sandwich == 0)
            {
                // if there's no student who want to circular sandwich, we can't do anything
                // meaning, rest of the students - which we know wanted to eat 'one' sandwithces will be unable to eat lunch.
                // we can return 'ones'
                if (zeros == 0)
                    return ones;

                // a 'zero' student will eventually eat this sandwich
                zeros--;
            }
            else if (sandwich == 1)
            {
                if (ones == 0)
                    return zeros;

                // a 'one' student will eventually eat this sandwich
                ones--;
            }
        }

        return 0;
    }
}