namespace StringDictLib;

public interface IStringDict
{
    void Add(string word);
    bool Contains(string word);
    void Remove(string word);
}
