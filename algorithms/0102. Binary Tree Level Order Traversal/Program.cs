/*
Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).

Example 1:
Input: root = [3,9,20,null,null,15,7]
Output: [[3],[9,20],[15,7]]

Example 2:
Input: root = [1]
Output: [[1]]

Example 3:
Input: root = []
Output: []

Constraints:
    The number of nodes in the tree is in the range [0, 2000].
    -1000 <= Node.val <= 1000
*/
// Iterative BFS
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
  public IList<IList<int>> LevelOrder(TreeNode root)
  {
    List<IList<int>> nodes = new();
    if (root == null)
      return nodes;

    Queue<TreeNode> queue = new();
    queue.Enqueue(root);

    while (queue.Count > 0)
    {
      List<int> level = new();
      int levelCount = queue.Count;

      for (int i = 0; i < levelCount; i++)
      {
        var node = queue.Dequeue();
        level.Add(node.val);

        if (node.left != null)
          queue.Enqueue(node.left);

        if (node.right != null)
          queue.Enqueue(node.right);
      }

      nodes.Add(level);
    }
 
    return nodes;
  }
}
// Recursive DFS
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution
{
  public IList<IList<int>> LevelOrder(TreeNode root)
  {
    List<IList<int>> nodes = new();
    DFS(root, 0, nodes);
    return nodes;

    void DFS(TreeNode root, int level, List<IList<int>> nodes)
    {
      if (root == null)
        return;
      
      if (level > nodes.Count - 1)
        nodes.Add(new List<int>());

      nodes[level].Add(root.val);
      DFS(root.left, level + 1, nodes);
      DFS(root.right, level + 1, nodes);
    }
  }
}