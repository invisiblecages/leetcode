/*
Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.

You must write an algorithm that runs in O(n) time.

Example 1:

Input: nums = [100,4,200,1,3,2]
Output: 4
Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.

Example 2:

Input: nums = [0,3,7,2,5,8,4,6,0,1]
Output: 9

Constraints:

    0 <= nums.length <= 105
    -109 <= nums[i] <= 109
*/
// First solution
// Time complexity: O(n * log n)
// Space complexity: O(1)
public class Solution
{
  public int LongestConsecutive(int[] nums)
  {
    if (nums.Length == 0)
      return 0;

    int count = 1;
    int res = 1;
    Array.Sort(nums);

    for (int i = 1; i < nums.Length; i++)
    {
      int num = nums[i];
      
      if (nums[i - 1] == num - 1)
        count++;
      else if (nums[i - 1] == num)
        continue;
      else
        count = 1;

      res = Math.Max(count, res);
    }

    return res;
  }
}
// Faster solution
// Time complexity: O(n)
// Space complexity: O(1)
public class Solution
{
  public int LongestConsecutive(int[] nums)
  {
    HashSet<int> set = new(nums);
    int res = 0;

    foreach (int num in set)
    {
      if (!set.Contains(num - 1))
      {
        int count = 1;

        while (set.Contains(num + count))
          count++;

        res = Math.Max(res, count);
      }
    }
    
    return res;
  }
}