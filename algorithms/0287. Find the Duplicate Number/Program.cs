/*
Given an array of integers nums containing n + 1 integers where each integer is in the range [1, n] inclusive.

There is only one repeated number in nums, return this repeated number.

You must solve the problem without modifying the array nums and uses only constant extra space.

Example 1:

Input: nums = [1,3,4,2,2]
Output: 2

Example 2:

Input: nums = [3,1,3,4,2]
Output: 3

Constraints:

    1 <= n <= 105
    nums.length == n + 1
    1 <= nums[i] <= n
    All the integers in nums appear only once except for precisely one integer which appears two or more times.

Follow up:

    How can we prove that at least one duplicate number must exist in nums?
    Can you solve the problem in linear runtime complexity?
*/
// Easy solution but violates the problem's constraint of constant extra space
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution 
{
  public int FindDuplicate(int[] nums) 
  {
    Dictionary<int, int> numbers = new();

    for (int i = 0; i < nums.Length; i++)
    {
      if (numbers.ContainsKey(nums[i]))
        return nums[i];

      numbers[nums[i]] = 1;
    }

    return 0;    
  }
}
// Floyd's cycle-finding algorithm / Tortoise and the Hare algorithm
// https://en.wikipedia.org/wiki/Cycle_detection#Floyd's_tortoise_and_hare
// Time complexity: O(n)
// Space complexity: O(1)
