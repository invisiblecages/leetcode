/*
Given a string s, partition the string into one or more substrings such that the characters in each substring are unique. 
That is, no letter appears in a single substring more than once.

Return the minimum number of substrings in such a partition.

Note that each character should belong to exactly one substring in a partition.

Example 1:
Input: s = "abacaba"
Output: 4
Explanation:
Two possible partitions are ("a","ba","cab","a") and ("ab","a","ca","ba").
It can be shown that 4 is the minimum number of substrings needed.

Example 2:
Input: s = "ssssss"
Output: 6
Explanation:
The only valid partition is ("s","s","s","s","s","s").

Constraints:
    1 <= s.length <= 105
    s consists of only English lowercase letters.
*/
// Time complexity: O(n)
// Space complexity: O(1) will be constant if using a counter instead of a list
public class Solution
{
  public int PartitionString(string s)
  {
    HashSet<char> set = new();
    List<string> substrings = new();

    foreach (char c in s)
    {
      if (set.Contains(c))
      {
        substrings.Add(string.Join("", set));
        set.Clear();
      }

      set.Add(c);
    }
    
    substrings.Add(string.Join("", set));
    return substrings.Count;
  }
}