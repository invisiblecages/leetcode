/*
Given the root of a binary tree, determine if it is a valid binary search tree (BST).

A valid BST is defined as follows:
    The left
    subtree
    of a node contains only nodes with keys less than the node's key.
    The right subtree of a node contains only nodes with keys greater than the node's key.
    Both the left and right subtrees must also be binary search trees.

Example 1:
Input: root = [2,1,3]
Output: true

Example 2:
Input: root = [5,1,4,null,null,3,6]
Output: false
Explanation: The root node's value is 5 but its right child's value is 4.

Constraints:
    The number of nodes in the tree is in the range [1, 104].
    -231 <= Node.val <= 231 - 1
*/
/*
In-order traversal
Where we visit the left subtree first, then the current node, and then the right subtree. 
During the traversal, we keep track of the previously visited node and compare it with the current node. 
If the current node's value is less than or equal to the previously visited node's value, it is not a valid BST.
*/
// Iterative - In-order traversal
// Time complexity: O(n)
// Space complexity: O(n)
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution
{
  public bool IsValidBST(TreeNode root)
  {
    Stack<TreeNode> stack = new();
    TreeNode prev = null;

    while (stack.Count > 0 || root != null)
    {
      while (root != null)
      {
        stack.Push(root);
        root = root.left;
      }

      root = stack.Pop();

      if (prev != null && prev.val >= root.val)
        return false;

      prev = root;
      root = root.right;
    }

    return true;
  }
}
// Recursive
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution
{
  public bool IsValidBST(TreeNode root) => IsValidBST(root, null, null);

  private bool IsValidBST(TreeNode root, TreeNode min, TreeNode max)
  {
    if (root == null)
      return true;

    if (min != null && root.val <= min.val || max != null && root.val >= max.val)
      return false;

    return IsValidBST(root.left, min, root) && 
      IsValidBST(root.right, root, max);
  }
}