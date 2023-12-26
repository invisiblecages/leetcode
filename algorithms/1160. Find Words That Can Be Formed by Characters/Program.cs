/*
You are given an array of strings words and a string chars.

A string is good if it can be formed by characters from chars (each character can only be used once).

Return the sum of lengths of all good strings in words.

Example 1:

Input: words = ["cat","bt","hat","tree"], chars = "atach"
Output: 6
Explanation: The strings that can be formed are "cat" and "hat" so the answer is 3 + 3 = 6.

Example 2:

Input: words = ["hello","world","leetcode"], chars = "welldonehoneyr"
Output: 10
Explanation: The strings that can be formed are "hello" and "world" so the answer is 5 + 5 = 10.

Constraints:

    1 <= words.length <= 1000
    1 <= words[i].length, chars.length <= 100
    words[i] and chars consist of lowercase English letters.
*/
// Time complexity: O(n^2)
// Space complexity: O(n)
public class Solution 
{
  public int CountCharacters(string[] words, string chars) 
  {
    Dictionary<char, int> cDict = new();
    int sum = 0;

    foreach (char c in chars)
    {
      if (cDict.ContainsKey(c))
        cDict[c]++;
      else
        cDict[c] = 1;
    }

    foreach (string word in words)
    {
      Dictionary<char, int> wDict = new();
      bool isGoodWord = true;

      foreach (char c in word)
      {
        if (wDict.ContainsKey(c))
          wDict[c]++;
        else
          wDict[c] = 1;

        if (!cDict.ContainsKey(c) || wDict[c] > cDict[c])
        {
          isGoodWord = false;
          break;
        }
      }

      sum += isGoodWord ? word.Length : 0;
    }

    return sum;
  }
}