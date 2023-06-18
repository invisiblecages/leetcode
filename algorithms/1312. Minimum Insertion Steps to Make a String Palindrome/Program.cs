/*
Given a string s. In one step you can insert any character at any index of the string.

Return the minimum number of steps to make s palindrome.

A Palindrome String is one that reads the same backward as well as forward.

Example 1:

Input: s = "zzazz"
Output: 0
Explanation: The string "zzazz" is already palindrome we do not need any insertions.

Example 2:

Input: s = "mbadm"
Output: 2
Explanation: String can be "mbdadbm" or "mdbabdm".

Example 3:

Input: s = "leetcode"
Output: 5
Explanation: Inserting 5 characters the string becomes "leetcodocteel".

Constraints:

    1 <= s.length <= 500
    s consists of lowercase English letters.
*/
// Time complexity: O(n * n)
// Space complexity: O(n * n)
public class Solution 
{
  private int FindMinInsertions(string s, int left, int right, int[,] cache)
  {
    if (left >= right)
      return 0;
    
    if (s[left] == s[right])
    {
      if (cache[left + 1, right - 1] == 0)
        cache[left + 1, right - 1] = FindMinInsertions(s, left + 1, right - 1, cache);

      return cache[left + 1, right - 1];
    }

    if (cache[left + 1, right] == 0)
      cache[left + 1, right] = FindMinInsertions(s, left + 1, right, cache);
    if (cache[left, right - 1] == 0)
      cache[left, right - 1] = FindMinInsertions(s, left, right - 1, cache);

    return Math.Min(cache[left + 1, right], cache[left, right - 1]) + 1;
  }

  public int MinInsertions(string s) 
  {
    int len = s.Length;
    int[,] cache = new int[len, len];
    
    return FindMinInsertions(s, 0, len - 1, cache);
  }
}