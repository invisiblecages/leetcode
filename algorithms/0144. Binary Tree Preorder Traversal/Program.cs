/*
Given the root of a binary tree, return the preorder traversal of its nodes' values.

Example 1:
Input: root = [1,null,2,3]
Output: [1,2,3]

Example 2:
Input: root = []
Output: []

Example 3:
Input: root = [1]
Output: [1]

Constraints:
    The number of nodes in the tree is in the range [0, 100].
    -100 <= Node.val <= 100

Follow up: Recursive solution is trivial, could you do it iteratively?
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
  public IList<int> PreorderTraversal(TreeNode root)
  {
    List<int> res = new();
    if (root == null)
      return res;

    Stack<TreeNode> stack = new();
    stack.Push(root);
    while (stack.Count > 0)
    {
      TreeNode curr = stack.Pop();
      res.Add(curr.val);

      if (curr.right != null)
        stack.Push(curr.right);
      if (curr.left != null)
        stack.Push(curr.left);
    }

    return res;
  }
}
// Recursive
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution
{
    public IList<int> PreorderTraversal(TreeNode root)
    {
        var list = new List<int>();
        PreorderTraversalRecursive(root, list);
        return list;
    }

    private void PreorderTraversalRecursive(TreeNode node, List<int> list)
    {
        if (node == null) return;
        list.Add(node.val);
        PreorderTraversalRecursive(node.left, list);
        PreorderTraversalRecursive(node.right, list);
    }
}