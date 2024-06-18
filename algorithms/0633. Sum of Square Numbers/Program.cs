/*
Given a non-negative integer c, decide whether there're two integers a and b such that a^2 + b^2 = c.

Example 1:

Input: c = 5
Output: true
Explanation: 1 * 1 + 2 * 2 = 5

Example 2:

Input: c = 3
Output: false

Constraints:

    0 <= c <= 2^31 - 1
*/
// Time complexity: O(sqrt(c))
// Space complexity: O(1)
public class Solution 
{
  public bool JudgeSquareSum(int c) 
  {
    long left = 0;
    long right = (long)Math.Sqrt(c);

    while (left <= right)
    {
      long sum = left * left + right * right;

      if (sum == c)
      {
        return true;
      }
      else if (sum < c)
      {
        left++;
      }
      else
      {
        right--;
      }
    }

    return false;
  }
}