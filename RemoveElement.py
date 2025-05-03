"""
27. Remove Element
Given an integer array nums and an integer val, remove all occurrences of val in nums in-place. The order of the elements may be changed. Then return the number of elements in nums which are not equal to val.
Consider the number of elements in nums which are not equal to val be k, to get accepted, you need to do the following things:
Change the array nums such that the first k elements of nums contain the elements which are not equal to val. The remaining elements of nums are not important as well as the size of nums.
Return k.
"""
class Solution(object):
    def removeElement(self, nums, val):
        """
        :type nums: List[int]
        :type val: int
        :rtype: int
        """
        k = 0
        if len(nums) == 0:
            return k
        i, j, l = 0, len(nums)-1, len(nums)-1

        while i <= j: 
            while i <= l and nums[i] != val and i <= j:
                k += 1
                i += 1
            if i >= l:
                return k
            while nums[j] == val and j >= 0 and i <= j:
                j -= 1
            if j == -1 or j == i: 
                return k
            if i <= j: 
                nums[i], nums[j] = nums[j], nums[i]
                i += 1
                j -= 1
                k += 1

        return k
