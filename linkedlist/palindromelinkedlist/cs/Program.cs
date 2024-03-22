namespace cs;

class ListNode
{
    public int val; 
    public ListNode next;

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
        head.next.next = new ListNode(2);
        head.next.next.next = new ListNode(1);

        var r = IsPalindrome(head);
        Console.WriteLine(r);
        Console.Read();
    }

    // https://leetcode.com/problems/palindrome-linked-list
    public static bool IsPalindrome(ListNode head) {

        if (head.next == null)
            return true;

        var slow = head;
        var fast = head.next;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        var reversed = ReverseList(slow.next);

        var ptr = head;
        var ptr1 = reversed;

        while (ptr != null && ptr1 != null)
        {
            if (ptr.val != ptr1.val)
                return false;

            ptr = ptr.next;
            ptr1 = ptr1.next;
        }

        return true;
    }

    public static ListNode ReverseList(ListNode head)
    {
        if (head.next == null)
            return head;

        var r = ReverseList(head.next);
        head.next.next = head;
        head.next = null;

        return r;
    }
}
