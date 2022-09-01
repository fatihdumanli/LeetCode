using System;
using DesignQueue;
using Xunit;

namespace DesignQueueTests;

public class DesignQueueTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 4, 8, 9, 11, 15 })]
    public void Test1(int[] elementsToAdd)
    {
        var myQueue = new MyQueue();

        foreach (var item in elementsToAdd)
        {
            myQueue.Enqueue(item);
        }

        for (int i = 0; i < elementsToAdd.Length; i++)
        {
            var dequeued = myQueue.Dequeue();
            Assert.Equal(elementsToAdd[i], dequeued);
        }
    }

    [Fact]
    public void Peek_ShouldThrowQueueEmptyException_WhenQueueIsEmpty()
    {
        var myQueue = new MyQueue();

        Func<object> action = () => myQueue.Peek();

        Assert.Throws<QueueEmptyException>(action);
    }

}
