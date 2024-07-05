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
        var head = new ListNode(0);
        head.next = new ListNode(3);
        head.next.next = new ListNode(1);
        head.next.next.next = new ListNode(0);
        head.next.next.next.next = new ListNode(4);
        head.next.next.next.next.next = new ListNode(5);
        head.next.next.next.next.next.next = new ListNode(2);
        head.next.next.next.next.next.next.next = new ListNode(0);

        var r = MergeNodes(head);

        Console.WriteLine("Hello, World!");
    }

    // https://leetcode.com/problems/merge-nodes-in-between-zeros
    public static ListNode MergeNodes(ListNode head) {

        var ptr = head.next;
        var sum = 0;

        var newHead = new ListNode(0);
        var newHeadPtr = newHead;

        while (ptr != null)
        {
            if (ptr.val == 0)
            {
                newHeadPtr.next = new ListNode(sum);
                newHeadPtr = newHeadPtr.next;
                sum = 0;
                ptr = ptr.next;
                continue;
            }

            sum += ptr.val;
            ptr = ptr.next;
        }

        return newHead.next;
    }
}
