"""
Given an array nums of size n, return the majority element.
The majority element is the element that appears more than ⌊n / 2⌋ times. You may assume that the majority element always exists in the array.
Example 1:
Input: nums = [3,2,3]
Output: 3
Example 2:
Input: nums = [2,2,1,1,1,2,2]
Output: 2

Constraints:
n == nums.length
1 <= n <= 5 * 104
-109 <= nums[i] <= 109
"""
class Solution(object):
    def majorityElement(self, nums):
        """
        :type nums: List[int]
        :rtype: int
        """
        """
        Solution #1:
        numsDict = dict()
        for i in range(len(nums)): 
            if nums[i] in numsDict: 
                numsDict[nums[i]] += 1
                if numsDict[nums[i]] >= len(nums)/2+1: 
                    break
            else: 
                numsDict[nums[i]] = 1
        return nums[i]

        Solution #2:
        val, count = None, 0
        for i in nums: 
            if count == 0:
                val = i
            count += (1 if i == val else -1)

        return val
        """
        n = len(nums)
        nums.sort()
        return nums[n/2]
