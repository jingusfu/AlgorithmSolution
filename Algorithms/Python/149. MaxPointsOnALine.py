"""
Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane, return the maximum number of points that lie on the same straight line.
Example 1: 
Input: points = [[1,1],[2,2],[3,3]]
Output: 3
Example 2: 
Input: points = [[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]
Output: 4
Constraints:
1 <= points.length <= 300
points[i].length == 2
-104 <= xi, yi <= 104
All the points are unique.
"""
class Solution(object):
    def maxPoints(self, points):
        """
        :type points: List[List[int]]
        :rtype: int
        """
        finalNum = 1
        for x in points:
            slopeDict, maxPoints = {}, 0
            for y in points:
                if x == y: continue
                if y[0] == x[0]: 
                    m = float('inf')
                    c = x[0]
                else: 
                    m = (y[1] - x[1]) / float((y[0] - x[0]))
                    c = x[1] - m*x[0]
                slopeDict[(m,c)] = slopeDict.get((m,c), 1)+1
                maxPoints = max(maxPoints, slopeDict[(m,c)])
            finalNum = max(finalNum, maxPoints)
        return finalNum

        
