using System.Collections;
using System.Collections.Generic;
using WordBreakLib;
using Xunit;

namespace WordBreak.Tests;

public class WordBreakerTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "carapplepenapple", new List<string>() { "apple", "pen" }, false };
        yield return new object[] { "applepenapple", new List<string>() { "apple", "pen" }, true };
        yield return new object[] { "leetcode", new List<string>() { "leet", "code" }, true };
        yield return new object[] { "leetcode", new List<string>() { "le", "leet", "code" }, true };
        yield return new object[] { "leetcode", new List<string>() { "leet", "tcod", "e", "lee" }, true };
        yield return new object[] { "leetcode", new List<string>() { "leet", "tcod", "e" }, false };
        yield return new object[] { "catsandog", new List<string>() { "cats", "dog", "sand", "and", "cat" }, false };
        yield return new object[] { "ccbb", new List<string>() { "bc", "cb" }, false };
        yield return new object[] { "ddadddbdddadd", new List<string>() { "dd", "ad", "da", "b" }, true };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class WordBreakerTests
{
    [Theory]
    [ClassData(typeof(WordBreakerTestData))]
    public void Test1(string s, IList<string> dict, bool expected)
    {
        var wordBreaker = new WordBreaker();

        var actual = wordBreaker.WordBreak(s, dict);

        Assert.Equal(expected, actual);
    }

    //[Theory]
    //[InlineData("carapplepenapple", "apple", new int[] { 3, 11 })]
    //[InlineData("carapplepenapple", "car", new int[] { 0 })]
    //[InlineData("carapplepenapple", "cat", new int[] { })]
    //[InlineData("leetcode", "ode", new int[] { 5 })]
    //[InlineData("leetcode", "e", new int[] { 1, 2, 7 })]
    //public void GetStartingIndexes_ShouldReturnIndexesAccurately(string s, string sub, int[] expected)
    //{
    //    var wb = new WordBreaker();

    //    var actual = wb.GetStartingIndexesOfSubstring(s, sub);

    //    Assert.Equal(actual, expected);
    //}
}
