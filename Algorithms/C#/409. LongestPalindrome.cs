/*
Given a string s which consists of lowercase or uppercase letters, return the length of the longest palindrome that can be built with those letters.
Letters are case sensitive, for example, "Aa" is not considered a palindrome.
Example 1:
Input: s = "abccccdd"
Output: 7
Explanation: One longest palindrome that can be built is "dccaccd", whose length is 7.
Example 2:
Input: s = "a"
Output: 1
Explanation: The longest palindrome that can be built is "a", whose length is 1.

Constraints:
1 <= s.length <= 2000
s consists of lowercase and/or uppercase English letters only.
*/

public class Solution {
    public int LongestPalindrome(string s) {
        if (s == null)
            return 0;

        Dictionary<char,int> myDict = new Dictionary<char,int>();
        int i, total = 0;
        bool found = false;
        DictionaryEntry entry;
        for (i=0; i<s.Length; i++)
        {
            if (myDict.ContainsKey(s[i]))
            {
                myDict[s[i]] = myDict[s[i]] + 1;

            }
            else
                myDict.Add(s[i],1);
        }

        foreach (KeyValuePair<char, int> item in myDict)
        {
            if ((item.Value % 2) == 0)
            {
                total = total + item.Value;
            }
            else 
            {
                if (!found)
                {
                    found = true;
                    total = total + 1;
                }
                if (item.Value>1)
                    total = total + item.Value - 1;
            }
        }
        return total;
    }
}
