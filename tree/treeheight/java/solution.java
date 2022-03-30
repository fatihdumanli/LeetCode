class TreeNode {
	int val;
	TreeNode left;
	TreeNode right;
}
class Program {
	public static void main(String[] args) {
	}

	public int maxDepth(TreeNode root) {
		if(root == null) {
			return 0;
		}

		var left = maxDepth(root.left);
		var right = maxDepth(root.right);

		return Math.max(left, right) + 1;
	}
}
