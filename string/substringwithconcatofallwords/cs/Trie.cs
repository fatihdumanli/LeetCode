namespace cs;

public class TrieNode
{
    public TrieNode[] Children { get; set; } = new TrieNode[26];
    public bool IsLeafNode { get; set; }
    
    public TrieNode(bool isLeafNode)
    {
        IsLeafNode = IsLeafNode;
    }
}

public class Trie
{
    public TrieNode Root { get; set; }

    public Trie()
    {
        Root = new TrieNode(isLeafNode: false);
    }

    public void AddWord(string word)
    {
        var ptr = Root;

        for (int i = 0; i < word.Length; i++)
        {
            var letter = word[i];
            var charAscii = (int)letter;
            var letterIndex = charAscii - 97;
            var child = ptr.Children[letterIndex];

            if (child == null)
            {
                ptr.Children[letterIndex] = new TrieNode(false);
            }

            ptr = ptr.Children[letterIndex];

            if (i == word.Length - 1)
            {
                ptr.IsLeafNode = true;
            }
        }
    }

    public bool SearchWord(string word)
    {
        var ptr = Root;

        foreach(var c in word)
        {
            var letterIndex = (int)c - 97;

            if (ptr.Children[letterIndex] == null)
                return false;

            ptr = ptr.Children[letterIndex];
        }

        return ptr.IsLeafNode;
    }
}
