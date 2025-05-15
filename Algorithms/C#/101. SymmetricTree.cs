/*
Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).
Example 1:
Input: root = [1,2,2,3,4,4,3]
Output: true
Example 2:
Input: root = [1,2,2,null,3,null,3]
Output: false

Constraints:
The number of nodes in the tree is in the range [1, 1000].
-100 <= Node.val <= 100
*/
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public bool IsSymmetric(TreeNode root) {
        if (root == null)
            return false;
        if ((root.left == null) && (root.right == null))
            return true;
        return isMatched(root.left, root.right);
    }

    private bool isMatched(TreeNode leftNode, TreeNode rightNode){
        bool leftNodeMatch, rightNodeMatch = false;
        if (leftNode == null)
        {
            if (rightNode == null)
                return true;
            else 
                return false;
        }
        else 
        {
            if (rightNode == null)
                return false;
            else 
            {
                if (leftNode.val != rightNode.val)
                    return false;
            }
        }

        if (leftNode.left == null) 
        {
            if (rightNode.right == null) 
                leftNodeMatch = isMatched(leftNode.right, rightNode.left);
            else 
                return false;
        }
        else 
        {
            if (rightNode.right == null) 
                return false;
            else 
            {
                if (leftNode.val != rightNode.val)
                    return false;
                else 
                    leftNodeMatch = isMatched(leftNode.right, rightNode.left);
            }
        }

        if (leftNode.right == null) 
        {
            if (rightNode.left == null) 
                rightNodeMatch = isMatched(leftNode.left, rightNode.right);
            else 
                return false;
        }
        else 
        {
            if (rightNode.left == null) 
                return false;
            else 
            {
                if (leftNode.val != rightNode.val)
                    return false;
                else 
                    rightNodeMatch = isMatched(leftNode.left, rightNode.right);
            }
        }
        return (leftNodeMatch && rightNodeMatch);
    }
}
