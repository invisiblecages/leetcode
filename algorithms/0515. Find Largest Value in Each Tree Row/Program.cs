/*
Given the root of a binary tree, return an array of the largest value in each row of the tree (0-indexed).

Example 1:

Input: root = [1,3,2,5,3,null,9]
Output: [1,3,9]

Example 2:

Input: root = [1,2,3]
Output: [1,3]

Constraints:

    The number of nodes in the tree will be in the range [0, 104].
    -231 <= Node.val <= 231 - 1
*/
// BFS (Level Order Traversal)
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
  public IList<int> LargestValues(TreeNode root) 
  {
    List<int> result = new();

    if (root is null)
      return result;

    Queue<TreeNode> queue = new();
    queue.Enqueue(root);

    while (queue.Count > 0)
    {
      int level = queue.Count;
      int maxValue = int.MinValue;

      for (int i = 0; i < level; i++)
      {
        var node = queue.Dequeue();
        maxValue = Math.Max(maxValue, node.val);
      
        if (node.left is not null)
          queue.Enqueue(node.left);
      
        if (node.right is not null)
          queue.Enqueue(node.right);
      }

      result.Add(maxValue);
    }
    
    return result; 
  }
}
// DFS (Recursion)
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
  private void DFS(TreeNode node, int level, List<int> result)
  {
    if (node is null)
      return;

    if (result.Count == level)
      result.Add(node.val);
    else
      result[level] = Math.Max(result[level], node.val);
    
    DFS(node.left, level + 1, result);
    DFS(node.right, level + 1, result);
  }

  public IList<int> LargestValues(TreeNode root) 
  {
    List<int> result = new();
    DFS(root, 0, result);
    
    return result; 
  }
}