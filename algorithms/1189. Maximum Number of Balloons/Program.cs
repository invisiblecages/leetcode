/*
Given a string text, you want to use the characters of text to form as many instances of the word "balloon" as possible.

You can use each character in text at most once. Return the maximum number of instances that can be formed.

Example 1:
Input: text = "nlaebolko"
Output: 1

Example 2:
Input: text = "loonbalxballpoon"
Output: 2

Example 3:
Input: text = "leetcode"
Output: 0

Constraints:
    1 <= text.length <= 104
    text consists of lower case English letters only.
*/
// Time complexity: O(n)
// Space complexity: O(1)
public class Solution
{
  public int MaxNumberOfBalloons(string text)
  {
    Dictionary<char, int> dict = new()
    {
      { 'b', 0 },
      { 'a', 0 },
      { 'l', 0 },
      { 'o', 0 },
      { 'n', 0 }
    };

    foreach (char c in text)
      if (dict.ContainsKey(c))
        dict[c]++;
    
    int cnt = 0;
    while (dict['b'] > 0 && dict['a'] > 0 && dict['l'] > 1 && dict['o'] > 1 && dict['n'] > 0)
    {
        dict['b']--;
        dict['a']--;
        dict['l'] -= 2;
        dict['o'] -= 2;
        dict['n']--;
        cnt++;
    }

    return cnt;
  }
}
// General solution which is a bit slower
// Time complexity: O(n)
// Space complexity: O(1)
public class Solution
{
  public int MaxNumberOfBalloons(string text)
  {
    Dictionary<char, int> textDict = new();
    Dictionary<char, int> wordDict = new();
    string word = "balloon";
    
    foreach (char c in word)
      if (wordDict.ContainsKey(c))
          wordDict[c]++;
      else
          wordDict[c] = 1;

    foreach (char c in text)
      if (wordDict.ContainsKey(c))
      {
        if (textDict.ContainsKey(c))
            textDict[c]++;
        else
            textDict[c] = 1;
      }

    int cnt = text.Length;
    foreach (char c in wordDict.Keys)
      cnt = Math.Min(cnt, textDict.GetValueOrDefault(c, 0) / wordDict[c]);

    return cnt;
  }
}