/*
Given the roots of two binary trees p and q, write a function to check if they are the same or not.

Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.

Example 1:
Input: p = [1,2,3], q = [1,2,3]
Output: true

Example 2:
Input: p = [1,2], q = [1,null,2]
Output: false

Example 3:
Input: p = [1,2,1], q = [1,1,2]
Output: false

Constraints:
    The number of nodes in both trees is in the range [0, 100].
    -104 <= Node.val <= 104
*/
// Time complexity: O(n)
// Space complexity: O(h) h = height of the taller tree
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
public class Solution
{
  public bool IsSameTree(TreeNode p, TreeNode q)
  {
    Stack<TreeNode> stack = new();
    stack.Push(p);
    stack.Push(q);

    while (stack.Count > 0)
    {
      var node1 = stack.Pop();
      var node2 = stack.Pop();

      if (node1 == null && node2 == null)
        continue;
      if (node1 == null || node2 == null)
        return false;
      if (node1.val != node2.val)
        return false;
      
      stack.Push(node1.right);
      stack.Push(node2.right);
      stack.Push(node1.left);
      stack.Push(node2.left);
    }
    
    return true;    
  }
}