/*
You are given row x col grid representing a map where grid[i][j] = 1 represents land and grid[i][j] = 0 represents water.

Grid cells are connected horizontally/vertically (not diagonally). 
The grid is completely surrounded by water, and there is exactly one island (i.e., one or more connected land cells).

The island doesn't have "lakes", meaning the water inside isn't connected to the water around the island. 
One cell is a square with side length 1. The grid is rectangular, width and height don't exceed 100. Determine the perimeter of the island.

Example 1:

Input: grid = [[0,1,0,0],[1,1,1,0],[0,1,0,0],[1,1,0,0]]
Output: 16
Explanation: The perimeter is the 16 yellow stripes in the image above.

Example 2:

Input: grid = [[1]]
Output: 4

Example 3:

Input: grid = [[1,0]]
Output: 4

Constraints:

    row == grid.length
    col == grid[i].length
    1 <= row, col <= 100
    grid[i][j] is 0 or 1.
    There is exactly one island in grid.
*/
// Time complexity: O(m * n)
// Space complexity: O(1)
public class Solution 
{
  public static readonly List<(int dx, int dy)> Directions =
  [
    (-1, 0),
    (1, 0),
    (0, -1),
    (0, 1)
  ];

  public int IslandPerimeter(int[][] grid) 
  {
    int perimeter = 0;

    for (int i = 0; i < grid.Length; i++)
    {
      for (int j = 0; j < grid[i].Length; j++)
      {
        if (grid[i][j] == 1)
        {
          foreach (var (dx, dy) in Directions)
          {
            int x = i + dx;
            int y = j + dy;

            if (x < 0 || x >= grid.Length || y < 0 || y >= grid[i].Length || grid[x][y] == 0)
            {
              perimeter++;
            }
          }
        }
      }
    } 

    return perimeter;
  }
}