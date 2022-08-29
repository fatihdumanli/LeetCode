using System.Collections;
using System.Collections.Generic;
using DeleteTheMiddleNodeLib;
using Xunit;
using Xunit.Abstractions;

namespace DeleteTheMiddleNodeLib.Tests;

public class DeleteMiddleNodeTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var head = new ListNode(1);
        head.next = new ListNode(3);
        head.next.next = new ListNode(4);
        head.next.next.next = new ListNode(7);
        head.next.next.next.next = new ListNode(1);
        head.next.next.next.next.next = new ListNode(2);
        head.next.next.next.next.next.next = new ListNode(6);

        var head1 = new ListNode(1);

        var head2 = new ListNode(4);
        head2.next = new ListNode(5);

        var head3 = new ListNode(4);
        head3.next = new ListNode(5);
        head3.next.next = new ListNode(6);

        var head4 = new ListNode(10);
        head4.next = new ListNode(11);
        head4.next.next = new ListNode(12);
        head4.next.next.next = new ListNode(13);
        head4.next.next.next.next = new ListNode(14);

        yield return new object[] { head, new int[] { 1, 3, 4, 1, 2, 6 } };
        yield return new object[] { head1, new int[] { 1 } };
        yield return new object[] { head2, new int[] { 4 } };
        yield return new object[] { head3, new int[] { 4, 6 } };
        yield return new object[] { head4, new int[] { 10, 11, 13, 14 } };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class DeleteMiddleNodeTests
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0)]
    [InlineData(2, 1)]
    [InlineData(3, 1)]
    [InlineData(4, 2)]
    [InlineData(5, 2)]
    public void TestMiddleIndex(int length, int expected)
    {
        var obj = new DeleteTheMiddleNode();
        var actual = obj.GetMiddleElement(length);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(DeleteMiddleNodeTestData))]
    public void Test1(ListNode head, int[] expected)
    {
        List<int> elements = new List<int>();

        var obj = new DeleteTheMiddleNode();
        obj.DeleteMiddle(head);

        var headPtr = head;

        while (headPtr != null)
        {
            elements.Add(headPtr.val);
            headPtr = headPtr.next;
        }
        var arr = elements.ToArray();

        Assert.Equal(expected, arr);
    }
}
