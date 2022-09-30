public class TrieNode
{
    public TrieNode[] children { get; set; }
    public string word { get; set; }

    public TrieNode()
    {
        children = new TrieNode[27];
    }
}

public class Trie
{
    public TrieNode root = new TrieNode();

    public void Add(string word)
    {
        var ptr = root;

        for (int i = 0; i < word.Length; i++)
        {
            var ascii = word[i];
            var idx = ascii - 'a';

            if (ptr.children[idx] == null)
            {
                ptr.children[idx] = new TrieNode();
            }

            ptr = ptr.children[idx];
        }

        ptr.word = word;
    }

}
class Program
{
    static void Main(string[] args)
    {
        var board = new char[][]
        {
            new char[] { 'o', 'a', 'a', 'n' },
            new char[] { 'e', 't', 'a', 'e' },
            new char[] { 'i', 'h', 'k', 'r' },
            new char[] { 'i', 'f', 'l', 'v' },
        };
        var words = new string[] { "oath", "pea", "eat", "rain" };
        var r = FindWords(board, words);
    }

    public static IList<string> FindWords(char[][] board, string[] words)
    {
        var trie = new Trie();

        foreach (var word in words)
        {
            trie.Add(word);
        }


        var result = new HashSet<string>();

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                var visited = new bool[board.Length * board[0].Length];
                DFS(board, i, j, trie.root, result, visited);
            }
        }

        return result.ToList();
    }

    public static int DFS(char[][] board, int i, int j, TrieNode node, HashSet<string> result, bool[] visited)
    {
        if (i < 0 || i >= board.Length || j < 0 || j >= board[i].Length)
            return -1;

        var cellIdx = (i * board[0].Length) + j;

        if (visited[cellIdx])
            return -1;

        var idx = board[i][j] - 'a';
        node = node.children[idx];

        if (node == null)
            return -1;

        if (!string.IsNullOrEmpty(node.word))
        {
            result.Add(node.word);
            node.word = null;
        }

        visited[cellIdx] = true;

        var left = DFS(board, i, j - 1, node, result, visited);
        if (left != -1)
            visited[left] = false;
        var right = DFS(board, i, j + 1, node, result, visited);
        if (right != -1)
            visited[right] = false;
        var top = DFS(board, i - 1, j, node, result, visited);
        if (top != -1)
            visited[top] = false;
        var bottom = DFS(board, i + 1, j, node, result, visited);
        if (bottom != -1)
            visited[bottom] = false;

        return cellIdx;
    }
}


