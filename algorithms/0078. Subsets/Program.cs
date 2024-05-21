/*
Given an integer array nums of unique elements, return all possible subsets (the power set).

The solution set must not contain duplicate subsets. Return the solution in any order.

Example 1:

Input: nums = [1,2,3]
Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]

Example 2:

Input: nums = [0]
Output: [[],[0]]

Constraints:

    1 <= nums.length <= 10
    -10 <= nums[i] <= 10
    All the numbers of nums are unique.
*/
// 2^n subsets and each subset has n elements
// Time complexity: O(n * 2^n)
// Space complexity: O(n * 2^n)
public class Solution 
{
  public IList<IList<int>> Subsets(int[] nums) 
  {
    List<IList<int>> subsets = [];
    subsets.Add([]);

    for (int i = 0; i < nums.Length; i++)
    {
      int count = subsets.Count;

      for (int j = 0; j < count; j++)
      {
        List<int> subset = [..subsets[j]];

        subset.Add(nums[i]);
        subsets.Add(subset);
      }
    }

    return subsets;
  }
}