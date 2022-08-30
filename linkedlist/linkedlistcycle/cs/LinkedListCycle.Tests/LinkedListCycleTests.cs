using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace LinkedListCycleLib.Tests;

public class LinkedListCycleTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var head = new ListNode(3);
        head.next = new ListNode(2);
        head.next.next = new ListNode(0);
        head.next.next.next = new ListNode(4);
        head.next.next.next.next = head.next;

        var head2 = new ListNode(1);
        head2.next = new ListNode(2);
        head2.next.next = new ListNode(3);

        var head3 = new ListNode(1);
        head3.next = new ListNode(2);

        var head4 = new ListNode(1);

        var head5 = new ListNode(4);
        head5.next = new ListNode(5);
        head5.next.next = head5;

        var head6 = new ListNode(1);
        head6.next = head6;

        yield return new object[] { head, true };
        yield return new object[] { head2, false };
        yield return new object[] { head3, false };
        yield return new object[] { head4, false };
        yield return new object[] { head5, true };
        yield return new object[] { head6, true };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class LinkedListCycleTests
{
    [Theory]
    [ClassData(typeof(LinkedListCycleTestData))]
    public void Test1(ListNode head, bool expected)
    {
        var obj = new LinkedListCycle();

        var actual = obj.HasCycle(head);

        Assert.Equal(expected, actual);
    }
}
