/*
Given a string array words, return an array of all characters that show up in all strings within the words (including duplicates). 
You may return the answer in any order.

Example 1:

Input: words = ["bella","label","roller"]
Output: ["e","l","l"]

Example 2:

Input: words = ["cool","lock","cook"]
Output: ["c","o"]

Constraints:

    1 <= words.length <= 100
    1 <= words[i].length <= 100
    words[i] consists of lowercase English letters.
*/
// Time complexity: O(m * n)
// Space complexity: O(n)
public class Solution 
{
  public IList<string> CommonChars(string[] words) 
  {
    Dictionary<char, int> chars = [];
    List<string> result = [];

    foreach (char c in words[0])
    {
      chars[c] = chars.ContainsKey(c) ? chars[c] + 1 : 1;
    }

    foreach (string word in words.Skip(1))
    {
      Dictionary<char, int> temp = [];

      foreach (char c in word)
      {
        temp[c] = temp.ContainsKey(c) ? temp[c] + 1 : 1;
      }

      foreach (var kvp in chars)
      { 
        char key = kvp.Key;

        if (temp.ContainsKey(key))
        {
          chars[key] = Math.Min(chars[key], temp[key]);
        }
        else
        {
          chars.Remove(key);
        }
      }
    }

    foreach (var kvp in chars)
    {
      result.AddRange(Enumerable.Repeat(kvp.Key.ToString(), kvp.Value));
    }

    return result;
  }
}