/*
Given two strings ransomNote and magazine, return true if ransomNote can be constructed by using the letters from magazine and false otherwise.
Each letter in magazine can only be used once in ransomNote.
Example 1:
Input: ransomNote = "a", magazine = "b"
Output: false
Example 2:
Input: ransomNote = "aa", magazine = "ab"
Output: false
Example 3:
Input: ransomNote = "aa", magazine = "aab"
Output: true

Constraints:
1 <= ransomNote.length, magazine.length <= 105
ransomNote and magazine consist of lowercase English letters.
*/

public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        if ((ransomNote.Length==0) || (magazine.Length==0) || (ransomNote.Length>magazine.Length))
            return false;
        int[] charCount = new int[26];
        int ind = 0;

        for (int i=0; i<magazine.Length; i++)
            charCount[magazine[i]-'a']++;

        for (int i=0; i<ransomNote.Length; i++)
        {
            ind = ransomNote[i]-'a';
            if (charCount[ind]==0)
                return false;
            charCount[ind]--;
        }
        return true;
    }
}
