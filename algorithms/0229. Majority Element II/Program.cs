/*
Given an integer array of size n, find all elements that appear more than ⌊ n/3 ⌋ times.

Example 1:

Input: nums = [3,2,3]
Output: [3]

Example 2:

Input: nums = [1]
Output: [1]

Example 3:

Input: nums = [1,2]
Output: [1,2]

Constraints:

    1 <= nums.length <= 5 * 104
    -109 <= nums[i] <= 109

Follow up: Could you solve the problem in linear time and in O(1) space?
*/
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution 
{
  public IList<int> MajorityElement(int[] nums) 
  {
    Dictionary<int, int> freq = new();
    int n = nums.Length;

    foreach (int num in nums)
    {
      if (freq.ContainsKey(num))
        freq[num]++;
      else
        freq[num] = 1;  
    }

    return freq.Where(x => x.Value > n / 3)
                .Select(x => x.Key)
                .ToList();
  }
}
// Follow up
// Time complexity: O(?)
// Space complexity: O(1)
