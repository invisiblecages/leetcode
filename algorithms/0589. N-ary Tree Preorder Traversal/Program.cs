﻿/*
Given the root of an n-ary tree, return the preorder traversal of its nodes' values.

Nary-Tree input serialization is represented in their level order traversal. Each group of children is separated by the null value (See examples)

 

Example 1:

Input: root = [1,null,3,2,4,null,5,6]
Output: [1,3,5,6,2,4]

Example 2:

Input: root = [1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14]
Output: [1,2,3,6,7,11,14,4,8,12,5,9,13,10]

 

Constraints:

    The number of nodes in the tree is in the range [0, 104].
    0 <= Node.val <= 104
    The height of the n-ary tree is less than or equal to 1000.

 

Follow up: Recursive solution is trivial, could you do it iteratively?
*/
// Iterative
// Time complexity: O(n)
// Space complexity: O(n)
/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val,IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/
public class Solution
{
  public IList<int> Preorder(Node root)
  {
    List<int> nodes = new();
    if (root == null)
      return nodes;

    Stack<Node> stack = new();
    stack.Push(root);
    while (stack.Count > 0)
    {
      var node = stack.Pop();
      nodes.Add(node.val);

      for (int i = node.children.Count - 1; i >= 0; i--)
        stack.Push(node.children[i]);
    }

    return nodes;
  }
}
// Recursive
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution
{
  public IList<int> Preorder(Node root)
  {
    List<int> nodes = new();
    Preorder(root);
    
    return nodes;
    
    void Preorder(Node node)
    {
      if (node == null)
        return;
      
      nodes.Add(node.val);
      foreach (var child in node.children)
        Preorder(child);
    }
  }
}