/*
Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.

An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
You may assume all four edges of the grid are all surrounded by water.

Example 1:
Input: grid = [
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
]
Output: 1

Example 2:
Input: grid = [
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
]
Output: 3

Constraints:
    m == grid.length
    n == grid[i].length
    1 <= m, n <= 300
    grid[i][j] is '0' or '1'.
*/
// Recursive
// Time complexity: O(x * y)
// Space complexity: O(x * y)
public class Solution
{
  public int NumIslands(char[][] grid)
  {
    int islands = 0;

    for (int x = 0; x < grid.Length; x++)
      for (int y = 0; y < grid[0].Length; y++)
        if (grid[x][y] == '1')
        {
          DFS(x, y);
          islands++;
        }

    return islands;

    void DFS(int x, int y)
    {
      if (x < 0 || x > grid.Length - 1 || y < 0 || y > grid[0].Length - 1)
        return;
      if (grid[x][y] == '0')
        return;
      
      grid[x][y] = '0';
      DFS(x + 1, y);
      DFS(x - 1, y);
      DFS(x, y + 1);
      DFS(x, y - 1);
    }
  }
}
// Iterative BFS
// Time complexity: O(x * y)
// Space complexity: O(min(x * y))
public class Solution
{
  public int NumIslands(char[][] grid)
  {
    int islands = 0;

    for (int x = 0; x < grid.Length; x++)
      for (int y = 0; y < grid[0].Length; y++)
        if (grid[x][y] == '1')
        {
          BFS(x, y);
          islands++;
        }

    return islands;

    void BFS(int x, int y)
    {
      int[][] directions = 
      {
        new int[] { -1, 0 },
        new int[] { 1, 0 },
        new int[] { 0, -1 },
        new int[] { 0, 1 }
      };

      Queue<(int x, int y)> queue = new();
      queue.Enqueue((x, y));
      grid[x][y] = '0';
      
      while (queue.Count > 0)
      {
        var pos = queue.Dequeue();
        for (int i = 0; i < directions.Length; i++)
        {
          int posX = pos.x + directions[i][0];
          int posY = pos.y + directions[i][1];
          if (posX >= 0 && posX < grid.Length && 
              posY >= 0 && posY < grid[0].Length && grid[posX][posY] == '1')
          {
            grid[posX][posY] = '0';
            queue.Enqueue((posX, posY));
          }
        }
      }
    }
  }
}