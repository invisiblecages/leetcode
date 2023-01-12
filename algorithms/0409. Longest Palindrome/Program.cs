/*
Given a string s which consists of lowercase or uppercase letters, 
return the length of the longest palindrome that can be built with those letters.

Letters are case sensitive, for example, "Aa" is not considered a palindrome here.

Example 1:
Input: s = "abccccdd"
Output: 7
Explanation: One longest palindrome that can be built is "dccaccd", whose length is 7.

Example 2:
Input: s = "a"
Output: 1
Explanation: The longest palindrome that can be built is "a", whose length is 1.

Constraints:
    1 <= s.length <= 2000
    s consists of lowercase and/or uppercase English letters only.
*/
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution
{
  public int LongestPalindrome(string s)
  {
    Dictionary<char, int> dict = new();
    foreach (char c in s)
      if (dict.ContainsKey(c))
        dict[c]++;
      else
        dict[c] = 1;

    string res = "";
    string odd = "";
    foreach (var kvp in dict.OrderByDescending(x => x.Value))
    {
      int count = kvp.Value;
      string tmp = "";
      if (kvp.Value % 2 == 0)
      {
        while (count-- > 0)
          tmp += kvp.Key.ToString();
      }
      else 
      {
        while (count-- > 1)
          tmp += kvp.Key.ToString();

        odd = kvp.Key.ToString();
      }

      res = res.Insert(res.Length / 2, tmp);
    }

    res = res.Insert(res.Length / 2, odd);
    return res.Length;      
  }
}