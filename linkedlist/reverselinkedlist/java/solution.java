class ListNode {
	int val;
	ListNode next;

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

		var result = reverseList(head);
	}

	public static ListNode reverseList(ListNode head) {
		if (head == null || head.next == null) {
			return head;
		}

		var result = reverseList(head.next);
		head.next.next = head;
		head.next = null;

		return result;
	}
}
