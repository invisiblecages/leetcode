/*
You are given the root of a binary tree.

A ZigZag path for a binary tree is defined as follow:

    Choose any node in the binary tree and a direction (right or left).
    If the current direction is right, move to the right child of the current node; otherwise, move to the left child.
    Change the direction from right to left or from left to right.
    Repeat the second and third steps until you can't move in the tree.

Zigzag length is defined as the number of nodes visited - 1. (A single node has a length of 0).

Return the longest ZigZag path contained in that tree.

Example 1:

Input: root = [1,null,1,1,1,null,null,1,1,null,1,null,null,null,1,null,1]
Output: 3
Explanation: Longest ZigZag path in blue nodes (right -> left -> right).

Example 2:

Input: root = [1,1,1,null,1,null,null,1,1,null,1]
Output: 4
Explanation: Longest ZigZag path in blue nodes (left -> right -> left -> right).

Example 3:

Input: root = [1]
Output: 0

Constraints:

    The number of nodes in the tree is in the range [1, 5 * 104].
    1 <= Node.val <= 100
*/
// Time complexity: O(n^2)
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
  public int LongestZigZag(TreeNode root) 
  {
    if (root == null)
      return 0;

    return Math.Max(DFS(root, 0, "left"), DFS(root, 0, "right"));

    int DFS(TreeNode node, int path, string direction)
    {
      if (direction == "left")
      {
        if (node.right != null)
          path = Math.Max(path, DFS(node.right, path + 1, "right"));
        if (node.left != null)
          path = Math.Max(path, DFS(node.left, 1, "left"));
      }
      else
      {
        if (node.left != null)
          path = Math.Max(path, DFS(node.left, path + 1, "left"));
        if (node.right != null)
          path = Math.Max(path, DFS(node.right, 1, "right"));
      }

      return path;
    }
  }
}