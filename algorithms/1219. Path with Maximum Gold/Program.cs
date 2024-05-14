/*
In a gold mine grid of size m x n, each cell in this mine has an integer representing the amount of gold in that cell, 0 if it is empty.

Return the maximum amount of gold you can collect under the conditions:

    Every time you are located in a cell you will collect all the gold in that cell.
    From your position, you can walk one step to the left, right, up, or down.
    You can't visit the same cell more than once.
    Never visit a cell with 0 gold.
    You can start and stop collecting gold from any position in the grid that has some gold.

Example 1:

Input: grid = [[0,6,0],[5,8,7],[0,9,0]]
Output: 24
Explanation:
[[0,6,0],
 [5,8,7],
 [0,9,0]]
Path to get the maximum gold, 9 -> 8 -> 7.

Example 2:

Input: grid = [[1,0,7],[2,0,6],[3,4,5],[0,3,0],[9,0,20]]
Output: 28
Explanation:
[[1,0,7],
 [2,0,6],
 [3,4,5],
 [0,3,0],
 [9,0,20]]
Path to get the maximum gold, 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7.

Constraints:

    m == grid.length
    n == grid[i].length
    1 <= m, n <= 15
    0 <= grid[i][j] <= 100
    There are at most 25 cells containing gold.
*/
// Time complexity: O(4^(m * n))
// Space complexity: O(m * n)
public class Solution 
{
  private int maxGold;
  private int m, n;

  private void DFS(int[][] grid, int x, int y, int collectedGold)
  {
    if (x < 0 || x >= m || y < 0 || y >= n || grid[x][y] == 0)
    {
      return;
    }

    int cellGold = grid[x][y];
    
    grid[x][y] = 0;
    collectedGold += cellGold;
    maxGold = Math.Max(maxGold, collectedGold);

    DFS(grid, x - 1, y, collectedGold);
    DFS(grid, x + 1, y, collectedGold);
    DFS(grid, x, y - 1, collectedGold);
    DFS(grid, x, y + 1, collectedGold);

    grid[x][y] = cellGold;
  }

  public int GetMaximumGold(int[][] grid) 
  {
    maxGold = 0;
    m = grid.Length;
    n = grid[0].Length;

    for (int x = 0; x < m; x++)
    {
      for (int y = 0; y < n; y++)
      {
        DFS(grid, x, y, 0);
      }
    }

    return maxGold;   
  }
}