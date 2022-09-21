using Xunit;

namespace FindKthLargestElement.Tests;

public class UnitTest1
{
    [Theory]
    [InlineData(new int[] { 3, 5, 13, 2, 4, 7, 8, 11 }, 2, 11)]
    [InlineData(new int[] { 3, 2, 1, 5, 6, 4 }, 2, 5)]
    [InlineData(new int[] { 3, 2, 1, 5, 6, 4 }, 1, 6)]
    [InlineData(new int[] { 3, 2, 1, 5, 6, 4 }, 3, 4)]
    [InlineData(new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4, 4)]
    [InlineData(new int[] { 1 }, 1, 1)]
    public void Test1(int[] elements, int k, int expected)
    {
        var finder = new KthLargestElementFinder();

        var actual = finder.FindKthLargest(elements, k);

        Assert.Equal(expected, actual);
    }
}
