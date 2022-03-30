class Program {
	public static void main(String[] args) {
		var strs = new String[] { "flower", "flow", "flight" };
		var result = longestCommonPrefix(strs);
		System.out.println(result);
	}

	public static String longestCommonPrefix(String[] strs) {

		if (strs.length == 1) {
			return strs[0];
		}

		Integer min = Integer.MAX_VALUE;
		Integer minIndex = Integer.MAX_VALUE;

		for(int i = 0; i < strs.length; i++) {
			if (strs[i].length() == 0) {
				return "";
			}

			if (strs[i].length() < min) {
				min = strs[i].length();
				minIndex = i;
			}
		}

		String shortestString = strs[minIndex];
		int length = 0; 

		for(int i = 0; i < shortestString.length(); i++) {
			var charToCompare = shortestString.charAt(i);

			for(int j = 0; j < strs.length; j++) {
				var stringToCompare = strs[j];
				if (stringToCompare.charAt(i) != charToCompare) {
					return shortestString.substring(0, length);
				}
			}
			length++;
		}	
		return shortestString;
	}
}
