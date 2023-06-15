/*
You are given a sorted unique integer array nums.

A range [a,b] is the set of all integers from a to b (inclusive).

Return the smallest sorted list of ranges that cover all the numbers in the array exactly. 
That is, each element of nums is covered by exactly one of the ranges, 
and there is no integer x such that x is in one of the ranges but not in nums.

Each range [a,b] in the list should be output as:

    "a->b" if a != b
    "a" if a == b

Example 1:

Input: nums = [0,1,2,4,5,7]
Output: ["0->2","4->5","7"]
Explanation: The ranges are:
[0,2] --> "0->2"
[4,5] --> "4->5"
[7,7] --> "7"

Example 2:

Input: nums = [0,2,3,4,6,8,9]
Output: ["0","2->4","6","8->9"]
Explanation: The ranges are:
[0,0] --> "0"
[2,4] --> "2->4"
[6,6] --> "6"
[8,9] --> "8->9"

Constraints:

    0 <= nums.length <= 20
    -231 <= nums[i] <= 231 - 1
    All the values of nums are unique.
    nums is sorted in ascending order.
*/
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution 
{
  private void AddRangeToList(int[] range, List<string> result)
  {
    if (range[0] == range[1])
      result.Add(range[0].ToString());
    else
      result.Add($"{range[0]}->{range[1]}");
  }

  public IList<string> SummaryRanges(int[] nums) 
  {
    List<string> result = new();
    if (nums.Length == 0)
      return result;
      
    if (nums.Length == 1)
      return new List<string> { nums[0].ToString() }; 

    int[] range = new int[2];
    range[0] = nums[0];
    range[1] = nums[0];
    
    for (int i = 1; i < nums.Length; i++)
    {
      if (nums[i] == range[1] + 1)
        range[1] = nums[i];
      else
      {
        AddRangeToList(range, result);
        range[0] = nums[i];
        range[1] = nums[i];
      }
    }

    AddRangeToList(range, result);

    return result;
  }
}