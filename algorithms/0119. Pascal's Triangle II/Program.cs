/*
Given an integer rowIndex, return the rowIndexth (0-indexed) row of the Pascal's triangle.

In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:

Example 1:

Input: rowIndex = 3
Output: [1,3,3,1]

Example 2:

Input: rowIndex = 0
Output: [1]

Example 3:

Input: rowIndex = 1
Output: [1,1]

Constraints:

    0 <= rowIndex <= 33

Follow up: Could you optimize your algorithm to use only O(rowIndex) extra space?
*/
// Time complexity: O(n^2)
// Space complexity: O(n)
public class Solution 
{
  public IList<int> GetRow(int rowIndex) 
  {
    List<int> result = new() { 1 };

    for (int i = 1; i <= rowIndex; i++)
    {
      List<int> row = new() { 1 };

      for (int j = 1; j < i; j++)
      {
        row.Add(result[j - 1] + result[j]);
      }

      row.Add(1);

      result = row;
    }

    return result;   
  }
}