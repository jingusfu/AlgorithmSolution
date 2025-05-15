/*
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
*/
public class Solution {
    public int MajorityElement(int[] nums) {
        if (nums.Length==1)
            return nums[0];
        Hashtable numberCount = new Hashtable();
        int finalNumber = 0;
        for (int i=0; i<nums.Length; i++){
            if (numberCount.ContainsKey(nums[i]))
            {
                numberCount[nums[i]] = (int)numberCount[nums[i]] + 1;
                if ((int)numberCount[nums[i]] > (nums.Length / 2))
                {
                    finalNumber = nums[i];
                    break;
                }
            }
            else 
                numberCount.Add(nums[i],1);
        }
        return finalNumber;
    }
}
