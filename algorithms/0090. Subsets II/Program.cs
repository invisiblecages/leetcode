/*
Given an integer array nums that may contain duplicates, return all possible subsets(the power set).

The solution set must not contain duplicate subsets. Return the solution in any order.

Example 1:

Input: nums = [1,2,2]
Output: [[],[1],[1,2],[1,2,2],[2],[2,2]]

Example 2:

Input: nums = [0]
Output: [[],[0]]

Constraints:

    1 <= nums.length <= 10
    -10 <= nums[i] <= 10
*/
// Time complexity: O(n * 2^n)
// Space complexity: O(n * 2^n)
public class Solution 
{
  public IList<IList<int>> SubsetsWithDup(int[] nums) 
  {
    List<IList<int>> subsets = [[]];
    int count = 0;

    Array.Sort(nums);

    for (int i = 0; i < nums.Length; i++)
    {
      int index = (i > 0 && nums[i - 1] == nums[i]) ? count : 0;
      count = subsets.Count;

      for (int j = index; j < count; j++)
      {
        List<int> subset = [..subsets[j]];

        subset.Add(nums[i]);
        subsets.Add(subset);
      }
    }

    return subsets;
  }
}