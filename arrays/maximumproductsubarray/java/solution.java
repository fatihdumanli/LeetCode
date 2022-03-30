class Program {
	public static void main(String[] args) {
		var nums = new int[] { 2,3, -2,4 };
		var result = maxProduct(nums);
		System.out.println(result);
	}

	public static int maxProduct(int[] nums) {

		int globalMax = Integer.MIN_VALUE;

		var min = 1;
		var max = 1;

		for(var i = 0; i < nums.length; i++) {
			var tempMin = min;
			min = Math.min(Math.min(nums[i], min * nums[i]), max * nums[i]);
			max = Math.max(Math.max(max * nums[i], tempMin * nums[i]), nums[i]);
			globalMax = Math.max(globalMax, max);
		}

		return globalMax;
	}
}
