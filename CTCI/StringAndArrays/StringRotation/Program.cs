namespace StringRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = "waterbottle";
            var s2 = "erbottlewat";
            var result = IsRotation(s1, s2);
        }

        static bool IsRotation(string s1, string s2)
        {
            return (s1.Length <= s2.Length) && (s2 + s2).Contains(s1);
        }
    }
}
