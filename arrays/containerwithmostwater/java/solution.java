class Program {
	public static void main(String[] args) {
		int[] heihgt = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
		var result = maxArea(heihgt);
		System.out.println(result);
	}

	public static int maxArea(int[] height) {
		Integer maxArea = 0;

		int left = 0;
		int right = height.length - 1;

		while(left <= right) {
			var min = Math.min(height[left], height[right]);
			var area = min * (right - left);
			maxArea = Math.max(maxArea, area);

			if (height[left] <= height[right]) {
				left++;
			} else {
				right--;
			}
		}
		return maxArea;
	}
}
