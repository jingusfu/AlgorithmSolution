"""
Given an integer array nums, rotate the array to the right by k steps, where k is non-negative.
Example 1:
Input: nums = [1,2,3,4,5,6,7], k = 3
Output: [5,6,7,1,2,3,4]
Explanation:
rotate 1 steps to the right: [7,1,2,3,4,5,6]
rotate 2 steps to the right: [6,7,1,2,3,4,5]
rotate 3 steps to the right: [5,6,7,1,2,3,4]
Example 2:
Input: nums = [-1,-100,3,99], k = 2
Output: [3,99,-1,-100]
Explanation: 
rotate 1 steps to the right: [99,-1,-100,3]
rotate 2 steps to the right: [3,99,-1,-100]
 
Constraints:
1 <= nums.length <= 105
-231 <= nums[i] <= 231 - 1
0 <= k <= 105
"""
class Solution(object):
    def rotate(self, nums, k):
        """
        :type nums: List[int]
        :type k: int
        :rtype: None Do not return anything, modify nums in-place instead.
        """
        """
        Solution #1
        k %= len(nums)
        nums[:] = nums[-k:]+nums[:-k]
        Solution #2
        k %= len(nums)
        nums[:] = reversed(list(reversed(nums[:len(nums)-k])) + list(reversed(nums[len(nums)-k:])))
        """
        k %= len(nums)
        self.reverse(nums, 0, len(nums)-k-1)
        self.reverse(nums, len(nums)-k, len(nums)-1)
        #nums[:] = reversed(nums)
        self.reverse(nums, 0, len(nums)-1)

    def reverse(self, nums, i, j):
        x = i
        y = j
        while x < y:
            nums[x], nums[y] = nums[y], nums[x]
            x += 1
            y -= 1
