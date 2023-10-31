/*
Given a string s, return the longest palindromic substring in s.

Example 1:

Input: s = "babad"
Output: "bab"
Explanation: "aba" is also a valid answer.

Example 2:

Input: s = "cbbd"
Output: "bb"

Constraints:

    1 <= s.length <= 1000
    s consist of only digits and English letters.
*/
// Sloooooooow brute force
// Time complexity: O(n^3)
// Space complexity: O(1)
public class Solution 
{
  private bool IsPalindrome(string str)
  {
    int left = 0;
    int right = str.Length - 1;

    while (left < right)
    {
      if (str[left] != str[right])
        return false;
      
      left++;
      right--;
    }

    return true;
  }

  public string LongestPalindrome(string s) 
  {
    string result = "";

    for (int i = 0; i < s.Length; i++)
    {
      for (int j = i; j < s.Length; j++)
      {
        string str = s.Substring(i, j - i + 1);
        if (str.Length > result.Length && IsPalindrome(str))
          result = str;
      }
    }

    return result;
  }
}
// Time complexity: O(n^2)
// Space complexity: O(1)
public class Solution 
{
  // Find the length a palindrome given its center
  private int ExpandAroundCenter(string s, int left, int right)
  {
    while (left >= 0 && right < s.Length && s[left] == s[right])
    {
      left--;
      right++;
    }

    return right - left - 1;
  }

  public string LongestPalindrome(string s) 
  {
    int start = 0;
    int end = 0;

    for (int i = 0; i < s.Length; i++)
    {
      int oddLength = ExpandAroundCenter(s, i, i);
      int evenLength = ExpandAroundCenter(s, i, i + 1);
      int maxLength = Math.Max(oddLength, evenLength);

      if (maxLength > end - start)
      {
        start = i - (maxLength - 1) / 2;
        end  = i + maxLength / 2;
      }
    }

    return s.Substring(start, end - start + 1);
  }
}