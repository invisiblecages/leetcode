/*
You are given a 2D integer array descriptions where descriptions[i] = [parenti, childi, isLefti] indicates that parenti is the parent of childi in a binary tree of unique values. 
Furthermore,

    If isLefti == 1, then childi is the left child of parenti.
    If isLefti == 0, then childi is the right child of parenti.

Construct the binary tree described by descriptions and return its root.

The test cases will be generated such that the binary tree is valid.

Example 1:

Input: descriptions = [[20,15,1],[20,17,0],[50,20,1],[50,80,0],[80,19,1]]
Output: [50,20,80,15,17,19]
Explanation: The root node is the node with value 50 since it has no parent.
The resulting binary tree is shown in the diagram.

Example 2:

Input: descriptions = [[1,2,1],[2,3,0],[3,4,1]]
Output: [1,2,null,null,3,4]
Explanation: The root node is the node with value 1 since it has no parent.
The resulting binary tree is shown in the diagram.

Constraints:

    1 <= descriptions.length <= 10^4
    descriptions[i].length == 3
    1 <= parenti, childi <= 10^5
    0 <= isLefti <= 1
    The binary tree described by descriptions is valid.
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
  public TreeNode CreateBinaryTree(int[][] descriptions) 
  {
    Dictionary<int, (TreeNode node, bool isChild)> nodes = [];

    for (int i = 0; i < descriptions.Length; i++)
    {
      int parent = descriptions[i][0];
      int child = descriptions[i][1];
      bool isLeft = Convert.ToBoolean(descriptions[i][2]);

      if (!nodes.ContainsKey(parent))
      {
        nodes[parent] = (new TreeNode(parent), false);
      }

      if (!nodes.ContainsKey(child))
      {
        nodes[child] = (new TreeNode(child), true);
      }
      else
      {
        nodes[child] = (nodes[child].node, true);
      }

      if (isLeft)
      {
        nodes[parent].node.left = nodes[child].node;
      }
      else
      {
        nodes[parent].node.right = nodes[child].node;
      }
    }

    foreach (var kvp in nodes)
    {
      if (!kvp.Value.isChild)
      {
        return kvp.Value.node;
      }
    }

    return new TreeNode();
  }
}