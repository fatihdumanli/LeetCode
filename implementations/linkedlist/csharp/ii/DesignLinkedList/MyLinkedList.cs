namespace DesignLinkedList;

class ListNode
{
    internal int _val;
    internal ListNode _next;

    public ListNode(int val)
    {
        _val = val;
    }

    public ListNode()
    {
    }
}

public class MyLinkedList
{

    private ListNode _head;

    public MyLinkedList()
    {
        _head = new ListNode();
    }

    public int Get(int index)
    {

        if (index < 0)
            return -1;

        var headPtr = _head._next;

        for (int i = 0; i < index; i++)
        {
            if (headPtr == null)
                return -1;

            headPtr = headPtr._next;
        }

        if (headPtr == null)
            return -1;

        return headPtr._val; ;
    }

    public void AddAtHead(int val)
    {
        var listNode = new ListNode(val);

        listNode._next = _head._next;
        _head._next = listNode;
    }

    public void AddAtTail(int val)
    {
        var headPtr = _head;

        while (headPtr._next != null)
        {
            headPtr = headPtr._next;
        }

        headPtr._next = new ListNode(val);
    }

    public void AddAtIndex(int index, int val)
    {

        if (index < 0)
            return;

        var headPtr = _head;

        for (int i = 0; i < index; i++)
        {
            if (headPtr == null)
                return;

            headPtr = headPtr._next;
        }

        if (headPtr == null)
            return;

        var listNode = new ListNode(val);
        listNode._next = headPtr._next;
        headPtr._next = listNode;
    }

    public void DeleteAtIndex(int index)
    {
        if (index < 0)
            return;

        var headPtr = _head;

        for (int i = 0; i < index; i++)
        {
            headPtr = headPtr._next;

            if (headPtr == null)
                return;
        }

        if (headPtr == null || headPtr._next == null)
            return;

        headPtr._next = headPtr._next._next;

    }
}


