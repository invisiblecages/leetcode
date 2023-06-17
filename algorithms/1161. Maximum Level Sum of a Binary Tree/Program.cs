/*
Given the root of a binary tree, the level of its root is 1, the level of its children is 2, and so on.

Return the smallest level x such that the sum of all the values of nodes at level x is maximal.

Example 1:

Input: root = [1,7,0,7,-8,null,null]
Output: 2
Explanation: 
Level 1 sum = 1.
Level 2 sum = 7 + 0 = 7.
Level 3 sum = 7 + -8 = -1.
So we return the level with the maximum sum which is level 2.

Example 2:

Input: root = [989,null,10250,98693,-89388,null,null,null,-32127]
Output: 2

Constraints:

    The number of nodes in the tree is in the range [1, 104].
    -105 <= Node.val <= 105
*/
// Time complexity: O(n)
// Space complexity: O(m)
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
  public int MaxLevelSum(TreeNode root) 
  {
    if (root is null)
      return 0;

    Queue<TreeNode> queue = new();
    queue.Enqueue(root);

    int level = 0;
    int maximumLevelSum = int.MinValue;
    int levelWithMaximalSum = 0;

    while (queue.Count > 0)
    {
      int levelCount = queue.Count;
      int levelSum = 0;

      while (levelCount-- > 0)
      {
        TreeNode node = queue.Dequeue();
        levelSum += node.val;

        if (node.left is not null)
          queue.Enqueue(node.left);

        if (node.right is not null)
          queue.Enqueue(node.right);
      }

      level++;

      if (levelSum > maximumLevelSum)
      {
        maximumLevelSum = levelSum;
        levelWithMaximalSum = level;
      }
    }

    return levelWithMaximalSum;
  }
}