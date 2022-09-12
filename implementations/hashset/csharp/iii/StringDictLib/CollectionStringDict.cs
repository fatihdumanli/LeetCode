namespace StringDictLib;

public class CollectionStringDict : IStringDict
{
    List<string> _words = new List<string>();

    public void Add(string word)
    {
        if (Contains(word))
            return;

        _words.Add(word);
    }

    public bool Contains(string word)
    {
        return _words.Contains(word);
    }

    public void Remove(string word)
    {
        _words.RemoveAll(w => w == word);
    }
}
