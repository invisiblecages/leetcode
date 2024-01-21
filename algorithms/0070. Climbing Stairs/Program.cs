/*
You are climbing a staircase. It takes n steps to reach the top.

Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

Example 1:
Input: n = 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps

Example 2:
Input: n = 3
Output: 3
Explanation: There are three ways to climb to the top.
1. 1 step + 1 step + 1 step
2. 1 step + 2 steps
3. 2 steps + 1 step

Constraints:
    1 <= n <= 45
*/
// Dynamic programming (Bottom-up) with memoization
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution
{
  public int ClimbStairs(int n)
  {
    int[] cache = new int[n + 1];
    cache[0] = 1;
    cache[1] = 1;
    
    for (int i = 2; i <= n; i++)
      cache[i] = cache[i - 1] + cache[i - 2];

    return cache[n];
  }
}
// Top-down approach
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution
{
  private int Climb(int n, Dictionary<int, int> cache)
  {
    if (n <= 1)
    {
      return 1;
    }

    if (!cache.ContainsKey(n))
    {
      cache[n] = Climb(n - 1, cache) + Climb(n - 2, cache);
    }

    return cache[n];
  }

  public int ClimbStairs(int n)
  {
    return Climb(n, []);
  }
}