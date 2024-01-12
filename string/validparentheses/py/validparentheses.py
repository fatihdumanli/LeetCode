# https://leetcode.com/problems/valid-parentheses
class Solution:
    def isValid(self, s: str) -> bool:

        # (([{ }]))
        # {()}

        # append corresponding closing parentheses as we encounter opening ones.
        # as soon as we encounter a closing parentheses e.g. ), } or ]
        # we need to pop from the stack

        # and see if the closing parentheses closes the accurate parentheses
        # } -> {
        # ) -> (
        # ] -> [
        
        openings = { "(": ")", "{": "}", "[": "]" }
        stack = []

        for c in s:
            if c in openings:
                stack.append(c)
            else:
                if len(stack) == 0: 
                    return False

                last = stack.pop()
                if openings[last] != c:
                    return False

        return len(stack) == 0

obj = Solution()
r = obj.isValid("(]")
print(r)
