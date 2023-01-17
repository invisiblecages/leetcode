/*
You are given an integer array cost where cost[i] is the cost of ith step on a staircase. 
Once you pay the cost, you can either climb one or two steps.

You can either start from the step with index 0, or the step with index 1.

Return the minimum cost to reach the top of the floor.

Example 1:
Input: cost = [10,15,20]
Output: 15
Explanation: You will start at index 1.
- Pay 15 and climb two steps to reach the top.
The total cost is 15.

Example 2:
Input: cost = [1,100,1,1,1,100,1,1,100,1]
Output: 6
Explanation: You will start at index 0.
- Pay 1 and climb two steps to reach index 2.
- Pay 1 and climb two steps to reach index 4.
- Pay 1 and climb two steps to reach index 6.
- Pay 1 and climb one step to reach index 7.
- Pay 1 and climb two steps to reach index 9.
- Pay 1 and climb one step to reach the top.
The total cost is 6.

Constraints:
    2 <= cost.length <= 1000
    0 <= cost[i] <= 999
*/
// Top-down
// Time complexity: O(n)
// Space complexity: O(1)
public class Solution
{
  public int MinCostClimbingStairs(int[] cost)
  { 
    for (int i = 2; i < cost.Length; i++)
      cost[i] += Math.Min(cost[i - 1], cost[i - 2]);

    return Math.Min(cost[cost.Length - 1], cost[cost.Length - 2]);
  }
}
// Bottom-up
// Time complexity: O(n)
// Space complexity: O(1)
public class Solution
{
  public int MinCostClimbingStairs(int[] cost)
  {
    for (int i = cost.Length - 3; i >= 0; i--)
      cost[i] = Math.Min(cost[i] + cost[i + 1], cost[i] + cost[i + 2]);
      
    return Math.Min(cost[0], cost[1]);
  }
}
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution
{
  public int MinCostClimbingStairs(int[] cost)
  {
    int[] cache = new int[cost.Length + 1];
    cache[0] = cost[0];
    cache[1] = cost[1];
    
    for (int i = 2; i < cost.Length; i++)
      cache[i] = Math.Min(cost[i] + cache[i - 1], cost[i] + cache[i - 2]);

    return Math.Min(cache[cost.Length - 1], cache[cost.Length - 2]);
  }
}