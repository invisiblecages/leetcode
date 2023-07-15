/*
Given a binary tree, find its minimum depth.

The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.

Note: A leaf is a node with no children.

Example 1:

Input: root = [3,9,20,null,null,15,7]
Output: 2

Example 2:

Input: root = [2,null,3,null,4,null,5,null,6]
Output: 5

Constraints:

    The number of nodes in the tree is in the range [0, 105].
    -1000 <= Node.val <= 1000
*/
// Time complexity: O(n)
// Space complexity: O(h)
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
  private int DFS(TreeNode node, int level)
  {
    if (node is null)
      return int.MaxValue;

    if (node.left is null && node.right is null)
      return level + 1;

    int leftMinDepth = DFS(node.left, level + 1);
    int rightMinDepth = DFS(node.right, level + 1);

    return Math.Min(leftMinDepth, rightMinDepth);
  }
  
  public int MinDepth(TreeNode root) 
  {
    if (root is null)
      return 0;

    return DFS(root, 0);
  }
}