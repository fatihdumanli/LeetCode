# https://leetcode.com/problems/valid-palindrome
class Solution:
    def isPalindrome(self, s: str) -> bool:

        left = 0
        right = len(s) - 1

        while left <= right:

            if self.isAlphanumeric(s[left]) == False:
                left += 1
                continue

            if self.isAlphanumeric(s[right]) == False:
                right -= 1
                continue

            leftChar = s[left]
            rightChar = s[right]

            if self.isUppercase(leftChar):
                leftChar = leftChar.lower()

            if self.isUppercase(rightChar):
                rightChar = rightChar.lower()

            if leftChar != rightChar:
                return False

            left += 1
            right -= 1

        return True

    def isAlphanumeric(self, c: str) -> bool:
        ascii = ord(c)
        return (ascii >= 48 and ascii <= 57) or (ascii >= 65 and ascii <= 90) \
    or (ascii >= 97 and ascii <= 122)

    def isUppercase(self, c: str) -> bool:
        ascii = ord(c)
        return ascii >= 65 and ascii <= 122

s = "A man, a plan, a canal: Panamaa"

sol = Solution()
r = sol.isPalindrome(s)

print(r)

