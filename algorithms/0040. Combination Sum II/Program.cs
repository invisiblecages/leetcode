/*
Given a collection of candidate numbers (candidates) and a target number (target), 
find all unique combinations in candidates where the candidate numbers sum to target.

Each number in candidates may only be used once in the combination.

Note: The solution set must not contain duplicate combinations.

Example 1:

Input: candidates = [10,1,2,7,6,1,5], target = 8
Output: 
[
[1,1,6],
[1,2,5],
[1,7],
[2,6]
]

Example 2:

Input: candidates = [2,5,2,1,2], target = 5
Output: 
[
[1,2,2],
[5]
]

Constraints:

    1 <= candidates.length <= 100
    1 <= candidates[i] <= 50
    1 <= target <= 30
*/
// Time complexity: O(2^n)
// Space complexity: O(2^n)
public class Solution 
{
  private void DFS(List<IList<int>> result, Stack<int> combination, int[] candidates, int index, int sum, int target)
  {
    if (sum > target)
      return;

    if (sum == target)
    {
      result.Add(combination.ToList());
      return;
    }

    for (int i = index; i < candidates.Length; i++)
    {
      if (i > index && candidates[i - 1] == candidates[i])
        continue;

      combination.Push(candidates[i]);
      DFS(result, combination, candidates, i + 1, sum + candidates[i], target);
      combination.Pop();
    }
  }

  public IList<IList<int>> CombinationSum2(int[] candidates, int target) 
  {
    var result = new List<IList<int>>();
    Array.Sort(candidates);
    DFS(result, new Stack<int>(), candidates, 0, 0, target);

    return result; 
  }
}