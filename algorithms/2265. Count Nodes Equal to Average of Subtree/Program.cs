/*
Given the root of a binary tree, 
return the number of nodes where the value of the node is equal to the average of the values in its subtree.

Note:

    The average of n elements is the sum of the n elements divided by n and rounded down to the nearest integer.
    A subtree of root is a tree consisting of root and all of its descendants.

Example 1:

Input: root = [4,8,5,0,1,null,6]
Output: 5
Explanation: 
For the node with value 4: The average of its subtree is (4 + 8 + 5 + 0 + 1 + 6) / 6 = 24 / 6 = 4.
For the node with value 5: The average of its subtree is (5 + 6) / 2 = 11 / 2 = 5.
For the node with value 0: The average of its subtree is 0 / 1 = 0.
For the node with value 1: The average of its subtree is 1 / 1 = 1.
For the node with value 6: The average of its subtree is 6 / 1 = 6.

Example 2:

Input: root = [1]
Output: 1
Explanation: For the node with value 1: The average of its subtree is 1 / 1 = 1.

Constraints:

    The number of nodes in the tree is in the range [1, 1000].
    0 <= Node.val <= 1000
*/
// First solution which is slow because of building subtrees
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
  private void DFS(TreeNode node, Dictionary<TreeNode, HashSet<TreeNode>> subtrees)
  {
    if (node is null)
      return;

    subtrees[node] = new();
    BuildSubtree(node, subtrees[node], true);

    DFS(node.left, subtrees);
    DFS(node.right, subtrees);
  }

  private void BuildSubtree(TreeNode node, HashSet<TreeNode> subtree, bool root = false)
  {
    if (node is null)
      return;

    if (root)
      subtree.Add(node);

    if (node.left is not null)
    {
      subtree.Add(node.left);
      BuildSubtree(node.left, subtree);
    }

    if (node.right is not null)
    {
      subtree.Add(node.right);
      BuildSubtree(node.right, subtree);
    }
  }

  public int AverageOfSubtree(TreeNode root) 
  {
    Dictionary<TreeNode, HashSet<TreeNode>> subtrees = new();
    int result = 0;

    DFS(root, subtrees);

    foreach (var kvp in subtrees)
    {
      int value = kvp.Key.val;
      var values = kvp.Value.Select(node => node.val);
      int average = values.Sum() / values.Count();

      if (value == average)
        result++;
    }

    return result;    
  }
}
// TODO: Solution that calculates the sum and count of nodes in each subtree in a single pass
// Time complexity: O(n)
// Space complexity: O(1)
