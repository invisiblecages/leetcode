/*
Given an integer array nums of length n where all the integers of nums are in the range [1, n] and each integer appears once or twice, 
return an array of all the integers that appears twice.

You must write an algorithm that runs in O(n) time and uses only constant extra space.

Example 1:

Input: nums = [4,3,2,7,8,2,3,1]
Output: [2,3]

Example 2:

Input: nums = [1,1,2]
Output: [1]

Example 3:

Input: nums = [1]
Output: []

Constraints:

    n == nums.length
    1 <= n <= 10^5
    1 <= nums[i] <= n
    Each element in nums appears once or twice.
*/
// Time complexity: O(n)
// Space complexity: O(1)
public class Solution 
{
  public IList<int> FindDuplicates(int[] nums) 
  {
    List<int> dupes = [];

    for (int i = 0; i < nums.Length; i++)
    {
      int num = Math.Abs(nums[i]);

      if (nums[num - 1] < 0)
      {
        dupes.Add(num);
      } 
      else
      {
        nums[num - 1] *= -1;
      }
    }

    return dupes;
  }
}