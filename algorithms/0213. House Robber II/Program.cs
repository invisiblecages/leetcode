﻿/*
You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed. 
All houses at this place are arranged in a circle. That means the first house is the neighbor of the last one. 
Meanwhile, adjacent houses have a security system connected, 
and it will automatically contact the police if two adjacent houses were broken into on the same night.

Given an integer array nums representing the amount of money of each house, 
return the maximum amount of money you can rob tonight without alerting the police.

Example 1:

Input: nums = [2,3,2]
Output: 3
Explanation: You cannot rob house 1 (money = 2) and then rob house 3 (money = 2), because they are adjacent houses.

Example 2:

Input: nums = [1,2,3,1]
Output: 4
Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
Total amount you can rob = 1 + 3 = 4.

Example 3:

Input: nums = [1,2,3]
Output: 3

Constraints:

    1 <= nums.length <= 100
    0 <= nums[i] <= 1000
*/
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution
{
  private int GetMaxMoney(int[] nums, int i, int n, Dictionary<int, int> cache)
  {
    if (i > n)
    {
      return 0;
    }

    if (cache.ContainsKey(i))
    {
      return cache[i];
    }

    int robHouse = nums[i] + GetMaxMoney(nums, i + 2, n, cache);
    int skipHouse = GetMaxMoney(nums, i + 1, n, cache);

    cache[i] = Math.Max(robHouse, skipHouse);

    return cache[i];
  }

  public int Rob(int[] nums)
  {
    int n = nums.Length;
    
    if (n == 1)
    {
      return nums[0];
    }
    
    int skipLastHouse = GetMaxMoney(nums, 0, n - 2, []);
    int skipFirstHouse = GetMaxMoney(nums, 1, n - 1, []);

    return Math.Max(skipLastHouse, skipFirstHouse);
  }
}