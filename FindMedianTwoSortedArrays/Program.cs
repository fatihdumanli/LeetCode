using System;

namespace FindMedianTwoSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://leetcode.com/problems/median-of-two-sorted-arrays/
            /*
             * Approach:
             * 1. Merge the arrays in traditional way using 3 pointers
             * 2. Find the median of merged array.
             */
            var arr1 = new int[] {1, 2};
            var arr2 = new int[] {3, 4};
            
            var merged = Merge(arr1, arr2);

            double median;
            
            if (merged.Length % 2 == 1)
            {
                var midPoint = merged.Length / 2;
                median = merged[midPoint];
            }

            //1,2,3,4
            else
            {
                var midPoint = merged.Length / 2;
                var num1 = merged[midPoint];
                var num2 = merged[midPoint - 1];
                median = ((double)num1 + (double)num2) / 2;
            }
            
        }

        static int[] Merge(int[] a, int[] b)
        {
            var c = new int[a.Length + b.Length];
            int i = 0, j = 0, k = 0;
            
            while (i < a.Length && j < b.Length)
            {
                if (a[i] == b[j])
                {
                    c[k++] = a[i++];
                    c[k++] = b[j++];
                    continue;
                }
                
                if (a[i] < b[j])
                {
                    c[k++] = a[i++];
                    continue;
                }

                if (b[j] < a[i])
                    c[k++] = b[j++];
            }

            for (; i < a.Length; i++)
                c[k++] = a[i];

            for (; j < b.Length; j++)
                c[k++] = b[j];
            
            return c;
        }
    }
}
