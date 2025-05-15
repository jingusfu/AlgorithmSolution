/*
You are given the heads of two sorted linked lists list1 and list2.
Merge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.
Return the head of the merged linked list.
Example 1:
Input: list1 = [1,2,4], list2 = [1,3,4]
Output: [1,1,2,3,4,4]
Example 2:
Input: list1 = [], list2 = []
Output: []
Example 3:
Input: list1 = [], list2 = [0]
Output: [0]

Constraints:
The number of nodes in both lists is in the range [0, 50].
-100 <= Node.val <= 100
Both list1 and list2 are sorted in non-decreasing order.
*/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if (list1 == null)
            return list2;
        if (list2 == null)
            return list1;

        ListNode curNodeList1 = list1;
        ListNode curNodeList2 = list2;
        ListNode newList = new ListNode(0, null);
        ListNode curNodeList = newList;
        
        while ((curNodeList1 != null) && (curNodeList2 != null))
        {
            if (curNodeList1.val > curNodeList2.val) {
                curNodeList.next = curNodeList2;
                curNodeList = curNodeList2;
                curNodeList2 = curNodeList2.next;
            }
            else 
            {
                curNodeList.next = curNodeList1;
                curNodeList = curNodeList1;
                curNodeList1 = curNodeList1.next;
            }
        }

        if (curNodeList1 == null)
        {
            curNodeList.next = curNodeList2;
        }
        else 
        {
            curNodeList.next = curNodeList1;
        } 

        return newList.next;
    }
}
