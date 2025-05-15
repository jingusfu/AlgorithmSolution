/*
Given the root of a binary tree, return the zigzag level order traversal of its nodes' values. (i.e., from left to right, then right to left for the next level and alternate between).
Example 1:
Input: root = [3,9,20,null,null,15,7]
Output: [[3],[20,9],[15,7]]
Example 2:
Input: root = [1]
Output: [[1]]
Example 3:
Input: root = []
Output: []

Constraints:
The number of nodes in the tree is in the range [0, 2000].
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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        IList<IList<int>> result = new List<IList<int>>();   
        List<int> curIntList = new List<int>();
        if (root == null)
            return result;
        
        List<TreeNode> curNodeList = new List<TreeNode>();
        bool reverse = true;
        int i = 0;
        int curPos = 0;
        int curCount = 0;
        curNodeList.Add(root);
        while (curCount < curNodeList.Count)
        {
            curCount = curNodeList.Count;
            for (i = curNodeList.Count - 1; i >= curPos; i--)
            {
                curIntList.Add(curNodeList[i].val);
                if (reverse) {
                    if (curNodeList[i].left != null)
                        curNodeList.Add(curNodeList[i].left);
                    if (curNodeList[i].right != null)
                        curNodeList.Add(curNodeList[i].right);
                }
                else 
                {
                    if (curNodeList[i].right != null)
                        curNodeList.Add(curNodeList[i].right);
                    if (curNodeList[i].left != null)
                        curNodeList.Add(curNodeList[i].left);
                }
            }
            reverse = !reverse;
            result.Add(curIntList);
            curIntList = new List<int>();
            curPos = curCount;
        }
        return result;
    }
}
