using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupAnagrams
{
    public class Solutions
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dict = new Dictionary<string, List<string>>();

            foreach(var str in strs)
            {
                var freq = new int[26];

                for(int i = 0; i < str.Length; i++)
                {
                    freq[str[i] - 97]++;
                }

                var dictKey = GenerateDictionaryKey(freq);

                if(dict.ContainsKey(dictKey))
                    dict[dictKey].Add(str);
                else
                    dict.Add(dictKey, new List<string> { str });
            }

            var x = dict.Values;

            var result = new List<IList<string>>();

            foreach(var v in dict.Values)
            {
                result.Add(v);
            }

            return result as IList<IList<string>>;
        }

        private string GenerateDictionaryKey(int[] frequency)
        {
            var sb = new StringBuilder();

            foreach(var item in frequency)
            {
                sb.Append(item);
                sb.Append(",");
            }

            return sb.ToString();
        }
    }
}
