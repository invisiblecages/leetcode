/*
Given the root of a Binary Search Tree (BST), 
return the minimum absolute difference between the values of any two different nodes in the tree.

Example 1:

Input: root = [4,2,6,1,3]
Output: 1

Example 2:

Input: root = [1,0,48,null,null,12,49]
Output: 1

Constraints:

    The number of nodes in the tree is in the range [2, 104].
    0 <= Node.val <= 105

Note: This question is the same as 783: https://leetcode.com/problems/minimum-distance-between-bst-nodes/
*/
// Time complexity: O(n)
// Space complexity: O(n)
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
  private int MinDiffInOrderTraversal(TreeNode node, ref TreeNode prev, int minDiff)
  {
    if (node is null)
      return minDiff;

    minDiff = MinDiffInOrderTraversal(node.left, ref prev, minDiff);

    if (prev is not null)
      minDiff = Math.Min(minDiff, node.val - prev.val);

    prev = node;

    return MinDiffInOrderTraversal(node.right, ref prev, minDiff);
  }

  public int GetMinimumDifference(TreeNode root) 
  {
    if (root is null)
      return 0;
      
    TreeNode prev = null;

    return MinDiffInOrderTraversal(root, ref prev, int.MaxValue);
  }
}