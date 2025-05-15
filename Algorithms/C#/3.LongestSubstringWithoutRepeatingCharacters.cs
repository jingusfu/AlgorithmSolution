/*
Given a string s, find the length of the longest substring without duplicate characters.
Example 1:
Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.
Example 2:
Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.
Example 3:
Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

Constraints:
0 <= s.length <= 5 * 104
s consists of English letters, digits, symbols and spaces.
*/
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (s.Length == 0)
            return 0;
        string longestSubStr = "";
        string tempStr = "";
        int i = 0;
        int j = 0;
        Char c;
        while (i<s.Length)
        {
            c = s[i];
            j = tempStr.IndexOf(c);
            if (j>=0)
            {
                if (tempStr.Length > longestSubStr.Length )
                    longestSubStr = tempStr;
                tempStr = tempStr.Substring(j+1, tempStr.Length-j-1)+ c.ToString();
            }
            else 
                tempStr = tempStr + c;
            i++;
        }
        if (longestSubStr.Length<tempStr.Length)
            return tempStr.Length;
        else
            return longestSubStr.Length;
    }
}
