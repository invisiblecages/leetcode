/*
Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.

Example 1:
Input: nums = [1,2,3,1]
Output: true

Example 2:
Input: nums = [1,2,3,4]
Output: false

Example 3:
Input: nums = [1,1,1,3,3,4,3,2,4,2]
Output: true

Constraints:
    1 <= nums.length <= 105
    -109 <= nums[i] <= 109
*/
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution
{
  public bool ContainsDuplicate(int[] nums) => nums.Length > nums.Distinct().Count();
}
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution
{
  public bool ContainsDuplicate(int[] nums) 
  {
    Dictionary<int, int> dict = new();

    foreach (int num in nums)
    {
      if (dict.ContainsKey(num))
        return true;
      else
        dict[num] = 1;
    }

    return false;
  }
}