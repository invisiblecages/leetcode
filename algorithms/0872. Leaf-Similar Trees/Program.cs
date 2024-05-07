/*
Consider all the leaves of a binary tree, from left to right order, the values of those leaves form a leaf value sequence.

For example, in the given tree above, the leaf value sequence is (6, 7, 4, 9, 8).

Two binary trees are considered leaf-similar if their leaf value sequence is the same.

Return true if and only if the two given trees with head nodes root1 and root2 are leaf-similar.

Example 1:

Input: root1 = [3,5,1,6,2,9,8,null,null,7,4], root2 = [3,5,1,6,7,4,2,null,null,null,null,null,null,9,8]
Output: true

Example 2:

Input: root1 = [1,2,3], root2 = [1,3,2]
Output: false

Constraints:

    The number of nodes in each tree will be in the range [1, 200].
    Both of the given trees will have values in the range [0, 200].
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
  private List<int> GetLeaves(TreeNode root)
  {
    List<int> leaves = [];
    Stack<TreeNode> stack = [];
    stack.Push(root);

    while (stack.Count > 0)
    {
      TreeNode node = stack.Pop();
            
      if (node.left is not null)
      {
        stack.Push(node.left);
      }
  
      if (node.right is not null)
      {
        stack.Push(node.right);
      }

      if (node.left is null && node.right is null)
      {
        leaves.Add(node.val);
      }
    }

    return leaves;
  }

  public bool LeafSimilar(TreeNode root1, TreeNode root2) 
  {
    List<int> leaves1 = GetLeaves(root1);
    List<int> leaves2 = GetLeaves(root2);

    return leaves1.SequenceEqual(leaves2);
  }
}