namespace DeleteTheMiddleNodeLib;

public class ListNode
{
    public int val { get; set; }
    public ListNode next { get; set; }

    public ListNode(int val)
    {
        this.val = val;
    }
}

public class DeleteTheMiddleNode
{
    public int GetMiddleElement(int length)
    {
        double middle = length / 2;
        middle = Math.Floor(middle);

        var intMiddle = (int)middle;
        return intMiddle;
    }

    public ListNode DeleteMiddle(ListNode head)
    {
        var headPtr = head;

        var length = 0;
        while(headPtr != null)
        {
            length++;
            headPtr = headPtr.next;
        }

        if(length <= 1)
            return null;

        headPtr = head;

        var middle = GetMiddleElement(length);

        for (int i = 0; i < middle - 1; i++)
        {
            headPtr = headPtr.next;
        }

        headPtr.next = headPtr.next.next;

        return head;
    }
}
