/*
Given the root of a Binary Search Tree (BST), return the minimum difference between the values of any two different nodes in the tree.

Example 1:
Input: root = [4,2,6,1,3]
Output: 1

Example 2:
Input: root = [1,0,48,null,null,12,49]
Output: 1

Constraints:
    The number of nodes in the tree is in the range [2, 100].
    0 <= Node.val <= 105
*/
// Time complexity: O(n)
// Space complexity: O(h) height of the tree
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
  public int MinDiffInBST(TreeNode root)
  {
    if (root == null)
      return 0;

    Stack<TreeNode> stack = new();
    TreeNode node = root;
    TreeNode prev = null;
    int minDiff = int.MaxValue;

    while (node != null || stack.Count > 0)
    {
      while (node != null)
      {
        stack.Push(node);
        node = node.left;
      }

      node = stack.Pop();
      if (prev != null)
        minDiff = Math.Min(minDiff, node.val - prev.val);

      prev = node;
      node = node.right;
    }

    return minDiff;
  }
}