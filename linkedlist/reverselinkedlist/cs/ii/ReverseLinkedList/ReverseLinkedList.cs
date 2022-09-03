namespace ReverseLinkedListLib;

public class ListNode
{
    public int val { get; set; }
    public ListNode next { get; set; }

    public ListNode(int val)
    {
        this.val = val;
    }
}

public class ReverseLinkedList
{
    /*
     *
     *  1 -> 2 -> 3 -> 4 -> 5 -> null
     *  
     *  5 -> 4 -> 3 -> 2 -> 1 -> null
     *
     *
     *  1 -> 2 -> 3 -> null
     *
     *  2 -> 1
     *  
     *  3 -> 2
     *
     */
    public ListNode ReverseList(ListNode head)
    {
        if (head.next == null)
            return head;

        var res = ReverseList(head.next);
        head.next.next = head;
        head.next = null;
        return res;
    }
}
