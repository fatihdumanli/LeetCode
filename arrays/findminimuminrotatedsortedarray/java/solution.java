class Program {
	public static void main(String[] args) {
		var nums = new int[] {4,5,1,2,3};
		var result = findMin(nums);
		System.out.println(result);
	}

	public static int findMin(int[] nums) {
		return binarySearch(nums, 0, nums.length);
	}

	public static int binarySearch(int[] nums, int start, int end) {
		if (start >= end) {
			return nums[start];
		}

		var mid = (start + end) / 2;
		if (nums[start] < nums[mid]) {
			var right = binarySearch(nums, mid, end);
			return Math.min(nums[start], right);
		} else {
			var left = binarySearch(nums, start, mid);
			return Math.min(left, nums[mid]);
		}
	}
}
