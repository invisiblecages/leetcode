/*
Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

Example 1:

Input: n = 3
Output: ["((()))","(()())","(())()","()(())","()()()"]

Example 2:

Input: n = 1
Output: ["()"]

Constraints:

    1 <= n <= 8
*/
// Time complexity: O(?)
// Space complexity: O(n)
public class Solution 
{
  private void DFS(int n, int open, int closed, List<char> combination, List<string> result)
  {
    if (n * 2 == combination.Count)
    {
      result.Add(string.Join("", combination));
      return;
    }

    if (open < n)
    {
      combination.Add('(');
      DFS(n, open + 1, closed, combination, result);
      combination.RemoveAt(combination.Count - 1);
    }

    if (open > closed)
    {
      combination.Add(')');
      DFS(n, open, closed + 1, combination, result);
      combination.RemoveAt(combination.Count - 1);
    }
  }

  public IList<string> GenerateParenthesis(int n) 
  {
    List<char> combination = new();
    List<string> result = new();

    DFS(n, 0, 0, combination, result);

    return result;    
  }
}