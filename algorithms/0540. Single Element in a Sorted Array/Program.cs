/*
You are given a sorted array consisting of only integers where every element appears exactly twice, 
except for one element which appears exactly once.

Return the single element that appears only once.

Your solution must run in O(log n) time and O(1) space.

Example 1:
Input: nums = [1,1,2,3,3,4,4,8,8]
Output: 2

Example 2:
Input: nums = [3,3,7,7,10,11,11]
Output: 10

Constraints:
    1 <= nums.length <= 105
    0 <= nums[i] <= 105
*/
// First solution
// Time complexity: O(log n)
// Space complexity: O(1)
public class Solution 
{
  public int SingleNonDuplicate(int[] nums) 
  {
    if (nums.Length == 1)
      return nums[0];

    int left = 0;
    int right = nums.Length - 1;
    int mid = left + (right - left) / 2;

    while (left < right)
    {
      mid = left + (right - left) / 2;

      if (nums[left] != nums[left + 1])
        return nums[left];
      
      if (nums[right] != nums[right - 1])
        return nums[right];

      left += 2;
      right -=2;
    }

    return mid;
  }
}