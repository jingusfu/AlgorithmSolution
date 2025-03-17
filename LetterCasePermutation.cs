/*
Given a string s, you can transform every letter individually to be lowercase or uppercase to create another string.
Return a list of all possible strings we could create. Return the output in any order.
Example 1:
Input: s = "a1b2"
Output: ["a1b2","a1B2","A1b2","A1B2"]

Example 2:
Input: s = "3z4"
Output: ["3z4","3Z4"]

Constraints:
1 <= s.length <= 12
s consists of lowercase English letters, uppercase English letters, and digits.
*/
public class Solution {
    List<string> result = new List<string>();
    public IList<string> LetterCasePermutation(string s) {
        if (s.Length==0)
            return null;
        string curStr = "";
        PerString(s, 0, curStr);
        return result;
    }

    private void PerString(string s, int pos, string curStr)
    {
        if (pos == s.Length)
        {
            result.Add(curStr);
            return;
        }
        Char c = s[pos];
        string tempStr = "";
        tempStr = curStr+c;
        PerString(s, pos+1, tempStr);

        if ((c >= 'a') && (c<='z'))
        {
            tempStr = curStr+Char.ToUpper(c);
            PerString(s, pos+1, tempStr);
        }
        if ((c >= 'A') && (c<='Z'))
        {
            tempStr = curStr+Char.ToLower(c);
            PerString(s, pos+1, tempStr);
        }
    }
}
