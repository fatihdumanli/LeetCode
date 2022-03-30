class Program {
	public static void main(String[] args) {
		String s = "fatih";
		String t = "httif";
		Boolean result = isAnagram(s, t);
		System.out.println(result);
	}
	
	public static boolean isAnagram(String s, String t) {
		if (s.length() != t.length()) {
			return false;
		}
		int[] freq = new int[26];

		for(int i = 0; i < s.length(); i++) {
			int currentChar = s.charAt(i);
			int index = currentChar - 'a';
			freq[index]++;
		}

		for(int i = 0; i < t.length(); i++) {
			int currentChar = t.charAt(i);
			int index = currentChar - 'a';
			freq[index]--;
		}

		for(int i = 0; i < 26; i++) {
			if (freq[i] != 0) {
				return false;
			}
		}

		return true;
	}
}
