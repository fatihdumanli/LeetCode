using Xunit;
using Xunit.Abstractions;

namespace DesignLinkedList.Tests;

public class MyLinkedListTests
{
    private readonly MyLinkedList _myLinkedList = new MyLinkedList();
    private readonly ITestOutputHelper _output;

    public MyLinkedListTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, 5)]
    [InlineData(new int[] { }, 1)]
    [InlineData(new int[] { 2 }, 1)]
    public void AddingToHead_ShouldResultInHeadChange(int[] initialValues, int val)
    {
        foreach (var item in initialValues)
        {
            _myLinkedList.AddAtHead(item);
        }

        _myLinkedList.AddAtHead(val);
        var actual = _myLinkedList.Get(0);

        Assert.Equal(expected: val, actual);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3 }, 0, 1)]
    [InlineData(new int[] { 1, 2, 3 }, 1, 2)]
    [InlineData(new int[] { 1, 2, 3 }, 2, 3)]
    [InlineData(new int[] { 1, 2, 3 }, 3, -1)]
    [InlineData(new int[] { 1, 2, 3 }, -1, -1)]
    [InlineData(new int[] { }, 0, -1)]
    [InlineData(new int[] { }, 1, -1)]
    [InlineData(new int[] { 1 }, 1, -1)]
    [InlineData(new int[] { 1 }, 0, 1)]
    public void Get_ShouldReturnAsExpected(int[] initialValues, int index, int expected)
    {
        foreach (var item in initialValues)
        {
            _myLinkedList.AddAtTail(item);
        }

        var actual = _myLinkedList.Get(index);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3 }, 4, 3)]
    [InlineData(new int[] { }, 4, 0)]
    [InlineData(new int[] { 2 }, 3, 1)]
    public void AddAtTail_ShouldWorkAsExpected(int[] initialValues, int itemToAdd, int tailIndex)
    {
        foreach (var item in initialValues)
        {
            _myLinkedList.AddAtTail(item);
        }

        _myLinkedList.AddAtTail(itemToAdd);

        var actual = _myLinkedList.Get(tailIndex);

        Assert.Equal(itemToAdd, actual);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3 }, 2, 4, 4)]
    [InlineData(new int[] { }, 0, 1, 1)]
    [InlineData(new int[] { }, 1, 4, -1)]
    [InlineData(new int[] { 1, 2 }, 2, 10, 10)]
    [InlineData(new int[] { 1, 2, 3 }, 3, 4, 4)]
    public void AddAtIndex_ShouldWorkAsExpected(int[] initialValues, int index, int val, int expectedValue)
    {
        foreach (var item in initialValues)
        {
            _myLinkedList.AddAtTail(item);
        }

        _myLinkedList.AddAtIndex(index, val);

        var actual = _myLinkedList.Get(index);

        Assert.Equal(expectedValue, actual);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3 }, 4, 1)]
    [InlineData(new int[] { 1, 2, 3, 4 }, 10, 1)]
    [InlineData(new int[] { }, 1, 1)]
    [InlineData(new int[] { 1, 2, 3 }, -1, 1)]
    public void AddAtIndex_WhenIndexIsGreaterThanListSize_ShouldNotAppendTheItem(int[] initialValues, int index, int val)
    {
        foreach (var item in initialValues)
        {
            _myLinkedList.AddAtTail(item);
        }

        // This test should pass if the call below doesn't throw any exception.
        _myLinkedList.AddAtIndex(index, val);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3 }, 1, 3)]
    [InlineData(new int[] { 1, 2, 3 }, 2, -1)]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 0, 2)]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 1, 3)]
    [InlineData(new int[] { 1, 2, 3 }, 2, -1)]
    [InlineData(new int[] { 1, 2, 3 }, 3, -1)]
    public void DeleteAtIndex(int[] initialValues, int indexDeleted, int expectedValue)
    {
        foreach (var item in initialValues)
        {
            _myLinkedList.AddAtTail(item);
        }

        _myLinkedList.DeleteAtIndex(indexDeleted);

        var actual = _myLinkedList.Get(indexDeleted);

        Assert.Equal(expectedValue, actual);
    }
}









