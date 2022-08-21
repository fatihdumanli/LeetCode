namespace DesignList.Tests;

using Xunit;
using DesignList;


public class MyListTests
{
    [Theory]
    [InlineData(5)]
    [InlineData(0)]
    [InlineData(1)]
    public void AddedElement_ShouldAppearInTheList(int data)
    {
        var myList = new MyList();
        myList.Add(data);
        Assert.True(myList.Contains(data));
    }

    [Fact]
    public void Contains_WhenZeroDoesNotExist_ShouldReturnFalse()
    {
        var myList = new MyList();
        Assert.False(myList.Contains(0));
    }

    [Theory]
    [InlineData(4, 5, 8)]
    [InlineData(4, 9, 16)]
    [InlineData(2, 1, 2)]
    [InlineData(2, 2, 2)]
    [InlineData(2, 3, 4)]
    [InlineData(2, 0, 2)]
    public void WhenExceededCapacity_TheListShouldBeResized(int initialCapacity, int numOfItemsToAdd, int expectedCapacity)
    {
        var myList = new MyList(capacity: initialCapacity);

        for (int i = 0; i < numOfItemsToAdd; i++)
        {
            myList.Add(i);
        }

        Assert.Equal(expectedCapacity, myList.Capacity);

    }

    [Theory]
    [InlineData(3, 3, true)]
    [InlineData(3, 4, false)]
    [InlineData(5, 5, true)]
    public void Contains_ShouldReturnExpectedValue(int added, int arg, bool expected)
    {
        var myList = new MyList();
        myList.Add(added);

        var result = myList.Contains(arg);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(2)]
    [InlineData(11)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(101)]
    [InlineData(1001)]
    public void CountProperty_ShouldReturnExpectedValue(int numOfItemsToAdd)
    {
        var myList = new MyList();

        for(int i = 0; i < numOfItemsToAdd; i++)
        {
            myList.Add(i);
        }

        Assert.Equal(numOfItemsToAdd, myList.Count);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, 3, false)]
    [InlineData(new int[] { 1, 2, 2, 4 }, 2, true)]
    [InlineData(new int[] { 5, 6, 7, 8, 9, 10}, 9, false)]
    [InlineData(new int[] { 101, 102, 102, 102, 103, 104 }, 102, true)]
    [InlineData(new int[] { 101, 102, 102, 102, 103, 104 }, 104, false)]
    public void RemoveFirst_WhenItemExist_ShouldRemoveTheFirstOccurence(int[] itemsToAdd, int itemToRemove, bool containsExpected)
    {
        var myList = new MyList();

        for(int i = 0; i < itemsToAdd.Length; i++)
        {
            myList.Add(itemsToAdd[i]);
        }

        myList.RemoveFirst(itemToRemove);

        var contains = myList.Contains(itemToRemove);

        Assert.Equal(containsExpected, contains);
    }

    
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 3, 4, new int[] { 1, 2, 4, 5 })]
    [InlineData(new int[] { 1, 2, 3, 4, 3, 5 }, 3, 5, new int[] { 1, 2, 4, 3, 5 })]
    [InlineData(new int[] { 1, 2, 3 }, 1, 2, new int[] { 2, 3 })]
    [InlineData(new int[] { 1, 2, 3 }, 3, 2, new int[] { 1, 2 })]
    public void RemoveFirst_AfterRemoving_ShouldntOverrideTheRestOfTheItems(int[] itemsToAdd, int itemToRemove, int expectedCount, int[] expectedValues)
    {
        var myList = new MyList();

        for(int i = 0; i < itemsToAdd.Length; i++)
        {
            myList.Add(itemsToAdd[i]);
        }
        
        myList.RemoveFirst(itemToRemove);

        Assert.Equal(expectedCount, myList.Count);

        for(int i = 0; i < expectedValues.Length; i++)
        {
            Assert.True(myList.Contains(expectedValues[i]));
        }
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, 3, 5, 4, new int[] { 1, 2, 4, 5 })]
    public void AddingElement_AfterRemovingFirst_ShouldntCorruptTheList(int[] itemsToAdd, int itemToRemove, int itemToAdd, int expectedCount, int[] expectedResult)
    {
        var myList = new MyList();

        for(int i = 0; i < itemsToAdd.Length; i++)
        {
            myList.Add(itemsToAdd[i]);
        }

        myList.RemoveFirst(itemToRemove);
        myList.Add(itemToAdd);

        var arr = myList.ToArray();

        Assert.Equal(expectedCount, arr.Length);
        Assert.Equal(expectedCount, myList.Count);

        for(int i = 0; i < arr.Length; i++)
        {
            Assert.Equal(expectedResult[i], arr[i]);
        }
    }

    //[Theory]
    //[InlineData(new int[] { 2, 3, 4, 5, 6, 7, 8, 7, 7, 9, 10, 4, 5, 8, 2}, 3)]
    //[InlineData(new int[] { 1, 1, 1, 1, 2, 3, 4, 5 }, 1)]
    //[InlineData(new int[] { 10, 11, 12, 13, 14 }, 13)]
    //public void RemoveAll_ShouldRemove_AllOccurences(int[] itemsToAdd, int itemToRemove)
    //{
    //    var myList = new MyList();

    //    for(int i = 0; i < itemsToAdd.Length; i++)
    //    {
    //        myList.Add(itemsToAdd[i]);
    //    }

    //    myList.RemoveAll(itemToRemove);

    //    var contains = myList.Contains(itemToRemove);

    //    Assert.False(contains);
    //}

    //[Theory]
    //[InlineData(new int[] { 1, 3, 3, 2, 3, 4, 5, 3, 3 }, 3, 4, new int[] { 1, 2, 4, 5 })]
    //[InlineData(new int[] { 1, 1, 1, 1 }, 1, 0, new int[] { })]
    //[InlineData(new int[] { 1, 2, 3  }, 2, 2, new int[] { 1, 3 })]
    //[InlineData(new int[] { 1, 2, 3, 3  }, 3, 2, new int[] { 1, 2 })]
    //public void RemoveAll_AfterRemoving_ShouldntOverrideTheRestOfTheItems(int[] itemsToAdd, int itemToRemove, int expectedCount, int[] expectedValues)
    //{
    //    var myList = new MyList();

    //    for(int i = 0; i < itemsToAdd.Length; i++)
    //    {
    //        myList.Add(itemsToAdd[i]);
    //    }

    //    myList.RemoveAll(itemToRemove);

    //    Assert.Equal(expectedCount, myList.Count);
    //    
    //    for(int i = 0; i < expectedValues.Length; i++)
    //    {
    //        Assert.True(myList.Contains(expectedValues[i]));
    //    }
    //}

    [Theory]
    [InlineData(new int[] { 2, 3, 4, 5, 6, 7, 8, 7, 7, 9, 10, 4, 5, 8, 2}, 0)]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 6)]
    [InlineData(new int[] { }, 0)]
    public void Remove_WhenItemDoesntExist_ShouldThrowException(int[] itemsToAdd, int itemToRemove)
    {
        var myList = new MyList();

        for(int i = 0; i < itemsToAdd.Length; i++)
        {
            myList.Add(itemsToAdd[i]);
        }

        var funcRemoveFirst = () => myList.RemoveFirst(itemToRemove);
        //var funcRemoveAll = () => myList.RemoveFirst(itemToRemove);

        Assert.Throws<ItemNotFoundException>(funcRemoveFirst);
        //Assert.Throws<ItemNotFoundException>(funcRemoveAll);
    }

}






