using AddAndSearchWordLib;
using Xunit;

namespace AddAndSearchWord.Tests;

public class AddAndSearchWordTests
{
    [Fact]
    public void Test1()
    {
        var dict = new WordDictionary();

        dict.AddWord("fatih");
        dict.AddWord("figen");
        dict.AddWord("nehir");
        dict.AddWord("hank");
        dict.AddWord("walt");

        Assert.True(dict.Search("fatih"));
        Assert.True(dict.Search("fati."));
        Assert.True(dict.Search("f.ti."));
        Assert.False(dict.Search("atih"));
    }

    [Fact]
    public void TestAA()
    {
        var dict = new WordDictionary();

        dict.AddWord("a");
        dict.AddWord("a");

        Assert.True(dict.Search("."));
        Assert.True(dict.Search("a"));
        Assert.False(dict.Search("aa"));
        Assert.True(dict.Search("a"));
        Assert.False(dict.Search(".a"));
        Assert.False(dict.Search("a."));
    }

    /*
     *
     *  ["WordDictionary","addWord","addWord","addWord","addWord","search","search","addWord","search","search","search","search","search","search"]
        [[],                ["at"],   ["and"],["an"],     ["add"], ["a"],    [".at"],["bat"],  [".at"], ["an."], ["a.d."],["b."],["a.d"],["."]]
        [null,null,null,null,null,                                 false,     false,  null,     true,    true,     false,  false, true,   false]
     */
    [Fact]
    public void Test3()
    {
        var dict = new WordDictionary();

        dict.AddWord("at");
        dict.AddWord("and");
        dict.AddWord("an");

        Assert.False(dict.Search("a"));
        Assert.False(dict.Search(".at"));
        dict.AddWord("bat");

        Assert.True(dict.Search(".at"));
        Assert.True(dict.Search("an."));
        Assert.False(dict.Search("a.d."));

        Assert.False(dict.Search("b."));
        Assert.True(dict.Search("a.d"));
        Assert.False(dict.Search("."));
    }
}
