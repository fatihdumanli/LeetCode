using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GroupAnagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            
            /*
             *  Sorting approach took 27382 ms
                Encoding approach took 10317 ms
             */
            
            var strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            stopWatch.Start();
            var result = GroupAnagramsOptimized(strs);
            Console.WriteLine($"Encoding approach took {stopWatch.ElapsedTicks} ms");
            stopWatch.Reset();
            stopWatch.Start();
            result = GroupAnagrams(strs);
            stopWatch.Stop();
            Console.WriteLine($"Sorting approach took {stopWatch.ElapsedTicks} ms");
           

            Dictionary<int[], List<string>> dict = new Dictionary<int[], List<string>>();
            dict.Add(new int[] { 0, 1, 2}, new List<string>());


            var check = new int[] { 0, 1, 2 };
            var contains = dict.ContainsKey(check);

        }


        static IList<IList<string>> GroupAnagramsOptimized(string[] strs)
        {
            var hashmap = new Dictionary<string, IList<string>>();
            foreach (var item in strs)
            {
                var charset = new int[26];
                foreach (var t in item)
                {
                    charset[t - 'a']++;
                }

                var encoded = EncodeArray(charset);
                
                if(hashmap.ContainsKey(encoded))
                    hashmap[encoded].Add(item);
                else
                    hashmap[encoded] = new List<string>() { item };
                
            }

            return hashmap.Values.ToList();
        }

        
        //0(26) - Constant time.
        static string EncodeArray(int[] arr)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                sb.Append(arr[i]);
                if(i < 25)
                    sb.Append(";");
            }
            return sb.ToString();
        }
        

        // O(N * M * LOG(M))
        // Where M is equal to avg. length and N is equal to number of strings.
        static IList<IList<string>> GroupAnagrams(string[] strs) {
        
            Dictionary<string, IList<string>> hashmap = new Dictionary<string, IList<string>>();
            
            //O(n * m log m)
            for(int i = 0; i < strs.Length; i++)
            {
                var charArr = strs[i].ToCharArray();
        
                // O(m * log m) where m is equal to the avg. length
                Array.Sort(charArr);
                var sorted = new string(charArr);
            
                if(hashmap.ContainsKey(sorted))
                    hashmap[sorted].Add(strs[i]);
                else {
                    hashmap.Add(sorted, new List<string>() {
                        strs[i]
                    });   
                }
            }

            return hashmap.Values.ToList();
        }
    }
}
