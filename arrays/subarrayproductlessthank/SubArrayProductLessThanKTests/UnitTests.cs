using SubArrayProductLessThanKLib;
using Xunit;

namespace SubArrayProductLessThanKTests;

public class UnitTests
{
    [Theory]
    [InlineData(new int[] { 10, 5, 2, 6 }, 100, 8)]
    [InlineData(new int[] { 1, 2, 3 }, 0, 8)]
    public void Test1(int[] arr, int k, int expected)
    {
        var helper = new SubArrayProductLessThanK();

        var actual = helper.NumSubarrayProductLessThanK(arr, k);
    }
}
