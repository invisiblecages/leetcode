/*
Given two strings ransomNote and magazine, return true if ransomNote can be constructed by using the letters from magazine and false otherwise.
Each letter in magazine can only be used once in ransomNote.

Example 1:
Input: ransomNote = "a", magazine = "b"
Output: false

Example 2:
Input: ransomNote = "aa", magazine = "ab"
Output: false

Example 3:
Input: ransomNote = "aa", magazine = "aab"
Output: true

Constraints:
    1 <= ransomNote.length, magazine.length <= 105
    ransomNote and magazine consist of lowercase English letters.
*/
// Time complexity: O(n^2)
// Space complexity: O(n)
public class Solution 
{
  public bool CanConstruct(string ransomNote, string magazine)
  {
    int cnt = 0;
    foreach (char c in ransomNote)
      if (magazine.Contains(c))
      {
        magazine = magazine.Remove(magazine.IndexOf(c), 1);
        cnt++;
      }

    return ransomNote.Length == cnt;
  }
}

// Time complexity: O(n)
// Space complexity: O(n)
public class Solution 
{
  public bool CanConstruct(string ransomNote, string magazine)
  {
    Dictionary<char, int> dict = new();
    foreach (char c in magazine)
      if (dict.ContainsKey(c))
        dict[c]++;
      else
        dict.Add(c, 1);

    foreach (char c in ransomNote)
      if (!dict.ContainsKey(c) || dict[c] == 0)
        return false;
	  else
		dict[c]--;   
    
    return true;
  }
}

// Hashtable
public class Solution 
{
  public bool CanConstruct(string ransomNote, string magazine)
  {
    Hashtable ht = new();
    foreach (char c in magazine)
      if (ht.ContainsKey(c))
        ht[c] = (int)ht[c] + 1;
      else
        ht.Add(c, 1);

    foreach (char c in ransomNote)
      if (!ht.ContainsKey(c) || (int)ht[c] == 0)
        return false;
      else
        ht[c] = (int)ht[c] - 1;   
    
    return true;
  }
}