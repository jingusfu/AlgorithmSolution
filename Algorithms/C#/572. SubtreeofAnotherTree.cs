/*
Given the roots of two binary trees root and subRoot, return true if there is a subtree of root with the same structure and node values of subRoot and false otherwise.
A subtree of a binary tree tree is a tree that consists of a node in tree and all of this node's descendants. The tree tree could also be considered as a subtree of itself.
Example 1:
Input: root = [3,4,5,1,2], subRoot = [4,1,2]
Output: true
Example 2:
Input: root = [3,4,5,1,2,null,null,null,null,0], subRoot = [4,1,2]
Output: false

Constraints:
The number of nodes in the root tree is in the range [1, 2000].
The number of nodes in the subRoot tree is in the range [1, 1000].
-104 <= root.val <= 104
-104 <= subRoot.val <= 104
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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        if ( (root == null) || (subRoot == null))
            return false;
       
        return FindMatch(root, subRoot);
    }

    private bool FindMatch(TreeNode curNode, TreeNode subRoot)
    {
        TreeNode theNode = null;
        bool result = false;

        theNode = FindNode(curNode, subRoot.val);
        if (theNode==null) return false;

        result = TraverseTree(theNode, subRoot);

        if (result) return result;
    
        if (curNode.left != null)
        {
            result = FindMatch(curNode.left, subRoot);
            if (result) return result;
        }
        if (curNode.right != null)
        {
            result = FindMatch(curNode.right, subRoot);
            if (result) return result;
        }

        return result;
    }

    private TreeNode FindNode(TreeNode p, int nodeValue)
    {
        TreeNode result = null;
        if (p.val == nodeValue){
            result = p;
        }
        else 
        {
            if (p.left != null)
            {
                result = FindNode(p.left, nodeValue);
            }
            if ((result==null) && (p.right != null)) 
            {
                result = FindNode(p.right, nodeValue);
            }
        }
        return result;
    }

    private bool TraverseTree(TreeNode p, TreeNode c)
    {
        if (p.val != c.val)
            return false;

        if ((p.left == null) && (c.left == null) && (p.right == null) && (c.right == null)) 
            return true;

        if (((p.left == null) && (c.left != null)) || ((p.right == null) && (c.right != null)))
            return false;

        if (((p.left != null) && (c.left == null)) || ((p.right != null) && (c.right == null)))
            return false;

        bool result = true;
        
        if ((p.left != null) && (c.left != null))
            result = TraverseTree(p.left, c.left);

        if ((result) && (p.right != null) && (c.right != null))
            result = TraverseTree(p.right, c.right);

        return result;
    }
}
