/*
Given a string s, find the length of the longest substring without repeating characters.

Example 1:
Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.

Example 2:
Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.

Example 3:
Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

Constraints:
    0 <= s.length <= 5 * 10^4
    s consists of English letters, digits, symbols and spaces.
*/
// Slow first solution
// Time complexity: O(n^2)
// Space complexity: O(n)
public class Solution
{
  public int LengthOfLongestSubstring(string s)
  {
    if (s.Length == 0)
      return 0;
      
    int res = 0;
    int left = 0;
    int right = 1;
    while (right <= s.Length - left)
    {
      int tmp = s.Substring(left, right).Distinct().Count();
      if (tmp > res)
      {
        res = tmp;
        right++;
      }
      else if (s.Substring(left, right).Count() > tmp)
        left++;
      else
      {
        left++;
        right++;
      }      
    }

    return res;
  }
}
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution
{
  public int LengthOfLongestSubstring(string s)
  {
    HashSet<char> chars = [];
    int max = 0;
    int left = 0;
    int right = 0;

    while (right < s.Length)
    {
      char c = s[right];

      if (chars.Contains(c))
      {
        chars.Remove(s[left]);
        left++;
      }
      else
      {
        chars.Add(c);
        right++;
        max = Math.Max(max, chars.Count);
      }
    }

    return max;
  }
}