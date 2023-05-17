/*
Given an m x n matrix, return all elements of the matrix in spiral order.

Example 1:

Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
Output: [1,2,3,6,9,8,7,4,5]

Example 2:

Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
Output: [1,2,3,4,8,12,11,10,9,5,6,7]

Constraints:

    m == matrix.length
    n == matrix[i].length
    1 <= m, n <= 10
    -100 <= matrix[i][j] <= 100
*/
// Time complexity: O(m * n)
// Space complexity: O(m * n)
public class Solution 
{
  public IList<int> SpiralOrder(int[][] matrix) 
  {
    List<int> res = new();
    int m = matrix.Length;
    int n = matrix[0].Length;
    int maxElements = m * n;
    int top = 0;
    int right = n - 1;
    int bottom = m - 1;
    int left = 0;

    while (res.Count < maxElements)
    {
      // top row
      for (int i = left; i <= right; i++)
        if (res.Count < maxElements)
          res.Add(matrix[top][i]);
      
      top++;

      // right column
      for (int i = top; i <= bottom; i++)
        if (res.Count < maxElements)
          res.Add(matrix[i][right]);

      right--;

      // bottom row
      for (int i = right; i >= left; i--)
        if (res.Count < maxElements)
          res.Add(matrix[bottom][i]);

      bottom--;

      // left column
      for (int i = bottom; i >= top; i--)
        if (res.Count < maxElements)
          res.Add(matrix[i][left]);
        
      left++;
    }

    return res;
  }
}