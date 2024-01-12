from typing import Optional

class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

class Solution:
    def reverseList(self, head: Optional[ListNode]) -> Optional[ListNode]:

        if head == None or head.next == None: 
            return head

        r = self.reverseList(head.next)

        head.next.next = head
        head.next = None

        return r


sol = Solution()

head = ListNode(1)
head.next = ListNode(2)
head.next.next = ListNode(3)

r = sol.reverseList(head)

print(r)

