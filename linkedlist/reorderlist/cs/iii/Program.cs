namespace iii;

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

        ReorderList(head);

        Console.WriteLine("Hello, World!");
    }

    static void ReorderList(ListNode head)
    {
        if (head.next == null)
            return;

        // Step 1: Identify the other half of the linked list
        var slow = head;
        var fast = head.next;

        while(fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        // Step 2: Reverse the second half of the linked list
        var first = head;
        var second = ReverseList(slow.next);
        slow.next = null;


        // Step 3: Weave the list in a way that pick one node from first and
        // pick one from the second as long as either of them is not null
        // In the end, either both of them are going to be null (even) or only the
        // second is going to be null. (odd)
        while (first != null && second != null)
        {
            var temp = first.next;

            var temp2 = second;
            second = second.next;

            temp2.next = temp;
            first.next = temp2;
            first = temp;
        }
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
