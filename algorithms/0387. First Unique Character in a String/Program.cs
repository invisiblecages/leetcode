/*
Given a string s, find the first non-repeating character in it and return its index. If it does not exist, return -1.

Example 1:

Input: s = "leetcode"
Output: 0

Example 2:

Input: s = "loveleetcode"
Output: 2

Example 3:

Input: s = "aabb"
Output: -1

Constraints:

    1 <= s.length <= 10^5
    s consists of only lowercase English letters.
*/
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution 
{
  public int FirstUniqChar(string s) 
  {
    Dictionary<char, List<int>> chars = [];

    for (int i = 0; i < s.Length; i++)
    {
      char c = s[i];

      if (chars.ContainsKey(c))
      {
        chars[c].Add(i);
      }
      else
      {
        chars[c] = [i];
      }
    }

    foreach (var list in chars.Values)
    {
      if (list.Count == 1)
      {
        return list[0];
      }
    }

    return -1;  
  }
}