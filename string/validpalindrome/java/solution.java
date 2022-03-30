class Program {
	public static void main(String[] args) {
		var str = "A man, a plan, a canal: Panama";
		var result = isPalindrome(str);
		System.out.println(result);
	}

	public static boolean isPalindrome(String s) {
		var left = 0;
		var right = s.length() - 1;

		while (left <= right) {
			if (!isAlphanumeric(s.charAt(left))) {
				left++;
				continue;
			}
			if (!isAlphanumeric(s.charAt(right))) {
				right--;
				continue;
			}
			if (!caseInsensitiveComparison(s.charAt(left), s.charAt(right))) {
				return false;
			}
			left++;
			right--;
		}
		return true;
	}

	public static boolean caseInsensitiveComparison(int a, int b) {
		if (isUppercased(a)) {
			a += 32;
		}
		if(isUppercased(b)) {
			b += 32;
		}
		return a == b;
	}

	public static boolean isUppercased(int c) {
		return c >= 'A' && c <= 'Z';
	}

	public static boolean isAlphanumeric(int c) {
		return (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9') || (c >= 'a' && c <= 'z');
	}
}
