namespace cs;

class ListNode
{
    public int val { get; set; }
    public ListNode next { get; set; }

    public ListNode(int val)
    {
        this.val = val;
    }
}
class Program
{
    static void Main(string[] args)
    {
        var head = new ListNode(1);
        head.next = new ListNode(2);
        head.next.next = new ListNode(3);
        head.next.next.next = new ListNode(4);
        head.next.next.next.next = new ListNode(5);
        head.next.next.next.next.next = new ListNode(6);
        
        var k = 2;

        var r = ReverseKGroup(head, k);
    }

    // https://leetcode.com/problems/reverse-nodes-in-k-group/
    static ListNode ReverseKGroup(ListNode head, int k)
    {
        // Split the list into groups of length of k
        var parts = new List<ListNode>();

        var currentGroupLength = 1;

        var start = head;
        var ptr = start;

        for (int i = 0; i < k - 1; i++)
        {
            ptr = ptr.next;
            currentGroupLength++;
        }

        // If we fail to reach k at our first attempt, return the list as is
        if (currentGroupLength < k)
            return head;


        while (currentGroupLength == k)
        {
            var bridgePtr = ptr.next;
            ptr.next = null;

            var reversed = ReverseList(start);
            parts.Add(reversed);

            if (bridgePtr == null)
            {
                currentGroupLength = 0;
                break;
            }

            // Meaning, there are still nodes as the bridgePtr is not null
            currentGroupLength = 0;

            start = bridgePtr;
            ptr = start;

            while (ptr != null && currentGroupLength < k)
            {
                currentGroupLength++;

                if (currentGroupLength == k)
                    break;

                ptr = ptr.next;
            }
        }

        // 1. First, merge everything in 'parts'
        var current = parts[0];
        var newHead = current;

        var tail = GetTail(current);

        for (int i = 1; i < parts.Count; i++)
        {
            tail.next = parts[i];
            tail = GetTail(parts[i]);
        }

        // If currentGroupLength > 0, meaning that there are leftovers, we need
        // to add those nodes to the list without reversing
        if (currentGroupLength > 0)
            tail.next = start;

        return newHead;
    }

    static ListNode GetTail(ListNode head)
    {
        var ptr = head;

        while (ptr.next != null)
        {
            ptr = ptr.next;
        }

        return ptr;
    }

    static ListNode ReverseList(ListNode head)
    {
        if (head.next == null)
            return head;

        var r = ReverseList(head.next);

        head.next.next = head;
        head.next = null;

        return r;
    }
}
