/*
You are given an m x n binary matrix grid, where 0 represents a sea cell and 1 represents a land cell.

A move consists of walking from one land cell to another adjacent (4-directionally) land cell or walking off the boundary of the grid.

Return the number of land cells in grid for which we cannot walk off the boundary of the grid in any number of moves.


Example 1:

Input: grid = [[0,0,0,0],[1,0,1,0],[0,1,1,0],[0,0,0,0]]
Output: 3
Explanation: There are three 1s that are enclosed by 0s, and one 1 that is not enclosed because its on the boundary.

Example 2:

Input: grid = [[0,1,1,0],[0,0,1,0],[0,0,1,0],[0,0,0,0]]
Output: 0
Explanation: All 1s are either on the boundary or can reach the boundary.


Constraints:

    m == grid.length
    n == grid[i].length
    1 <= m, n <= 500
    grid[i][j] is either 0 or 1.
*/
// Time complexity: O(n * m)
// Space complexity: O(n * m)
public class Solution 
{
  public int NumEnclaves(int[][] grid) 
  {
    int landCells = 0;
    int rows = grid.Length;
    int cols = grid[0].Length;

    // DFS left and right boundaries of the grid
    for (int i = 0; i < rows; i++)
    { 
      DFS(i, 0, grid);
      DFS(i, cols - 1, grid);
    }

    // DFS top and bottom boundaries of the grid
    for (int i = 0; i < cols; i++)
    { 
      DFS(0, i, grid);
      DFS(rows - 1, i, grid);
    }

    // Count land cells not connected to the boundary of the grid
    for (int i = 0; i < rows; i++)
      for (int j = 0; j < cols; j++)
        if (grid[i][j] == 1)
          landCells++;

    return landCells;
  }
  
  // Marks all connected land cells as sea cells
  public void DFS(int row, int col, int[][] grid)
  {
    if (row < 0 || row > grid.Length - 1 || col < 0 || col > grid[0].Length - 1 || grid[row][col] == 0)
      return;
    
    grid[row][col] = 0;

    DFS(row + 1, col, grid);
    DFS(row - 1, col, grid);
    DFS(row, col + 1, grid);
    DFS(row, col - 1, grid);
  }
}