/*
You are given two strings of the same length s and t. 
In one step you can choose any character of t and replace it with another character.

Return the minimum number of steps to make t an anagram of s.

An Anagram of a string is a string that contains the same characters with a different (or the same) ordering.

Example 1:

Input: s = "bab", t = "aba"
Output: 1
Explanation: Replace the first 'a' in t with b, t = "bba" which is anagram of s.

Example 2:

Input: s = "leetcode", t = "practice"
Output: 5
Explanation: Replace 'p', 'r', 'a', 'i' and 'c' from t with proper characters to make t anagram of s.

Example 3:

Input: s = "anagram", t = "mangaar"
Output: 0
Explanation: "anagram" and "mangaar" are anagrams. 

Constraints:

    1 <= s.length <= 5 * 10^4
    s.length == t.length
    s and t consist of lowercase English letters only.
*/
// Time complexity: O(n)
// Space complexity: O(n) could be O(1) by using a size 26 char array
public class Solution 
{
  public int MinSteps(string s, string t)
  {
    Dictionary<char, int> freq = [];
    int steps = 0;

    for (int i = 0; i < s.Length; i++)
    {
      freq[s[i]] = freq.TryGetValue(s[i], out int sv) ? ++sv : 1;
      freq[t[i]] = freq.TryGetValue(t[i], out int tv) ? --tv : -1;
    }

    foreach (int count in freq.Values)
    {
      steps += Math.Abs(count);
    }
	
	// divide by 2 because each step involves changing two characters
    return steps / 2;
  }
}
