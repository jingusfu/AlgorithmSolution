"""
Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.
You must implement a solution with a linear runtime complexity and use only constant extra space.
Example 1:
Input: nums = [2,2,1]
Output: 1
Example 2:
Input: nums = [4,1,2,1,2]
Output: 4
Example 3:
Input: nums = [1]
Output: 1

Constraints:
1 <= nums.length <= 3 * 104
-3 * 104 <= nums[i] <= 3 * 104
"""
class Solution(object):
    def singleNumber(self, nums):
        """
        :type nums: List[int]
        :rtype: int
        """
        """
        Solution #2 is the best, then #3, last is #1
        Solution #1: 
        numSet = set()
        for i in nums: 
            if i in numSet: numSet.remove(i)
            else: numSet.add(i)
        return numSet.pop()

        Solution #2: 
        theNum = 0 
        for i in nums: 
            theNum ^= i
        return theNum
        """
        return 2*sum(set(nums)) - sum(nums)
