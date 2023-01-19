/*
There is a robot on an m x n grid. The robot is initially located at the top-left corner (i.e., grid[0][0]). 
The robot tries to move to the bottom-right corner (i.e., grid[m - 1][n - 1]). 
The robot can only move either down or right at any point in time.

Given the two integers m and n, return the number of possible unique paths that the robot can take to reach the bottom-right corner.

The test cases are generated so that the answer will be less than or equal to 2 * 109.

Example 1:
Input: m = 3, n = 7
Output: 28

Example 2:
Input: m = 3, n = 2
Output: 3
Explanation: From the top-left corner, there are a total of 3 ways to reach the bottom-right corner:
1. Right -> Down -> Down
2. Down -> Down -> Right
3. Down -> Right -> Down

Constraints:
    1 <= m, n <= 100
*/
// Recursive dfs using memoization
// Time complexity: O(m * n)
// Space complexity: O(m * n)
public class Solution
{
  public int UniquePaths(int m, int n)
  {
    // declare a 2D array to store the number of unique paths to each cell
    int[,] cache = new int[m, n];
    // initialize the cache array with -1
    for (int x = 0; x < m; x++)
      for (int y = 0; y < n; y++)
        cache[x, y] = -1;
    
    // call the helper method to calculate the unique paths
    return DFS(0, 0);

    int DFS(int x, int y)
    {
      // base case: if we reach the last row and last col we found one unique path
      if (x == m - 1 && y == n - 1)
        return 1;
      // if we exceed the grid boundaries return 0
      if (x >= m || y >= n)
        return 0;
      // check if we already calculated the result for the current cell
      if (cache[x, y] != -1)
        return cache[x, y];
      // calculate the result for the current cell
      cache[x, y] = DFS(x + 1, y) + DFS(x, y + 1);
      return cache[x, y];
    }
  }
}
// Faster solution
// Time complexity: O(m * n)
// Space complexity: O(m * n)
public class Solution
{
  public int UniquePaths(int m, int n)
  {
    int[,] cache = new int[m, n];
    for (int x = 0; x < m; x++)
      for (int y = 0; y < n; y++)
        if (x == 0 || y == 0)
          cache[x, y] = 1;
        else
          cache[x, y] = cache[x - 1, y] + cache[x, y - 1];
         
    return cache[m - 1, n - 1];
  }
}