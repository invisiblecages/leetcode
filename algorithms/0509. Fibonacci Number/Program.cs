/*
The Fibonacci numbers, commonly denoted F(n) form a sequence, called the Fibonacci sequence, 
such that each number is the sum of the two preceding ones, starting from 0 and 1. That is,

F(0) = 0, F(1) = 1
F(n) = F(n - 1) + F(n - 2), for n > 1.

Given n, calculate F(n).

Example 1:
Input: n = 2
Output: 1
Explanation: F(2) = F(1) + F(0) = 1 + 0 = 1.

Example 2:
Input: n = 3
Output: 2
Explanation: F(3) = F(2) + F(1) = 1 + 1 = 2.

Example 3:
Input: n = 4
Output: 3
Explanation: F(4) = F(3) + F(2) = 2 + 1 = 3.

Constraints:
    0 <= n <= 30
*/
// Recursion
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution
{
  public int Fib(int n)
  {
    if (n == 0)
      return 0;
    if (n == 1)
      return 1;
    
    return Fib(n - 1) + Fib(n - 2);    
  }
}
// Dynamic programming (Bottom-up) with memoization 
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution
{
  public int Fib(int n)
  {
    if (n <= 0)
      return 0;
    if (n <= 2)
      return 1;

    int[] cache = new int[n + 1];
    cache[0] = 0;
    cache[1] = 1;

    for (int i = 2; i <= n; i++)
      cache[i] = cache[i - 1] + cache[i - 2];
      
    return cache[n];
  }
}