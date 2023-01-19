/*
Given two strings s and p, return an array of all the start indices of p's anagrams in s. You may return the answer in any order.

An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, 
typically using all the original letters exactly once.

Example 1:
Input: s = "cbaebabacd", p = "abc"
Output: [0,6]
Explanation:
The substring with start index = 0 is "cba", which is an anagram of "abc".
The substring with start index = 6 is "bac", which is an anagram of "abc".

Example 2:
Input: s = "abab", p = "ab"
Output: [0,1,2]
Explanation:
The substring with start index = 0 is "ab", which is an anagram of "ab".
The substring with start index = 1 is "ba", which is an anagram of "ab".
The substring with start index = 2 is "ab", which is an anagram of "ab".

Constraints:
    1 <= s.length, p.length <= 3 * 104
    s and p consist of lowercase English letters.
*/
// Slow first solution
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution
{
  public IList<int> FindAnagrams(string s, string p)
  {
    List<int> res = new();
    if (p.Length > s.Length)
      return res;

    SortedDictionary<char, int> wDict = new();
    SortedDictionary<char, int> pDict = new();
    int left = 1;
    int right = p.Length;

    foreach (char c in s.Substring(left - 1, p.Length))
      if (wDict.ContainsKey(c))
        wDict[c]++;
      else
        wDict[c] = 1;
    
    foreach (char c in p)
      if (pDict.ContainsKey(c))
        pDict[c]++;
      else
        pDict[c] = 1;

    if (wDict.ToList().SequenceEqual(pDict.ToList()))
      res.Add(left - 1);

    while (left <= s.Length - p.Length)
    {
      if (wDict[s[left - 1]] == 1)
        wDict.Remove(s[left - 1]);
      else
        wDict[s[left - 1]]--;
      
      if (wDict.ContainsKey(s[right]))
        wDict[s[right]]++;
      else
        wDict[s[right]] = 1;

      if (wDict.ToList().SequenceEqual(pDict.ToList()))
        res.Add(left);

      left++;
      right++;
    }

    return res;   
  }
}