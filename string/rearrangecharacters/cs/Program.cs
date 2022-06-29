//https://leetcode.com/problems/rearrange-characters-to-make-target-string/
//
string s = "ilovecodingonleetcode";
string target = "code";

var result = RearrangeCharacters(s, target);
Console.WriteLine(result);

int RearrangeCharacters(string s, string target) {

    //1. Arrange the hashmap
    var hashmap = new Dictionary<char, int>();

    foreach(char c in s) 
    {
        if(hashmap.ContainsKey(c))
        {
            hashmap[c]++;
            continue;
        }
        hashmap.Add(c, 1);
    }

    int totalCopies = 0;

    while(true)
    {
        foreach(char c in target)
        {
            var ascii = c;

            if(!hashmap.ContainsKey(ascii))
                return totalCopies;

            if(hashmap[ascii] == 0)
                return totalCopies;
            
            hashmap[ascii]--;
        }

        totalCopies++;
    }
}