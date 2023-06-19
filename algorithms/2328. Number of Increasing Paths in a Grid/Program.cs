/*
You are given an m x n integer matrix grid, where you can move from a cell to any adjacent cell in all 4 directions.

Return the number of strictly increasing paths in the grid such that you can start from any cell and end at any cell. 
Since the answer may be very large, return it modulo 10^9 + 7.

Two paths are considered different if they do not have exactly the same sequence of visited cells.

Example 1:

Input: grid = [[1,1],[3,4]]
Output: 8
Explanation: The strictly increasing paths are:
- Paths with length 1: [1], [1], [3], [4].
- Paths with length 2: [1 -> 3], [1 -> 4], [3 -> 4].
- Paths with length 3: [1 -> 3 -> 4].
The total number of paths is 4 + 3 + 1 = 8.

Example 2:

Input: grid = [[1],[2]]
Output: 3
Explanation: The strictly increasing paths are:
- Paths with length 1: [1], [2].
- Paths with length 2: [1 -> 2].
The total number of paths is 2 + 1 = 3.

Constraints:

    m == grid.length
    n == grid[i].length
    1 <= m, n <= 1000
    1 <= m * n <= 105
    1 <= grid[i][j] <= 105
*/
// Time complexity: O(rows * cols * max path length)
// Space complexity: O(rows * cols)
public class Solution 
{
  private const int MODULO = 1000000007;
  private int[,] cache;

  private int DFS(int[][] grid, int row, int col, int prevValue)
  {
    /* Check grid bounds for the current cell
       Check if the cell value is greater than previous cell */
    if (row < 0 || row >= grid.Length || 
        col < 0 || col >= grid[0].Length || 
        grid[row][col] <= prevValue)
      return 0;

    // Return computed cell from cache
    if (cache[row, col] > 0)
      return cache[row, col];

    // Increasing path from this cell
    cache[row, col] = 1;
    
    // Recursive calls to the cells four neighbors
    cache[row, col] += (
      DFS(grid, row + 1, col, grid[row][col]) +
      DFS(grid, row - 1, col, grid[row][col]) +
      DFS(grid, row, col + 1, grid[row][col]) +
      DFS(grid, row, col - 1, grid[row][col])) % MODULO;

    return cache[row, col];
  }

  public int CountPaths(int[][] grid) 
  {
    int rows = grid.Length;
    int cols = grid[0].Length;
    cache = new int[rows, cols];
    int paths = 0;

    for (int i = 0; i < rows; i++)
      for (int j = 0; j < cols; j++)
        paths = (paths + DFS(grid, i, j, 0)) % MODULO;

    return paths;
  }
}