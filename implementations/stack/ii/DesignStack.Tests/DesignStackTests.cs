using System;
using System.Collections.Generic;
using DesignStack;
using Xunit;

namespace DesignStackTests;

public class DesignStackTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3 }, 3)]
    [InlineData(new int[] { }, 0)]
    [InlineData(new int[] { 9 }, 1)]
    public void TheCountProperty_ShouldBeAccurate(int[] elementsToAdd, int expectedCount)
    {
        var mystack = new MyStack();

        foreach (var elm in elementsToAdd)
        {
            mystack.Push(elm);
        }

        Assert.Equal(expectedCount, mystack.Count);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5 })]
    [InlineData(new int[] { 5, 4, 3, 2, 1 })]
    [InlineData(new int[] { 9 })]
    [InlineData(new int[] { })]
    public void PushedElements_ShouldBePoppedOutInRightOrder(int[] elementsToAdd)
    {
        var myStack = new MyStack();

        foreach (var item in elementsToAdd)
        {
            myStack.Push(item);
        }

        for (int i = elementsToAdd.Length - 1; i >= 0; i--)
        {
            var popped = myStack.Pop();
            Assert.Equal(elementsToAdd[i], popped);
        }
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 5)]
    [InlineData(new int[] { 1 }, 1)]
    public void PoppedElement_ShouldBeTheLastOne(int[] elements, int expected)
    {
        var myStack = new MyStack();

        foreach (var item in elements)
        {
            myStack.Push(item);
        }

        var popped = myStack.Pop();

        Assert.Equal(expected, popped);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 5)]
    [InlineData(new int[] { 1 }, 1)]
    public void PeekedElement_ShouldBeTheLastOne(int[] elements, int expected)
    {
        var myStack = new MyStack();

        foreach (var item in elements)
        {
            myStack.Push(item);
        }

        var peeked = myStack.Peek();

        Assert.Equal(expected, peeked);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5 })]
    public void AfterPopping_StackShouldntContainTheElement(int[] elements)
    {
        var myStack = new MyStack();

        foreach (var item in elements)
        {
            myStack.Push(item);
        }

        myStack.Pop();
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 5)]
    [InlineData(new int[] { 1, 2, 3 }, 3)]
    public void Peek_ShouldntRemoveTheElement(int[] elements, int lastElement)
    {
        var myStack = new MyStack();

        foreach (var item in elements)
        {
            myStack.Push(item);
        }

        myStack.Peek();

        var hashset = new HashSet<int>();

        while (!myStack.IsEmpty)
        {
            hashset.Add(myStack.Pop());
        }

        Assert.Contains(lastElement, hashset);
    }

    [Fact]
    public void Pop_ShouldThrow_StackEmptyException_WhenTheStackIsEmpty()
    {
        var myStack = new MyStack();

        Func<object> action = () => myStack.Pop();

        Assert.Throws<StackEmptyException>(action);
    }

    [Fact]
    public void Peek_ShouldThrow_StackEmptyException_WhenTheStackIsEmpty()
    {
        var myStack = new MyStack();

        Func<object> action = () => myStack.Peek();

        Assert.Throws<StackEmptyException>(action);
    }

}
