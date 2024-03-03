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

        var r = RemoveNthFromEnd(head, 1);
        Console.WriteLine("Hello, World!");
    }

    // https://leetcode.com/problems/remove-nth-node-from-end-of-list
    static ListNode RemoveNthFromEnd(ListNode head, int n) 
    {
        if (head == null || head.next == null)
            return null;

        // 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7 -> 8 -> null
        // length=2
        // n=1
        var length = 0;
        var ptr = head;

        while (ptr != null)
        {
            length++;
            ptr = ptr.next;
        }

        if (n == length)
            return head.next;

        ptr = head;
        for (int i = 0; i < length - n - 1; i++)
        {
            ptr = ptr.next;
        }
        ptr.next = ptr.next.next;

        return head;
    }
}
