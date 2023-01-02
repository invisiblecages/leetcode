/*
Given two strings s and t, return true if t is an anagram of s, and false otherwise.
An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

Example 1:
Input: s = "anagram", t = "nagaram"
Output: true

Example 2:
Input: s = "rat", t = "car"
Output: false

Constraints:
    1 <= s.length, t.length <= 5 * 104
    s and t consist of lowercase English letters.

Follow up: What if the inputs contain Unicode characters? How would you adapt your solution to such a case?
*/
// Time complexity: O(n + n)
// Space complexity: O(n + n)
public class Solution
{
  public bool IsAnagram(string s, string t)
  {
    if (s.Length != t.Length)
      return false;
      
    Dictionary<char, int> sDict = new();
    Dictionary<char, int> tDict = new();
    for (int i = 0; i < s.Length; i++)
    {
      if (sDict.ContainsKey(s[i]))
        sDict[s[i]]++;
      else
        sDict[s[i]] = 1;

      if (tDict.ContainsKey(t[i]))
        tDict[t[i]]++;
      else
        tDict[t[i]] = 1;
    }

    foreach (char c in sDict.Keys)
      if (!tDict.ContainsKey(c) || sDict[c] != tDict[c])
        return false;

    return true;
  }
}