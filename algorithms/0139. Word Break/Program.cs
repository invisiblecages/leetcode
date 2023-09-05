/*
Given a string s and a dictionary of strings wordDict, 
return true if s can be segmented into a space-separated sequence of one or more dictionary words.

Note that the same word in the dictionary may be reused multiple times in the segmentation.

Example 1:

Input: s = "leetcode", wordDict = ["leet","code"]
Output: true
Explanation: Return true because "leetcode" can be segmented as "leet code".

Example 2:

Input: s = "applepenapple", wordDict = ["apple","pen"]
Output: true
Explanation: Return true because "applepenapple" can be segmented as "apple pen apple".
Note that you are allowed to reuse a dictionary word.

Example 3:

Input: s = "catsandog", wordDict = ["cats","dog","sand","and","cat"]
Output: false

Constraints:

    1 <= s.length <= 300
    1 <= wordDict.length <= 1000
    1 <= wordDict[i].length <= 20
    s and wordDict[i] consist of only lowercase English letters.
    All the strings of wordDict are unique.
*/
// TLE without caching
// Time complexity: O(n * m)
// Space complexity: O(n)
public class Solution 
{
  private bool DFS(string str, IList<string> list, Dictionary<string, bool> memo)
  {
    if (memo.ContainsKey(str))
      return memo[str];

    if (str.Length == 0)
      return true;

    foreach (string word in list)
    {
      if (str.StartsWith(word) && DFS(str.Substring(word.Length), list, memo))
      {
        memo[str] = true;
        return true;
      }
    }
    
    memo[str] = false;
    return false;
  }

  public bool WordBreak(string s, IList<string> wordDict) 
  {
    Dictionary<string, bool> memo = new();
    return DFS(s, wordDict, memo);
  }
}
// Time complexity: O(n^2)
// Space complexity: O(n)
public class Solution 
{
  public bool WordBreak(string s, IList<string> wordDict) 
  {
    bool[] cache = new bool[s.Length + 1];
    cache[0] = true;

    for (int i = 1; i < cache.Length; i++)
    {
      for (int j = 0; j < i; j++)
      {
        string subStr = s.Substring(j, i - j);
        bool containsSubStr = wordDict.Contains(subStr);

        if (cache[j] && containsSubStr)
        {
          cache[i] = true;
          break;
        }
      }
    }

    return cache[s.Length];
  }
}