import java.util.Stack;

class Solution {
	public static void main(String[] args) {
		var str = "()))";
		var result = isValid(str);
		System.out.println(result);
	}

	public static boolean isValid(String s) {
		if (s.length() == 1) {
			return false;
		}

		Stack<Character> stack = new Stack<Character>();

		for(int i = 0; i < s.length(); i++) {
			var curChar = s.charAt(i);

			if (curChar == '(') {
				stack.push(')');
				continue;
			}

			if(curChar == '{') {
				stack.push('}');
				continue;
			}

			if(curChar == '[') {
				stack.push(']');
				continue;
			}

			if (stack.isEmpty()) {
				return false;
			}

			if (curChar != stack.pop()) {
				return false;
			}
		}

		return stack.isEmpty();
	}
}
