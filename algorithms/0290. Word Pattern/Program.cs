/*
Given a pattern and a string s, find if s follows the same pattern.

Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in s.

Example 1:
Input: pattern = "abba", s = "dog cat cat dog"
Output: true

Example 2:
Input: pattern = "abba", s = "dog cat cat fish"
Output: false

Example 3:
Input: pattern = "aaaa", s = "dog cat cat dog"
Output: false

Constraints:
    1 <= pattern.length <= 300
    pattern contains only lower-case English letters.
    1 <= s.length <= 3000
    s contains only lowercase English letters and spaces ' '.
    s does not contain any leading or trailing spaces.
    All the words in s are separated by a single space.
*/
// Slow first solution
// Time complexity: O(n)
// Space complexity: O(1)
public class Solution
{
  public bool WordPattern(string pattern, string s)
  {
    string[] arr = s.Split(' ');
    if (pattern.Length != arr.Length)
        return false;
	
	//Dictionary<char, string> dict = new() is much slower
    Dictionary<string, string> dict = new();
    for (int i = 0; i < pattern.Length; i++)
    {
      string key = pattern[i].ToString();
      string str = arr[i];
      if (!dict.ContainsKey(key) && !dict.ContainsValue(str))
        dict[key] = str;
      else if (!dict.ContainsKey(key) && dict.ContainsValue(str))
        return false;
      else if (dict.TryGetValue(key, out string? value))
        if (value != str)
          return false;
    }
    
    return true;
  }
}

// faster and cleaner code
public bool WordPattern1(string pattern, string s)
{
    string[] arr = s.Split(' ');
    if (pattern.Length != arr.Length)
        return false;
    
    Dictionary<string, string> dict = new();
    for (int i = 0; i < pattern.Length; i++)
    {
        string key = pattern[i].ToString();
        if (dict.ContainsKey(key))
        {
            if (dict[key] != arr[i])
                return false;
        }
        else
        {
            if (dict.ContainsValue(arr[i]))
                return false;

            dict[key] = arr[i];
        }
    }

    return true;
}