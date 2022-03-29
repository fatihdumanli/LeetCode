import java.util.HashMap;

class Program {
	public static void main(String[] args) {
		var nums = new int[] { 1,2,3,4,5 };
		twoSum(nums, 5);
	}

	public static int[] twoSum(int[] nums, int target) {
		HashMap<Integer, Integer> hashmap = new HashMap<Integer, Integer>();

		for(int i = 0; i < nums.length; i++) {
			var curNum = nums[i];
			var diff = target - curNum;

			if (hashmap.containsKey(diff)) {
				return new int[] { i, hashmap.get(diff) };
			} else if (!hashmap.containsKey(curNum)) {
				hashmap.put(curNum, i);
			}
		}
		return new int[]{};
	}
}
