/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    Hashtable ht = new Hashtable(); 
    public Node CloneGraph(Node node) {
        if (node == null)
            return null;
        if (node.neighbors == null)
            return node;
        
        Node result; 
        result = new Node(node.val);
        ht.Add(node.val, result);
        result = traverseNode(result, node.neighbors);
        return result;
    }

    private Node traverseNode(Node node, IList<Node> neighbors)
    {
        Node curNode;
        foreach (Node n in neighbors) 
        {
            if (ht.ContainsKey(n.val))
                curNode = (Node)ht[n.val];
            else
            {
                curNode = new Node(n.val);
                ht.Add(n.val, curNode);
                curNode = traverseNode(curNode, n.neighbors);
            }
            node.neighbors.Add(curNode);
        }
        return node;
    }
}
