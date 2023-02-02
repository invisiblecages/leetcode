/*
Given an array of strings strs, group the anagrams together. You can return the answer in any order.
An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

Example 1:
Input: strs = ["eat","tea","tan","ate","nat","bat"]
Output: [["bat"],["nat","tan"],["ate","eat","tea"]]

Example 2:
Input: strs = [""]
Output: [[""]]

Example 3:
Input: strs = ["a"]
Output: [["a"]]
 
Constraints:
    1 <= strs.length <= 104
    0 <= strs[i].length <= 100
    strs[i] consists of lowercase English letters.
*/
// Time complexity: O(n * k * log k)
// Space complexity: O(n * k)
public class Solution
{
  public IList<IList<string>> GroupAnagrams(string[] strs)
  {
    Dictionary<string, IList<string>> res = new();

    for (int i = 0; i < strs.Length; i++)
    {
      string word = new string (strs[i].OrderBy(c => c).ToArray());

      if (!res.ContainsKey(word))
        res[word] = new List<string>();
      
      res[word].Add(strs[i]);
    }

    return res.Values.ToList();
  }
}