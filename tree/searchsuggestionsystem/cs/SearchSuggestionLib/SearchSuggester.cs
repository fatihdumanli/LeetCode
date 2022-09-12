using System.Text;

namespace SearchSuggestionLib;

public class TrieNode
{
    public TrieNode[] Children { get; set; }
    public bool IsNullNode { get; set; }

    public TrieNode()
    {
        Children = new TrieNode[27];
    }
}

public class Trie
{
    public TrieNode Root { get; set; }

    public Trie()
    {
        Root = new TrieNode();
    }

    public void AddWord(string word)
    {
        var ptr = Root;

        for (int i = 0; i < word.Length; i++)
        {
            var ascii = word[i];

            var childIdx = ascii - 97;

            if (ptr.Children[childIdx] == null)
            {
                ptr.Children[childIdx] = new TrieNode();
            }

            ptr = ptr.Children[childIdx];
        }

        ptr.Children[26] = new TrieNode() { IsNullNode = true };
    }
}

public class SearchSuggester
{
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
    {
        var trie = new Trie();
        foreach (var item in products)
        {
            trie.AddWord(item);
        }

        var result = new List<IList<string>>();
        var prefix = new StringBuilder();

        var ptr = trie.Root;

        // searchWord: "mouse"
        for (int i = 0; i < searchWord.Length; i++)
        {
            var list = new List<string>();

            prefix.Append(searchWord[i]);

            var idx = searchWord[i] - 97;
            ptr = ptr?.Children[idx];

            if (ptr == null)
            {
                result.Add(list);
                continue;
            }

            GetWordsByPrefix(ptr, prefix.ToString(), list);

            result.Add(list);
        }

        return result;
    }


    public void GetWordsByPrefix(TrieNode root, string prefix, List<string> result)
    {
        if (result.Count == 3)
            return;

        if (root.Children[26] != null)
        {
            result.Add(prefix);
        }

        for (int i = 0; i < root.Children.Length; i++)
        {
            var child = root.Children[i];

            if (child != null)
            {
                var val = (char)(i + 97);
                GetWordsByPrefix(child, prefix + val, result);
            }
        }
    }
}
















