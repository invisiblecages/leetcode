/*
Given the root of a binary search tree (BST) with duplicates, 
return all the mode(s) (i.e., the most frequently occurred element) in it.

If the tree has more than one mode, return them in any order.

Assume a BST is defined as follows:

    The left subtree of a node contains only nodes with keys less than or equal to the node's key.
    The right subtree of a node contains only nodes with keys greater than or equal to the node's key.
    Both the left and right subtrees must also be binary search trees.

Example 1:

Input: root = [1,null,2,2]
Output: [2]

Example 2:

Input: root = [0]
Output: [0]

Constraints:

    The number of nodes in the tree is in the range [1, 104].
    -105 <= Node.val <= 105

Follow up: 
Could you do that without using any extra space? (Assume that the implicit stack space incurred due to recursion does not count).
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
  private void DFS(TreeNode node, Dictionary<int, int> freq)
  {
    if (node is null)
      return;

    int element = node.val;

    if (freq.ContainsKey(element))
      freq[element]++;
    else
      freq[element] = 1;

    DFS(node.left, freq);
    DFS(node.right, freq);
  }

  public int[] FindMode(TreeNode root) 
  {
    Dictionary<int, int> freq = new();

    DFS(root, freq);

    int maxFreq = freq.Values.Max();
    int[] nodes = freq.Where(x => x.Value == maxFreq)
                      .Select(x => x.Key)
                      .ToArray();

    return nodes;
  }
}
// Follow up
// Time complexity: O(n)
// Space complexity: O(1)
