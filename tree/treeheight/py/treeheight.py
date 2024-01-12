from typing import Optional

class TreeNode:
    def __init__(self, val = 0, left = None, right = None):
        self.val = val
        self.left = left
        self.right = right

# https://leetcode.com/problems/maximum-depth-of-binary-tree
class Solution:
    def maxDepth(self, root: Optional[TreeNode]) -> int:
        if root == None:
            return 0
        
        l = self.maxDepth(root.left)
        r = self.maxDepth(root.right)

        return max(l, r) + 1

root = TreeNode(3)

sol = Solution()
r = sol.maxDepth(root)
print(r)
