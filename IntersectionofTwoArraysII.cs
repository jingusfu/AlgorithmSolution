/*
Given two integer arrays nums1 and nums2, return an array of their intersection. Each element in the result must appear as many times as it shows in both arrays and you may return the result in any order.
Example 1:
Input: nums1 = [1,2,2,1], nums2 = [2,2]
Output: [2,2]

Example 2:
Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
Output: [4,9]
Explanation: [9,4] is also accepted.

Constraints:
1 <= nums1.length, nums2.length <= 1000
0 <= nums1[i], nums2[i] <= 1000
*/
public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        if ((nums1.Length == 0) || (nums2.Length == 0))
            return null;

        List<int> resultList = new List<int>();
        Dictionary<int, int> numsDict1 = new Dictionary<int, int>();
        Dictionary<int, int> numsDict2 = new Dictionary<int, int>();
        int i, j, curMinCount = 0;
        for (i=0; i<nums1.Length; i++)
        {
            if (numsDict1.ContainsKey(nums1[i]))
                numsDict1[nums1[i]] = numsDict1[nums1[i]] + 1;
            else
                numsDict1.Add(nums1[i],1);
        }
        for (i=0; i<nums2.Length; i++)
        {
            if (numsDict2.ContainsKey(nums2[i]))
                numsDict2[nums2[i]] = numsDict2[nums2[i]] + 1;
            else
                numsDict2.Add(nums2[i],1);
        }
        if (numsDict1.Count < numsDict2.Count)
        {
            foreach(KeyValuePair<int, int> item in numsDict1)
            {
                if (numsDict2.ContainsKey(item.Key))
                {
                    curMinCount = item.Value;
                    if (numsDict2[item.Key] < curMinCount)
                        curMinCount = numsDict2[item.Key];
                    for (j=1; j<=curMinCount; j++)
                        resultList.Add(item.Key);
                }
            }
        }
        else 
        {
            foreach(KeyValuePair<int, int> item in numsDict2)
            {
                if (numsDict1.ContainsKey(item.Key))
                {
                    curMinCount = item.Value;
                    if (numsDict1[item.Key] < curMinCount)
                        curMinCount = numsDict1[item.Key];
                    for (j=1; j<=curMinCount; j++)
                        resultList.Add(item.Key);
                }
            }

        }
        
        int[] resultArray = resultList.ToArray();
        return resultArray;
    }
}
