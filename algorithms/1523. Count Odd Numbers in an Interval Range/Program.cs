/*
Given two non-negative integers low and high. Return the count of odd numbers between low and high (inclusive).

Example 1:
Input: low = 3, high = 7
Output: 3
Explanation: The odd numbers between 3 and 7 are [3,5,7].

Example 2:
Input: low = 8, high = 10
Output: 1
Explanation: The odd numbers between 8 and 10 are [9].

Constraints:
    0 <= low <= high <= 10^9
*/
// First solution
// Time complexity: O(n)
// Space complexity: O(1)
public class Solution
{
  public int CountOdds(int low, int high)
  {
    int odd = 0;
    for (int i = low; i <= high; i++)
      if (i % 2 != 0)
        odd++;

    return odd;    
  }
}
// Constant time formula
// Time complexity: O(1)
// Space complexity: O(1)
public class Solution
{
  public int CountOdds(int low, int high) => (high + 1) / 2 - low / 2;
}
// The difference between these two numbers is the count of even numbers between low rounded down and high rounded up, 
// which is equal to the count of odd numbers between low and high (inclusive).