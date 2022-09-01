namespace DesignQueue;

public class QueueEmptyException : Exception
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

public class MyQueue
{
    private ListNode _head;

    public int Peek()
    {
        if (_head == null)
            throw new QueueEmptyException();

        return _head.val;
    }

    public void Enqueue(int val)
    {
        if (_head == null)
        {
            _head = new ListNode(val);
            return;
        }

        var headPtr = _head;

        while (headPtr.next != null)
            headPtr = headPtr.next;

        headPtr.next = new ListNode(val);
    }

    public int Dequeue()
    {
        if (_head == null)
            throw new QueueEmptyException();

        var val = _head.val;

        _head = _head.next;

        return val;
    }
}
