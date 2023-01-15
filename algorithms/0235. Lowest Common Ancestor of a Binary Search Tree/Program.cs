/*
Given a binary search tree (BST), find the lowest common ancestor (LCA) node of two given nodes in the BST.

According to the definition of LCA on Wikipedia: 
“The lowest common ancestor is defined between two nodes p and q as the lowest node in T that has both p and q as descendants 
(where we allow a node to be a descendant of itself).”

Example 1:
Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 8
Output: 6
Explanation: The LCA of nodes 2 and 8 is 6.

Example 2:
Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 4
Output: 2
Explanation: The LCA of nodes 2 and 4 is 2, since a node can be a descendant of itself according to the LCA definition.

Example 3:
Input: root = [2,1], p = 2, q = 1
Output: 2
 
Constraints:
    The number of nodes in the tree is in the range [2, 105].
    -109 <= Node.val <= 109
    All Node.val are unique.
    p != q
    p and q will exist in the BST.
*/
// Iterative
// Time complexity: O(log n) h: height of the tree
// Space complexity: O(1)
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
  public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
  {
    while (root != null)
    {
      if (root.val > p.val && root.val > q.val)
        root = root.left;
      else if (root.val < p.val && root.val < q.val)
        root = root.right;
      else
        return root;
    }

    return root;
  }
}
// Refined first solution
public class Solution
{
  public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
  {
    int min = Math.Min(p.val, q.val);
    int max = Math.Max(p.val, q.val);
    Stack<TreeNode> stack = new();
    stack.Push(root);

    while (stack.Count > 0)
    {
      var node = stack.Pop();

      if (node.val > min && node.val < max || node == p || node == q)
        return node;
        
      if (node.left != null)
        stack.Push(node.left);
      if (node.right != null)
        stack.Push(node.right);
    }

    return root;
  }
}