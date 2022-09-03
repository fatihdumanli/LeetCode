using System.Collections;
using System.Collections.Generic;
using ReverseLinkedListLib;
using Xunit;

namespace ReverseLinkedListTests;

public class ReverseLinkedListTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var head1 = new ListNode(1);
        head1.next = new ListNode(2);
        head1.next.next = new ListNode(3);

        var head2 = new ListNode(1);

        yield return new object[] { head1, new int[] { 3, 2, 1 } };
        yield return new object[] { head2, new int[] { 1 } };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class ReverseLinkedListTests
{
    [Theory]
    [ClassData(typeof(ReverseLinkedListTestData))]
    public void AfterReversingLinkedList_TheOutputShouldBeAccurate(ListNode head, int[] expected)
    {
        var obj = new ReverseLinkedList();

        var result = obj.ReverseList(head);

        var list = new List<int>();

        while (result != null)
        {
            list.Add(result.val);
            result = result.next;
        }

        var arr = list.ToArray();

        Assert.Equal(expected, arr);
    }
}



