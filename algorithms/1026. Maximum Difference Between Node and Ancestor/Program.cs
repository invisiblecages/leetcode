/*
Given the root of a binary tree, 
find the maximum value v for which there exist different nodes a and b where v = |a.val - b.val| and a is an ancestor of b.

A node a is an ancestor of b if either: any child of a is equal to b or any child of a is an ancestor of b.

Example 1:

Input: root = [8,3,10,1,6,null,14,null,null,4,7,13]
Output: 7
Explanation: We have various ancestor-node differences, some of which are given below :
|8 - 3| = 5
|3 - 7| = 4
|8 - 1| = 7
|10 - 13| = 3
Among all possible differences, the maximum value of 7 is obtained by |8 - 1| = 7.

Example 2:

Input: root = [1,null,2,null,0,3]
Output: 3

Constraints:

    The number of nodes in the tree is in the range [2, 5000].
    0 <= Node.val <= 10^5
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
  public int MaxAncestorDiff(TreeNode root) 
  {
    Dictionary<int, List<int>> ancestors = [];
    Stack<TreeNode> stack = [];
    int maxDiff = 0;

    stack.Push(root);
    ancestors[root.val] = [];

    while (stack.Count > 0)
    {
      TreeNode node = stack.Pop();
      List<int> nodeAncestors = ancestors[node.val];

      if (node.left is not null)
      {
        stack.Push(node.left);
        ancestors[node.left.val] = [node.val, ..nodeAncestors];
      }

      if (node.right is not null)
      {
        stack.Push(node.right);
        ancestors[node.right.val] = [node.val, ..nodeAncestors];
      }
    }

    foreach (var kvp in ancestors.Skip(1))
    {
      int min = kvp.Value.Min();
      int max = kvp.Value.Max();
      int diff = Math.Max(Math.Abs(kvp.Key - min), Math.Abs(kvp.Key - max));
      maxDiff = Math.Max(maxDiff, diff);
    }

    return maxDiff;
  }
}