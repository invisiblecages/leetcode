/*
Find all valid combinations of k numbers that sum up to n such that the following conditions are true:

    Only numbers 1 through 9 are used.
    Each number is used at most once.

Return a list of all possible valid combinations. The list must not contain the same combination twice, 
and the combinations may be returned in any order.

Example 1:

Input: k = 3, n = 7
Output: [[1,2,4]]
Explanation:
1 + 2 + 4 = 7
There are no other valid combinations.

Example 2:

Input: k = 3, n = 9
Output: [[1,2,6],[1,3,5],[2,3,4]]
Explanation:
1 + 2 + 6 = 9
1 + 3 + 5 = 9
2 + 3 + 4 = 9
There are no other valid combinations.

Example 3:

Input: k = 4, n = 1
Output: []
Explanation: There are no valid combinations.
Using 4 different numbers in the range [1,9], the smallest sum we can get is 1+2+3+4 = 10 and since 10 > 1, 
there are no valid combination.

Constraints:

    2 <= k <= 9
    1 <= n <= 60
*/
// Time complexity: O(9 * k) ~ O(1)
// Space complexity: O(k)
public class Solution 
{
  private void DFS(List<IList<int>> result, Stack<int> combination, int number, int sum, int k, int n)
  {
    if (sum == n && combination.Count == k)
    {
      result.Add(combination.ToList());
      return;
    }

    if (sum > n || number > 9)
      return;

    for (int i = number; i < 10; i++)
    {
      combination.Push(i);
      DFS(result, combination, i + 1, sum + i, k, n);
      combination.Pop();
    }
  }

  public IList<IList<int>> CombinationSum3(int k, int n) 
  {
    var result = new List<IList<int>>();
    DFS(result, new Stack<int>(), 1, 0, k, n);

    return result;   
  }
}