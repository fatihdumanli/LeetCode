namespace DesignStack;

public class StackEmptyException : Exception
{
}

public class ListNode
{
    public int val { get; set; }
    public ListNode next { get; set; }

    public ListNode(int val)
    {
        this.val = val;
    }
}


public class MyStack
{
    private ListNode head;

    public int Count { get; set; }

    public bool IsEmpty => Count == 0;

    public void Push(int val)
    {
        Count++;

        if (head == null)
        {
            head = new ListNode(val);
            return;
        }

        var newHead = new ListNode(val);
        newHead.next = head;
        head = newHead;
    }

    public int Pop()
    {
        if (head == null)
            throw new StackEmptyException();

        Count--;
        var headVal = head.val;

        head = head.next;

        return headVal;
    }

    public int Peek()
    {
        if (head == null)
            throw new StackEmptyException();

        return head.val;
    }
}
