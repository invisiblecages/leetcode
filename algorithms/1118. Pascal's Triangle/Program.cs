/*
Given an integer numRows, return the first numRows of Pascal's triangle.

In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:

Example 1:
Input: numRows = 5
Output: [[1],[1,1],[1,2,1],[1,3,3,1],[1,4,6,4,1]]

Example 2:
Input: numRows = 1
Output: [[1]]

Constraints:
    1 <= numRows <= 30
*/
// Time complexity: O(n^2)
// Space complexity: O(n^2)
public class Solution
{
  public IList<IList<int>> Generate(int numRows)
  {
    List<IList<int>> res = new();

    for (int i = 1; i <= numRows; i++)
    {
      List<int> tmp = new();
      int count = i;
      
      while (count-- > 0)
        if (count == 0 || count == i - 1)
          tmp.Add(1);
        else
          tmp.Add(res[i - 2][count - 1] + res[i - 2][count]);

      res.Add(tmp);
    }

    return res; 
  }
}