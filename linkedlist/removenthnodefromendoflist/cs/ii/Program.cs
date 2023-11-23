using MyNameSpace;

var head = new ListNode(1);
head.next = new ListNode(2);

var r = RemoveNthFromEnd(head, 2);

Console.WriteLine(r.val);

// https://leetcode.com/problems/remove-nth-node-from-end-of-list
ListNode RemoveNthFromEnd(ListNode head, int n) {

    // Int32.MaxValoe is the result code for successful operation
    // If not, it means the 'n' pointing to the head
    if(Helper(head, n) != Int32.MaxValue)
        head = head.next;

    return head;
}

int Helper(ListNode head, int n)
{
    if(head == null)
        return 0;

    var r = Helper(head.next, n);

    if(r == Int32.MaxValue)
        return Int32.MaxValue;
    
    if(r == n)
    {
        head.next = head.next.next;
        return Int32.MaxValue;
    }

    return r + 1;
}

//ListNode RemoveNthFromEnd(ListNode head, int n) {
//
//    // 1. get the size
//    var ptr = head;
//    var size = 0;
//
//    while(ptr != null)
//    {
//        size++;
//        ptr = ptr.next;
//    }
//
//    ptr = head;
//
//    for(int i = 0; i < size - n - 1; i++)
//        ptr = ptr.next;
//
//    if(size - n == 0)
//        head = head.next;
//    else
//        ptr.next = ptr.next.next;
//
//    return head;
//}


