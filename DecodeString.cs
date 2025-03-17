/*
Given an encoded string, return its decoded string.
The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets is being repeated exactly k times. Note that k is guaranteed to be a positive integer.
You may assume that the input string is always valid; there are no extra white spaces, square brackets are well-formed, etc. Furthermore, you may assume that the original data does not contain any digits and that digits are only for those repeat numbers, k. For example, there will not be input like 3a or 2[4].
The test cases are generated so that the length of the output will never exceed 105.

Example 1:
Input: s = "3[a]2[bc]"
Output: "aaabcbc"

Example 2:
Input: s = "3[a2[c]]"
Output: "accaccacc"

Example 3:
Input: s = "2[abc]3[cd]ef"
Output: "abcabccdcdcdef"

Constraints:
1 <= s.length <= 30
s consists of lowercase English letters, digits, and square brackets '[]'.
s is guaranteed to be a valid input.
All the integers in s are in the range [1, 300].
*/

public class Solution {
    public string DecodeString(string s) {
        Stack myStack = new Stack();
        StringBuilder sb = new StringBuilder();
        StringBuilder sbNum = new StringBuilder();
        char c;
        int r = 0;
        string tempStr = "";

        for (int i=s.Length-1; i>=0; i--)
        {
            c = s[i];
            Console.WriteLine("i="+i+", c="+c);
            if ( (c=='[')  || (c==']') || (c >= 'a' && c <= 'z'))
            {
                if (sbNum.Length>0)
                {
                    r = int.Parse(sbNum.ToString());
                    tempStr = "";
                    while ((tempStr != "]") && (myStack.Count > 0))
                    {
                        tempStr = myStack.Pop().ToString();

                        if ((tempStr != "[") && (tempStr != "]"))
                            sb = sb.Append(tempStr);
                    }
                    tempStr = sb.ToString();
                    sb.Insert(0, tempStr, r-1);
                    myStack.Push(sb.ToString());
                    sb = new StringBuilder();
                    sbNum = new StringBuilder();
                }
                myStack.Push(c.ToString());
            }
            else  //number
            {
                sbNum.Insert(0, c.ToString(), 1);
            }
        }
        if (sbNum.Length>0)
        {
            r = int.Parse(sbNum.ToString());
            tempStr = "";
            while ((tempStr != "]") && (myStack.Count > 0))
            {
                tempStr = myStack.Pop().ToString();

                if ((tempStr != "[") && (tempStr != "]"))
                    sb = sb.Append(tempStr);
            }
            tempStr = sb.ToString();
            sb.Insert(0, tempStr, r-1);
            myStack.Push(sb.ToString());
        }

        sb = new StringBuilder();
        while (myStack.Count > 0)
        {
            tempStr = myStack.Pop().ToString();
            sb = sb.Append(tempStr);
        }
        return sb.ToString();
    }
}
