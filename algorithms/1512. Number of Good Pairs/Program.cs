﻿/*
Given an array of integers nums, return the number of good pairs.

A pair (i, j) is called good if nums[i] == nums[j] and i < j.

Example 1:

Input: nums = [1,2,3,1,1,3]
Output: 4
Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.

Example 2:

Input: nums = [1,1,1,1]
Output: 6
Explanation: Each pair in the array are good.

Example 3:

Input: nums = [1,2,3]
Output: 0

Constraints:

    1 <= nums.length <= 100
    1 <= nums[i] <= 100
*/
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution 
{
  public int NumIdenticalPairs(int[] nums) 
  {
    Dictionary<int, int> count = new();
    int pairs = 0;

    foreach (int num in nums)
    {
      if (count.ContainsKey(num))
        pairs += count[num]++;
      else
        count[num] = 1;
    }

    return pairs;    
  }
}
// Time complexity: O(n^2)
// Space complexity: O(1)
public class Solution 
{
  public int NumIdenticalPairs(int[] nums) 
  {
    int pairs = 0;

    for (int i = 0; i < nums.Length; i++)
    {
      for (int j = i + 1; j < nums.Length; j++)
      {
        if (nums[i] == nums[j])
          pairs++;
      }
    }

    return pairs;    
  }
}