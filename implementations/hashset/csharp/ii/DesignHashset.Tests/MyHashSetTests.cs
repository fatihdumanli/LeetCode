using Xunit;

namespace DesignHashset.Tests;

public class UnitTest1
{
    [Fact]
    public void AfterAddingAnElement_ContainsShouldReturnAsExpected()
    {
        var myHashset = new MyHashSet();

        myHashset.Add(5);

        Assert.True(myHashset.Contains(5));
    }

    [Fact]
    public void AfterCallingRemove_ContainsShouldReturnFalse()
    {
        var myHashset = new MyHashSet();
        
        myHashset.Add(5);
        myHashset.Add(6);
        myHashset.Add(7);

        myHashset.Remove(5);

        var contains = myHashset.Contains(5);

        Assert.False(contains);
        Assert.True(myHashset.Contains(6));
        Assert.True(myHashset.Contains(7));
    }

    [Fact]
    public void Contains_ShouldReturnFalse_AfterAddingDuplicateElementAndRemovingIt()
    {
        var myHashset = new MyHashSet();

        myHashset.Add(5);
        myHashset.Add(5);

        myHashset.Remove(5);

        var actual = myHashset.Contains(5);

        Assert.False(actual);
    }

    [Fact]
    public void Removing_FromTail()
    {
        var myHashset = new MyHashSet();
        myHashset.Add(5);
        myHashset.Add(25);

        myHashset.Remove(25);
    }


}
