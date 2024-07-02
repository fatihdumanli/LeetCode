using System.Text.Json;

namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var nums1 = new int[] { 1, 2, 2, 1 };
        var nums2 = new int[] { 2, 2 };

        var r = Intersect(nums1, nums2);

        Console.WriteLine(JsonSerializer.Serialize(r));
    }

    // https://leetcode.com/problems/intersection-of-two-arrays-ii/
    static int[] Intersect(int[] nums1, int[] nums2) {

        var result = new List<int>();
        var freq1 = new Dictionary<int, int>();
        var freq2 = new Dictionary<int, int>();

        for (int i = 0; i < nums1.Length; i++)
        {
            var num = nums1[i];
            if (freq1.ContainsKey(num))
                freq1[num]++;
            else
                freq1.Add(num, 1);
        }


        for (int i = 0; i < nums2.Length; i++)
        {
            var num = nums2[i];
            if (freq2.ContainsKey(num))
                freq2[num]++;
            else
                freq2.Add(num, 1);
        }

        for (int i = 0; i < nums1.Length; i++)
        {
            var num = nums1[i];

            if (freq1.ContainsKey(num) && freq2.ContainsKey(num))
            {
                var min = Math.Min(freq1[num], freq2[num]);

                for (int k = 0; k < min; k++)
                    result.Add(num);
            }

            freq1[num] = -1;
        }

        return result.ToArray();
    }
}
