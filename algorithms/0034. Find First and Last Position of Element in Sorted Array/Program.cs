/*
Given an array of integers nums sorted in non-decreasing order, find the starting and ending position of a given target value.

If target is not found in the array, return [-1, -1].

You must write an algorithm with O(log n) runtime complexity.

Example 1:

Input: nums = [5,7,7,8,8,10], target = 8
Output: [3,4]

Example 2:

Input: nums = [5,7,7,8,8,10], target = 6
Output: [-1,-1]

Example 3:

Input: nums = [], target = 0
Output: [-1,-1]

Constraints:

    0 <= nums.length <= 105
    -109 <= nums[i] <= 109
    nums is a non-decreasing array.
    -109 <= target <= 109
*/
// 
// Time complexity: O(log n)
// Space complexity: O(1)
public class Solution 
{
  public int[] SearchRange(int[] nums, int target) 
  {
    int[] result = new int[] { -1, -1 };
    int left = 0;
    int right = nums.Length - 1;

    // lower bound
    while (left <= right)
    {
      int mid = left + (right - left) / 2;

      if (nums[mid] == target)
        result[0] = mid;

      if (nums[mid] < target)
        left = mid + 1;
      else
        right = mid - 1;
    }
    
    right = nums.Length - 1;

    // upper bound
    while (left <= right)
    {
      int mid = left + (right - left) / 2;

      if (nums[mid] == target)
        result[1] = mid;

      if (nums[mid] <= target)
        left = mid + 1;
      else
        right = mid - 1;
    }

    return result;
  }
}
// First solution
// Time complexity: O(n)
// Space complexity: O(1)
public class Solution 
{
  public int[] SearchRange(int[] nums, int target) 
  {
    int[] result = new int[] { -1, -1 };
    int left = 0;
    int right = nums.Length;

    // inefficent 
    while (left < right)
    {
      int mid = left + (right - left) / 2;

      if (nums[mid] == target)
        result[0] = mid;

      if (nums[mid] < target)
        left++;
      else
        right = mid;
    }

    // should probably binary search upper bounds
    for (int i = right; i < nums.Length; i++)
    {
      if (nums[i] == target)
        result[1] = i;
      else
        break;
    }

    return result;
  }
}