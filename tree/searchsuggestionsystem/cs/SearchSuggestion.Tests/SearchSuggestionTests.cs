using SearchSuggestionLib;
using Xunit;

namespace SearchSuggestion.Tests;

public class SearchSuggestionTests
{
    [Fact]
    public void Test1()
    {
        var products = new string[] { "mobile", "mouse", "moneypot", "monitor", "mousepad" };

        var searchSuggester = new SearchSuggester();
        searchSuggester.SuggestedProducts(products, "mouse");
    }

    [Fact]
    public void Test2()
    {
        var products = new string[] { "havana" };

        var searchSuggester = new SearchSuggester();
        searchSuggester.SuggestedProducts(products, "tatiana");
    }
}
