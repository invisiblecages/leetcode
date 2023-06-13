/*
Given a m x n matrix grid which is sorted in non-increasing order both row-wise and column-wise, 
return the number of negative numbers in grid.

Example 1:

Input: grid = [[4,3,2,-1],[3,2,1,-1],[1,1,-1,-2],[-1,-1,-2,-3]]
Output: 8
Explanation: There are 8 negatives number in the matrix.

Example 2:

Input: grid = [[3,2],[1,0]]
Output: 0

Constraints:

    m == grid.length
    n == grid[i].length
    1 <= m, n <= 100
    -100 <= grid[i][j] <= 100

Follow up: Could you find an O(n + m) solution?
*/
// Time complexity: O(n * m) row * col
// Space complexity: O(1)
public class Solution 
{
  public int CountNegatives(int[][] grid) 
  {
    int rowLength = grid.Length;
    int colLength = grid[0].Length;
    int negativeNumbers = 0;

    for (int i = 0; i < rowLength; i++)
      for (int j = 0; j < colLength; j++)
        if (grid[i][j] < 0)
        {
          negativeNumbers += colLength - j;
          break;
        }

    return negativeNumbers;    
  }
}
// Binary Search
// Time complexity: O(n + m)
// Space complexity: O(1)