using System.Collections;
using System.Collections.Generic;
using StringDictLib;
using Xunit;

namespace StringDictLibTests;

public class StringDictTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var dict1 = new HashSetStringDict();
        dict1.Add("fatih");
        dict1.Add("hashset");
        dict1.Add("bytes");
        dict1.Add("integers");
        dict1.Add("cats");

        yield return new object[] { dict1, "fatih", true };
        yield return new object[] { dict1, "hashset", true };
        yield return new object[] { dict1, "bytes", true };
        yield return new object[] { dict1, "integers", true };
        yield return new object[] { dict1, "cats", true };
        yield return new object[] { dict1, "dogs", false };
        yield return new object[] { dict1, "giraffes", false };
        yield return new object[] { dict1, "strings", false };
        yield return new object[] { dict1, "bits", false };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class StringDictTests
{
    [Theory]
    [InlineData("fatih")]
    [InlineData("hashset")]
    [InlineData("bytes")]
    [InlineData("integers")]
    [InlineData("cats")]
    public void Add_AfterAdding_ContainsShouldReturnTrue(string word)
    {
        var dict = new HashSetStringDict();

        dict.Add(word);

        Assert.True(dict.Contains(word));
    }

    [Theory]
    [ClassData(typeof(StringDictTestData))]
    public void Contains_ShouldReturnAccurateValues(IStringDict dict, string word, bool expected)
    {
        var actual = dict.Contains(word);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(StringDictTestData))]
    public void Contains_ShouldReturnFalse_AfterRemoving(IStringDict dict, string word, bool expected)
    {
        var actual = dict.Contains(word);

        Assert.Equal(expected, actual);

        dict.Remove(word);

        actual = dict.Contains(word);

        Assert.False(actual);
    }
}
