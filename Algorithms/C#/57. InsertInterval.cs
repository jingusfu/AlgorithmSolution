/*
You are given an array of non-overlapping intervals intervals where intervals[i] = [starti, endi] represent the start and the end of the ith interval and intervals is sorted in ascending order by starti. You are also given an interval newInterval = [start, end] that represents the start and end of another interval.
Insert newInterval into intervals such that intervals is still sorted in ascending order by starti and intervals still does not have any overlapping intervals (merge overlapping intervals if necessary).
Return intervals after the insertion.
Note that you don't need to modify intervals in-place. You can make a new array and return it.
Example 1:
Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
Output: [[1,5],[6,9]]
Example 2:
Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
Output: [[1,2],[3,10],[12,16]]
Explanation: Because the new interval [4,8] overlaps with [3,5],[6,7],[8,10].

Constraints:
0 <= intervals.length <= 104
intervals[i].length == 2
0 <= starti <= endi <= 105
intervals is sorted by starti in ascending order.
newInterval.length == 2
0 <= start <= end <= 105
*/

public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        if ((intervals==null) || (intervals.Length==0))
        {
            return (new int[][]{newInterval});
        }
        if ((newInterval==null) || (newInterval.Length==0))
        {
            return intervals;
        }
        List<int[]> jaggedArrayList = new List<int[]>();

        int start = newInterval[0];
        int end = newInterval[1];
        int i, j;

        for (i=0; i<intervals.Length; i++)
        {
            if (intervals[i][1]<start) 
            {
                jaggedArrayList.Add(new int[] { intervals[i][0], intervals[i][1] });
                continue;
            }
            if (intervals[i][1]==start) 
            {
                start = intervals[i][0];
                continue;
            }
            if (intervals[i][0]<start) 
            {
                start = intervals[i][0];
            }
            if (end < intervals[i][0])
            {
                jaggedArrayList.Add(new int[] { start, end });
                start = -1;
                i--;
                break;
            }
            if (end == intervals[i][0])
            {
                end = intervals[i][1];
                jaggedArrayList.Add(new int[] { start, end });
                start = -1;
                break;
            }
            if (end <= intervals[i][1])
            {
                end = intervals[i][1];
                if (intervals[i][0]<start)
                    start = intervals[i][0];
                jaggedArrayList.Add(new int[] { start, end });
                start = -1;
                break;
            }
        }

        if (start>-1)
            jaggedArrayList.Add(new int[] { start, end });
        for (j=i+1; j<intervals.Length; j++)
        {
            jaggedArrayList.Add(new int[] { intervals[j][0], intervals[j][1] });
        }
        return jaggedArrayList.ToArray();
    }
}
