/*
Given two non-negative integers num1 and num2 represented as strings, return the product of num1 and num2, also represented as a string.
Note: You must not use any built-in BigInteger library or convert the inputs to integer directly.

Example 1:
Input: num1 = "2", num2 = "3"
Output: "6"

Example 2:
Input: num1 = "123", num2 = "456"
Output: "56088"
 
Constraints:
1 <= num1.length, num2.length <= 200
num1 and num2 consist of digits only.
Both num1 and num2 do not contain any leading zero, except the number 0 itself.
*/
public class Solution {
    public string Multiply(string num1, string num2) {
        BigInteger n1 =0;
        BigInteger n2 = 0;
        BigInteger num; 
        for (int i=0; i<num1.Length; i++){
            num = num1[i]-'0';
            n1 =+ n1*10 + num;
        }
        for (int i=0; i<num2.Length; i++){
            num = num2[i]-'0';
            n2 =+ n2*10 + num;
        }
        num = n1*n2;
        StringBuilder result = new StringBuilder();
        char c;
        if (num==0)
            return "0";
        while (num>0)
        {
            c = (char) (num%10 + '0');
            num = num / 10;
            result.Insert(0,c.ToString());
        }
        return result.ToString();
    }
}
