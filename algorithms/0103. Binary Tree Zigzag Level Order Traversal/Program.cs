/*
Given the root of a binary tree, return the zigzag level order traversal of its nodes' values. 
(i.e., from left to right, then right to left for the next level and alternate between).

Example 1:
Input: root = [3,9,20,null,null,15,7]
Output: [[3],[20,9],[15,7]]

Example 2:
Input: root = [1]
Output: [[1]]

Example 3:
Input: root = []
Output: []

Constraints:
    The number of nodes in the tree is in the range [0, 2000].
    -100 <= Node.val <= 100
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
  public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
  {
    List<IList<int>> res = new();
    if (root == null)
      return res;

    Queue<TreeNode> queue = new();
    queue.Enqueue(root);
    bool zigzag = false;

    while (queue.Count > 0)
    {
      List<int> nodes = new();
      Stack<int> stack = new();
      int levelCount = queue.Count;

      for (int i = 0; i < levelCount; i++)
      {
        TreeNode node = queue.Dequeue();

        if (zigzag)
          stack.Push(node.val);
        else
          nodes.Add(node.val);
          
        if (node.left != null)
          queue.Enqueue(node.left);
        if (node.right != null)
          queue.Enqueue(node.right);
      }

      while (stack.Count > 0)
        nodes.Add(stack.Pop());
      
      zigzag = !zigzag;
      res.Add(nodes);
    }

    return res;
  }
}