/*
Given an array of integers nums which is sorted in ascending order, and an integer target, 
write a function to search target in nums. If target exists, then return its index. Otherwise, return -1.

You must write an algorithm with O(log n) runtime complexity.

Example 1:
Input: nums = [-1,0,3,5,9,12], target = 9
Output: 4
Explanation: 9 exists in nums and its index is 4

Example 2:
Input: nums = [-1,0,3,5,9,12], target = 2
Output: -1
Explanation: 2 does not exist in nums so return -1

Constraints:
    1 <= nums.length <= 104
    -104 < nums[i], target < 104
    All the integers in nums are unique.
    nums is sorted in ascending order.
*/
// Time complexity: O(log n)
// Space complexity: O(1)
public class Solution
{
  public int Search(int[] nums, int target)
  {
    int left = 0;
    int right = nums.Length - 1;

    while (left <= right)
    {
      int mid = left + (right - left) / 2;

      if (nums[mid] == target)
        return mid;
      else if (nums[mid] < target)
        left = mid + 1;
      else
        right = mid - 1;
    }

    return -1;
  }
}
/*
The expression int mid = (left + right) / 2;
can lead to an integer overflow when the sum of left and right exceeds the maximum value that an int can hold.

When two large numbers are added together, the result can be larger than the maximum value that can be stored in an int variable. 
In that case, the overflow occurs and the result wraps around to a smaller value, which can lead to unexpected results in your code.

One way to avoid integer overflow when calculating the middle index is to use the following expression instead:

int mid = left + (right - left) / 2;

This is equivalent to (left + right) / 2, but it avoids the overflow by subtracting left from right before the division, 
which guarantees that the result will always be within the range of an int.

Another approach is to use the unchecked keyword or use the Math.DivRem method, 
which will not throw an exception if the result is too large to fit in an int, but returns the correct result.

unchecked
{
    int mid = (left + right) / 2;
}

int mid = Math.DivRem(left + right, 2, out _);

Both of these approaches will prevent integer overflow and ensure that your code produces the expected results.
*/