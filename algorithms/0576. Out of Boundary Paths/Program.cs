/*
There is an m x n grid with a ball. The ball is initially at the position [startRow, startColumn]. 
You are allowed to move the ball to one of the four adjacent cells in the grid (possibly out of the grid crossing the grid boundary). 
You can apply at most maxMove moves to the ball.

Given the five integers m, n, maxMove, startRow, startColumn, return the number of paths to move the ball out of the grid boundary. 
Since the answer can be very large, return it modulo 109 + 7.

Example 1:

Input: m = 2, n = 2, maxMove = 2, startRow = 0, startColumn = 0
Output: 6

Example 2:

Input: m = 1, n = 3, maxMove = 3, startRow = 0, startColumn = 1
Output: 12

Constraints:

    1 <= m, n <= 50
    0 <= maxMove <= 50
    0 <= startRow < m
    0 <= startColumn < n
*/
// Time complexity: O(m * n * maxMove)
// Space complexity: O(m * n * maxMove)
public class Solution 
{
  private readonly Dictionary<(int, int, int), int> cache = [];
  private const int MOD = (int)1e9 + 7;

  private int FindBounds(int m, int n, int moves, int x, int y)
  {
    if (moves < 0)
    {
      return 0;
    }

    if (x < 0 || x > m - 1 || y < 0 || y > n - 1)
    {
      return 1;
    }

    if (cache.ContainsKey((x, y, moves)))
    {
      return cache[(x, y, moves)];
    }

    int up = FindBounds(m, n, moves - 1, x - 1, y);
    int down = FindBounds(m, n, moves - 1, x + 1, y);
    int left = FindBounds(m, n, moves - 1, x, y - 1);
    int right = FindBounds(m, n, moves - 1, x, y + 1);

    cache[(x, y, moves)] = ((up + down) % MOD + (right + left) % MOD) % MOD;

    return cache[(x, y, moves)];
  }

  public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn) 
  {
    return FindBounds(m, n, maxMove, startRow, startColumn);
  }
}