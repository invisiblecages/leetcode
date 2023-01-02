﻿/*
A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, 
it reads the same forward and backward. Alphanumeric characters include letters and numbers.

Given a string s, return true if it is a palindrome, or false otherwise.

Example 1:
Input: s = "A man, a plan, a canal: Panama"
Output: true
Explanation: "amanaplanacanalpanama" is a palindrome.

Example 2:
Input: s = "race a car"
Output: false
Explanation: "raceacar" is not a palindrome.

Example 3:
Input: s = " "
Output: true
Explanation: s is an empty string "" after removing non-alphanumeric characters.
Since an empty string reads the same forward and backward, it is a palindrome.

Constraints:
    1 <= s.length <= 2 * 105
    s consists only of printable ASCII characters.
*/
// Time complexity: O(n)
// Space complexity: O(1)
public class Solution
{
  public bool IsPalindrome(string s)
  {
    int l = 0;
    int r = s.Length - 1;
    while (l < r)
    {
      if (!char.IsLetterOrDigit(s[l]))
        l++;
      else if (!char.IsLetterOrDigit(s[r]))
        r--;
      else 
      {
        if (char.ToLower(s[l]) != char.ToLower(s[r]))
          return false;

        l++;
        r--;
      }
    }

    return true;
  }
}
// First solution which is a bit slower
// Time complexity: O(n)
// Space complexity: O(1)
using System.Text.RegularExpressions;

public class Solution
{
  public bool IsPalindrome(string s)
  {
    s = Regex.Replace(s, @"[^a-z0-9]", "", RegexOptions.IgnoreCase).ToLower();
    for (int i = 0; i < s.Length / 2; i++)
      if (s[i] != s[s.Length - i - 1])
        return false;

    return true; 
  }
}