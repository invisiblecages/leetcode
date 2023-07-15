/*
You are given an m x n integer matrix matrix with the following two properties:

    Each row is sorted in non-decreasing order.
    The first integer of each row is greater than the last integer of the previous row.

Given an integer target, return true if target is in matrix or false otherwise.

You must write a solution in O(log(m * n)) time complexity.

Example 1:

Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 3
Output: true

Example 2:

Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 13
Output: false

Constraints:

    m == matrix.length
    n == matrix[i].length
    1 <= m, n <= 100
    -104 <= matrix[i][j], target <= 104
*/
// Time complexity: O(log m + log n)
// Space complexity: O(1)
public class Solution 
{
  private int SearchRow(int[][] matrix, int target)
  {
    int top = 0;
    int bottom = matrix.Length - 1;
    int length = matrix[0].Length - 1;

    while (top <= bottom)
    {
      int mid = top + (bottom - top) / 2;

      if (matrix[mid][0] <= target && target <= matrix[mid][length])
        return mid;
      else if (matrix[mid][0] < target)
        top = mid + 1;
      else
        bottom = mid - 1;
    }

    return -1;
  }

  private bool SearchColumn(int[] row, int target)
  {
    int left = 0;
    int right = row.Length - 1;

    while (left <= right)
    {
      int mid = left + (right - left) / 2;

      if (row[mid] == target)
        return true;
      else if (row[mid] < target)
        left = mid + 1;
      else
        right = mid - 1;
    }

    return false;
  }

  public bool SearchMatrix(int[][] matrix, int target) 
  {
    int row = SearchRow(matrix, target);

    if (row == -1)
      return false;

    return SearchColumn(matrix[row], target);  
  }
}
// First solution
// Time complexity: O(m * (log n))
// Space complexity: O(1)
public class Solution 
{
  public bool SearchMatrix(int[][] matrix, int target) 
  {
    for (int i = 0; i < matrix.Length; i++)
    {
      int left = 0;
      int right = matrix[0].Length - 1;

      if (matrix[i][0] <= target && target <= matrix[i][right])
      {
        while (left <= right)
        {
          int mid = left + (right - left) / 2;
          
          if (matrix[i][mid] == target)
            return true;
          else if (matrix[i][mid] < target)
            left = mid + 1;
          else
            right = mid - 1;
        }

        break;
      }
    }

    return false;  
  }
}