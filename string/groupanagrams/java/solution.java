import java.util.List;
import java.util.HashMap;
import java.util.ArrayList;
import java.util.Set;
import java.util.Iterator;

class Program {
	public static void main(String[] args) {
		String[] strs = new String[] { "eat", "tea", "ate", "nat", "bat" };
		var result = groupAnagrams(strs);
		System.out.println(result);
	}

	public static List<List<String>> groupAnagrams(String[] strs) {
		List<List<String>> result = new ArrayList<List<String>>();

		HashMap<String, List<String>> hashmap = new HashMap<String, List<String>>();

		for(int i = 0; i < strs.length; i++) {
			String encodedString = encodeFreq(strs[i]);

			if (hashmap.containsKey(encodedString)) {
				hashmap.get(encodedString).add(strs[i]);
			} else {
				List<String> newList = new ArrayList<String>();
				newList.add(strs[i]);
				hashmap.put(encodedString, newList);
			}
		}

		Set<String> keys = hashmap.keySet();
		Iterator<String> iterator = keys.iterator();

		while(iterator.hasNext()) {
			var key = iterator.next();
			var val = hashmap.get(key);
			result.add(val);
		}


		return result;
	}

	// Separate freq elements with a semicolon (;)
	// 1;0;0;0;1;0...............................;
	public static String encodeFreq(String str) {
		int[] freq = new int[26];

		for(int i = 0; i < str.length(); i++) {
			int curChar = str.charAt(i);
			int idx = curChar - 'a';
			freq[idx]++;
		}

		StringBuilder sb = new StringBuilder();

		for(int i = 0; i < 26; i++) {
			sb.append(freq[i]);
			sb.append(';');
		}

		return sb.toString();
	}

}
