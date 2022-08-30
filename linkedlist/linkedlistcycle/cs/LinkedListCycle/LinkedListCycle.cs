namespace LinkedListCycleLib;

public class ListNode
{
    public int val { get; set; }
    public ListNode next { get; set; }

    public ListNode(int val)
    {
        this.val = val;
    }
}

public class LinkedListCycle
{
    public bool HasCycle(ListNode head)
    {
        if (head == null)
            return false;

        var fastPtr = head.next;
        var slowPtr = head;

        while(fastPtr != null && fastPtr.next != null)
        {
            if(fastPtr == slowPtr)
                return true;

            slowPtr = slowPtr.next;
            fastPtr = fastPtr.next.next;
        }

        return false;
    }
}
