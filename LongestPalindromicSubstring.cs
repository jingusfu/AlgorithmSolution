//To find the Longest Palindromic Substring
public class Solution {
    public string LongestPalindrome(string s) {
        if (s.Length<=1)
            return s;
        int left = 0;
        int right = 0;
        string result = "";
        for (int i=0; i<s.Length-1; i++)
        {
            left = i;
            right = i;
            while ((left>=0) && (s[left]==s[i]))
                left--;
            while ((right<=s.Length-1) && (s[right]==s[i]))
                right++;
            while ((left>=0) && (right<=s.Length-1) && (s[left]==s[right]))
            {
                left--;
                right++;
            }
            left++;
            right--;
            if ((right-left+1)>result.Length)
                result = s.Substring(left, (right-left+1));
        }
        return result;
    }
}
