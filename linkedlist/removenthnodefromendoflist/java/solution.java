class ListNode {
	public int val;
	public ListNode next;

	public ListNode(int val) {
		this.val = val;
	}
}
class Program {
	public static void main(String[] args) {
		var head = new ListNode(1);
		head.next = new ListNode(2);
		head.next.next = new ListNode(3);
		head.next.next.next = new ListNode(4);
		head.next.next.next.next = new ListNode(5);

		removeNthFromEnd(head, 2);
	}

	public static ListNode removeNthFromEnd(ListNode head, int n) {
		if (head == null) {
			return head;
		}

		int c = 0;
		ListNode ptr = head;
		while(ptr != null) {
			ptr = ptr.next;
			c++;
		}

		if(c == 1 || n == 1) {
			return null;
		}

		var target = c - n - 1;
		ptr = head;
		for(int i = 0; i < target; i++) {
			ptr = ptr.next;
		}

		ptr.next = ptr.next.next;
		return head;
	}
}
