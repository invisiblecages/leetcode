/*
Given an array nums of size n, return the majority element.

The majority element is the element that appears more than ⌊n / 2⌋ times. 
You may assume that the majority element always exists in the array.

Example 1:
Input: nums = [3,2,3]
Output: 3

Example 2:
Input: nums = [2,2,1,1,1,2,2]
Output: 2

Constraints:
    n == nums.length
    1 <= n <= 5 * 104
    -109 <= nums[i] <= 109
Follow-up: Could you solve the problem in linear time and in O(1) space?
*/
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution
{
  public int MajorityElement(int[] nums)
  {
    Dictionary<int, int> dict = new();
    foreach (int num in nums)
      if (dict.ContainsKey(num))
        dict[num]++;
      else
        dict[num] = 1;
        
    return dict.FirstOrDefault(x => x.Value == dict.Values.Max()).Key;
  }
}
// Follow-up
// Time complexity: O(n)
// Space complexity: O(1)
