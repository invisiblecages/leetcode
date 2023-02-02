/*
Given an array nums of n integers where nums[i] is in the range [1, n], 
return an array of all the integers in the range [1, n] that do not appear in nums.

Example 1:
Input: nums = [4,3,2,7,8,2,3,1]
Output: [5,6]

Example 2:
Input: nums = [1,1]
Output: [2]

Constraints:
    n == nums.length
    1 <= n <= 105
    1 <= nums[i] <= n
 
Follow up: Could you do it without extra space and in O(n) runtime? You may assume the returned list does not count as extra space.
*/
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution
{
  public IList<int> FindDisappearedNumbers(int[] nums)
  {
    Dictionary<int, int> dict = new();
    List<int> res = new();

    foreach (int num in nums)
      if (!dict.ContainsKey(num))
        dict[num] = 1;

    for (int i = 1; i <= nums.Length; i++)
      if (!dict.ContainsKey(i))
        res.Add(i);

    return res;  
  }
}
// Follow up
// Time complexity: O(n)
// Space complexity: O(1)
public class Solution
{
  public IList<int> FindDisappearedNumbers(int[] nums)
  {
    List<int> res = new();
    for (int i = 0; i < nums.Length; i++)
    {
      int index = Math.Abs(nums[i]) - 1;
      if (nums[index] > 0)
        nums[index] = -nums[index];
    }
    
    for (int i = 0; i < nums.Length; i++)
      if (nums[i] > 0)
        res.Add(i + 1);

    return res;  
  }
}