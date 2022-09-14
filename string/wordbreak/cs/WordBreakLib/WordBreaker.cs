namespace WordBreakLib;

public class Node
{
    public string val { get; set; }
    public int len { get; set; }

    public Node(string val)
    {
        this.val = val;
    }
}


public class WordBreaker
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        // s = "leetcode" wordDict = ["leet", "code"] => true
        // s = "leetcode" wordDict = ["le", "leet", "code"] => true
        // s = "leetcode" wordDict = ["leet", "tcod", "e", "lee"] => true
        var root = new Node(s);
        root.len = s.Length;

        return Recursion(root, wordDict);
    }

    // s = "applepenapple" dict = ["car", "apple", "pen"]
    // s = "xxxxxpenxxxxx" dict = ["car", "apple", "pen"]
    // s = "carapplepenapple" dict = ["car", "apple", "pen"]
    public bool Recursion(Node root, IList<string> dict)
    {
        foreach (var word in dict)
        {
            if (root.len == 0)
                return true;

            if (!root.val.Contains(word))
            {
                continue;
            }

            var childVal = root.val.ToArray();
            var idx = root.val.IndexOf(word);

            for (int i = idx; i < idx + word.Length; i++)
            {
                childVal[i] = 'x';
            }

            var childNode = new Node(new string(childVal));
            childNode.len = root.len - word.Length;

            var res = Recursion(childNode, dict);

            if (res)
                return true;
        }
        return false;
    }

    //public List<int> GetStartingIndexesOfSubstring(string s, string substring)
    //{
    //    List<int> startingIndexes = new List<int>();

    //    // Contains O(m * n)
    //    int windowSize = substring.Length;
    //    var left = 0;
    //    var right = left + windowSize - 1;

    //    //"carapplepenapple"

    //    while (right < s.Length)
    //    {
    //        var sub = s.Substring(left, right - left + 1);

    //        if (sub == substring)
    //        {
    //            startingIndexes.Add(left);
    //            left = right + 1;
    //            right = left + windowSize - 1;
    //        }

    //        else
    //        {
    //            left++;
    //            right++;
    //        }
    //    }

    //    return startingIndexes;
    //}
}















