# https://leetcode.com/problems/valid-anagram/
class Solution:
    def isAnagram(self, s: str, t: str) -> bool:
        freq = [0] * 26

        for c in s:
            freq[ord(c) - 97] += 1

        for c in t:
            freq[ord(c) - 97] -= 1

        for item in freq:
            if item != 0:
                return False

        return True


obj = Solution()
r = obj.isAnagram("fat", "taf")
print(r)
