// See https://aka.ms/new-console-template for more information
using ReorderList;

var head = new ListNode(1);

ReorderList(head);

// https://leetcode.com/problems/reorder-list/
void ReorderList(ListNode head)
{
    if(head.next == null)
        return;

    var queue = new Queue<ListNode>();
    var stack = new Stack<ListNode>();

    var ptr = head.next;
    while(ptr != null)
    {
        queue.Enqueue(ptr);
        stack.Push(ptr);
        ptr = ptr.next;
    }

    char last = 'S';
    ListNode consumed = stack.Pop();
    ptr = head;

    while(consumed != ptr)
    {
        consumed.next = null;
        ptr.next = consumed;
        ptr = ptr.next;

        if(last == 'S' && queue.Count > 0)
        {
            consumed = queue.Dequeue();
            last = 'Q';
        }
        else if (last == 'Q' && stack.Count > 0)
        {
            consumed = stack.Pop();
            last = 'S';
        }
        else
            return;
    }
}


