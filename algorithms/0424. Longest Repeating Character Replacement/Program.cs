/*
You are given a string s and an integer k. 
You can choose any character of the string and change it to any other uppercase English character. 
You can perform this operation at most k times.

Return the length of the longest substring containing the same letter you can get after performing the above operations.

Example 1:
Input: s = "ABAB", k = 2
Output: 4
Explanation: Replace the two 'A's with two 'B's or vice versa.

Example 2:
Input: s = "AABABBA", k = 1
Output: 4
Explanation: Replace the one 'A' in the middle with 'B' and form "AABBBBA".
The substring "BBBB" has the longest repeating letters, which is 4.

Constraints:
    1 <= s.length <= 105
    s consists of only uppercase English letters.
    0 <= k <= s.length
*/
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution
{
  public int CharacterReplacement(string s, int k)
  {
    Dictionary<char, int> dict = new();
    int res = 0;
    int left = 0;
    string str = "";

    for (int i = 0; i < s.Length; i++)
    {
      if (dict.ContainsKey(s[i]))
        dict[s[i]]++;
      else
        dict[s[i]] = 1;

      while (i - left + 1 - dict.Values.Max() > k)
        dict[s[left++]]--;
      
	  // If I want to know what the longest substring contains
      string tmp = s.Substring(left, i - left + 1);
      if (tmp.Length > str.Length)
       str = tmp;
      
      res = Math.Max(res, i - left + 1);
    }

    return res;
  }
}