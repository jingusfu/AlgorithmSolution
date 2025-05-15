/*
Given a binary tree
struct Node {
  int val;
  Node *left;
  Node *right;
  Node *next;
}
Populate each next pointer to point to its next right node. If there is no next right node, the next pointer should be set to NULL.
Initially, all next pointers are set to NULL.
Example 1:
Input: root = [1,2,3,4,5,null,7]
Output: [1,#,2,3,#,4,5,7,#]
Explanation: Given the above binary tree (Figure A), your function should populate each next pointer to point to its next right node, just like in Figure B. The serialized output is in level order as connected by the next pointers, with '#' signifying the end of each level.
Example 2:
Input: root = []
Output: []

Constraints:
The number of nodes in the tree is in the range [0, 6000].
-100 <= Node.val <= 100
*/
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    public Node Connect(Node root) {
        Queue myQ = new Queue();
        myQ.Enqueue(root);
        while (myQ.Count>0)
            TraverseNode(myQ);
        return root;
    }
    private void TraverseNode(Queue myQ)
    {
        Node curNode = (Node)myQ.Dequeue();
        if (curNode==null)
            return;
        Console.WriteLine("curNode.val="+curNode.val);
        Node theNode = curNode.next;
        if (curNode.left != null) 
        {
            if (curNode.right != null) 
                curNode.left.next = curNode.right;
            else 
            {
                theNode = curNode.next;
                while (theNode != null)
                {
                    if (theNode.left != null)
                    {
                        curNode.left.next = theNode.left;
                        break;
                    }
                    if (theNode.right != null)
                    {
                        curNode.left.next = theNode.right;
                        break;
                    }
                    theNode = theNode.next;
                }
            }
        }

        if (curNode.right != null) 
        {
            theNode = curNode.next;
            while (theNode != null)
            {
                if (theNode.left != null)
                {
                    curNode.right.next = theNode.left;
                    break;
                }
                if (theNode.right != null)
                {
                    curNode.right.next = theNode.right;
                    break;
                }
                theNode = theNode.next;
            }
        }

        if (curNode.left != null) 
            myQ.Enqueue(curNode.left); 
        if (curNode.right != null) 
            myQ.Enqueue(curNode.right); 
    }
}
