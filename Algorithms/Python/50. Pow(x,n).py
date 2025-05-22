"""
Implement pow(x, n), which calculates x raised to the power n (i.e., xn).
Example 1:
Input: x = 2.00000, n = 10
Output: 1024.00000
Example 2:
Input: x = 2.10000, n = 3
Output: 9.26100
Example 3:
Input: x = 2.00000, n = -2
Output: 0.25000
Explanation: 2-2 = 1/22 = 1/4 = 0.25

Constraints:
-100.0 < x < 100.0
-231 <= n <= 231-1
n is an integer.
Either x is not zero or n > 0.
-104 <= xn <= 104
"""
class Solution(object):
    
    def funcPow(self, x, n):
        half = n//2
        if half == 0: return x
        y = self.funcPow(x, half)
        if n%2 == 0: return y*y
        else: return y*y*x

    def myPow(self, x, n):
        """
        :type x: float
        :type n: int
        :rtype: float
        """
        if x in [0, 1]: return x
        if n == 0: return float(1)
        y = self.funcPow(x, abs(n))
        if n > 0: return y
        else: return 1/y

            
        
