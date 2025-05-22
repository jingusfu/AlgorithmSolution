"""
Given a non-negative integer x, return the square root of x rounded down to the nearest integer. The returned integer should be non-negative as well.
You must not use any built-in exponent function or operator.
For example, do not use pow(x, 0.5) in c++ or x ** 0.5 in python.
Example 1:
Input: x = 4
Output: 2
Explanation: The square root of 4 is 2, so we return 2.
Example 2:
Input: x = 8
Output: 2
Explanation: The square root of 8 is 2.82842..., and since we round it down to the nearest integer, 2 is returned.

Constraints:
0 <= x <= 231 - 1
"""
class Solution(object):
    import math
    def mySqrt(self, x):
        """
        :type x: int
        :rtype: int
        """
        """
        Solution #1:
        if x in [0, 1]: return x
        prior, next = 1, 2
        while next * next <= x: 
            prior = next
            next += 1
        return prior 

        Solution #2
        if x in [0, 1]: return x
        lo, hi = 0, x
        while lo < hi: 
            mid = (lo+hi) / 2
            if mid == lo: return mid
            temp = mid * mid
            if temp == x: return mid
            elif temp < x: lo = mid+1
            else: hi = mid-1
        """
        rootValue = math.sqrt(x)
        return int(math.floor(rootValue))
